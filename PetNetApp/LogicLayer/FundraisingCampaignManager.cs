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
        public List<FundraisingCampaign> RetrieveAllFundraisingCampaignsByShelterId(int shelterId)
        {
            List<FundraisingCampaign> campaigns = null;
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
