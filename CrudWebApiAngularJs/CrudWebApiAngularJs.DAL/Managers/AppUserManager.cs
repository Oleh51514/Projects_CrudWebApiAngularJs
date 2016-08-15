using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Managers
{
    public class AppUserManager : UserManager<AppUser, string>
    {
        public AppUserManager(IUserStore<AppUser, string> store)
            : base(store)
        {
        }

    }
}
