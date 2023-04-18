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
        /// Molly Meister
        /// Created: 2023/04/03
        /// 
        /// Inserts an adoption application response.
        /// Returns rows affected.
        /// </summary>
        /// <param name="adoptionApplicationResponseVM">the AdoptionApplicationResponseVM object to insert</param>
        /// <exception cref="SQLException">insert fails</exception>
        /// <returns>Rows affected.</returns>
        int InsertAdoptionApplicationResponseByAdoptionApplicationId(AdoptionApplicationResponseVM adoptionApplicationResponseVM);
    }
}
