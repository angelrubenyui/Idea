using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.DI
{
     public class Factory
    {
        private IUnityContainer mContainer {get;set;}
        private ContainerDB mContainerDB = new ContainerDB();
        private ContainerFake mContainerFake = new ContainerFake();
        
        public void Setup(Environment env)
        {
            mContainer = null;
            switch(env){
                case Environment.Database:
                    mContainer = mContainerDB.GetContainer();
                    break;
                case Environment.Memory:
                    mContainer = mContainerFake.GetContainer();
                    break;
            }
        }

     }
}
