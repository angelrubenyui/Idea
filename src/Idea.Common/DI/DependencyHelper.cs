using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.DI
{
    public static class DependencyHelper
    {
        private static IUnityContainer _unity;

        public static void SetUnityContainerProvider(IUnityContainer container)
        {
            if (DependencyHelper._unity == null)
            {
                DependencyHelper._unity = container;
            }
            else
            {
                throw new Exception("DependencyFactory cannot be changed once intialized");
            }
        }

        public static T Resolve<T>()
        {
            return DependencyHelper._unity.Resolve<T>();
        }
    }

}
