using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public int UserId { get; set; }
        public string ApplicantGivenName { get; set; }
        public string ApplicantFamilyName { get; set; }
        public string ApplicantAddress { get; set; }
        public string ApplicantAddress2 { get; set; }
        public string ApplicantZipCode { get; set; }
        public string ApplicantPhoneNumber { get; set; }
        public string ApplicantEmail { get; set; }
        public string HomeTypeId { get; set; }
        public string HomeOwnershipId { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfPets { get; set; }
        public bool CurrentlyAcceptingAnimals { get; set; }

    }
}
