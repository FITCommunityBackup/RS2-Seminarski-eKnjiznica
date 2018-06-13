using eKnjiznica.Commons.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Books
{
    [DataContract]
    public class BookOfferVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public IList<CategoryVM> Categories { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public DateTime OfferCreatedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
