using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Donation
    {
        public int DonationId { get; set; }
        public int? UserId { get; set; }
        public int ShelterId { get; set; }
        public decimal? Amount { get; set; }
        public string Message { get; set; }
        public DateTime? DateDonated { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public bool HasInKindDonation { get; set; }
        public bool Anonymous { get; set; }
        public string Target { get; set; }
        public string PaymentMethod { get; set; }
        public int? ScheduledDonationId { get; set; }
        public int? FundraisingEventId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class DonationVM : Donation
    {
        public List<InKind> InKindList { get; set; }
        public Users User { get; set; }
        public string ShelterName { get; set; }
    }
}
