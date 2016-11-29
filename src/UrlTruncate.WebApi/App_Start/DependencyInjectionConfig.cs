
namespace UrlTruncate.WebApi.App_Start
{
    using System.ComponentModel;
    using System.Web.Http;
    using System.Web.Mvc;

    using Microsoft.Practices.Unity;

    using UrlTruncate.Service.Providers;

    public static class DependencyInjectionConfig
    {
        public static void Initialize()
        {
            var container = new UnityContainer();
            container.RegisterType<ITruncatedUrlServiceProvider, TruncatedUrlServiceProvider>();

            //DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            // Configures container for WebAPI
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}