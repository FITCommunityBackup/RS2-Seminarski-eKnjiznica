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
    public class CategoryUpdateVm
    {
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public bool? IsActive{ get; set; }
    }
}
