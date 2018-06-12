using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class UserBook
    {
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
     
        
        #region Navigation
        public int BookOfferId { get; set; }
        public BookOffer BookOffer { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        #endregion

    }
}
