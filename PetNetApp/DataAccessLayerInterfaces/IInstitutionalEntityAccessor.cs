/// <summary>
/// Asa Armstrong
/// Created: 2023/03/01
/// 
/// Data Accessor class to CRUD Institutional Entity objects.
/// </summary>
///
/// <remarks>
/// Asa Armstrong
/// Updated: 2023/03/01
/// Created
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IInstitutionalEntityAccessor
    {
        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/03/01
        /// 
        /// Selects all Institutional Entities for a shelter.
        /// </summary>
        ///
        /// <remarks>
        /// Asa Armstrong
        /// Updated: 2023/03/01
        /// Created
        /// </remarks>
        /// <param name="shelterId">int</param>
        /// <param name="entityType">type of entity to select</param>
        /// <exception cref="SQLException">Select fails.</exception>
        /// <returns>List<InstitutionalEntity></returns>
        List<InstitutionalEntity> SelectAllInstitutionalEntitiesByShelterIdAndEntityType(int shelterId, string entityType);

        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/03/01
        /// 
        /// Selects an Institutional Entity by its Id.
        /// </summary>
        ///
        /// <remarks>
        /// Asa Armstrong
        /// Updated: 2023/03/01
        /// Created
        /// </remarks>
        /// <param name="InstitutionalEntityId">int</param>
        /// <exception cref="SQLException">Select fails.</exception>
        /// <returns>InstitutionalEntityId</returns>
        InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId);
    }
}