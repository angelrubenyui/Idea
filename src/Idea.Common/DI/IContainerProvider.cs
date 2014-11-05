using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.DI
{
    public interface IContainerProvider
    {
        IUnityContainer GetContainer();
    }
}
