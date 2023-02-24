﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IKennelAccessor
    {
        List<KennelVM> SelectKennels(int ShelterId);
        List<string> SelectAnimalTypes();
        int InsertKennel(Kennel kennel);
        int UpdateKennelStatusByKennelId(int KennelId);
        int DeleteAnimalKennelingByKennelId(int KennelId);

        /// <summary>
        /// William Rients
        /// Created: 2023/02/10
        /// 
        /// Selects a specific kennel with an AnimalId
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="AnimalId">int for the the specific kennel</param>
        /// <exception cref="Exception">No kennel is retrived witht that AnimalId</exception>
        /// <returns>Kennel Object</returns>
        Kennel SelectKennelIdByAnimalId(int AnimalId);

        /// <summary>
        /// William Rients
        /// Created: 2023/02/10
        /// 
        /// Inserts an animal into a specific kennel
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="KennelId">int for the the specific kennel</param>
        /// /// <param name="AnimalId">int for the the specific animal</param>
        /// <exception cref="Exception">Failed to insert animal into kennel</exception>
        /// <returns>Rows affected</returns>
        int InsertAnimalIntoKennelByAnimalId(int KennelId, int AnimalId);

        /// <summary>
        /// William Rients
        /// Created: 2023/02/10
        /// 
        /// Gets a list of animals available to 
        /// be assigned to a kennel
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="ShelterId">int for the the specific shelter</param>
        /// /// <param name="AnimalTypeId">string for the the specific type of animal</param>
        /// <exception cref="Exception">Failed to retrived a list of animals</exception>
        /// <returns>List of animals</returns>
        List<Animal> SelectAllAnimalsForKennel(int ShelterId, string AnimalTypeId);
        int DeleteAnimalKennelingByKennelIdAndAnimalId(int kennelId, int animalId);
    }
}
