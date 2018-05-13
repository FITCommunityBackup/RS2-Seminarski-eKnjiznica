using AutoMapper;
using eKnjiznica.API.Models.Admin;
using eKnjiznica.CORE.Model.Admin;
using eKnjiznica.CORE.Services.Admin;
using eKnjiznica.CORE.Services.Logger;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{
    [Authorize(Roles = EntityRoles.AdminRole)]
    [RoutePrefix("api/admin")]
    public class AdminController : BaseController
    {

        private ILoggerService loggerService;
        private IAdminService adminService;

        public AdminController(ILoggerService loggerService, IAdminService adminService)
        {
            this.loggerService = loggerService;
            this.adminService = adminService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult AddAdminAccount([FromBody] AdminAddVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            AdminAccount adminAccount = adminService.FindByUsernameOrEmail(model.Username, model.Email);
            if (adminAccount == null)
            {
                ModelState.AddModelError("", "Account exists");
                return BadRequest(ModelState);
            }

            adminService.AddAdminAccount(Mapper.Map<AdminAccount>(model), model.Password);
            loggerService.LogAdminAction(GetUserId(), LogType.CREATE, "Admin account created");
            return Ok();
        }

        [Route("")]
        [HttpPatch]
        public IHttpActionResult UpdateAdminAccount([FromBody] AdminUpdateVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adminAccount = adminService.UpdateAdminAccount(new AdminAccount {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            });

            if (adminAccount == null)
                return NotFound();

            loggerService.LogAdminAction(GetUserId(), LogType.UPDATE, "Admin account updated");
            return Ok();
        }


        [Route("")]
        [HttpPut]
        public IHttpActionResult ToggleAdminAccountStatus([FromBody] AdminStatusChangeVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adminAccount = adminService.FindById(model.Id);
            if (adminAccount == null)
                return NotFound();

            adminService.ToggleAdminAccountStatus(model.Id);
            loggerService.LogAdminAction(GetUserId(), LogType.UPDATE, "Admin account status changed");

            return Ok();
        }
    }
}
