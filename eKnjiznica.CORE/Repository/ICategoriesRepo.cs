using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Category;
namespace eKnjiznica.CORE.Repository
{
    public interface ICategoriesRepo
    {
        IList<CategoryVM> GetCategories(string nameFilter,bool includeInactive);
        CategoryVM GetCategory(int id);
        CategoryVM GetCategoryByName(string categoryName);
        void CreateCategory(CategoryAddVM model, string userId);
    }
}
