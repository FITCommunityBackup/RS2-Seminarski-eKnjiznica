using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.CORE.Services.Auctions;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{
    [RoutePrefix("api/auctions")]
    [AllowAnonymous]
    //[Authorize(Roles =EntityRoles.AdminRole+","+EntityRoles.ClientRole)]
    public class AuctionsController : ApiController
    {

        private IAuctionService auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAuctions(
            [FromUri(Name ="dateFrom")]
            DateTime? dateFrom=null,
            [FromUri(Name ="dateTo")]
            DateTime? dateTo=null,
            [FromUri(Name ="inactive")]
            bool includeInactive=false)
        {
            var result = auctionService.GetAuctions(dateFrom, dateTo, includeInactive);
            return Ok(result);
        }
        [HttpGet]
        [Route("active")]
        public IHttpActionResult GetActiveAuctions()
        {
            var result = auctionService.GetActiveAuctions();
            return Ok(result);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateAuction(AuctionCreateVM auctionCreateVM)
        {
            var result = auctionService.CreateAuction(auctionCreateVM);
            return Ok();
        }
        [HttpGet]
        [Route("{auctionId}")]
        public IHttpActionResult GetAuctionById(int auctionId)
        {
            var auction = auctionService.GetAuctionById(auctionId);
            return Ok(auction);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateAuction(AuctionUpdateVM vm,int id)
        {
            auctionService.UpdateAuction(vm, id);
            return Ok();
        }
    }
}
