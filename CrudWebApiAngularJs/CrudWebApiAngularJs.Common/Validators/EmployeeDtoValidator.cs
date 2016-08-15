using CrudWebApiAngularJs.Common.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {

        public EmployeeDtoValidator()
        {
            RuleFor(x => x.FirstName).
                NotEmpty().WithMessage("The department Name cannot be blank.").
                Must(UniqueName).WithMessage("This First Name already exists.");
            RuleFor(x => x.LastName).
                NotEmpty().WithMessage("The LastName cannot be blank.");
            RuleFor(x => x.Age).
                NotEmpty().WithMessage("The Age cannot be blank.");
            RuleFor(x => x.Department).
            NotEmpty().WithMessage("The Department cannot be blank.");
        }
        private bool UniqueName(string name)
        {
            //var category = repository.Get<Department>().Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefault();
            //return category == null ? true : false;
            return true;
        }
    }
}
