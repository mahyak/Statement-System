using Ninject;
using Ninject.Web.Common;
using Statement.Data.EFRepositories;
using Statement.Data.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Statement.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUserRepository>().To<EFUserRepository>().InRequestScope();
            kernel.Bind<ICustomerRepository>().To<EFCustomerRepository>().InRequestScope();
            kernel.Bind<IMaterialRepository>().To<EFMaterialRepository>().InRequestScope();
            kernel.Bind<IFactorRepository>().To<EFFactorRepository>().InRequestScope();
            kernel.Bind<IMaterialFactorRepository>().To<EFMaterialFactorRepository>().InRequestScope();
        }
    }
}