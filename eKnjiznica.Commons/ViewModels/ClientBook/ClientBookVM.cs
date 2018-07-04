using eKnjiznica.Commons.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.ClientBook
{
    [DataContract]
    public class ClientBookVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BookTitle { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string BookDescription { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public DateTime BuyDate { get; set; }
        [DataMember]
        public DateTime BookReleaseDate { get; set; }
        [DataMember]
        public List<CategoryVM> Categories{ get; set; }
        [DataMember]
        public string ImageUrl{ get; set; }
        [DataMember]
        public int TransactionId { get; set; }
        [DataMember]
        public int OfferId { get; set; }

        [IgnoreDataMember]
        public Uri ImageUri { get; set; }
    }
}
