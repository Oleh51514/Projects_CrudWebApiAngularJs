﻿using CrudWebApiAngularJs.Common.API;
using CrudWebApiAngularJs.Common.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.DTO
{
    [Validator(typeof(EmployeeDtoValidator))]
    public class EmployeeDto: IBaseDto<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
