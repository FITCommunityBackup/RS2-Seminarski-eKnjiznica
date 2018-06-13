using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Common.ViewModels.Auctions
{
    public class AuctionUpdateVM
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo{ get; set; }
        public int BookId{ get; set; }
        public decimal StartPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
