using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Idea.Bussiness.Integration.Test
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
            container.RegisterType(typeof (IUnitOfWork), typeof (UnitOfWork));
            container.RegisterType(typeof (IRepository), typeof (Repository));
            return container;
        }
    }
}

}
