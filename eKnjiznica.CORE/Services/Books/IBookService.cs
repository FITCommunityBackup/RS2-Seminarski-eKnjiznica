using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Books
{
    public interface IBookService
    {
        List<BooksVM> GetBooks(string title, string author);
        void UpdateBook(UpdateBookVM model, int id,string userId);
        void CreateBook(CreateBookVM model, string userId);
    }
}
