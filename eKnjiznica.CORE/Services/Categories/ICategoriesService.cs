using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Category;
namespace eKnjiznica.CORE.Services.Categories
{
    public interface ICategoriesService
    {
        IList<CategoryVM> GetCategories(string nameFilter,bool includeInactive);
        CategoryVM GetCategoryById(int id);
        IList<CategoryVM> GetCategoryTopSellingCategories();
        CategoryVM GetCategoryByName(string categoryName);
        void CreateCategory(CategoryAddVM model,string userId);
        void UpdateCategory(CategoryUpdateVm model, int id);
    }
}
