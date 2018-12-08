using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.ClientBook;
using eKnjiznica.CORE.Repository;
using eKnjiznica.CORE.Services.EmailService;

namespace eKnjiznica.CORE.Services.ClientBooks
{
    public class ClientBooksService : IClientBooksService
    {
        private IClientBooksRepo clientBooksRepo;
        private IEmailService emailService;
        private IClientRepo clientRepo;
        public ClientBooksService(IClientBooksRepo clientBooksRepo,IEmailService emailService,IClientRepo clientRepo)
        {
            this.clientRepo = clientRepo;
            this.emailService = emailService;
            this.clientBooksRepo = clientBooksRepo;
        }

        public async Task BuyBook(string userId, List<BookOfferVM> books)
        {
            var user = clientRepo.GetClientById(userId);
            List<string> bookFiles = clientBooksRepo.GetBookLocations(books.Select(x=>x.BookId).ToList());

            await emailService.SendBooks(bookFiles, user.Email);
            clientBooksRepo.AddBooksToUser(userId, books);
        }

        public List<ClientBookVM> GetClientBooks(string userId,string bookName=null)
        {
            return clientBooksRepo.GetClientBooks(userId,bookName);
        }


        public List<ClientBookVM> GetClientBooks(string title, string author, string user)
        {
            return clientBooksRepo.GetClientBooks(title,author,user);
        }

        public async Task ResendBookToEmail(int bookOfferId, string userId)
        {
            var user = clientRepo.GetClientById(userId);
            List<string> bookFiles = clientBooksRepo.GetBookLocations(new List<int>() {
                bookOfferId
            });

            await emailService.SendBooks(bookFiles, user.Email);

        }
    }
}
