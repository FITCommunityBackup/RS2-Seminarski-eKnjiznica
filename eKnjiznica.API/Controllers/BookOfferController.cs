using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Services.Books;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{
    [RoutePrefix("api/books/admin/offers")]
    public class BookOfferController : BaseController
    {
        private IBookService bookService;

        public BookOfferController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = EntityRoles.AdminRole +","+EntityRoles.ClientRole)]
        public IHttpActionResult GetCurrentOffers(
            [FromUri(Name = "title")] string title = null,
            [FromUri(Name = "author")] string author = null,
            [FromUri(Name = "includeInactive")] bool includeInactive = false
            )
        {
            var result = bookService.GetBookOffers(title, author, includeInactive);
            return Ok(result);
        }


        [HttpPost]
        [Route("")]
        [Authorize(Roles = EntityRoles.AdminRole)]
        public IHttpActionResult CreateBookOfffer([FromBody]CreateBookOfferVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = bookService.CreateBookOffer(model);
            return Created($"api/books/offer/{result.Id}",result);
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = EntityRoles.AdminRole)]
        public IHttpActionResult UpdateBookOffer([FromBody]UpdateBookOfferVM model,[FromUri(Name ="id")] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            bookService.UpdateBookOffer(model,id);
            return Ok();
        }

    }
}
