using Autofac;
using Autofac.Integration.Web;
using Serilog;
using System;
using System.IO;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebFormsServices.BusinessServices;
using WebFormsServices.Interfaces;

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
            ContainerBuilder builder = new ContainerBuilder();
            var location = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var file = File.CreateText(location + "\\serilogexceptions.log");
            Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));
            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                    .WriteTo.Elasticsearch()
                    .WriteTo.RollingFile(
                        AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "/Log-{Date}.txt")
                    .CreateLogger();
            }).SingleInstance();

            builder.RegisterType<MyCustomBusinessService>().As<IBusinessService>();
            _containerProvider = new ContainerProvider(builder.Build());
        }
    }
}