using CrudWebApiAngularJs.Common.DTO;
using CrudWebApiAngularJs.DAL.API.Repositories;
using CrudWebApiAngularJs.DAL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.Validators
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        
        public DepartmentDtoValidator()
        {        
            RuleFor(x => x.Name).
                NotEmpty().WithMessage("The department Name cannot be blank.").
                SetValidator(new UniqueNamelValidator());
            RuleFor(x => x.Description).
                NotEmpty().WithMessage("The Description cannot be blank.");
            RuleFor(x => x.CreatedAt).
                NotEmpty().WithMessage("The date of creation cannot be blank.");
        }
    }
}
