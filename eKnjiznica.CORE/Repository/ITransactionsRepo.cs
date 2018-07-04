using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.TransactionVM;

namespace eKnjiznica.CORE.Repository
{
    public interface ITransactionsRepo
    {
        void MakeNewAmountUpdateTransaction(decimal amount, string clientId, string adminId);
        IList<TransactionVM> GetTransactions(string clientUsername, string adminUsername);
        TransactionVM GetTransaction(int id);
        IList<TransactionVM> GetTransactionsByClientId(string clientId);
    }
}
