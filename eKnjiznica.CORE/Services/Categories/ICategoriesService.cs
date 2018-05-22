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
        CategoryVM GetCategoryByName(CategoryAddVM model);
        void CreateCategory(CategoryAddVM model,string userId);
    }
}
