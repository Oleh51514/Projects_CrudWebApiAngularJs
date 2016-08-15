using CrudWebApiAngularJs.DAL.API.Repositories;
using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Repositories
{
    public class RoleManagerRepository : IRoleManagerRepository
    {
        protected readonly RoleManager<AppRole> roleManager;
        public RoleManagerRepository(TestContext context)
        {
            this.roleManager = new RoleManager<AppRole>(new RoleStore<AppRole>(context));
        }

        public IEnumerable<AppRole> GetRolesByHierarchy(int hierarchy)
        {
            return roleManager.Roles.Where(value => value.Hierarchy <= hierarchy);
        }

        public async Task<IdentityResult> CreateAsync(AppRole role)
        {
            return await roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(AppRole role)
        {
            return await roleManager.DeleteAsync(role);
        }

        public AppRole FindById(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<AppRole> FindByIdAsync(string roleId)
        {
            return await roleManager.FindByIdAsync(roleId);
        }

        public AppRole FindByName(string roleName)
        {
            return roleManager.FindByName(roleName);
        }

        public async Task<AppRole> FindByNameAsync(string roleName)
        {
            return await roleManager.FindByNameAsync(roleName);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await roleManager.RoleExistsAsync(roleName);
        }

        public async Task<IdentityResult> UpdateAsync(AppRole role)
        {
            return await roleManager.UpdateAsync(role);
        }
    }
}
