using CrudWebApiAngularJs.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.API.Handlers
{
    public interface IDepartmentHandler: IBaseHandler<DepartmentDto, int>
    {
        bool IsDepartmentNameExists(string DepartmentName);
    }
}
