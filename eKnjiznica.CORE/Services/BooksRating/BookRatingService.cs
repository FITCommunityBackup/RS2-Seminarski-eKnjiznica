using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.BooksRating
{

    public class BookRatingService : IBooksRatingService
    {
        private IBookRatingRepo bookRatingRepo;

        public BookRatingService(IBookRatingRepo bookRatingRepo)
        {
            this.bookRatingRepo = bookRatingRepo;
        }

        public List<BookRatingVM> GetBookRatings(int bookId)
        {
            return bookRatingRepo.GetBookRatings(bookId);
        }

        public void RateBook(int bookId, int rating, string userId)
        {
            var userRating = bookRatingRepo.GetUsersBookRating(userId, bookId);
            if (userRating != null)
                bookRatingRepo.DeleteRating(userRating.Id);
            bookRatingRepo.RateBook(userId, bookId, rating);
        }
    }
}
