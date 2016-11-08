using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountValidationService.Models
{
    public class Account
    {
        public int accountId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Iban { get; set; }
        [Required]
        public string Username { get; set; }
    }
}