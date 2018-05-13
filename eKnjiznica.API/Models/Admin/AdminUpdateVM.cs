using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace eKnjiznica.API.Models.Admin
{
    [DataContract]
    public class AdminUpdateVM
    {
        [DataMember]
        [Required]
        public string Id { get; set; }
        [DataMember]
        public string FirstName{ get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
}