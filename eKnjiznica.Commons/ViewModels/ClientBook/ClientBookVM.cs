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
        public string ClientName{ get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int TransactionId { get; set; }
    }
}
