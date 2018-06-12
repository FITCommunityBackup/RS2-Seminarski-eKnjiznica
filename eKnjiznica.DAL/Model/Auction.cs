using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class Auction
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }


        #region Navigation
        public int BookId { get; set; }
        public Book Book { get; set; }

        public ICollection<AuctionBid> AuctionBids{ get; set; }
        #endregion
    }
}
