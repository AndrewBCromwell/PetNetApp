using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IInstitutionalEntityAccessor
    {
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/05
        /// 
        /// Gets a list of all the institutional entities that are sponsors for the fundraising campaign
        /// </summary>
        /// <param name="fundraisingCampaignId">Id of the campaign</param>
        /// <returns></returns>
        List<InstitutionalEntity> SelectFundraisingSponsorsByCampaignId(int fundraisingCampaignId);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/03/05
        /// 
        /// Gets a list of all the institutional entities that are sponsors
        /// </summary>
        /// <returns></returns>
        List<InstitutionalEntity> SelectAllSponsors();
        List<InstitutionalEntity> SelectAllHosts();
        List<InstitutionalEntity> SelectAllContact();
        InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId);
    }
}
