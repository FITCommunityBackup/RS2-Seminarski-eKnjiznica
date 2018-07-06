using eKnjiznica.Common.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.CORE.Services.Auctions;
using eKnjiznica.CORE.Services.Books;
using eKnjiznica.CORE.Services.ClientBooks;
using eKnjiznica.CORE.Services.Clients;
using eKnjiznica.CORE.Services.EmailService;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace eKnjiznica.API.Jobs

{
    public class AuctionCrawlerJob : IJob
    {
        private IAuctionService auctionService;
        private IClientService clientService;
        private IClientBooksService clientBooksService;
        private IBookService bookService;

        public AuctionCrawlerJob(
            IAuctionService auctionService, 
            IClientService clientService, 
            IClientBooksService clientBooksService, 
            IBookService bookService)
        {
            this.auctionService = auctionService;
            this.clientService = clientService;
            this.clientBooksService = clientBooksService;
            this.bookService = bookService;
        }


        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(async () =>
            {
                var auctions = auctionService.GetFinishedUnsendAuctions();

                foreach (var item in auctions)
                {
                    if (string.IsNullOrEmpty(item.WinnerBidderId))
                        continue;

                   var winner = clientService.GetClientAccount(item.WinnerBidderId);
                   var bookOffer = bookService.CreateAuctionBookOffer(new CreateAuctionBookOfferVM
                    {
                        BookId = item.BookId,
                        Price = item.CurrentPrice
                    });
                    await clientBooksService.BuyBook(winner.Id, new List<BookOfferVM>
                    {
                        bookOffer
                    });
                }
                auctionService.CompleteAuctions(auctions.Select(x => x.Id).ToList());
            });
        }
    }
}