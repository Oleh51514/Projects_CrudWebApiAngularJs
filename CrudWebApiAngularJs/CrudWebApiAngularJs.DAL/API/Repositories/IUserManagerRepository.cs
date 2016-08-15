using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.API.Repositories
{
    public interface IUserManagerRepository : IDisposable
    {
        Task<IdentityResult> RegisterUserAync(AppUser user, string password);
        IdentityResult RegisterUser(AppUser user, string password);
        Task<AppUser> FindUserAsync(string userName, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(AppUser user, string authenticationType);
        Task<AppUser> FindAsync(string userName, string password);
        Task<AppUser> FindAsync(string Id);
        Task<AppUser> FindByNameAsync(string userName);
        IdentityResult AddToRole(string userId, string role);
        IdentityResult RemoveFromRole(string userId, string role);
        Task<IdentityResult> CreateAsync(AppUser appUser);
        Task<IdentityResult> AddPasswordAsync(string userId, string password);
        IList<string> GetRoles(string userId);
        string GetTopRole(string userId);
    }
}
