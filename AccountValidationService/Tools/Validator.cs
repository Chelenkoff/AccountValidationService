using AccountValidationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace AccountValidationService.Tools
{
    public class Validator
    {
       


        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool isValidUsername(string username)
        {
            //            (?=.{ 3,15}$)                          Must be 3 - 15 characters in the string
            //            ([A - Za - z0 - 9][._()\[\] -]?)*      The string is a sequence of alphanumerics,
            //                                                   each of which may be followed by a symbol


            if (String.IsNullOrEmpty(username) || username.Equals("undefined")) return false;

            string pattern = @"^(?=.{3,15}$)([A-Za-z0-9][._()\[\]-]?)*$";
            Match result = Regex.Match(username, pattern);

            if (result.Success)
            {
                return true;
            }

            return false;
        }

        public static bool isValidIban(string iban)
        {

            if (String.IsNullOrEmpty(iban) || iban.Equals("undefined"))
            { return false; }

            if (iban.Length < 5) return false;
               

            iban = iban.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW

            if (System.Text.RegularExpressions.Regex.IsMatch(iban, "^[A-Z0-9]"))
            {
                iban = iban.Replace(" ", String.Empty);
                string bank =
                iban.Substring(4, iban.Length - 4) + iban.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
                return false;
        }


    }
}