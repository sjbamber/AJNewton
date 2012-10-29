using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AJNewton.Models.Validators;

namespace AJNewton.Models
{ 
    public class ContactModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        [Email(ErrorMessage="The email entered is not valid")]
        public string email { get; set; }
        [Telephone(ErrorMessage = "The phone number entered is not valid")]
        public string phone { get; set; }
        [Required]
        public string message { get; set; }
    }
}