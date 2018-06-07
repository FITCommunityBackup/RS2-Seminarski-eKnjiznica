using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.TransactionVM
{
    [DataContract]
    public class TransactionVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public TransactionType TransactionType { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public decimal PreviousBalance { get; set; }
        [DataMember]
        public decimal NewBalance { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string ClientUsername{ get; set; }
        [DataMember]
        public string AdminUsername { get; set; }

    }
}
