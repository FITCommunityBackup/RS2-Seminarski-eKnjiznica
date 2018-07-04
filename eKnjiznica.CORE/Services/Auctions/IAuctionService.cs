using eKnjiznica.Commons.ViewModels.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Auctions
{
    public interface IAuctionService
    {
        List<AuctionVM> GetAuctions(DateTime? dateFrom, DateTime? dateTo,bool includeInactive);
        int CreateAuction(AuctionCreateVM auctionCreateVM);
        void UpdateAuction(AuctionUpdateVM vm, int id);
        List<AuctionVM> GetActiveAuctions();
        AuctionVM GetAuctionById(int auctionId);
        bool IsUserLatestBidder(int auctionId, string userId);
        void CreateNewBid(decimal amount, int auctionId, string userId);
    }
}
