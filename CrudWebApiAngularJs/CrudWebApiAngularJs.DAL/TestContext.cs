using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace CrudWebApiAngularJs.DAL
{
    public class TestContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
         public TestContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Department> Departments { get; set; }
    }
}
