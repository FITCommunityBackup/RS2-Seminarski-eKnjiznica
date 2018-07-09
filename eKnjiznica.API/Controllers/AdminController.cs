using AutoMapper;
using eKnjiznica.API.Models.Admin;
using eKnjiznica.Commons.ViewModels;
using eKnjiznica.CORE.Model.Admin;
using eKnjiznica.CORE.Services.Admin;
using eKnjiznica.CORE.Services.Logger;
using eKnjiznica.DAL.EF;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

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

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAdminAccounts(string username=null)
        {
            var result = adminService.GetAdminAccountList(username)
                .Select(x => new AdministratorProfileVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    IsActive = x.IsActive,
                    Email =x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Username =x.Username
                })
                .OrderBy(x=>x.FirstName)
                .ThenBy(x=>x.LastName)
                .ToList();

            return Ok(result);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult AddAdminAccount([FromBody] AdminAddVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AdminAccount adminAccount = adminService.FindByUsername(model.Username);
            if (adminAccount != null)
            {
                ModelState.AddModelError("", Commons.Resources.ACCOUNT_WITH_USERNAME_EXISTS);
                return BadRequest(ModelState);
            }

            adminService.AddAdminAccount(Mapper.Map<AdminAccount>(model), model.Password);
            loggerService.LogAdminAction(GetUserId(), LogType.CREATE, $"Created admin account {model.Username}");
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                IsActive = model.IsActive,
                Password = model.Password
            });

            if (adminAccount == null)
                return NotFound();

            loggerService.LogAdminAction(GetUserId(), LogType.UPDATE, $"Updated admin account {model.Id}");
            return Ok();
        }


        [Route("logs")]
        [HttpGet]
        [ResponseType(typeof(LogsVM))]
        public IHttpActionResult GetLogs()
        {
            var userLogs = loggerService.GetLogs();
            return Ok(userLogs);
        }

    }
}
