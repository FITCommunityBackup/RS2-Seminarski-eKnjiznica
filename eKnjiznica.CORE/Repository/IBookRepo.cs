using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface IBookRepo
    {
        List<BooksVM> GetBooks(string title, string authorName);
        void UpdateBook(UpdateBookVM model, int id);
        void UpdateBookCategories(UpdateBookVM model, int id,string userId);

        void CreateBook(CreateBookVM model, string userId);
    }
}
