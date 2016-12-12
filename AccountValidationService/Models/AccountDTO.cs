using AccountValidationService.Tools;
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

        public AccountDTO(string username, string email, string iban)
        {
            Username = username;
            Email = email;
            Iban = iban;
        }

     

        public void ValidateAccount()
        {
            if(!isAccountValid())
            {
                this.Id = -1;

                if (!Validator.isValidUsername(this.Username))
                {
                    this.Username = String.Format("{0} - Invalid username format!", this.Username);
                }
                else  this.Username = "";

                if (!Validator.IsValidEmail(this.Email))
                {
                    this.Email = String.Format("{0} - Invalid email format!", this.Email);
                }
                else this.Email = "";
                if (!Validator.isValidIban(this.Iban))
                {
                    this.Iban = (String.Format("{0} - Invalid Iban format!", this.Iban));
                }
                else this.Iban = "";

            }
        }

        private bool isAccountValid()
        {
            bool isValid = true;
            if (!Validator.isValidUsername(this.Username))
            {
                isValid = false;
            }
            if (!Validator.IsValidEmail(this.Email))
            {
                isValid = false;
            }
            if (!Validator.isValidIban(this.Iban))
            {
                isValid = false;
            }
            return isValid;
        }



        public AccountDTO()
        {}
    }
}