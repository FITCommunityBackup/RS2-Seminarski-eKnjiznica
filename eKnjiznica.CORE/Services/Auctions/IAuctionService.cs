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
    }
}
