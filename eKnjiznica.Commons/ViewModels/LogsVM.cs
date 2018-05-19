using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels
{
    [DataContract]
   public class LogsVM
    {
        [DataMember]
        public string AdminId { get; set; }
        [DataMember]
        public string AdminUsername { get; set; }
        [DataMember]
        public DateTime Date{ get; set; }
        [DataMember]
        public string ActionType { get; set; }
        [DataMember]
        public string ActionDescription { get; set; }
    }
}
