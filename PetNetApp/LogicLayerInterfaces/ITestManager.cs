using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface ITestManager
    {
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/23
        /// 
        /// Calls the Accessor method to retrieve all tests for an animal
        /// </summary>
        /// <param name="animalId">The ID of the animal to get tests for</param>
        /// <exception cref="ApplicationException">Thrown if something goes wrong running the stored procedure</exception>
        /// <returns>A list of tests for the animal</returns>
        List<Test> RetrieveTestsByAnimalId(int animalId);

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/10
        /// 
        /// Calls the Accessor method to retrieve the test associated with the specified medical record
        /// </summary>
        /// <param name="medicalRecordId">The ID of the medical record to get test for</param>
        /// <exception cref="ApplicationException">If the retrieval fails</exception>
        /// <returns>A TestVM object for the medical record</returns>
        TestVM RetrieveTestByMedicalRecordId(int medicalRecordId);
    }
}
