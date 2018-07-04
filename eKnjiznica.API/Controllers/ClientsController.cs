using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eKnjiznica.Commons.ViewModels.Clients;
using eKnjiznica.CORE.Services.Admin;
using eKnjiznica.CORE.Services.Clients;
using eKnjiznica.DAL.EF;

namespace eKnjiznica.API.Controllers
{
    [RoutePrefix("api/clients")]
    public class ClientsController : BaseController
    {
        private IClientService clientService;
        private IAdminService adminService;

        public ClientsController(IClientService clientService, IAdminService adminService)
        {
            this.adminService = adminService;
            this.clientService = clientService;
        }

        [Authorize(Roles = EntityRoles.AdminRole)]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetClientAccounts(
            [FromUri(Name = "username")] string username = null,
            [FromUri(Name = "includeInactive")] bool includeInactive = false)
        {
            var result = clientService.GetClientAccounts(username, includeInactive);
            return Ok(result);
        }


        [Authorize(Roles = EntityRoles.AdminRole + "," + EntityRoles.ClientRole)]
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IHttpActionResult CreateClientAccount(ClientAddVM model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (clientService.FindClientByUsername(model.UserName) != null || adminService.FindByUsername(model.UserName) != null)
            {
                ModelState.AddModelError("create_client", Commons.Resources.ACCOUNT_WITH_USERNAME_EXISTS);
                return BadRequest(ModelState);
            }

            var result = clientService.CreateClientAccount(model, GetUserId());
            return Ok();
        }

        [Authorize(Roles = EntityRoles.AdminRole)]
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateClientAccount(ClientUpdateVM model, string id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            clientService.UpdateClientAccount(model, id);
            return Ok();
        }


        [Authorize(Roles = EntityRoles.ClientRole)]
        [HttpGet]
        [Route("profile")]
        public IHttpActionResult GetClientAccount()
        {

            var result = clientService.GetClientAccount(GetUserId());
            return Ok(result);
        }

        [Authorize(Roles = EntityRoles.ClientRole)]
        [HttpPut]
        [Route("profile")]
        public IHttpActionResult UpdateClientAccount([FromBody] ClientUpdateVM vm)
        {
            if (!string.IsNullOrEmpty(vm.OldPassword) && !string.IsNullOrEmpty(vm.Password))
            {
                bool changePassword = clientService.ChangeClientPassword(GetUserId(), vm);
                if (!changePassword)
                {
                    ModelState.AddModelError("profile_update", Commons.Resources.PASSWORD_CHANGE_FAILED);
                    return BadRequest(ModelState);
                }
                vm.Password = null;
            }
            vm.IsActive = true;
            clientService.UpdateClientAccount(vm, GetUserId());
            return Ok();
        }
    }
}
