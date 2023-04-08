using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IFundraisingEventManager
    {
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/05
        /// 
        /// A method to get the fundraising events for this shelter
        /// </summary>
        /// 
        /// <param name="shelterId">The shelter Id of the logged in user to retrieve all the events for</param>
        /// <exception cref="SQLException">Load Fails</exception>
        /// <returns>List<FundraisingEvent></FundraisingEvent></returns>
        List<FundraisingEventVM> RetrieveAllFundraisingEventsByShelterId(int shelterId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/04/06
        /// 
        /// A method to get the fundraising events for the campaign
        /// </summary>
        /// <param name="campaignId">the campaign to get events for</param>
        /// <returns>List of Fundraising Events for the campaign</returns>
        List<FundraisingEventVM> RetrieveAllFundraisingEventsByCampaignId(int campaignId);
    }
}
