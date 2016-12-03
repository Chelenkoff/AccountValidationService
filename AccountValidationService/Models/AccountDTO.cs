using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountValidationService.Models
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        public string Username { get; set; }
    }
}