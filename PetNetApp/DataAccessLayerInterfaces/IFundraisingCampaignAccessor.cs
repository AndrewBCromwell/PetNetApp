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

        int UpdateFundraisingCampaignDetails(FundraisingCampaignVM oldFundraisingCampaignVM, FundraisingCampaignVM newFundraisingCampaignVM);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/04
        /// 
        /// Loads a Fundraising Campaign VM by its id
        /// </summary>
        /// <param name="fundraisingCampaignId">The Id of the Fundraising Campaign to load</param>
        /// <returns>A Fundraising Campaign VM</returns>
        FundraisingCampaignVM SelectFundraisingCampaignByFundraisingCampaignId(int fundraisingCampaignId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/07
        /// 
        /// Deactivates the record for this fundraising campaign
        /// </summary>
        /// <param name="fundraisingCampaign">Campaign to deactivate</param>
        /// <returns>the number of campaigns deactivated</returns>
        int DeleteFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign);
    }
}
