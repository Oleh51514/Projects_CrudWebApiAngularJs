using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.API.Repositories
{
    public interface IRoleManagerRepository
    {
        Task<IdentityResult> CreateAsync(AppRole role);
        Task<IdentityResult> DeleteAsync(AppRole role);
        Task<AppRole> FindByIdAsync(string roleId);
        Task<AppRole> FindByNameAsync(string roleName);
        AppRole FindById(string roleId);
        AppRole FindByName(string roleName);
        IEnumerable<AppRole> GetRolesByHierarchy(int hierarchy);

        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityResult> UpdateAsync(AppRole role);
    }
}
