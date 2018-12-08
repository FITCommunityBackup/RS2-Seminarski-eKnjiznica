using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.ClientBook;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using eKnjiznica.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class ClientBooksRepo : IClientBooksRepo
    {
        private EKnjiznicaDB context;

        public ClientBooksRepo(EKnjiznicaDB context)
        {
            this.context = context;
        }

        public void AddBooksToUser(string userId, IList<BookOfferVM> books)
        {
            var amount = books.Sum(x => x.Price);
            var accountBalance = context.UserFinancialAccounts.First(x => x.UserFinancialAccountId == userId);

            var transaction = new Transaction
            {
                Amount = amount,
                DateUtc = DateTime.UtcNow,
                PreviousAccountBalance = accountBalance.Balance,
                NewAccountBalance = accountBalance.Balance - amount,
                TransactionType = Commons.ViewModels.TransactionType.BUY,
                UserFinancialAccountId = accountBalance.UserFinancialAccountId
            };
            foreach (var item in books)
            {
                context.UserBooks.Add(new UserBook
                {
                    BookOfferId = item.Id,
                    DateOfPurchase = DateTime.UtcNow,
                    Transaction = transaction,
                    UserId = userId
                });
            }
            accountBalance.Balance -= amount;
            context.SaveChanges();
        }

        public List<string> GetBookLocations(List<int> bookIds)
        {
            var result = context.Books.Where(x => bookIds.Any(y => y == x.Id))
                .Select(x => x.FileLocation)
                .ToList();

            return result;
        }

        public ClientBookVM GetClientBook(int bookOfferId, string userId)
        {
            return context
                .UserBooks
                .Where(x => x.UserId == userId)
                .Where(x => x.BookOfferId == bookOfferId)
                .Include(x => x.BookOffer)
                .Include(x => x.BookOffer.Book)
                .Include(x => x.BookOffer.Book.Categories)
                .Include(x => x.User)
                .Select(ClientVmMapper(userId))
              .FirstOrDefault();
        }

        public List<ClientBookVM> GetClientBooks(string userId,string bookname=null)
        {
            return context.UserBooks
                .Where(x => x.UserId == userId)
                .Include(x => x.BookOffer)
                .Include(x => x.BookOffer.Book)
                .Include(x => x.BookOffer.Book.Categories)
                .Include(x => x.User)
                .Where(x=> string.IsNullOrEmpty(bookname) ||  x.BookOffer.Book.Title.Contains(bookname))
                .Select(ClientVmMapper(userId))
                .ToList();
        }

        private Expression<Func<UserBook, ClientBookVM>> ClientVmMapper(string userId)
        {
            return x => new ClientBookVM
            {
                AuthorName = x.BookOffer.Book.Autor,
                BookTitle = x.BookOffer.Book.Title,
                BuyDate = x.DateOfPurchase,
                BookReleaseDate = x.BookOffer.Book.ReleaseDate,
                Categories = x.BookOffer.Book.Categories.Where(y => y.IsActive).Select(y => new Commons.ViewModels.Category.CategoryVM
                {
                    Id = y.CategoryId,
                    CategoryName = y.Category.CategoryName,
                    IsActive = y.IsActive,
                }).ToList(),
                Id = x.Id,
                Price = x.BookOffer.Price,
                TransactionId = x.TransactionId,
                ClientName = x.User.UserName,
                ImageUrl = x.BookOffer.Book.ImageLocation,
                OfferId = x.BookOfferId,
                BookDescription = x.BookOffer.Book.Description,
                BookId = x.BookOffer.BookId,
                AverageRating = x.BookOffer.Book.BookRatings.Where(y => y.IsActive).Average(y => y.Rating),
                UserRating=
                x.BookOffer.Book.BookRatings.FirstOrDefault(y=>y.IsActive&&y.UserId==userId)!=null?
                x.BookOffer.Book.BookRatings.FirstOrDefault(y=>y.IsActive &&y.UserId==userId).Rating:0
            };
        }

        public List<ClientBookVM> GetClientBooks(string title, string author, string user)
        {
            return context.UserBooks
                .Include(x => x.BookOffer)
                .Include(x => x.BookOffer.Book)
                .Include(x => x.BookOffer.Book.Categories)
                .Include(x => x.User)
                .Where(x => string.IsNullOrEmpty(title) || x.BookOffer.Book.Title.Contains(title))
                .Where(x => string.IsNullOrEmpty(author) || x.BookOffer.Book.Autor.Contains(author))
                .Where(x => string.IsNullOrEmpty(user) || x.User.UserName.Contains(user))
                .Select(ClientVmMapper(user)).ToList();
        }
      
    }
}
