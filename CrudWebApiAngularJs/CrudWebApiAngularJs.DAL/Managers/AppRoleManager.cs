using CrudWebApiAngularJs.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Managers
{
    class AppRoleManager : RoleManager<AppRole, string>
    {
        public AppRoleManager(IRoleStore<AppRole, string> store)
        : base(store)
        {
        }
    }
}
