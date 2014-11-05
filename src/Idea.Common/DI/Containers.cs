using Idea.Common.Logging;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.DI
{
    public enum Environment
    {
        Database,
        Memory
    }

    public class ContainerDB : IContainerProvider
    {
        private Logger getCurrentLogger()
        {
            Configuration.SetupFile();
            return new Logger();
        }

        public IUnityContainer GetContainer()
        {
            //Registramos
            UnityContainer container = new UnityContainer();
            //container.RegisterType(typeof(IBussines), typeof(BussinessImplementation), new InjectionProperty("Log", getCurrentLogger());
            return container;
        }
    }

    public class ContainerFake : IContainerProvider
    {
        private Logger getCurrentLogger()
        {
            Configuration.SetupMem();
            return new Logger();
        }

        public IUnityContainer GetContainer()
        {
            //Registramos
            UnityContainer container = new UnityContainer();
            //container.RegisterType(typeof(IBussines), typeof(BussinessImplementation), new InjectionProperty("Log", getCurrentLogger());
            return container;
        }
    }
}
