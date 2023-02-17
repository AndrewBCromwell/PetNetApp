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
        public static Regex ZipcodeRegex { get; private set; } = new Regex(@"^(\d{5}|\d{9})$");
        public static Regex PhoneRegex { get; private set; } = new Regex(@"^\d{10,13}$");
        public static Regex AmountRegex { get; private set; } = new Regex(@"^(([1-9]\d{0,4})|0)(\.\d{1,2})?$");
        public static Regex EmailRegex { get; private set; } = new Regex(@"^(?=^.{1,64}@)[a-zA-Z0-9]+([-_\.]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(-?[a-zA-Z0-9]+)*\.[a-zA-Z0-9]{2,}([-\.]?[a-zA-Z0-9]{2,})*$");
        public static Regex FirstNameRegex { get; private set; } = new Regex(@"^[a-zA-Z][a-zA-Z0-9\-\. ']*$");
        public static Regex LastNameRegex { get; private set; } = new Regex(@"^[a-zA-Z]([a-zA-Z\.\- '][a-zA-Z0-9\.\- ']*)?$");
        public static bool IsValidLastName(this string name)
        {
            return name != null && name.Length <= 50 && LastNameRegex.IsMatch(name);
        }
        public static bool IsValidFirstName(this string name)
        {
            return name != null && name.Length <= 50 && FirstNameRegex.IsMatch(name);
        }
        public static bool IsValidShortDescription(this string description)
        {
            return description == null || description.Length <= 250;
        }
        public static bool IsValidLongDescription(this string description)
        {
            return description == null || description.Length <= 500;
        }
        public static bool IsValidAddress(this string address)
        {
            return address != "" && address != null && address.Length <= 50;
        }
        public static bool IsValidAddress2(this string address2)
        {
            return address2 == null || address2.Length <= 50;
        }
        public static bool IsValidZipcode(this string zipcode)
        {
            return zipcode != null && ZipcodeRegex.IsMatch(zipcode);
        }
        public static bool IsValidEmail(this string email)
        {
            return email != null && EmailRegex.IsMatch(email) && email.Length <= 254;
        }
        public static bool IsValidPhone(this string phone)
        {
            return phone != null && PhoneRegex.IsMatch(phone);
        }
        public static bool IsValidAmount(this string amount)
        {
            return amount != null && AmountRegex.IsMatch(amount);
        }
    }
}
