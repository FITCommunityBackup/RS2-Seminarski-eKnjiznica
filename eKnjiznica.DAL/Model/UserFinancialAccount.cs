﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class UserFinancialAccount
    {
        [ForeignKey("ApplicationUser")]
        public string UserFinancialAccountId { get; set; }
        public decimal Balance{ get; set; }


        #region Navigation
        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        #endregion
    }
}
