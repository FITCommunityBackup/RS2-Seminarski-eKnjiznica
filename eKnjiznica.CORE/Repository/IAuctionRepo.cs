using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Auctions;

namespace eKnjiznica.CORE.Repository
{
    public interface IAuctionRepo
    {
        List<AuctionVM> GetAuctions(DateTime? dateFrom, DateTime? dateTo,bool includeInactive);
        decimal? GetCurrentPriceForAuction(int id);
        int CreateAuction(AuctionCreateVM auctionCreateVM);
        void UpdateAuction(AuctionUpdateVM vm, int id);
        string GetAuctionWinnerName(int id);
        List<AuctionVM> GetActiveAuctions();
        AuctionVM GetAuctionById(int auctionId);
        string GetLatestBidderId(int auctionId);
        void CreateAuctionBid(decimal amount, int auctionId, string userId);
    }
}
