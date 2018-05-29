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
    public class BooksVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public List<CategoryVM> Categories{ get; set; }
        [DataMember]
        public string BookTitle { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime ReleaseDate { get; set; }

        [DataMember]
        public string FileLocation { get; set; }

        [DataMember]
        public string FileName{ get; set; }



    }
}
