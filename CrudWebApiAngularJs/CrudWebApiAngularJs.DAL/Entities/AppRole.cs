using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Entities
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name, int hierarchy)
            : base()
        {
            this.Name = name;
            this.Hierarchy = hierarchy;
        }
        public int Hierarchy { get; set; }
    }
}
