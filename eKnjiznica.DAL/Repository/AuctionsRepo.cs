using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class AuctionsRepo : IAuctionRepo
    {
        private EKnjiznicaDB context;
        public AuctionsRepo(EKnjiznicaDB context)
        {
            this.context = context;
        }

        public int CreateAuction(AuctionCreateVM vm)
        {
            var auction = new Auction
            {
                BookId = vm.BookId,
                EndTime = vm.DateTo,
                StartTime = vm.DateFrom,
                IsActive = true,
                StartingPrice = vm.StartPrice
            };
            context.Auctions.Add(auction);
            context.SaveChanges();

            return auction.Id;
        }
        public void UpdateAuction(AuctionUpdateVM vm,int id)
        {

            var auction = context.Auctions.FirstOrDefault(x => x.Id == id);
            if (auction == null)
                return;
            auction.StartTime = vm.DateFrom;
            auction.EndTime= vm.DateTo;
            auction.BookId = vm.BookId;
            auction.StartingPrice = vm.StartPrice;
            auction.IsActive = vm.IsActive;
            context.SaveChanges();
        }

        public List<AuctionVM> GetAuctions(DateTime? dateFrom, DateTime? dateTo,bool includeInactive)
        {
            return context.Auctions
                .Where(x => x.IsActive || includeInactive)
                .Where(x => dateFrom == null || x.StartTime >= dateFrom)
                .Where(x => dateTo == null || x.EndTime <= dateTo)
                .Select(x=>new AuctionVM
                {
                     Id=x.Id,
                     StartPrice=x.StartingPrice,
                     StartDate=x.StartTime,
                     EndDate=x.EndTime,
                     AuthorName=x.Book.Autor,
                     BookTitle=x.Book.Title,
                     IsActive=x.IsActive
                }).ToList();
        }

        public decimal? GetCurrentPriceForAuction(int id)
        {
            return context.AuctionBids.Where(x => x.AuctionId == id)
                .OrderBy(x => x.Amount)
                .Select(x => x.Amount)
                .Take(1).FirstOrDefault();
        }

        public string GetAuctionWinnerName(int id)
        {
            return context.AuctionBids.Where(x => x.AuctionId == id)
                .OrderBy(x => x.Amount)
                .Select(x => x.User.UserName)
                .Take(1).FirstOrDefault();
        }
    }
}
