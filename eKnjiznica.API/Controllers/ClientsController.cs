using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eKnjiznica.Commons.ViewModels.Clients;
using eKnjiznica.CORE.Services.Clients;
using eKnjiznica.DAL.EF;

namespace eKnjiznica.API.Controllers
{
    [Authorize(Roles = EntityRoles.AdminRole)]
    [RoutePrefix("api/clients")]
    public class ClientsController : BaseController
    {
        private IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetClientAccounts(
            [FromUri(Name = "username")] string username=null,
            [FromUri(Name = "includeInactive")] bool includeInactive=false)
        {
            var result = clientService.GetClientAccount(username, includeInactive);
            return Ok(result);
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateClientAccount(ClientAddVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = clientService.CreateClientAccount(model,GetUserId());
            return Ok();
        }
    }
}
