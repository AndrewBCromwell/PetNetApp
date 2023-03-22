using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class DonationManager : IDonationManager
    {
        private IDonationAccessor donationAccessor = null;
        public DonationManager()
        {
            donationAccessor = new DonationAccessor();
        }
        public DonationManager(IDonationAccessor da)
        {
            donationAccessor = da;
        }

        public List<DonationVM> RetrieveAllDonations()
        {
            try
            {
                return donationAccessor.SelectAllDonations();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve donations", ex);
            }
        }

        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023/03/02
        /// Description: Retrieves donations by ShelterId
        /// </summary>
        /// <param name="ShelterId"></param>
        /// <returns></returns>
        public List<DonationVM> RetrieveDonationsByShelterId(int ShelterId)
        {
            try
            {
                return donationAccessor.SelectDonationsByShelterId(ShelterId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve donations", ex);
            }
        }

        public List<InKind> RetrieveInKindsByDonationId(int donationId)
        {
            try
            {
                return donationAccessor.SelectInKindsByDonationId(donationId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve in-kind donations", ex);
            }
        }
    }
}
