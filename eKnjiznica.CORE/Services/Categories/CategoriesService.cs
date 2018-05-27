using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Category;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepo categoriesRepo;

        public CategoriesService(ICategoriesRepo categoriesRepo)
        {
            this.categoriesRepo = categoriesRepo;
        }

        public void CreateCategory(CategoryAddVM model,string userId)
        {
            categoriesRepo.CreateCategory(model,userId);

        }

        public IList<CategoryVM> GetCategories(string nameFilter,bool includeInactive)
        {
            return categoriesRepo.GetCategories(nameFilter,includeInactive).OrderBy(x=>x.CategoryName).ToList();
        }

        public CategoryVM GetCategoryById(int id)
        {
            return categoriesRepo.GetCategory(id);
        }

        public CategoryVM GetCategoryByName(string categoryName)
        {
            return categoriesRepo.GetCategoryByName(categoryName);

        }

        public void UpdateCategory(CategoryUpdateVm model, int id)
        {
            var result = categoriesRepo.GetCategory(id);
            result.CategoryName = model.CategoryName ?? result.CategoryName;
            result.IsActive= model.IsActive.HasValue?model.IsActive.Value:result.IsActive;
            categoriesRepo.UpdateCategory(result);
        }
    }
}
