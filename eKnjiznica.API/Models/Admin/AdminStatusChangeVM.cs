using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace eKnjiznica.API.Models.Admin
{
    [DataContract]
    public class AdminStatusChangeVM
    {
        [DataMember]
        public string Id { get; set; }
    }
}