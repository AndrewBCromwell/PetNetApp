using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class AdoptionApplicationResponse
    {
        public int AdoptionApplicationResponseId { get; set; }
        public int AdoptionApplicationId { get; set; }
        public int ResponderUserId { get; set; }
        public bool Approved { get; set; }
        public DateTime AdoptionApplicationResponseDate { get; set; }
        public string AdoptionApplicationResponseNotes { get; set; }

        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/03/30
        /// 
        /// Returns true if two AdoptionApplicationResponses are equal.
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// <returns>True if all the properties of the two objects are the same.</returns>
        public override bool Equals(object obj)
        {
            try
            {
                AdoptionApplicationResponse response2 = (AdoptionApplicationResponse)obj;

                return (this.AdoptionApplicationResponseId == response2.AdoptionApplicationResponseId) &&
                    (this.AdoptionApplicationId == response2.AdoptionApplicationId) &&
                    (this.ResponderUserId == response2.ResponderUserId) &&
                    (this.Approved == response2.Approved) &&
                    (this.AdoptionApplicationResponseDate.Equals(response2.AdoptionApplicationResponseDate)) &&
                    (this.AdoptionApplicationResponseNotes.Equals(response2.AdoptionApplicationResponseNotes))
                    ;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class AdoptionApplicationResponseVM : AdoptionApplicationResponse
    {
        public int ApplicantId { get; set; }
        public string AdoptionApplicantGivenName { get; set; }
        public string AdoptionApplicantFamilyName { get; set; }

        /*
        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/03/30
        /// 
        /// Returns true if two AdoptionApplicationResponseVMs are equal.
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// <returns>True if all the properties of the two objects are the same.</returns>
        public override bool Equals(object obj)
        {
            try
            {
                AdoptionApplicationResponseVM response2 = (AdoptionApplicationResponseVM)obj;

                return (this.AdoptionApplicationResponseId == response2.AdoptionApplicationResponseId) &&
                    (this.AdoptionApplicationId == response2.AdoptionApplicationId) &&
                    (this.UsersId == response2.UsersId) &&
                    (this.Approved == response2.Approved) &&
                    (this.AdoptionApplicationResponseDate.Equals(response2.AdoptionApplicationResponseDate)) &&
                    (this.AdoptionApplicationResponseNotes.Equals(response2.AdoptionApplicationResponseNotes)) &&
                    (this.ApplicantId == response2.ApplicantId) &&
                    (this.AdoptionApplicantGivenName.Equals(response2.AdoptionApplicantGivenName)) &&
                    (this.AdoptionApplicantFamilyName.Equals(response2.AdoptionApplicantFamilyName))
                    ;
            }
            catch (Exception)
    {
                return false;
            }
        }
        */
        public AdoptionApplication Application { get; set; }
        public Users Responder { get; set; }
    }
}
