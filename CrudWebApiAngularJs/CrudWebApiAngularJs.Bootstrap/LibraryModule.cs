using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrudWebApiAngularJs.BL.API.Handlers;
using CrudWebApiAngularJs.BL.Handlers;
using CrudWebApiAngularJs.Common.Validators;
using CrudWebApiAngularJs.DAL;
using CrudWebApiAngularJs.DAL.API.Repositories;
using CrudWebApiAngularJs.DAL.Repositories;
using FluentValidation;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Bootstrap
{
    public class LibraryModule : NinjectModule
    {
        public override void Load()
        {
            this.InitializeRepositories();
            this.InitializeHandlers();            
            this.InitializeAutomapper();
        }

        private void InitializeRepositories()
        {            
            Bind<TestContext>().ToSelf().InRequestScope().WithConstructorArgument("nameOrConnectionString", "DbConnection");
            Bind<IUserManagerRepository>().To<UserManagerRepository>().InRequestScope();
            Bind<IRepository>().To<Repository>().InRequestScope();;
            Bind<IRoleManagerRepository>().To<RoleManagerRepository>();
        }
        private void InitializeHandlers()
        {            
            Bind<IRoleHandler>().To<RoleHandler>();
            Bind<IAppUserHandler>().To<AppUserHandler>();
            Bind<IDepartmentHandler>().To<DepartmentHandler>();
            Bind<IEmployeeHandler>().To<EmployeeHandler>();
        }
        private void InitializeAutomapper()
        {
            Bind<MapperConfiguration>()
              .ToSelf()
              .InRequestScope()
              .WithConstructorArgument<Action<IMapperConfiguration>>(
                    cfg => new AutoMapperConfig(cfg));
            Bind<IConfigurationProvider>().ToMethod(ctx => ctx.Kernel.Get<MapperConfiguration>());
            Bind<IMapper>().ToMethod(maper => Kernel.Get<MapperConfiguration>().CreateMapper()).InSingletonScope();
            Bind<IExpressionBuilder>().ToConstructor(ctx => new ExpressionBuilder(Kernel.Get<MapperConfiguration>()));
        }
        
    }
}
