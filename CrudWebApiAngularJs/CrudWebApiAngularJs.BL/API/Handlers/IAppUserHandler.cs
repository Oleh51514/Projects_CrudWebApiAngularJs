using CrudWebApiAngularJs.Common.DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.API.Handlers
{
    public interface IAppUserHandler : IBaseHandler<AppUserDto, string>
    {
        Task<IHandlerResult<AppUserDto>> RegisterUserAsync(AppUserDto user);
        Task<IHandlerResult<AppUserDto>> FindUserAsync(string userName, string password);
        Task<IHandlerResult<AppUserDto>> FindByName(string userName);
        Task<IHandlerResult<ClaimsIdentity>> CreateIdentityAsync(AppUserDto user, string authenticationType);
        IdentityResult AddToRole(string userId, string role);
        IdentityResult RemoveFromRole(string userId, string role);        
    }
}
