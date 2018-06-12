using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.ClientBook;
using eKnjiznica.CORE.Repository;

namespace eKnjiznica.CORE.Services.ClientBooks
{
    public class ClientBooksService : IClientBooksService
    {
        public IClientBooksRepo clientBooksRepo;

        public ClientBooksService(IClientBooksRepo clientBooksRepo)
        {
            this.clientBooksRepo = clientBooksRepo;
        }

        public List<ClientBookVM> GetClientBooks(string userId)
        {
            return clientBooksRepo.GetClientBooks(userId);
        }


        public List<ClientBookVM> GetClientBooks(string title, string author, string user)
        {
            return clientBooksRepo.GetClientBooks(title,author,user);
        }
    }
}
