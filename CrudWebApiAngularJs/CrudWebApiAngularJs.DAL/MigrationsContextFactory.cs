using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.DAL
{
    public class MigrationsContextFactory : IDbContextFactory<TestContext>
    {
        public TestContext Create()
        {
            return new TestContext("DbConnection");
        }
    }
}
