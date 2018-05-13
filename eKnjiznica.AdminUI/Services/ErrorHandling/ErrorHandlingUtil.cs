using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.AdminUI.Services.ErrorHandling
{
   public class ErrorHandlingUtil
    {
        public string GetErrorMessage(HttpResponseMessage httpResponseMessage)
        {
            return "Došlo je do neočekivane greške";
        }
    }
}
