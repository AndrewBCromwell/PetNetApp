using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IAdoptionApplicationAccessor
    {
        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/19
        /// 
        /// Inserts an adoption application.
        /// Returns rows affected.
        /// </summary>
        /// <param name="adoptionApplication">the AdoptionApplication object to insert</param>
        /// <exception cref="SQLException">insert fails</exception>
        /// <returns>Rows affected.</returns>
        int InsertAdoptionApplication(AdoptionApplicationVM adoptionApplication);

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/19
        /// 
        /// Retrieves all home types.
        /// Returns a list of strings that represent the home types.
        /// </summary>
        /// 
        /// <exception cref="SQLException">retrieval fails</exception>
        /// <returns>List<string></string></returns>
        List<string> SelectAllHomeTypes();

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/19
        /// 
        /// Retrieves all home ownership types.
        /// Returns a list of strings that represent the home ownership types.
        /// </summary>
        /// 
        /// <exception cref="SQLException">retrieval fails</exception>
        /// <returns>List<string></string></returns>
        List<string> SelectAllHomeOwnershipTypes();
    }
}
