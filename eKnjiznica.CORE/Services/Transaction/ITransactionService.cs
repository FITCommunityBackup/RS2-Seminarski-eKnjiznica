using eKnjiznica.Commons.ViewModels.TransactionVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.CORE.Services.Transaction
{
    public interface ITransactionService
    {
        void AddAmount(decimal amount, string clientId, string adminId);
        IList<TransactionVM> GetTransactions(string clientUsername, string adminUsername);
        TransactionVM GetTransaction(int id);
        IList<TransactionVM> GetTransactionsByClientId(string clientId);
    }
}
