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
    public class UpdateBookVM
    {
        [DataMember]
        public string BookTitle { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public string BookDescription { get; set; }
        [DataMember]
        [Required]
        public List<int> CategoriesId { get; set; }

        [DataMember]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [DataMember]
        [Required]
        public bool IsActive { get; set; }
    }
}
