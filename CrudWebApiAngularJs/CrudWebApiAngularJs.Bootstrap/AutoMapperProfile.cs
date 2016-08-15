using AutoMapper;
using CrudWebApiAngularJs.Common.DTO;
using CrudWebApiAngularJs.DAL.Entities;

namespace CrudWebApiAngularJs.Bootstrap
{
    class AutoMapperProfile : Profile
    {       
        private readonly IMapperConfiguration MappingConfiguration;
        public AutoMapperProfile(IMapperConfiguration config)
        {
            MappingConfiguration = config;

        }
        protected override void Configure()
        {
            EntityToDto();
            DtoToEntity();
            DtoToDto();
        }

        private void DtoToDto()
        {
            MappingConfiguration.CreateMap<AppUserDto, AppUserDto>();
            MappingConfiguration.CreateMap<RoleDto, RoleDto>();
            MappingConfiguration.CreateMap<DepartmentDto, DepartmentDto>();
            MappingConfiguration.CreateMap<EmployeeDto, EmployeeDto>();
        }
        private void EntityToDto()
        {
            MappingConfiguration.CreateMap<AppUser, AppUserDto>();
            MappingConfiguration.CreateMap<AppRole, RoleDto>();
            MappingConfiguration.CreateMap<Department, DepartmentDto>();
            MappingConfiguration.CreateMap<Employee, EmployeeDto>();
        }
        private void DtoToEntity()
        {
            MappingConfiguration.CreateMap<AppUserDto, AppUser>().
                ForMember(c => c.Id, opt => opt.Ignore());
            MappingConfiguration.CreateMap<RoleDto, AppRole>().
                ForMember(c => c.Id, opt => opt.Ignore());
            //MappingConfiguration.CreateMap<DepartmentDto, Department>();
            MappingConfiguration.CreateMap<DepartmentDto, Department>().ForMember(p => p.Employees, opt => opt.Ignore());
            MappingConfiguration.CreateMap<EmployeeDto, Employee>().
                ForMember(c => c.DepartmentId, opt => opt.MapFrom(p => p.Department.Id)).
                ForMember(c => c.Department, opt => opt.Ignore());
            
        }

    }
}
