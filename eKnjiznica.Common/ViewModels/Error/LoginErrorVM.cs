using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Error
{
    [DataContract]
    public class LoginErrorVM
    {
        [DataMember(Name ="error")]
        public string Error { get; set; }
        [DataMember(Name = "error_description")]
        public string ErrorDescription { get; set; }
    }
}
