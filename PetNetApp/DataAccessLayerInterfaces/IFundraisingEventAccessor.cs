using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IFundraisingEventAccessor
    {
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/05
        /// 
        /// A method to get the fundraising events for the logged in user's shelter id
        /// </summary>
        /// 
        /// <param name="shelterId">ShelterId to select all the Fundraising Events for</param>
        /// <exception cref="SQLException">Load Fails</exception>
        /// <returns>List<FundraisingEvent></returns>
        List<FundraisingEventVM> SelectAllFundraisingEventsByShelterId(int shelterId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/04/06
        /// 
        /// A method to get the fundraising events for the campaign
        /// </summary>
        /// <param name="campaignId">the campaign to get events for</param>
        /// <returns>a list of events for the campaign</returns>
        List<FundraisingEventVM> SelectAllFundraisingEventsByCampaignId(int campaignId);
    }
}
