using eKnjiznica.Commons.ViewModels;
using eKnjiznica.Commons.ViewModels.TransactionVM;
using eKnjiznica.CORE.Repository;
using eKnjiznica.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Repository
{
    public class TransactionRepo : ITransactionsRepo
    {
        private EKnjiznicaDB context;

        public TransactionRepo(EKnjiznicaDB context)
        {
            this.context = context;
        }

        public TransactionVM GetTransaction(int id)
        {
            return context.Transactions
                           .Include(x => x.UserFinancialAccount.ApplicationUser)
                           .Include(x => x.Admin)
                           .Where(x => x.Id == id)
                           .Select(x => new TransactionVM
                           {
                               AdminUsername = x.Admin != null ? x.Admin.UserName : null,
                               Amount = x.Amount,
                               ClientUsername = x.UserFinancialAccount.ApplicationUser.UserName,
                               Date = x.DateUtc,
                               NewBalance = x.NewAccountBalance,
                               PreviousBalance = x.PreviousAccountBalance,
                               Id = x.Id,
                               TransactionType = x.TransactionType,
                               BuyedBooks = x.UserBooks.Select(y => new Commons.ViewModels.ClientBook.ClientBookVM
                               {
                                   AuthorName = y.BookOffer.Book.Autor,
                                   BookTitle = y.BookOffer.Book.Title,
                                   Date = y.DateOfPurchase,
                                   Id = y.Id,
                                   Price = y.BookOffer.Price
                               }).ToList()
                           }).FirstOrDefault();
        }

        public IList<TransactionVM> GetTransactions(string clientUsername, string adminUsername)
        {
            return context.Transactions
                .Include(x => x.UserFinancialAccount.ApplicationUser)
                .Include(x => x.Admin)
                .Where(x => string.IsNullOrEmpty(clientUsername) || x.UserFinancialAccount.ApplicationUser.UserName.Contains(clientUsername))
                   .Where(x => string.IsNullOrEmpty(adminUsername) || (x.Admin != null && x.Admin.UserName.Contains(adminUsername)))
                .Select(x => new TransactionVM
                {
                    AdminUsername = x.Admin != null ? x.Admin.UserName : null,
                    Amount = x.Amount,
                    ClientUsername = x.UserFinancialAccount.ApplicationUser.UserName,
                    Date = x.DateUtc,
                    NewBalance = x.NewAccountBalance,
                    PreviousBalance = x.PreviousAccountBalance,
                    Id = x.Id,
                    TransactionType = x.TransactionType,
                    BuyedBooks = x.UserBooks.Select(y => new Commons.ViewModels.ClientBook.ClientBookVM {
                        AuthorName = y.BookOffer.Book.Autor,
                        BookTitle = y.BookOffer.Book.Title,
                        Date = y.DateOfPurchase,
                        Id = y.Id,
                        Price = y.BookOffer.Price
                    }).ToList()
                })
                .ToList();


        }

        public void MakeNewAmountUpdateTransaction(decimal amount, string clientId, string adminId)
        {
            var account = context.UserFinancialAccounts.FirstOrDefault(x => x.UserFinancialAccountId == clientId);
            if (account == null)
                return;

            context.Transactions.Add(new Model.Transaction
            {
                AdminId = adminId,
                UserFinancialAccountId = clientId,
                Amount = amount,
                PreviousAccountBalance = account.Balance,
                NewAccountBalance = account.Balance + amount,
                DateUtc = DateTime.UtcNow,
                TransactionType = TransactionType.PAY_IN
            });
            account.Balance+= amount;
            context.SaveChanges();
        }
    }
}
