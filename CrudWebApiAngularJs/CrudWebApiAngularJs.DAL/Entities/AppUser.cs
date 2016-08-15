using CrudWebApiAngularJs.DAL.API;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Entities
{
    public class AppUser : IdentityUser, IBaseEntity<string>
    {       
        public AppUser()
        {           
        }                
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }        
    }
}
