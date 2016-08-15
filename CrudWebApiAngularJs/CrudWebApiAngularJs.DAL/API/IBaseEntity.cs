using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.API
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
