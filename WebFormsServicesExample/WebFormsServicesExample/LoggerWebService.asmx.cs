using Autofac;
using Autofac.Integration.Web;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebFormsServices.Interfaces;

namespace WebFormsServicesExample
{
    /// <summary>
    /// Summary description for LoggerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class LoggerWebService : System.Web.Services.WebService
    {
        public ILogger Logger { get; set; }
        public IBusinessService BusinessService { get; set; }
        public LoggerWebService() {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectProperties(this);
        }


        [WebMethod]
        public string HelloWorld()
        {
            if (Logger != null)
            {
                Logger.Information("The time is {Now}", DateTime.Now);
            }

            if (BusinessService != null)
            {
                return BusinessService.Select();
            }

            return "Hello World";
        }
    }
}
