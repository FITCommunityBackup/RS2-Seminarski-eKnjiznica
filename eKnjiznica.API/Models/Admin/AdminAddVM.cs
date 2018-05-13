using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace eKnjiznica.API.Models.Admin
{
    [DataContract]
    public class AdminAddVM
    {
        [DataMember]
        [Required]
        public string Username { get; set; }
        [DataMember]
        [Required]
        public string Password { get; set; }
        [DataMember]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataMember]
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [DataMember]
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [DataMember]
        [Required]
        public string PhoneNumber { get; set; }
    }
}