using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Common.ViewModels.Books
{
    [DataContract]
    public class BookRatingVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public int BookId { get; set; }
    }
}
