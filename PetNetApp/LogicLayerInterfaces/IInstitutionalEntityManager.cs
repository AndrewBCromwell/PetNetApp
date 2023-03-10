using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

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
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/01
        /// 
        /// Retrieves a list of all InstitutionalEntities for by shelterId and entityType
        /// </summary>
        ///
        /// <remarks>
        /// Updater
        /// Updated: 2023/02/24
        /// Added Comment.
        /// </remarks>
        /// <param name="shelterId"/>
        /// <param name="entityType"/>
        /// <exception cref="SQLException">Retrieve fails.</exception>
        /// <returns>List of InstitutionalEntity</returns>
        List<InstitutionalEntity> RetrieveAllInstitutionalEntitiesByShelterIdAndEntityType(int shelterId, string entityType);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/01
        /// 
        /// Retrieves a list of all InstitutionalEntities for a shelter
        /// </summary>
        ///
        /// <remarks>
        /// Updater
        /// Updated: 2023/02/24
        /// Added Comment.
        /// </remarks>
        /// <param name="institutionalEntityId"/>
        /// <exception cref="SQLException">Retrieve fails.</exception>
        /// <returns>Returns an InstitutionalEntity</returns>
        InstitutionalEntity RetrieveInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId);
    }

}
