using System;
using Idea.Bussiness;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Idea.DAL;
using Idea.DAL.Repositories;
using System.Web;

namespace Idea.WebAPI.App_Start
{


    public class PerHttpRequestLifetimeManager : LifetimeManager
    {
        private readonly Guid _key = Guid.NewGuid();

        public override object GetValue()
        {
            return HttpContext.Current.Items[_key];
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_key] = newValue;
        }

        public override void RemoveValue()
        {
            var obj = GetValue();
            HttpContext.Current.Items.Remove(obj);
        }
    }

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //Si no tengo ni idea lfManager a Transient
            LifetimeManager transient1 = new TransientLifetimeManager();
            //Si voy a compartir un datacontext de ef en diferentes operaciones 
            //LifetimeManager lfManager = new PerResolveLifetimeManager();
            //BONUS:
            LifetimeManager PerRequest = new PerHttpRequestLifetimeManager();


            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            container.RegisterType<IUnitOfWork, FakeUnitOfWork>(new TransientLifetimeManager());
            container.RegisterType<IRepository, FakeRepository>(new TransientLifetimeManager());
            container.RegisterType<IBusiness, FacturaManager>(new TransientLifetimeManager());
            //Hago referencia a este container, para que en toda mi solución funcione con estas dependencias ya configuradas.
            Idea.Common.DI.DependencyHelper.SetUnityContainerProvider(container);
            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
