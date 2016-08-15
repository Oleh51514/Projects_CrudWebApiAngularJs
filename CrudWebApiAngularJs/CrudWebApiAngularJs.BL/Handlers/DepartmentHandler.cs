using AutoMapper;
using CrudWebApiAngularJs.BL.API.Handlers;
using CrudWebApiAngularJs.Common.DTO;
using CrudWebApiAngularJs.DAL.API.Repositories;
using CrudWebApiAngularJs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.Handlers
{
    public class DepartmentHandler : BaseHandler<IRepository, DepartmentDto, Department, int, IMapper>, IDepartmentHandler
    {
        public DepartmentHandler(IRepository repository, IMapper modelMapper)
            : base(repository, modelMapper)
        {

        }

        public bool IsDepartmentNameExists(string DepartmentName)
        {
            bool value = false;
            return value;
        }
    }
}
