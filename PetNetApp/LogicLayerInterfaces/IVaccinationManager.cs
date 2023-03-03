/// <summary>
/// Zaid Rachman
/// Created: 2023/02/09
/// 
/// Logic layer interface for the VaccinationManager
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IVaccinationManager
    {


        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/02/09
        /// 
        /// Inserts a new Vaccination. Takes in an animalId and a Vaccination object as parameters.
        /// </summary>
        /// 
        ///  <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// 
        /// <param name="vaccine"></param>
        /// <param name="animalId"></param>
        /// <returns></returns>
        bool AddVaccination(Vaccination vaccine, int animalId);
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/02/09
        /// 
        /// Retrieves a list of vaccination by Animal Id. Takes in an animal Id as a parameter
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// 
        /// 
        /// 
        /// <param name="animalId"></param>
        /// <returns></returns>
        List<Vaccination> RetrieveVaccinationsByAnimalId(int animalId);
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/02/09
        /// 
        /// Updates Vaccination record. Takes in the oldVaccine and new Vaccine objects as parameters
        /// 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// 
        /// <param name="oldVaccine"></param>
        /// <param name="newVaccine"></param>
        /// <returns></returns>
        bool EditVaccination(Vaccination oldVaccine, Vaccination newVaccine);
    }
}
