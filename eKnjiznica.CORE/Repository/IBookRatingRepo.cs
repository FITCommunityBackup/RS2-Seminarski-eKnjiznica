using eKnjiznica.Common.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface IBookRatingRepo
    {
        BookRatingVM GetUsersBookRating(string userId, int bookId);
        void RateBook(string userId, int bookId, int rating);
        void DeleteRating(int bookRatingId);
        List<BookRatingVM> GetBookRatings(int bookId);
        double GetAverageBookRating(int bookId);
    }
}
