using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CrudWebApiAngularJs.Bootstrap
{
    public class Kernel
    {
        public static StandardKernel Initialize()
        {
            var kernel = new StandardKernel(new LibraryModule());
            RegisterValidators(kernel);

            return kernel;
        }
        private static void RegisterValidators(IKernel kernel)
        {
            AssemblyScanner
                .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(result => kernel.Bind(result.InterfaceType)
                .To(result.ValidatorType)
                .InRequestScope());
        }
    }
}
