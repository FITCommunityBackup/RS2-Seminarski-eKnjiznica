using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Books
{
    [DataContract]
    public class CreateBookOfferVM
    {
        [Required]
        [DataMember]
        public int BookId { get; set; }
        [Required]
        [DataMember]
        public decimal Price { get; set; }
    }
}
