using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Recommender
{
    public class RecommenderService : IRecommenderService
    {

        private ICategoriesRepo categoriesRepo;
        private IBookRepo bookRepo;

        public RecommenderService(ICategoriesRepo categoriesRepo, IBookRepo bookRepo)
        {
            this.categoriesRepo = categoriesRepo;
            this.bookRepo = bookRepo;
        }

        public List<BookOfferVM> GetTopSellingRecommendedBooksForUser(string userId)
        {

            var categories = categoriesRepo.GetCategoriesAndBookNumber(userId).OrderByDescending(x=>x.Value).ToList();

            var topSelling=bookRepo.GetTopSellingBooksInCategories(categories.Select(x=>x.Key).ToList(), userId);
            if (topSelling.Count < 15)
            {
                topSelling.AddRange(bookRepo.GetTopSellingBooks(topSelling.Select(x => x.Id).ToList(), userId, 15));
            }

            return topSelling;
        }
    }
}
