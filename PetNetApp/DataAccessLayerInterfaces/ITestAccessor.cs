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

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/10
        /// 
        /// Gets the test for a specified medical record
        /// </summary>
        /// <param name="medicalRecordId">The medical record ID to get the test for</param>
        /// <returns>A TestVM object</returns>
        TestVM SelectTestByMedicalRecordId(int medicalRecordId);
    }
}
