using CrudWebApiAngularJs.Common.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.DTO
{
    public class RoleDto : IBaseDto<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Hierarchy { get; set; }
    }
}
