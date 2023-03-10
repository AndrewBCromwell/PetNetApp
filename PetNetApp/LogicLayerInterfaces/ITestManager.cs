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
        /// Nathan Zumsande
        /// Created: 2023/02/09
        /// 
        /// Creates a new Test
        /// </summary>
        /// 
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="test"></param>
        /// <param name="medicalRecordId"></param>
        /// <returns>True or false if row was edited</returns>
        bool AddTestByMedicalRecordId(Test test, int medicalRecordId);
    }
}
