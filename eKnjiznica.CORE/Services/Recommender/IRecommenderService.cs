using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Recommender
{
    public interface IRecommenderService
    {
        List<BookOfferVM> GetRecommendedBooksForUser(string userId);
    }
}
