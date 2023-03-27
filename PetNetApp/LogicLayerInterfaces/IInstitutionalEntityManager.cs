/// <summary>
/// Barry Mikulas
/// Created: 2023/03/01
/// 
/// Contains interfaces for Instutional Entity functions
/// </summary>
///
/// <remarks>
/// Updater
/// Updated: 
/// Comment:
/// </remarks>
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
        /// Barry Mikulas
        /// Created: 2023/03/01
        /// 
        /// Retrieves a list of all InstitutionalEntities for by shelterId and contactType
        /// </summary>
        ///
        /// <remarks>
        /// Updater
        /// Updated: 2023/02/24
        /// Added Comment.
        /// </remarks>
        /// <param name="shelterId"/>
        /// <param name="contactType"/>
        /// <exception cref="SQLException">Retrieve fails.</exception>
        /// <returns>List of InstitutionalEntity</returns>
        List<InstitutionalEntity> RetrieveAllInstitutionalEntitiesByShelterIdAndContactType(int shelterId, string contactType);

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