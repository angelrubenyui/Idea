using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idea.Common.DI;
using Idea.Common.Logging;
using Idea.DAL;
using Idea.DAL.Repositories;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Idea.Bussines.Test
{
    [TestClass]
    public abstract class Configuration
    {
        private static bool _isDependencyFactoryInitialized = false;

        [TestInitialize()]
        public void TestConfigBaseInitialize()
        {
            if (!Configuration._isDependencyFactoryInitialized)
            {
                DependencyHelper.SetUnityContainerProvider(ContainerFactory.GetContainer());
                Configuration._isDependencyFactoryInitialized = true;
            }
        }
        
    }

    public static class ContainerFactory
    {
       public static IUnityContainer GetContainer()
        {
            //Registramos
            UnityContainer container = new UnityContainer();
            container.RegisterType(typeof (IUnitOfWork), typeof (FakeUnitOfWork));
            container.RegisterType(typeof (IRepository), typeof (FakeRepository));
            //container.RegisterType(typeof(IBussines), typeof(BussinessImplementation), new InjectionProperty("Log", getCurrentLogger());
            return container;
        }
    }
}
