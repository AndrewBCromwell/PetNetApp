/// <summary>
/// Asa Armstrong
/// Created: 2023/03/30
/// 
/// Adoption Application Response Accessor class to CRUD Adoption Application Response objects.
/// </summary>
///
/// <remarks>
/// Asa Armstrong
/// Updated: 2023/03/30
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IAdoptionApplicationResponseAccessor
    {
        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/03/23
        /// 
        /// Inserts a Adoption Application Response record.
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// <param name="AdoptionApplicationResponse">AdoptionApplicationResponse</param>
        /// <exception cref="SQLException">Insert fails.</exception>
        /// <returns>Rows edited</returns>
        int InsertAdoptionApplicationResponse(AdoptionApplicationResponse adoptionApplicationResponse);

        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/03/23
        /// 
        /// Updates a Adoption Application Response record.
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// <param name="newAdoptionApplicationResponse">The new AdoptionApplicationResponse record to replace the old record</param>
        /// <param name="oldAdoptionApplicationResponse">The old AdoptionApplicationResponse record</param>
        /// <exception cref="SQLException">Update fails.</exception>
        /// <returns>Rows edited</returns>
        int UpdateAdoptionApplicationResponse(AdoptionApplicationResponse newAdoptionApplicationResponse, AdoptionApplicationResponse oldAdoptionApplicationResponse);

        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/03/23
        /// 
        /// Selects a Adoption Application Response record.
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// <param name="adoptionApplicationId">int AdoptionApplicationId</param>
        /// <exception cref="SQLException">Select fails.</exception>
        /// <returns>AdoptionApplicationResponseVM</returns>
        AdoptionApplicationResponseVM SelectAdoptionApplicationResponseByAdoptionApplicationId(int adoptionApplicationId);
    }
}
