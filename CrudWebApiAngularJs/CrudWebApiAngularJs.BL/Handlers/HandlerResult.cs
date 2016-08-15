using CrudWebApiAngularJs.BL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.Handlers
{
    public class HandlerResult<TResult> : IHandlerResult<TResult> where TResult : class
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public TResult Result { get; private set; }

        public HandlerResult(bool success, string message, TResult result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public HandlerResult(TResult result) : this(true, string.Empty, result)
        {
        }

        public HandlerResult(string message) : this(false, message, null)
        {

        }
    }
}
