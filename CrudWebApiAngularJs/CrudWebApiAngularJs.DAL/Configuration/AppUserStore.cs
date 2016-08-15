using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Configuration
{
    class AppUserStore : UserStore<AppUser, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public AppUserStore(TestContext context)
        : base(context)
        {
        }
    }
}
