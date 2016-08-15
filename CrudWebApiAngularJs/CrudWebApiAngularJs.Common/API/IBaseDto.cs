using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.API
{
    public interface IBaseDto<TKey>
    {
        TKey Id { get; set; }
    }
}
