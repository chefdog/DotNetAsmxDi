using Autofac.Integration.Web;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebFormsServices.BusinessServices;

namespace WebFormsServicesExample
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Autofac
            AutofacService autofacService = new AutofacService();
            autofacService.RegisterServices();
            _containerProvider = new ContainerProvider(autofacService.ContainerBuilder.Build());
        }
    }
}