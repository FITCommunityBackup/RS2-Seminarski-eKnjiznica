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
    public class CreateBookVM
    {
        [DataMember]
        [Required]
        public string BookTitle { get; set; }
        [DataMember]
        [Required]
        public string AuthorName { get; set; }
        [DataMember]
        [Required]
        public string BookDescription { get; set; }
        [DataMember]
        [Required]
        public List<int> CategoriesId{ get; set; }

        [DataMember]
        public DateTime ReleaseDate { get; set; }
    }
}
