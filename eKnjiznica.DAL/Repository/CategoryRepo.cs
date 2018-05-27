using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Category;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;

namespace eKnjiznica.DAL.Repository
{
    public class CategoriesRepo : ICategoriesRepo
    {
        private EKnjiznicaDB context;

        public CategoriesRepo(EKnjiznicaDB context)
        {
            this.context = context;
        }

        public void CreateCategory(CategoryAddVM model, string userId)
        {
            context.Categories.Add(new Model.Category
            {
                CategoryName = model.CategoryName,
                IsActive = true,
                UserId = userId
            });
            context.SaveChanges();
        }

        public IList<CategoryVM> GetCategories(string nameFilter,bool includeInactive)
        {
            return context.Categories
                .Where(x=>string.IsNullOrEmpty(nameFilter) || x.CategoryName.Contains(nameFilter))
                .Where(x => includeInactive || x.IsActive)
                .Select(x => new CategoryVM
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                IsActive = x.IsActive,
                NumberOfBooks = x.Books.Count()
            }).ToList();
        }

        public CategoryVM GetCategory(int id)
        {
            return context.Categories.Where(x => x.Id == id)

              .Select(x => new CategoryVM
              {
                  Id = x.Id,
                  CategoryName = x.CategoryName,
                  IsActive = x.IsActive,
                  NumberOfBooks = x.Books.Count()
              }).FirstOrDefault();
        }

        public CategoryVM GetCategoryByName(string categoryName)
        {
            return context.Categories.Where(x => x.CategoryName.Equals(categoryName))
             .Select(x => new CategoryVM
             {
                 Id = x.Id,
                 CategoryName = x.CategoryName,
                 IsActive = x.IsActive,
                 NumberOfBooks = x.Books.Count()
             }).FirstOrDefault();
        }


        public void UpdateCategory(CategoryVM category)
        {
            var result = context.Categories.Where(x => x.Id == category.Id).First();
            result.CategoryName = category.CategoryName;
            result.IsActive= category.IsActive;
            context.SaveChanges();
        }

    }
}
