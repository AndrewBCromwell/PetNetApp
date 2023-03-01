using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface ITestAccessor
    {
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Gets a list of tests for the specified animal
        /// </summary>
        /// <param name="animalId">The animals ID to get tests for</param>
        /// <returns>Returns a list of tests</returns>
        List<Test> SelectTestsByAnimalId(int animalId);
    }
}
