using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Auctions
{
    [DataContract]
    public class AuctionCreateVM
    {
        [DataMember]
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        [DataMember]
        public DateTime DateTo { get; set; }
        [Required]
        [DataMember]
        public int BookId { get; set; }
        [Required]
        [DataMember]
        public decimal StartPrice { get; set; }
    }
}
