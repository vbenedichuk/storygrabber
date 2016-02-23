using AnekdotGrabber.Web.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace AnekdotGrabber.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IApplicationDbContext, ApplicationDbContext>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}