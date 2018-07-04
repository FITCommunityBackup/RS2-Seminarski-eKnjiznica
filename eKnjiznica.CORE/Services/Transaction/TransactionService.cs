using eKnjiznica.Commons.ViewModels.TransactionVM;
using eKnjiznica.CORE.Repository;
using eKnjiznica.CORE.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private ITransactionsRepo transactionsRepo;
        private ILoggerService loggerService;
        public TransactionService(ITransactionsRepo transactionsRepo,ILoggerService loggerService)
        {
            this.loggerService = loggerService;
            this.transactionsRepo = transactionsRepo;
        }

        public void AddAmount(decimal amount, string clientId, string adminId)
        {
            loggerService.LogAdminAction(adminId, LogType.UPDATE, $"FinancialAccountUpdate - {clientId} - {amount}KM");
            transactionsRepo.MakeNewAmountUpdateTransaction(amount, clientId, adminId);
        }

        public TransactionVM GetTransaction(int id)
        {
            return transactionsRepo.GetTransaction(id);

        }

        public IList<TransactionVM> GetTransactions(string clientUsername, string adminUsername)
        {
            return transactionsRepo.GetTransactions(clientUsername,adminUsername);
        }

        public IList<TransactionVM> GetTransactionsByClientId(string clientId)
        {
            return transactionsRepo.GetTransactionsByClientId(clientId);

        }
    }
}
