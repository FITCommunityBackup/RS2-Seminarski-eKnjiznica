using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eKnjiznica.Commons.ViewModels.Error
{
    [DataContract]
    public class BaseErrorVM
    {

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Dictionary<string,List<string>> ModelState { get; set; }

    }
}
