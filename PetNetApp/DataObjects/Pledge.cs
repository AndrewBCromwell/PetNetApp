///<summary>
/// William Rients
/// Created: 2023/04/07
/// 
/// </summary>
/// <remarks>
/// Oleksiy Fedchuk
/// Updated: 2023/04/20
/// Final QA
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Pledge
    {
        public int PledgeId { get; set; }
        public DateTime Date { get; set; }
        public int DonationId { get; set; }
        public decimal Amount { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public string Requirement { get; set; }
        public bool RequirementMet { get; set; }
        public int UserId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsContactPreferencePhone { get; set; }
        public int FundraisingEventId { get; set; }
        public bool ReminderSent { get; set; }
        public DateTime ReminderDate { get; set; }
    }

    public class PledgeVM : Pledge
    {
        public decimal DonationAmount { get; set; }
        public DateTime? DonationDate { get; set; }
    }
}
