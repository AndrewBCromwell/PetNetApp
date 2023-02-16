using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataObjects
{
    public static class ValidationHelpers
    {
        private static Regex _zipcodeRegex = new Regex(@"^\d{9}$");
        private static Regex _phoneRegex = new Regex(@"^\d{10,13}$");
        private static Regex _amountRegex = new Regex(@"^(([1-9]\d{0,4})|0)(\.\d{1,2})?$");
        private static Regex _emailRegex = new Regex(@"^(?=^.{1,64}@)[a-zA-Z0-9]+([-_\.]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(-?[a-zA-Z0-9]+)*\.[a-zA-Z0-9]{2,}([-\.]?[a-zA-Z0-9]{2,})*$");
        public static bool IsValidName(this string name)
        {
            return name != "" && name != null && name.Length <= 50;
        }
        public static bool IsValidShortDescription(this string description)
        {
            return description != "" && description != null && description.Length <= 250;
        }
        public static bool IsValidLongDescription(this string description)
        {
            return description != "" && description != null && description.Length <= 500;
        }

        public static bool IsValidAddress(this string address)
        {
            return address != "" && address != null && address.Length <= 50;
        }

        public static bool IsValidAddress2(this string address2)
        {
            return address2 == null || address2.Length < 50;
        }
        public static bool IsValidZipcode(this string zipcode)
        {
            return _zipcodeRegex.IsMatch(zipcode);
        }
        public static bool IsValidEmail(this string email)
        {
            return _emailRegex.IsMatch(email) && email.Length <= 254;
        }
        public static bool IsValidPhone(this string phone)
        {
            return _phoneRegex.IsMatch(phone);
        }
        public static bool IsValidAmount(this string amount)
        {
            return _amountRegex.IsMatch(amount);
        }
    }
}
