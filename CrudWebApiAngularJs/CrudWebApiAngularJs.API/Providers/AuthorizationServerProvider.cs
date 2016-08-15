using CrudWebApiAngularJs.BL.API.Handlers;
using CrudWebApiAngularJs.Common.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CrudWebApiAngularJs.API.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IKernel _kernel;

        public AuthorizationServerProvider(IKernel kernel)
        {
            this._kernel = kernel;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "POST" });
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "accept", "authorization", "content-type" });
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            IAppUserHandler handler = _kernel.Get<IAppUserHandler>();
            AppUserDto user;
            try
            {
                user = (await handler.FindUserAsync(context.UserName, context.Password)).Result;
            }
            catch
            {
                context.SetError("server_error");
                context.Rejected();
                return;
            }
            if (user != null)
            {
                ClaimsIdentity identity = (await handler.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer)).Result;
                var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();
                AuthenticationProperties properties = CreateProperties(user.UserName, user.Email, string.Join(",", roles), user.Id);
                AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Invalid User Id or password'");
                context.Rejected();
            }

        }

        // Add authentication properties to request token
        protected static AuthenticationProperties CreateProperties(string userName, string userEmail, string Roles, string userId)
        {
            IDictionary<string, string> data = new Dictionary<string, string> {
                {"userEmail", userEmail },
                { "userName", userName },
                { "roles", Roles },
                {"userId", userId }
            };
            return new AuthenticationProperties(data);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}