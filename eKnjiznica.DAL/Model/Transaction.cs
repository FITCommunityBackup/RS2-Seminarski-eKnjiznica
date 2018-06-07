using eKnjiznica.Commons.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
   
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal PreviousAccountBalance { get; set; }
        [Required]
        public decimal NewAccountBalance { get; set; }
        [Required]
        public DateTime DateUtc{ get; set; }
        [Required]
        public TransactionType TransactionType { get; set; }
        #region Navigation

        public string UserFinancialAccountId{ get; set; }
        public UserFinancialAccount UserFinancialAccount { get; set; }

        public virtual ApplicationUser Admin { get; set; }
        public string AdminId { get; internal set; }
        #endregion
    }
}
