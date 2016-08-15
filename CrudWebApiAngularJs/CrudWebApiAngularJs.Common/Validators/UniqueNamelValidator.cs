using CrudWebApiAngularJs.DAL.API.Repositories;
using CrudWebApiAngularJs.DAL.Entities;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.Validators
{    
    public class UniqueNamelValidator : PropertyValidator
    {
        private readonly IRepository repository;
        public UniqueNamelValidator( )
            : base("Email address is already registered")
        { }

        public UniqueNamelValidator(IRepository repository)
            : base("Email address is already registered")
        {
            this.repository = repository;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            //var category = repository.Get<Department>().Where(x => x.Name == context.PropertyValue as string).SingleOrDefault();
            //return category == null;
            return true;
        }
    }
}
