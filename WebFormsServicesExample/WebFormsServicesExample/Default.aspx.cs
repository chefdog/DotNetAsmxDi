using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsServices.Interfaces;

namespace WebFormsServicesExample
{
    public partial class _Default : Page
    {
        public ILogger Logger { get; set; }
        public IBusinessService BusinessService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Logger != null)
            {
                Logger.Information("The time is {Now}", DateTime.Now);
            }

            if (BusinessService != null)
            {
                litTitle.Text = BusinessService.Select();
            }
        }
    }
}