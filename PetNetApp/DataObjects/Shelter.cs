using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Shelter
    {
        public int ShelterId { get; set; }
        public string Address { get; set; }
        public string AddressTwo { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Areasofneed { get; set; }
        public bool ShelterActive { get; set; }
    }
}
