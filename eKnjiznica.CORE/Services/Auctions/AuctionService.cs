using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.Commons.ViewModels.Clients;
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
                var user = GetAuctionWinner(a.Id);
                a.WinnerBidderUsername = user?.UserName;
                a.WinnerBidderId = user?.Id;
                a.CurrentPrice = GetCurrentPrice(a.Id);
            });

            return auctions;
        }
        public List<AuctionVM> GetAuctions(DateTime? dateFrom, DateTime? dateTo, bool includeInactive)
        {
            List<AuctionVM> auctions = auctionRepo.GetAuctions(dateFrom, dateTo, includeInactive);
            auctions.ForEach(a =>
            {
                var user = GetAuctionWinner(a.Id);
                a.WinnerBidderUsername = user?.UserName;
                a.WinnerBidderId= user?.Id;
                a.CurrentPrice = GetCurrentPrice(a.Id);
            });

            return auctions;
        }

        private decimal GetCurrentPrice(int id)
        {
            return auctionRepo.GetCurrentPriceForAuction(id)??0;
        }

        private ClientVM GetAuctionWinner(int id)
        {
            return auctionRepo.GetAuctionWinner(id);
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
            var user = GetAuctionWinner(auction.Id);
            auction.WinnerBidderUsername = user?.UserName;
            auction.WinnerBidderId= user?.Id;
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

        public List<AuctionVM> GetFinishedUnsendAuctions()
        {
            var auctions = auctionRepo.GetFinishedUnsendAuctions();
            try
            {
                auctions.ForEach(a =>
                {
                    var user = GetAuctionWinner(a.Id);
                    a.WinnerBidderUsername = user?.UserName;
                    a.WinnerBidderId = user?.Id;
                    a.CurrentPrice = GetCurrentPrice(a.Id);
                });
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return auctions;
        }

        public void CompleteAuctions(List<int> list)
        {
            auctionRepo.CompleteAuctions(list);
        }
    }
}
