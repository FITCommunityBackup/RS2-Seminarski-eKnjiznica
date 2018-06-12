using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class AuctionBid
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        #region Navigation
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        #endregion
    }
}
