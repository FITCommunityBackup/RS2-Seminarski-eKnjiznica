using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Books
{
    public class BookService : IBookService
    {
        IBookRepo bookRepo;

        public BookService(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public BookOfferVM CreateAuctionBookOffer(CreateAuctionBookOfferVM createAuctionBookOfferVM)
        {
            return bookRepo.CreateAuctionBookOffer(createAuctionBookOfferVM);
        }

        public BooksVM CreateBook(CreateBookVM model, string userId)
        {
            return bookRepo.CreateBook(model, userId);
        }

        public BookOfferVM CreateBookOffer(CreateBookOfferVM model)
        {
            return bookRepo.CreateBookOffer(model);
        }

        public List<BookOfferVM> GetBookOfferByCategory(int categoryId,string userId,string title=null)
        {
            return bookRepo.GetBookOffersByCategory(categoryId, userId,title);

        }

        public List<BookOfferVM> GetBookOffers(string title, string author, bool includeInactive)
        {
            return bookRepo.GetBookOffers(title, author, includeInactive);
        }

        public List<BooksVM> GetBooks(string title, string author,bool includeInactive, int categoryId)
        {
           return bookRepo.GetBooks(title, author,includeInactive, categoryId);
        }

        public List<BookOfferVM> GetTopSellingBooks(string userId = null)
        {
            return bookRepo.GetTopSellingBooks(userId);

        }

        public void UpdateBook(UpdateBookVM model, int id,string userId)
        {

            bookRepo.UpdateBook(model, id);
            bookRepo.UpdateBookCategories(model, id,userId);
        }

        public void UpdateBookOffer(UpdateBookOfferVM model, int id)
        {
            bookRepo.UpdateBookOffer(model, id);

        }
    }
}
