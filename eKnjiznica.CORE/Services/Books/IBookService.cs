using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Books
{
    public interface IBookService
    {
        List<BooksVM> GetBooks(string title, string author,bool includeInactive,int categoryId);
        void UpdateBook(UpdateBookVM model, int id,string userId);
        BooksVM CreateBook(CreateBookVM model, string userId);
        List<BookOfferVM> GetBookOffers(string title, string author, bool includeInactive);
        BookOfferVM CreateBookOffer(CreateBookOfferVM model);
        void UpdateBookOffer(UpdateBookOfferVM model, int id);
        List<BookOfferVM> GetBookOfferByCategory(int categoryId,string userId);
        BookOfferVM CreateAuctionBookOffer(CreateAuctionBookOfferVM createAuctionBookOfferVM);
        List<BookOfferVM> GetTopSellingBooks();
    }
}
