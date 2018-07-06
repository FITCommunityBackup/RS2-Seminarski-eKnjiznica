using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.Commons.ViewModels.Clients;

namespace eKnjiznica.CORE.Repository
{
    public interface IAuctionRepo
    {
        List<AuctionVM> GetAuctions(DateTime? dateFrom, DateTime? dateTo,bool includeInactive);
        decimal? GetCurrentPriceForAuction(int id);
        int CreateAuction(AuctionCreateVM auctionCreateVM);
        void UpdateAuction(AuctionUpdateVM vm, int id);
        ClientVM GetAuctionWinner(int id);
        List<AuctionVM> GetActiveAuctions();
        AuctionVM GetAuctionById(int auctionId);
        string GetLatestBidderId(int auctionId);
        void CreateAuctionBid(decimal amount, int auctionId, string userId);
        List<AuctionVM> GetFinishedUnsendAuctions();
        void CompleteAuctions(List<int> list);
    }
}
