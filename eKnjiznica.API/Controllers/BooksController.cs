using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Services.Books;
using eKnjiznica.CORE.Services.Recommender;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : BaseController
    {
        private IBookService bookService;
        private IRecommenderService recommenderService;

        public BooksController(IBookService bookService, IRecommenderService recommenderService)
        {
            this.bookService = bookService;
            this.recommenderService = recommenderService;
        }
        [Authorize(Roles = EntityRoles.AdminRole)]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBooks(
            [FromUri(Name = "title")] string title = null,
            [FromUri(Name = "author")] string author = null,
            [FromUri(Name = "includeInactive")] bool includeInactive = false,
            [FromUri(Name = "categoryId")] int categoryId = 0)
        {
            var result = bookService.GetBooks(title, author,includeInactive,categoryId);
            return Ok(result);
        }


        [HttpGet]
        [Route("topselling")]
        public IHttpActionResult GetTopSellingOffer()
        {
            var result = bookService.GetTopSellingBooks();
            return Ok(result);
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        [Authorize(Roles = EntityRoles.AdminRole + "," + EntityRoles.ClientRole)]
        public IHttpActionResult GetBooksByCategory(
            int categoryId)
        {
            var result = bookService.GetBookOfferByCategory(categoryId, GetUserId());
            return Ok(result);
        }

        [HttpGet]
        [Route("recommended")]
        [Authorize(Roles=EntityRoles.ClientRole)]
        public IHttpActionResult GetRecommendedBooks()
        {
            var result = recommenderService.GetTopSellingRecommendedBooksForUser(GetUserId());
            return Ok(result);
        }


        [Authorize(Roles = EntityRoles.AdminRole)]
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateBook([FromBody] CreateBookVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = bookService.CreateBook(model, GetUserId());
            return Created($"api/books/{result.Id}",result);
        }
        [Authorize(Roles = EntityRoles.AdminRole)]
        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult UpdateBook([FromBody] UpdateBookVM model, [FromUri] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bookService.UpdateBook(model, id, GetUserId());
            return Ok();
        }


    }
}
