using eKnjiznica.CORE.Services.Books;
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

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBooks([FromUri(Name = "title")] string title = null, [FromUri(Name = "author")] string author = null)
        {
            var result = bookService.GetBooks(title, author);
            return Ok(result);
        }

    }
}
