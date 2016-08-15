using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Configuration
{
    class AppRoleStore : RoleStore<AppRole, string, IdentityUserRole>
    {
        public AppRoleStore(TestContext context)
        : base(context)
        {
        }
    }
}
