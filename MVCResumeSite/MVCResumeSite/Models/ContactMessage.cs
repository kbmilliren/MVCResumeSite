using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCResumeSite.Models
{
    public class ContactMessage
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
       
    }
}