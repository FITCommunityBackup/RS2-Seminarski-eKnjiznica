using eKnjiznica.CORE.Services.Auctions;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eKnjiznica.CORE.Services.Clients;
namespace eKnjiznica.API.Controllers
{
    [RoutePrefix("api/auction/{auctionId}/bids")]
    public class AuctionBidController : BaseController
    {

        private IAuctionService auctionService;
        private IClientService clientService;
        public AuctionBidController(IAuctionService auctionService,IClientService clientService)
        {
            this.auctionService = auctionService;
            this.clientService = clientService;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles =EntityRoles.ClientRole)]
        public IHttpActionResult CreateBid([FromUri] int auctionId, [FromBody] decimal amount)
        {
            string userId = GetUserId();

            var auction = auctionService.GetAuctionById(auctionId);
            if (auction == null)
                return NotFound();

            if (auction.EndDate < DateTime.UtcNow)
            {
                ModelState.AddModelError("auction_bid", "Aukcija je završila");
                return BadRequest(ModelState);
            }
            if (auction.StartPrice > amount)
            {
                ModelState.AddModelError("auction_bid", $"Vaša ponuda treba biti veća od {auction.StartPrice} KM!");
                return BadRequest(ModelState);
            }
            if (auctionService.IsUserLatestBidder(auctionId, userId))
            {
                ModelState.AddModelError("auction_bid", "Zadnja ponuda je vaša!");
                return BadRequest(ModelState);
            }

            if(auction.CurrentPrice>=amount)
            {
                ModelState.AddModelError("auction_bid", $"Vaša ponuda nije veća od trenutne najveće ponude.");
                return BadRequest(ModelState);
            }
            var userAccount = clientService.GetUserFinancialAccount(userId);
            if(userAccount.Balance<amount)
            {
                ModelState.AddModelError("auction_bid", $"Nemate dovoljno novca na računu.");
                return BadRequest(ModelState);
            }
            auctionService.CreateNewBid(amount, auctionId, userId);

            //var highestBid = _context.AuctionBids
            //        .Where(x => x.AuctionId == item.AuctionId)
            //        .OrderByDescending(x => x.Amount)
            //        .FirstOrDefault();
          
            //AuctionBid auctionBid = new AuctionBid
            //{
            //    Amount = item.Amount,
            //    AuctionId = item.AuctionId,
            //    BidDate = DateTime.UtcNow,
            //    UserId = userId
            //};
            //int numberOfCurrentOffer = _context.AuctionBids.Where(x => x.AuctionId == item.AuctionId).AsNoTracking().Count();
            //_context.AuctionBids.Add(auctionBid);
            //auction.SellPrice = auctionBid.Amount;
            //_context.SaveChanges();

            //AuctionHub.OnNewBid(new NewBidVM { AuctionId = auction.Id, BidAmount = item.Amount, Id = auction.Id, CurrentOffersCount = numberOfCurrentOffer + 1 });

            return Ok();
        }
    }
}
