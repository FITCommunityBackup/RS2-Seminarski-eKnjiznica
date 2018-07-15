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
        private IClientBooksRepo clientBooksRepo;
        private ICategoriesRepo categoriesRepo;
        private IBookRepo bookRepo;
        private IBookRatingRepo bookRatingRepo;
        public RecommenderService(IClientBooksRepo clientBooksRepo, ICategoriesRepo categoriesRepo, IBookRepo bookRepo, IBookRatingRepo bookRatingRepo)
        {
            this.clientBooksRepo = clientBooksRepo;
            this.categoriesRepo = categoriesRepo;
            this.bookRepo = bookRepo;
            this.bookRatingRepo = bookRatingRepo;
        }

        public List<BookOfferVM> GetRecommendedBooksForUser(string userId)
        {
            var userRatedBooks = bookRepo.GetUserRatedBooks(userId);
            var userBuyedBooks = clientBooksRepo.GetClientBooks(userId);


            var userMissingBookOfferRatings = GetBookOffersRatings(userId);

            List<BookOfferVM> recommendedBooks = new List<BookOfferVM>();
            //add similar books based on user rated books
            foreach (var item in userRatedBooks)
            {
                var similar = GetSimilar(item.Id, userMissingBookOfferRatings, userId)
                    //filter with already added books
                    .Where(x => !recommendedBooks.Any(y => y.Id == x.Id));

                recommendedBooks.AddRange(similar);
            }
            //add similar books based on user buyed books
            foreach (var item in userBuyedBooks)
            {
                var similar = GetSimilar(item.OfferId, userMissingBookOfferRatings, userId)
                    //filter with already added books
                    .Where(x => !recommendedBooks.Any(y => y.Id == x.Id));

                recommendedBooks.AddRange(similar);
            }

            //Get top selling books
            var topSelling = bookRepo
                .GetTopSellingBooks(recommendedBooks.Select(x => x.Id).ToList(), userId, 30);

            recommendedBooks.AddRange(topSelling);
            //order books based on rating
            recommendedBooks.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).ToList();

            return recommendedBooks;
        }

        private List<BookOfferVM> GetSimilar(int currentOfferId,
            Dictionary<int, List<BookRatingVM>> userMissingBookOfferRatings, string userId)
        {
            //Get all ratings for current books that are not rated by logged user
            var itemRatings = bookRatingRepo.GetBookRatings(currentOfferId)
                .Where(x => x.UserId != userId)
                .OrderBy(x => x.UserId)
                .ToList();

            var common1 = new List<BookRatingVM>();
            var common2 = new List<BookRatingVM>();

            var result = new List<BookOfferVM>();

            foreach (var item in userMissingBookOfferRatings)
            {
                foreach (var rating in itemRatings)
                {
                    //check if user who has rated some book has also rated current book offer
                    if (item.Value.Any(x => x.UserId == rating.UserId))
                    {
                        common1.Add(rating);
                        common2.Add(item.Value.First(x => x.UserId == rating.UserId));
                    }
                }
                //
                //calculate simiilarity between some book offer and current book
                if (CalculateSimilarity(common1, common2) > 0.5)
                {
                    result.Add(bookRepo.GetBookOfferById(item.Key, userId));
                }
                common1.Clear();
                common2.Clear();
            }

            return result;
        }

        private double calculateSimiliraty(List<BookRatingVM> common1, List<BookRatingVM> common2)
        {
            if (common1.Count != common2.Count)
                return 0;
            double numerator = 0, denominator1 = 0, denominator2 = 0;
            for (int i = 0; i < common1.Count; i++)
            {
                numerator += common1[i].Rating * common2[i].Rating;
                denominator1 += common1[i].Rating * common1[i].Rating;
                denominator2 += common2[i].Rating * common2[i].Rating;
            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);

            double denominator = denominator1 * denominator2;
            if (denominator == 0)
                return 0;
            return numerator / denominator;
        }


        private double CalculateSimilarity(List<BookRatingVM> commonRatings1, List<BookRatingVM> commonRatings2)
        {
            if (commonRatings1.Count != commonRatings2.Count)
                return 0;

            double numerator = 0, int1 = 0, int2 = 0;

            for (int i = 0; i < commonRatings1.Count; i++)
            {
                numerator += commonRatings1[i].Rating * commonRatings2[i].Rating;
                int1 += Math.Pow(commonRatings1[i].Rating, 2);
                int2 += Math.Pow(commonRatings2[i].Rating, 2);

            }

            int1 = Math.Sqrt(int1);
            int2 = Math.Sqrt(int2);

            if (int1 * int2 != 0)
                return numerator / (int1 * int2);

            return 0;

        }


        public Dictionary<int, List<BookRatingVM>> GetBookOffersRatings(string userId)
        {
            var result = new Dictionary<int, List<BookRatingVM>>();
            List<BookOfferVM> sellingBook = bookRepo.GetUserMissingBookOffers(userId);
            foreach (var item in sellingBook)
            {
                var ratings = bookRatingRepo.GetBookRatings(item.BookId)
                    .Where(x => x.UserId != userId)
                    .OrderBy(x => x.UserId).ToList();
                if (ratings.Count > 0)
                {
                    result.Add(item.Id, ratings);
                }
            }
            return result;
        }
    }
}
