using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.ExceptionHandling;
using Ninject;
using CrudWebApiAngularJs.API.Providers;
using CrudWebApiAngularJs.Bootstrap;
using WebApiContrib.IoC.Ninject;
using FluentValidation.WebApi;

[assembly: OwinStartup(typeof(CrudWebApiAngularJs.API.Startup))]
namespace CrudWebApiAngularJs.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = Kernel.Initialize();  
            ConfigureOAuth(app, kernel);
            HttpConfiguration config = new HttpConfiguration();            
            config.DependencyResolver = new NinjectResolver(kernel);
            
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
           
            
        }
        private void ConfigureOAuth(IAppBuilder app, IKernel kernel)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider(kernel)
            };
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}