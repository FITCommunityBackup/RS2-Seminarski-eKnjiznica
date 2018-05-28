using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class BookRepo : IBookRepo
    {
        private EF.EKnjiznicaDB context;

        public BookRepo(EKnjiznicaDB context)
        {
            this.context = context;
        }

        public List<BooksVM> GetBooks(string title, string authorName)
        {
            return context
                 .Books
                 .Where(x => string.IsNullOrEmpty(title) || x.Title.Contains(title))
                 .Where(x => string.IsNullOrEmpty(authorName) || x.Autor.Contains(authorName))
                 .Select(x => new BooksVM
                 {
                     Id = x.Id,
                     AuthorName = x.Autor,
                     BookTitle = x.Title,
                     Categories = x.Categories.Select(y => new Commons.ViewModels.Category.CategoryVM {
                         Id = y.CategoryId,
                         CategoryName = y.Category.CategoryName,
                         IsActive = y.IsActive,
                     }).ToList()

                 }).ToList();
        }
    }
}
