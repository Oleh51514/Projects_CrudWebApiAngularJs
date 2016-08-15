using CrudWebApiAngularJs.DAL.API.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL.Repositories
{
    public class Repository : IRepository
    {
        protected readonly TestContext context;

        public Repository(TestContext context)
        {
            this.context = context;
        }      

        public virtual IQueryable<T> Get<T>() where T : class
        {
            return this.context.Set<T>();
        }

        public virtual int GetCount<T>() where T : class
        {
            return this.context.Set<T>().Count();
        }

        public virtual T Get<T>(object id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }

        public virtual void Delete<T>(object id) where T : class
        {
            this.context.Set<T>().Remove(this.context.Set<T>().Find(id));
            this.context.SaveChanges();
        }

        public void Save<T>(T data) where T : class
        {
            //needed fo track changes for auidit while change relationships between entities
            if (!context.Set<T>().Local.Any(d => d == data))
            {
                this.context.Set<T>().Add(data);
                this.context.Entry(data).State = EntityState.Added;
            }
            else
            {
                this.context.Entry(data).State = EntityState.Modified;
            }
            this.context.SaveChanges();
        }
    }
}
