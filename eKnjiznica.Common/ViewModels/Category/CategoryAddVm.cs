using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Category
{
    [DataContract]
    public class CategoryAddVM
    {
        [DataMember]
        [Required]
        public string CategoryName { get; set; }
    }
}
