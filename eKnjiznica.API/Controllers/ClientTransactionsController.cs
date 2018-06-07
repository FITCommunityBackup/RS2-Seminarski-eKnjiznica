using eKnjiznica.CORE.Services.Clients;
using eKnjiznica.CORE.Services.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{
    [RoutePrefix("api/transactions")]
    public class ClientTransactionsController : BaseController
    {
        private IClientService clientService;
        private ITransactionService transactionService;
        public ClientTransactionsController(IClientService clientService, ITransactionService transactionService)
        {
            this.transactionService = transactionService;
            this.clientService = clientService;
        }


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTransactions(
            [FromUri(Name = "clientUsername")] string clientUsername=null, 
            [FromUri(Name = "adminUsername")] string adminUsername=null)
        {

            var result = transactionService.GetTransactions(clientUsername, adminUsername).OrderByDescending(x=>x.Date).ToList();
            return Ok(result);
        }

        [HttpPost]
        [Route("client/{id}")]
        public IHttpActionResult AddNewTransaction([FromBody] decimal amount, [FromUri(Name = "id")] string clientId)
        {
            var client = clientService.FindClientById(clientId);
            if (client == null)
                return NotFound();
            if (amount <= 0)
            {
                ModelState.AddModelError("create_transaction", Commons.Resources.ENTER_VALID_AMOUNT);
                return BadRequest(ModelState);
            }
            if (!client.IsActive)
            {
                ModelState.AddModelError("create_transaction", Commons.Resources.ERR_CLIENT_NOT_ACTIVE);
                return BadRequest(ModelState);
            }

            transactionService.AddAmount(amount, clientId, GetUserId());
            return Ok();
        }
    }
}
