using CrudWebApiAngularJs.Common.API;
using CrudWebApiAngularJs.Common.Validators;
using FluentValidation.Attributes;
using System;

namespace CrudWebApiAngularJs.Common.DTO
{
    [Validator(typeof(DepartmentDtoValidator))]
    public class DepartmentDto: IBaseDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
