using CrudWebApiAngularJs.Common.DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.API.Handlers
{
    public interface IRoleHandler : IBaseHandler<RoleDto, string>
    {

        Task<IdentityResult> CreateAsync(RoleDto data);
        Task<IdentityResult> DeleteAsync(RoleDto data);
        Task<RoleDto> FindByIdAsync(string roleId);
        Task<RoleDto> FindByNameAsync(string roleName);
        IHandlerResult<IEnumerable<RoleDto>> GetRolesByHierarchy(int hierarchy);

        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityResult> UpdateAsync(RoleDto data);
    }
}
