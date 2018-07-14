using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Recommender
{
    public class RecommenderService : IRecommenderService
    {

        private ICategoriesRepo categoriesRepo;
        private IBookRepo bookRepo;
        private IBookRatingRepo bookRatingRepo;
        public RecommenderService(ICategoriesRepo categoriesRepo, IBookRepo bookRepo,IBookRatingRepo bookRatingRepo)
        {
            this.categoriesRepo = categoriesRepo;
            this.bookRepo = bookRepo;
            this.bookRatingRepo = bookRatingRepo;
        }

        public List<BookOfferVM> GetRecommendedBooksForUserBasedOnUserRatings(string userId)
        {
            var userRatedBooks = bookRepo.GetUserRatedBooks(userId);
            
            var userMissingBookOfferRatings = GetBookOffersRatings(userId);


            List<BookOfferVM> recommendedBooks = new List<BookOfferVM>();
            foreach (var item in userRatedBooks)
            {
                var similar = GetSimilar(item, userMissingBookOfferRatings,userId)
                    //filter with already added books
                    .Where(x=>!recommendedBooks.Any(y=>y.Id==x.Id));

                recommendedBooks.AddRange(similar);
            }

            return recommendedBooks;
        }

        private List<BookOfferVM> GetSimilar(BookOfferVM currentOffer,
            Dictionary<int, List<BookRatingVM>> userMissingBookOfferRatings,string userId)
        {
            var itemRatings = bookRatingRepo.GetBookRatings(currentOffer.BookId);

            var common1 = new List<BookRatingVM>();
            var common2 = new List<BookRatingVM>();

            var result = new List<BookOfferVM>();
            foreach (var item in userMissingBookOfferRatings)
            {
                foreach (var rating in itemRatings)
                {
                    if (item.Value.Any(x => x.UserId == rating.UserId))
                    {
                        common1.Add(rating);
                        common2.Add(item.Value.First(x => x.UserId == rating.UserId));
                    }
                }
                if (calculateSimmiliraty(common1, common2) > 0.5)
                {
                    result.Add(bookRepo.GetBookOfferById(item.Key,userId));
                }
                common1.Clear();
                common2.Clear();
            }

            return result;
        }

        private double calculateSimmiliraty(List<BookRatingVM> common1, List<BookRatingVM> common2)
        {
            if (common1.Count != common2.Count)
                return 0;
            double numerator = 0, denominator1 = 0, denominator2 = 0;
            for (int i = 0; i < common1.Count; i++)
            {
                numerator = common1[i].Rating * common2[i].Rating;
                denominator1 = common1[i].Rating * common2[i].Rating;
                denominator2 = common2[i].Rating * common2[i].Rating;
            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);

            double nazivnik = denominator1 * denominator2;
            if (nazivnik == 0)
                return 0;
            return numerator / nazivnik;
        }

        public Dictionary<int, List<BookRatingVM>> GetBookOffersRatings(string userId)
        {
            var result = new Dictionary<int, List<BookRatingVM>>();
            List<BookOfferVM> sellingBook = bookRepo.GetUserMissingBookOffers(userId);
            foreach (var item in sellingBook)
            {
                var ratings = bookRatingRepo.GetBookRatings(item.BookId).OrderBy(x => x.UserId).ToList();
                if (ratings.Count > 0)
                {
                    result.Add(item.Id, ratings);
                }
            }
            return result;
        }
    }
}
