using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IInstitutionalEntityManager
    {
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/04
        /// 
        /// Uses the Accessor method to retrieve Sponsors for the campaign and rewraps exceptions
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        List<InstitutionalEntity> RetrieveFundraisingSponsorsByCampaignId(int campaignId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/05
        /// 
        /// Uses the Accessor method to retrieve all Institutional entities that are sponsors
        /// </summary>
        /// <returns></returns>
        List<InstitutionalEntity> RetrieveAllSponsors();
    }
}
