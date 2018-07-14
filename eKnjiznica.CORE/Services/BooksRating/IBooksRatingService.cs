using eKnjiznica.Common.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.BooksRating
{
    public interface  IBooksRatingService
    {
        List<BookRatingVM> GetBookRatings(int bookId);
        void RateBook(int bookId, int rating, string userId);
    }
}
