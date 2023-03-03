using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IFundraisingCampaignAccessor
    {
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// A method to get the fundraising campaigns for this shelter
        /// </summary>
        /// 
        /// <param name="shelterId">The Shelters Id to get the Fundraising Campaigns for</param>
        /// <exception cref="SQLException">Load Fails</exception>
        /// <returns>List<FundraisingCampaign></FundraisingCampaign></returns>
        List<FundraisingCampaignVM> SelectAllFundraisingCampaignsByShelterId(int shelterId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/02
        /// 
        /// A method to create a new fundraising campaign for this shelter
        /// </summary>
        /// <param name="fundraisingCampaign"></param>
        /// <returns>Total Number of Rows affected</returns>
        int InsertFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign);

        int UpdateFundraisingCampaign(FundraisingCampaignVM oldFundraisingCampaignVM, FundraisingCampaignVM newFundraisingCampaignVM);
    }
}
