using CrudWebApiAngularJs.DAL.API.Repositories;
using CrudWebApiAngularJs.DAL.Configuration;
using CrudWebApiAngularJs.DAL.Entities;
using CrudWebApiAngularJs.DAL.Managers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Repositories
{
    public class UserManagerRepository : IUserManagerRepository
    {
        protected readonly AppUserManager userManager;
        protected readonly string[] roleOrder = { "SuperAdmin", "Admin", "Manager", "User" };

        public UserManagerRepository(TestContext context)
        {

            this.userManager = new AppUserManager(new AppUserStore(context));
            this.userManager.UserValidator = new UserValidator<AppUser>(this.userManager) { RequireUniqueEmail = true };
        }
        public async Task<AppUser> FindUserAsync(string userName, string password)
        {
            var user = await userManager.FindAsync(userName, password);
            return user;
        }
        public async Task<AppUser> FindByNameAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user;
        }
        public async Task<ClaimsIdentity> CreateIdentityAsync(AppUser user, string authenticationType)
        {
            var result = await userManager.CreateIdentityAsync(user, authenticationType);
            return result;
        }

        public async Task<AppUser> FindAsync(string userName, string password)
        {
            var result = await userManager.FindAsync(userName, password);
            return result;
        }

        public async Task<AppUser> FindAsync(string Id)
        {
            var result = await userManager.FindByIdAsync(Id);
            return result;
        }

        public async Task<IdentityResult> RegisterUserAync(AppUser user, string password)
        {
            IdentityResult result = await userManager.CreateAsync(user, password);

            return result;
        }

        public IdentityResult AddToRole(string userId, string role)
        {
            IdentityResult result = new IdentityResult();
            int posInOrder = Array.FindIndex(roleOrder, r => r == role);
            for (int i = posInOrder; i < roleOrder.Length; i++)
            {
                result = userManager.AddToRole(userId, roleOrder[i]);
            }
            return result;
        }

        public IdentityResult RemoveFromRole(string userId, string role)
        {
            return userManager.RemoveFromRole(userId, role);
        }

        public Task<IdentityResult> CreateAsync(AppUser appUser)
        {
            return userManager.CreateAsync(appUser);
        }

        public Task<IdentityResult> AddPasswordAsync(string userId, string password)
        {
            return userManager.AddPasswordAsync(userId, password);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (userManager != null) userManager.Dispose();
            }
        }

        public IdentityResult RegisterUser(AppUser user, string password)
        {
            IdentityResult result = userManager.Create(user, password);

            return result;
        }

        public IList<string> GetRoles(string userId)
        {
            if (userId == null) throw new ArgumentNullException("userId");
            return userManager.GetRoles(userId);
        }

        public string GetTopRole(string userId)
        {
            var roles = userManager.GetRoles(userId);
            for (int i = 0; i < roleOrder.Length; i++)
            {
                if (roles.Contains(roleOrder[i])) return roleOrder[i];
            }
            return null;
        }
    }
}
