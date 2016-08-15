using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.DTO
{
    public class PageData<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
    }
}
