using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.ClientBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.ClientBooks
{
    public interface IClientBooksService
    {
        List<ClientBookVM> GetClientBooks(string userId);
        List<ClientBookVM> GetClientBooks(string title,string author,string user);
        Task BuyBook(string v, List<BookOfferVM> books);
        Task ResendBookToEmail(int bookOfferId, string userId);
    }
}
