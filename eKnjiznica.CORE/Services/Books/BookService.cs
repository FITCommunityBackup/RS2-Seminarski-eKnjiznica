using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.Books
{
    public class BookService : IBookService
    {
        IBookRepo bookRepo;

        public BookService(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public List<BooksVM> GetBooks(string title, string author)
        {
           return bookRepo.GetBooks(title, author);
        }
    }
}
