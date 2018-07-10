using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.Commons.ViewModels.Clients;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                .Select(AuctionMapper()).ToList();
        }
        public List<AuctionVM> GetActiveAuctions()
        {
            return context.Auctions
              .Where(x => x.IsActive )
              .Where(x => x.EndTime > DateTime.UtcNow)
              .Select(AuctionMapper()).ToList();
        }
        private static System.Linq.Expressions.Expression<Func<Auction, AuctionVM>> AuctionMapper()
        {
            return x => new AuctionVM
            {
                Id = x.Id,
                StartPrice = x.StartingPrice,
                StartDate = x.StartTime,
                EndDate = x.EndTime,
                AuthorName = x.Book.Autor,
                ImageUrl = x.Book.ImageLocation,
                BookTitle = x.Book.Title,
                IsActive = x.IsActive,
                BookId=x.Book.Id,
                IsEmailSent=x.IsEmailSent
            };
        }

        public decimal? GetCurrentPriceForAuction(int id)
        {
            decimal? amount =  context.AuctionBids.Where(x => x.AuctionId == id)
                .OrderByDescending(x => x.Amount)
                .Select(x => x.Amount).FirstOrDefault();

            if (amount == null)
                return null;
            return amount;
        }

        public ClientVM GetAuctionWinner(int id)
        {
            var bid = context.AuctionBids
                .Include(x => x.User)
                .Include(x => x.User.UserFinancialAccount)
                .Where(x => x.AuctionId == id)
                .OrderByDescending(x => x.Amount)
                .Take(1).FirstOrDefault();
            if (bid == null)
                return null;
            return new ClientVM
            {
              Id= bid.User.Id,
              AccountBalance= bid.User.UserFinancialAccount.Balance,
              DateOfBirth= bid.User.BirthDate.HasValue? bid.User.BirthDate.Value:DateTime.MinValue,
              Email= bid.User.Email,
              FirstName= bid.User.FirstName,
              LastName= bid.User.LastName,
              PhoneNumber= bid.User.PhoneNumber,
              IsActive= bid.User.IsActive,
              UserName= bid.User.FirstName
            };
        }

        public AuctionVM GetAuctionById(int auctionId)
        {
            return context.Auctions
                .Where(x => x.IsActive)
                .Where(x => x.EndTime > DateTime.UtcNow)
                .Where(x=>x.Id==auctionId)
                .Select(AuctionMapper()).FirstOrDefault();
        }

        public string GetLatestBidderId(int auctionId)
        {
            return context.AuctionBids
                .Where(x => x.AuctionId == auctionId)
                .OrderByDescending(x => x.Amount)
                .Select(x => x.User.Id)
                .Take(1).FirstOrDefault();
        }

        public void CreateAuctionBid(decimal amount, int auctionId, string userId)
        {
            context.AuctionBids
                .Add(new AuctionBid
                {
                    Amount = amount,
                    AuctionId = auctionId,
                    UserId = userId
                });
            context.SaveChanges();
        }

        public List<AuctionVM> GetFinishedUnsendAuctions()
        {
            return context
                .Auctions
                .Where(x => x.EndTime < DateTime.UtcNow)
                 .Where(x => !x.IsEmailSent)
                .Select(AuctionMapper())
                .ToList();
        }

        public void CompleteAuctions(List<int> list)
        {
            var auctions = context
                 .Auctions
                 .Where(x => list.Any(y => x.Id == y)).ToList();
            auctions.ForEach(x => x.IsEmailSent = true);
            context.SaveChanges();
        }
    }
}
