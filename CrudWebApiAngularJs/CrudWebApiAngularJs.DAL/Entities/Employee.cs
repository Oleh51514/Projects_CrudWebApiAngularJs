using CrudWebApiAngularJs.DAL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Entities
{
    public class Employee: IBaseEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
