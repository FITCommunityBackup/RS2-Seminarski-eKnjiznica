using eKnjiznica.Commons.ViewModels.Category;
using eKnjiznica.CORE.Services.Categories;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eKnjiznica.API.Controllers
{
    [Authorize(Roles = EntityRoles.AdminRole)]
    [RoutePrefix("api/categories")]
    public class CategoriesController : BaseController
    {

        private ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCategories(
            [FromUri(Name = "nameFilter")] string nameFilter = null,
            [FromUri(Name = "includeInactive")] bool includeInactive = false)
        {
            var result = categoriesService.GetCategories(nameFilter,includeInactive);
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategory(int id)
        {
            var result = categoriesService.GetCategoryById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCategory([FromBody] CategoryAddVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = categoriesService.GetCategoryByName(model);
            if (result != null)
            {
                ModelState.AddModelError("create_category", Commons.Resources.CATEGORY_WITH_THAT_NAME_EXISTS);
                return BadRequest(ModelState);
            }
            categoriesService.CreateCategory(model, GetUserId());
            return Ok();
        }
    }
}
