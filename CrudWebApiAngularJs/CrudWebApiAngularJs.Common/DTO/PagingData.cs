using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.DTO
{
    public class PagingData
    {
        public int CurrentPage { get; set; }
        public int SkipPageSize { get; set; }
        public int TakePageSize { get; set; }
        public string[] SortColumns { get; set; }
        public string[] Filters { get; set; }

        public PagingData()
        {
            SortColumns = new string[0];
            Filters = new string[0];
        }
    }
}
