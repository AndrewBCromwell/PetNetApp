using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Users
    {
        public int UsersId { get; set; }
        public string GenderId { get; set; }
        public string PronoundId { get; set; }
        public int ShelterId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string AddressTwo { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public bool Suspended { get; set; }
    }
}
