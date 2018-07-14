using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class BookRatingRepo : IBookRatingRepo
    {
        private EKnjiznicaDB _context;

        public BookRatingRepo(EKnjiznicaDB context)
        {
            _context = context;
        }

        public void DeleteRating(int bookRatingId)
        {
            var bookRating = _context.BookRatings.Where(x => x.IsActive && x.Id == bookRatingId).FirstOrDefault();
            if (bookRating == null)
                return;
            bookRating.IsActive = false;
            _context.SaveChanges();
        }

        public double GetAverageBookRating(int bookId)
        {
            return _context.BookRatings
                 .Where(x => x.BookId == bookId && x.IsActive)
                 .Average(x => x.Rating);
        }

        public List<BookRatingVM> GetBookRatings(int bookId)
        {
            return _context.BookRatings
                .Where(x => x.BookId == bookId && x.IsActive)
                .Select(BookRatingMapper()).ToList();
        }

    

        public BookRatingVM GetUsersBookRating(string userId, int bookId)
        {
            return _context.BookRatings.Where(x => x.IsActive && x.BookId == bookId && x.UserId == userId)
                .Select(BookRatingMapper())
                 .FirstOrDefault();
        }

        public void RateBook(string userId, int bookId, int rating)
        {
            _context.BookRatings.Add(new Model.BookRating
            {
                BookId = bookId,
                IsActive = true,
                Rating = rating,
                UserId = userId
            });
            _context.SaveChanges();
        }


        private static System.Linq.Expressions.Expression<Func<Model.BookRating, BookRatingVM>> BookRatingMapper()
        {
            return x => new BookRatingVM
            {
                Id = x.Id,
                Rating = x.Rating,
                UserId = x.UserId,
                BookId = x.BookId
            };
        }
    }
}
