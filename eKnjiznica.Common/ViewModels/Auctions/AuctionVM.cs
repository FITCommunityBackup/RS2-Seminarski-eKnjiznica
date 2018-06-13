using System;
using System.Runtime.Serialization;

namespace eKnjiznica.Commons.ViewModels.Auctions
{
    [DataContract]
    public class AuctionVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public decimal CurrentPrice { get; set; }
        [DataMember]
        public decimal StartPrice { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string BookTitle { get; set; }
        [DataMember]
        public string AuthorName { get; set; }

        [DataMember]
        public string WinnerBidderUsername { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
