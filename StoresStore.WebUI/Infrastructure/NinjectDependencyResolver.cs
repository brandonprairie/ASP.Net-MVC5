using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using StoresStore.WebUI.Infrastructure.Concrete;
using StoresStore.WebUI.Infrastructure.Abstract;

namespace StoresStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }
        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }
        private void AddBindings()
        {
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse
                (ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            mykernel.Bind<IOrderProcessor>()
                            .To<EmailOrderProcessor>()
                            .WithConstructorArgument("settings", emailSettings);

            mykernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}