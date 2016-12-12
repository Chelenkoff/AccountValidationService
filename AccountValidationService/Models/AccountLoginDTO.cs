using AccountValidationService.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountValidationService.Models
{
    public class AccountLoginDTO
    {


        public bool IsInputValid { get; set; }
        public bool DoesAccountExist { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        public List<String> ErrorMessages { get; set; }


        public AccountLoginDTO(string email, string username, string iban)
        {
            this.Email = email;
            this.Username = username;
            this.Iban = iban;

            ErrorMessages = new List<string>();
        }

        public AccountLoginDTO()
        {
            ErrorMessages = new List<string>();
        }

        public void ValidateInputAccount()
        {
            if (isInputAccountValid() == false)
            {
                DoesAccountExist = false;
                Id = 0;

                if (!Validator.isValidUsername(this.Username))
                {
                    ErrorMessages.Add("Invalid Username format! - Must be 3 - 15 characters  sequence of alphanumerics, each of which may be followed by a symbol");

                }

                if (!Validator.IsValidEmail(this.Email))
                {
                    ErrorMessages.Add( "Invalid Email format! - Example of a valid format: test@abv.bg");
                }

                if (!Validator.isValidIban(this.Iban))
                {
                    ErrorMessages.Add("Invalid Iban format! - Example of a valid format: BG80BNBG96611020345678");
                }

                Username = null;
                Email = null;
                Iban = null;

            }
        }

        private bool isInputAccountValid()
        {
            IsInputValid = true;
            if (!Validator.isValidUsername(this.Username)
                || !Validator.IsValidEmail(this.Email)
                || !Validator.isValidIban(this.Iban))
            {
                IsInputValid = false;
            }

            return IsInputValid;
        }
    }
}