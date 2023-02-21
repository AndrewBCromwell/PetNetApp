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
        List<FundraisingCampaign> RetrieveAllFundraisingCampaignsByShelterId(int shelterId);
    }
}
