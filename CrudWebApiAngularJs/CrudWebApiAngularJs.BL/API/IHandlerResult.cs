using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.API
{
    public interface IHandlerResult<TResult>
    {
        bool Success { get; }
        string Message { get; }
        TResult Result { get; }
    }
}
