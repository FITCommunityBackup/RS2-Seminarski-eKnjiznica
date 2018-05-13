using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace eKnjiznica.API.Controllers
{
    public class BaseController : ApiController
    {
        public string GetUserId()
        {
            return RequestContext.Principal.Identity.GetUserId();
        }
    }
    
}
