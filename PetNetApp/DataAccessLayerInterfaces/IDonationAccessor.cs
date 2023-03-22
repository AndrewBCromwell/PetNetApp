using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    /// <summary>
    /// Author: Gwen Arman
    /// Date: 2023/03/02
    /// Description: Selects all of the donations by ShelterId
    /// </summary>
    /// <param name="ShelterId"></param>
    /// <returns></returns>
    public interface IDonationAccessor
    {
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023/03/01
        /// Description: Selects donations by a shelter id
        /// </summary>
        /// <param name="ShelterId"></param>
        /// <returns></returns>
        List<DonationVM> SelectDonationsByShelterId(int ShelterId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023/03/21
        /// Description: Selects all donations
        /// </summary>
        /// <returns></returns>
        List<DonationVM> SelectAllDonations();
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023/03/08
        /// Description: Selects all inkinds by donation id
        /// </summary>
        /// <param name="donationId"></param>
        /// <returns></returns>
        List<InKind> SelectInKindsByDonationId(int donationId);
    }
}
