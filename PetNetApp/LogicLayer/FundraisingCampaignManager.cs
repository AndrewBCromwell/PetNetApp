using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class FundraisingCampaignManager : IFundraisingCampaignManager
    {
        private IFundraisingCampaignAccessor _fundraisingCampaignAccessor = null;
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// </summary>
        /// <returns>FundraisingCampaignManager</returns>
        public FundraisingCampaignManager()
        {
            _fundraisingCampaignAccessor = new FundraisingCampaignAccessor();
        }

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/20
        /// 
        /// Constructor for fake data and testing
        /// </summary>
        /// <param name="fundraisingCampaignAccessor">The instance of the fake dataaccess object</param>
        /// <returns>FundraisingCampaignManager</returns>
        public FundraisingCampaignManager(IFundraisingCampaignAccessor fundraisingCampaignAccessor)
        {
            _fundraisingCampaignAccessor = fundraisingCampaignAccessor;
        }

        public bool AddFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign)
        {
            bool success = false;
            try
            {
                success = _fundraisingCampaignAccessor.InsertFundraisingCampaign(fundraisingCampaign) != 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add the new FundraisingCampaign", ex);
            }
            return success;
        }

        public bool EditFundraisingCampaign(FundraisingCampaignVM oldFundraisingCampaignVM, FundraisingCampaignVM newFundraisingCampaignVM)
        {
            bool success = false;
            try
            {
                success = _fundraisingCampaignAccessor.UpdateFundraisingCampaign(oldFundraisingCampaignVM, newFundraisingCampaignVM) != 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add the new FundraisingCampaign", ex);
            }
            return success;
        }

        public List<FundraisingCampaignVM> RetrieveAllFundraisingCampaignsByShelterId(int shelterId)
        {
            List<FundraisingCampaignVM> campaigns = null;
            try
            {
                campaigns = _fundraisingCampaignAccessor.SelectAllFundraisingCampaignsByShelterId(shelterId);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Failed to load Campaigns", ex);
            }
            return campaigns;
        }
    }
}
