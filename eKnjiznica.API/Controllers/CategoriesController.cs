using eKnjiznica.Commons;
using eKnjiznica.Commons.ViewModels.Category;
using eKnjiznica.CORE.Services.Categories;
using eKnjiznica.DAL.EF;
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
        [AllowAnonymous]
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
        [HttpGet]
        [Route("topselling")]
        [AllowAnonymous]
        public IHttpActionResult GetTopSellingCategories()
        {
            var result = categoriesService.GetCategoryTopSellingCategories();
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCategory([FromBody] CategoryAddVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = categoriesService.GetCategoryByName(model.CategoryName);
            if (result != null)
            {
                ModelState.AddModelError("create_category", Resources.CATEGORY_WITH_THAT_NAME_EXISTS);
                return BadRequest(ModelState);
            }
            categoriesService.CreateCategory(model, GetUserId());
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateCategory([FromBody] CategoryUpdateVm model,[FromUri] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = categoriesService.GetCategoryById(id);
            if (result == null)
            {
                ModelState.AddModelError("update_category",Resources.CATEGORY_DOES_NOT_EXIST);
                return BadRequest(ModelState);
            }
           
            if (!string.IsNullOrEmpty(model.CategoryName) && categoriesService.GetCategoryByName(model.CategoryName)!=null)
            {
                ModelState.AddModelError("update_category", Resources.CATEGORY_WITH_THAT_NAME_EXISTS);
                return BadRequest(ModelState);
            }

            categoriesService.UpdateCategory(model,id);
            return Ok();
        }
    }
}
