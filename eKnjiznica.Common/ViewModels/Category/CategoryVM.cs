using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Category
{
    [DataContract]
    public class CategoryVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int NumberOfBooks { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
