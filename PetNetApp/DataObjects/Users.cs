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
        public string PronounId { get; set; }
        public int ? ShelterId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AddressTwo { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public bool SuspendEmployee { get; set; }
    }

    public class UsersVM : Users
    {
        public List<string> Roles {get;set;}
        public List<ScheduleVM> Schedule { get; set; }
    }
}
