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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.Handlers
{
    public class AppUserHandler : BaseHandler<IRepository, AppUserDto, AppUser, string, IMapper>, IAppUserHandler
    {
        private readonly IUserManagerRepository userManager;        
        public AppUserHandler(IRepository repository, IUserManagerRepository userManager, IMapper mapper) : base(repository, mapper)
        {
            this.userManager = userManager;            
        }

        public override IHandlerResult<AppUserDto> Add(AppUserDto data)
        {
            var user = new AppUser();
            mapper.Map(data, user);
            IdentityResult result = userManager.RegisterUser(user, data.Password);
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, "User");
                return new HandlerResult<AppUserDto>(mapper.Map<AppUser, AppUserDto>(user));
            }
            else
            {
                return new HandlerResult<AppUserDto>("Error while creating user");
            }
        }


        public async Task<IHandlerResult<ClaimsIdentity>> CreateIdentityAsync(AppUserDto user, string authenticationType)
        {

            var identity = await userManager.FindAsync(user.Id.ToString());
            var result = await userManager.CreateIdentityAsync(identity, authenticationType);

            return new HandlerResult<ClaimsIdentity>(result);

        }


        public override IHandlerResult<AppUserDto> Get(string id)
        {
            var result = base.Get(id).Result;
            result.Role = this.GetTopRoleName(id).Result;
            return new HandlerResult<AppUserDto>(result);
        }
        public async Task<IHandlerResult<AppUserDto>> FindUserAsync(string id)
        {
            var user = await userManager.FindAsync(id);
            return new HandlerResult<AppUserDto>(mapper.Map<AppUserDto>(user));
        }

        public async Task<IHandlerResult<AppUserDto>> FindByName(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return new HandlerResult<AppUserDto>(mapper.Map<AppUserDto>(user));
        }

        public async Task<IHandlerResult<AppUserDto>> FindUserAsync(string userName, string password)
        {
            var user = await userManager.FindUserAsync(userName, password);
            return new HandlerResult<AppUserDto>(mapper.Map<AppUserDto>(user));
        }

        public async Task<IHandlerResult<AppUserDto>> RegisterUserAsync(AppUserDto user)
        {
            var entity = new AppUser();
            mapper.Map<AppUserDto, AppUser>(user, entity);
            IdentityResult result = await userManager.RegisterUserAync(entity, user.Password);
            if (result.Succeeded)
            {
                userManager.AddToRole(entity.Id, "User");
                var dto = mapper.Map<AppUser, AppUserDto>(repository.Get<AppUser>(entity.Id));
                return new HandlerResult<AppUserDto>(dto);
            }
            else
            {
                return new HandlerResult<AppUserDto>("Error while creating user");
            }
        }                
        public IHandlerResult<IEnumerable<RoleDto>> GetRoles(string userId)
        {
            var UserRoles = repository.Get<AppUser>(userId).Roles.Select(u => u.RoleId);
            var roles = repository.Get<AppRole>().Where(r => UserRoles.Contains(r.Id));
            var result = mapper.Map<IEnumerable<AppRole>, IEnumerable<RoleDto>>(roles);
            return new HandlerResult<IEnumerable<RoleDto>>(result);
        }

        public IHandlerResult<string> GetTopRoleName(string userId)
        {
            return new HandlerResult<string>(true, string.Empty, userManager.GetTopRole(userId));
        }

        public override IHandlerResult<AppUserDto> Update(AppUserDto data)
        {
            AppUser user = repository.Get<AppUser>(data.Id);
            mapper.Map(data, user);
            repository.Save(user);
            var roles = userManager.GetRoles(user.Id);
            foreach (var role in roles)
            {
                userManager.RemoveFromRole(user.Id, role);
            }
            userManager.AddToRole(user.Id, data.Role);
            return new HandlerResult<AppUserDto>(mapper.Map<AppUser, AppUserDto>(user));
        }

        public IdentityResult AddToRole(string userId, string role)
        {
            return userManager.AddToRole(userId, role);
        }

        public IdentityResult RemoveFromRole(string userId, string role)
        {
            return userManager.RemoveFromRole(userId, role);
        }
    }
}
