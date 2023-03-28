using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IAdoptionApplicationManager
    {
        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/19
        /// 
        /// Passes an adoptionApplication to the AdoptionApplicationAccessor to add an adoption application into the database.
        /// Returns a bool if the insert passes or fails
        /// </summary>
        /// <param name="adoptionApplication">the animalId of the animal retrieving medical records for</param>
        /// <exception cref="ApplicationException">Add Fails</exception>
        /// <returns>Bool</returns>
        bool AddAdoptionApplication(AdoptionApplicationVM adoptionApplication);

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/19
        /// 
        /// Calls the Accessor method to retrieve all home types.
        /// </summary>
        /// <exception cref="ApplicationException">If the retrieval fails</exception>
        /// <returns>List</returns>
        List<string> RetrieveAllHomeTypes();

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/19
        /// 
        /// Calls the Accessor method to retrieve all home ownership types.
        /// </summary>
        /// <exception cref="ApplicationException">If the retrieval fails</exception>
        /// <returns>List</returns>
        List<string> RetrieveAllHomeOwnershipTypes();
    }
}
