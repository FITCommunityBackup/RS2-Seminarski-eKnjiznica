using eKnjiznica.CORE.Services.ClientBooks;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{
    [Authorize(Roles = EntityRoles.AdminRole + "," + EntityRoles.ClientRole)]
    [RoutePrefix("api/clients/books")]
    public class ClientBooksController : BaseController
    {
        private IClientBooksService clientBooksService;

        public ClientBooksController(IClientBooksService clientBooksService)
        {
            this.clientBooksService = clientBooksService;
        }
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetClientsBooks(
           [FromUri(Name = "title")] string title = null,
           [FromUri(Name = "author")] string author = null,
           [FromUri(Name = "user")] string user = null
            )
        {
            var result = clientBooksService.GetClientBooks(title, author, user);
            return Ok(result);
        }

        [HttpGet]
        [Route("{clientId}")]
        public IHttpActionResult GetClientsBooks(string clientId)
        {
            var result = clientBooksService.GetClientBooks(clientId);
            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetClientsBooks()
        {
            var clientId = GetUserId();
            var result = clientBooksService.GetClientBooks(clientId);
            return Ok(result);
        }

    }
}
