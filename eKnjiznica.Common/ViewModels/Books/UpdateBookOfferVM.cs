using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Books
{
   [DataContract]
    public class UpdateBookOfferVM
    {
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
