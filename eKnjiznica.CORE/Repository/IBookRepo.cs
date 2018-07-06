using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface IBookRepo
    {
        List<BooksVM> GetBooks(string title, string authorName);
        void UpdateBook(UpdateBookVM model, int id);
        void UpdateBookCategories(UpdateBookVM model, int id,string userId);

        BooksVM CreateBook(CreateBookVM model, string userId);
        BooksVM GetBookById(int bookId);
        void SaveFilePath(BooksVM book, string relativePath,string fileName);
        BookOfferVM CreateAuctionBookOffer(CreateAuctionBookOfferVM createAuctionBookOfferVM);
        List<BookOfferVM> GetBookOffers(string title, string author,bool includeInactive);
        BookOfferVM CreateBookOffer(CreateBookOfferVM model);
        BookOfferVM GetBookOfferById(int id);
        void UpdateBookOffer(UpdateBookOfferVM model, int id);
        List<BookOfferVM> GetBookOffersByCategory(int categoryId,string userId);
        void SaveImageFilePath(BooksVM book, string relativePath, string uploadedFileName);
    }
}
