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
    public class EmployeeHandler : BaseHandler<IRepository, EmployeeDto, Employee, int, IMapper>, IEmployeeHandler
    {
        public EmployeeHandler(IRepository repository, IMapper modelMapper)
            : base(repository, modelMapper)
        {

        }
    }
}
