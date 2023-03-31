using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IFundraisingCampaignManager
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
        List<FundraisingCampaignVM> RetrieveAllFundraisingCampaignsByShelterId(int shelterId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/02
        /// 
        /// A method to create a new fundraising campaign for this shelter
        /// </summary>
        /// <param name="fundraisingCampaign"></param>
        /// <returns>Whether the operation was successful</returns>
        bool AddFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/02
        /// 
        /// A method to change the data for a fundraising campaign
        /// </summary>
        /// <param name="oldFundraisingCampaignVM"></param>
        /// <param name="newFundraisingCampaignVM"></param>
        /// <returns></returns>
        bool EditFundraisingCampaignDetails(FundraisingCampaignVM oldFundraisingCampaignVM, FundraisingCampaignVM newFundraisingCampaignVM);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/04
        /// 
        /// Calls the Accessor method to retrieve a fundraising campaign and rewraps exceptions
        /// </summary>
        /// <param name="fundraisingCampaignId"></param>
        /// <returns></returns>
        FundraisingCampaignVM RetrieveFundraisingCampaignByFundraisingCampaignId(int fundraisingCampaignId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/07
        /// 
        /// Calls the Accessor method to remove the fundraising campaign
        /// </summary>
        /// <param name="fundraisingCampaign">Fundraising Campaign to remove</param>
        /// <returns>Whether the record was successfully removed</returns>
        bool RemoveFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign);

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/03/23
        /// 
        /// A method to create a new fundraising campaign update
        /// </summary>
        /// <param name="campaignUpdate">The campaign update record</param>
        /// <returns>Bool indicating success</returns>
        bool AddCampaignUpdate(CampaignUpdate campaignUpdate);

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/03/23
        /// 
        /// A method to update the fundraising campaign results
        /// </summary>
        /// <param name="oldFundraisingCampaignVM">The original campaign record</param>
        /// <param name="newFundraisingCampaignVM">The new campaign record</param>
        /// <returns>Bool indicating success</returns>
        bool EditFundraisingCampaignResults(FundraisingCampaignVM oldFundraisingCampaignVM,
            FundraisingCampaignVM newFundraisingCampaignVM);
    }
}
