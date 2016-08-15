using CrudWebApiAngularJs.DAL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Entities
{
    public class Department : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public DateTime CreatedAt { get; set; }

        private ICollection<Employee> _employees;
        public virtual ICollection<Employee> Employees
        {
            get { return _employees ?? (_employees = new List<Employee>()); }
            set { _employees = value; }
        }
    }
}
