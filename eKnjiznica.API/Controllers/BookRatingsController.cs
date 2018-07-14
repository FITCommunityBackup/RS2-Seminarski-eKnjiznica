using eKnjiznica.CORE.Services.Books;
using eKnjiznica.CORE.Services.BooksRating;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{

    [Authorize(Roles =EntityRoles.ClientRole)]
    [RoutePrefix("api/books/{bookId}/ratings")]
    public class BookRatingsController : BaseController
    {
        private IBooksRatingService BookRatingService;

        public BookRatingsController(IBooksRatingService bookRatingService)
        {
            BookRatingService = bookRatingService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBookRatings(int bookId)
        {
            var result = BookRatingService.GetBookRatings(bookId);
            return Ok(result);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult AddBookRating([FromUri]int bookId, [FromBody] int rating)
        {
            BookRatingService.RateBook(bookId, rating, GetUserId());
            return Ok();
        }
    }
}
