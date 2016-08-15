using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.API.Repositories
{
    public interface IRepository
    {
        IQueryable<T> Get<T>() where T : class;
        int GetCount<T>() where T : class;
        T Get<T>(object id) where T : class;
        void Delete<T>(object id) where T : class;
        void Save<T>(T data) where T : class;

    }
}
