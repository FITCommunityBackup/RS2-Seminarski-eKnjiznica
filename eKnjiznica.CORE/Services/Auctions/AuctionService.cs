using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Auctions
{
    public class AuctionService : IAuctionService
    {
        private IAuctionRepo auctionRepo;

        public AuctionService(IAuctionRepo auctionRepo)
        {
            this.auctionRepo = auctionRepo;
        }

        public List<AuctionVM> GetActiveAuctions()
        {
            List<AuctionVM> auctions = auctionRepo.GetActiveAuctions();
            auctions.ForEach(a =>
            {
                a.WinnerBidderUsername = GetAuctionWinner(a.Id);
                a.CurrentPrice = GetCurrentPrice(a.Id);
            });

            return auctions;
        }
        public List<AuctionVM> GetAuctions(DateTime? dateFrom, DateTime? dateTo, bool includeInactive)
        {
            List<AuctionVM> auctions = auctionRepo.GetAuctions(dateFrom, dateTo, includeInactive);
            auctions.ForEach(a =>
            {
                a.WinnerBidderUsername = GetAuctionWinner(a.Id);
                a.CurrentPrice = GetCurrentPrice(a.Id);
            });

            return auctions;
        }

        private decimal GetCurrentPrice(int id)
        {
            return auctionRepo.GetCurrentPriceForAuction(id)??0;
        }

        private string GetAuctionWinner(int id)
        {
            return auctionRepo.GetAuctionWinnerName(id);
        }

        public int CreateAuction(AuctionCreateVM auctionCreateVM)
        {
            return auctionRepo.CreateAuction(auctionCreateVM);
        }

        public void UpdateAuction(AuctionUpdateVM vm, int id)
        {
            auctionRepo.UpdateAuction(vm,id);

        }

        public AuctionVM GetAuctionById(int auctionId)
        {
            AuctionVM auction = auctionRepo.GetAuctionById(auctionId);
            auction.WinnerBidderUsername = GetAuctionWinner(auction.Id);
            auction.CurrentPrice = GetCurrentPrice(auction.Id);
            return auction;
        }

        public bool IsUserLatestBidder(int auctionId, string userId)
        {
            var lastBidderId = auctionRepo.GetLatestBidderId(auctionId);
            if (string.IsNullOrEmpty(lastBidderId))
                return false;

            return lastBidderId.Equals(userId);
        }

        public void CreateNewBid(decimal amount, int auctionId, string userId)
        {
            auctionRepo.CreateAuctionBid(amount, auctionId, userId);
        }
    }
}
