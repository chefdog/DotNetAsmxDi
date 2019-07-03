using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsServices.Interfaces;

namespace WebFormsServices.BusinessServices
{
    public class MyCustomBusinessService : IBusinessService
    {

        public MyCustomBusinessService()
        {

        }

        public string Select()
        {
            return "Hello from my custom service";
        }
    }
}
