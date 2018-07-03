using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public BooksVM CreateBook(CreateBookVM model, string userId)
        {
            return bookRepo.CreateBook(model, userId);
        }

        public BookOfferVM CreateBookOffer(CreateBookOfferVM model)
        {
            return bookRepo.CreateBookOffer(model);
        }

        public List<BookOfferVM> GetBookOfferByCategory(int categoryId,string userId)
        {
            return bookRepo.GetBookOffersByCategory(categoryId, userId);

        }

        public List<BookOfferVM> GetBookOffers(string title, string author, bool includeInactive)
        {
            return bookRepo.GetBookOffers(title, author, includeInactive);
        }

        public List<BooksVM> GetBooks(string title, string author)
        {
           return bookRepo.GetBooks(title, author);
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
