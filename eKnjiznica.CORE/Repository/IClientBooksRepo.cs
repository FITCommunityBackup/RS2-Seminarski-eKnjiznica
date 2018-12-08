using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.ClientBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Repository
{
    public interface IClientBooksRepo
    {
        List<ClientBookVM> GetClientBooks(string userId,string bookName=null);
        List<ClientBookVM> GetClientBooks(string title, string author, string user);
        void AddBooksToUser(string userId, IList<BookOfferVM> books);
        List<string> GetBookLocations(List<int> bookId);
        ClientBookVM GetClientBook(int bookId, string userId);
    }
}
