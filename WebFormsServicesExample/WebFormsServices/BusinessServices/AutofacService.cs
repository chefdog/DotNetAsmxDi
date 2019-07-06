using Autofac;
using Serilog;
using System;
using System.IO;
using WebFormsServices.Interfaces;

namespace WebFormsServices.BusinessServices
{
    public class AutofacService
    {
        public ContainerBuilder ContainerBuilder { get; private set; }

        public AutofacService() {
           ContainerBuilder  = new ContainerBuilder();
        }

        public void RegisterServices() {
            var location = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var file = File.CreateText(location + "\\serilogexceptions.log");
            Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));
            ContainerBuilder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                    //.WriteTo.Elasticsearch()
                    .WriteTo.RollingFile(
                        AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "/Log-{Date}.txt")
                    .CreateLogger();
            }).SingleInstance();

            ContainerBuilder.RegisterType<MyCustomBusinessService>().As<IBusinessService>();
        }
    }
}
