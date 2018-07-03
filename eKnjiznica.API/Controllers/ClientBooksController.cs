using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Services.ClientBooks;
using eKnjiznica.CORE.Services.Clients;
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
        private IClientService clientService;
        public ClientBooksController(IClientBooksService clientBooksService,IClientService clientService)
        {
            this.clientBooksService = clientBooksService;
            this.clientService = clientService;
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

        [HttpPost]
        [Route("buy")]
        public IHttpActionResult BuyBook([FromBody] IList<BookOfferVM> books) 
        {
            var amount = books.Sum(x => x.Price);
            if (!clientService.HasMoneyOnAccount(GetUserId(), amount))
            {
                ModelState.AddModelError("buy_book", Commons.Resources.NOT_ENOUGH_MONEY_ON_ACCOUNT);
                return BadRequest(ModelState);
            }

            clientBooksService.BuyBook(GetUserId(), books);
            return Ok();
        }

    }
}
