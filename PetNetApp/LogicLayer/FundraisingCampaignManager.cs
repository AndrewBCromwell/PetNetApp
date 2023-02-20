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
        public FundraisingCampaignManager()
        {
            _fundraisingCampaignAccessor = new FundraisingCampaignAccessor();
        }
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
            catch(ApplicationException ex)
            {
                throw new ApplicationException("Failed to load Campaigns", ex);
            }
            return campaigns;
        }
    }
}
