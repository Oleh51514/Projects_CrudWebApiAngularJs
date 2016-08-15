using AutoMapper;
using CrudWebApiAngularJs.BL.API;
using CrudWebApiAngularJs.BL.API.Handlers;
using CrudWebApiAngularJs.Common.DTO;
using CrudWebApiAngularJs.DAL.API.Repositories;
using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.Handlers
{
    public class RoleHandler : IRoleHandler
    {
        private readonly IRepository repository;
        private readonly IRoleManagerRepository roleManager;
        private readonly IMapper mapper;

        public RoleHandler(IRepository repository, IRoleManagerRepository roleManager, IMapper mapper)
        {
            this.repository = repository;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public IHandlerResult<RoleDto> Add(RoleDto data)
        {
            var role = new AppRole();
            mapper.Map(data, role);
            repository.Save(role);
            return new HandlerResult<RoleDto>(mapper.Map<AppRole, RoleDto>(role));
        }

        public async Task<IdentityResult> CreateAsync(RoleDto data)
        {
            var role = new AppRole();
            mapper.Map(data, role);
            return await roleManager.CreateAsync(role);
        }

        public void Delete(string id)
        {
            repository.Delete<AppRole>(id);
        }

        public async Task<IdentityResult> DeleteAsync(RoleDto data)
        {
            var role = await roleManager.FindByNameAsync(data.Name);
            return await roleManager.DeleteAsync(role);
        }

        public async Task<RoleDto> FindByIdAsync(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            return mapper.Map<AppRole, RoleDto>(role);

        }

        public async Task<RoleDto> FindByNameAsync(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            return mapper.Map<AppRole, RoleDto>(role);

        }

        public IHandlerResult<PageData<RoleDto>> GetPageData(PagingData pagingData)
        {
            throw new NotImplementedException();
        }

        public IHandlerResult<IEnumerable<RoleDto>> Get()
        {
            var result = mapper.Map<IEnumerable<AppRole>, IEnumerable<RoleDto>>(repository.Get<AppRole>());
            return new HandlerResult<IEnumerable<RoleDto>>(result);
        }

        public IHandlerResult<IEnumerable<RoleDto>> GetRolesByHierarchy(int hierarchy)
        {
            var result = mapper.Map<IEnumerable<AppRole>, IEnumerable<RoleDto>>(roleManager.GetRolesByHierarchy(hierarchy));
            return new HandlerResult<IEnumerable<RoleDto>>(result);
        }

        public IHandlerResult<RoleDto> Get(string id)
        {
            var result = mapper.Map<AppRole, RoleDto>(repository.Get<AppRole>(id));
            return new HandlerResult<RoleDto>(result);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await roleManager.RoleExistsAsync(roleName);
        }

        public IHandlerResult<RoleDto> Update(RoleDto data)
        {
            var role = roleManager.FindByName(data.Name);
            mapper.Map(data, role);
            repository.Save(role);
            return new HandlerResult<RoleDto>(mapper.Map<AppRole, RoleDto>(role));
        }

        public async Task<IdentityResult> UpdateAsync(RoleDto data)
        {
            var role = await roleManager.FindByNameAsync(data.Name);
            mapper.Map(data, role);
            return await roleManager.UpdateAsync(role);
        }
    }
}
