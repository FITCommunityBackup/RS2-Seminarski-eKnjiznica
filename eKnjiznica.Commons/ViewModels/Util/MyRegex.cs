using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.Util
{
   public class MyRegex
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return (match.Success);
        }

        public bool ValidatePassword(string password)
        {
            var input = password;
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");

            return hasLowerChar.IsMatch(input) && hasUpperChar.IsMatch(input) && hasNumber.IsMatch(input);
        }
        public bool IsValidPhone(string phone)
        {
           

            if (string.IsNullOrEmpty(phone))
                return false;
            Regex regex = new Regex(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{3}$");
            Regex regex2 = new Regex(@"^(\+?[0-9]{9,12})$");
            Match match = regex.Match(phone);
            Match match2 = regex2.Match(phone);
            return (match.Success) || match2.Success;
        }
    }
}
