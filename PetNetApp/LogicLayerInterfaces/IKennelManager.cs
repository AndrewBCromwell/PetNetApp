using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IKennelManager
    {
        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods rewraps SelectKennels method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="ShelterId">A description of the parameter that this method takes</param>
        /// <exception cref="ApplicationException"></exception>
        /// <returns>List<KennelVM></returns>
        List<KennelVM> RetrieveKennels(int ShelterId);
        Kennel RetrieveKennelIdByAnimalId(int AnimalId);
        bool AddAnimalIntoKennelByAnimalId(int KennelId, int AnimalId);

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods rewraps SelectAnimalTypes method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <exception cref="ApplicationException"></exception>
        /// <returns>List<KennelVM></returns>
        List<Animal> RetrieveAllAnimalsForKennel(int ShelterId, string AnimalTypeId);
        List<string> RetrieveAnimalTypes();

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods rewraps InsertKennel method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="Kennel">A description of the parameter that this method takes</param>
        /// <exception cref="ApplicationException"></exception>
        /// <returns>List<KennelVM></returns>
        bool AddKennel(Kennel kennel);
        bool EditKennelStatusByKennelId(int KennelId);

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods rewraps DeleteAnimalKennelingByKennelId method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="KennelId">A description of the parameter that this method takes</param>
        /// <exception cref="ApplicationException"></exception>
        /// <returns>List<KennelVM></returns>
        bool RemoveAnimalKennlingByKennelId(int KennelId);
        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/02/24
        /// 
        /// Removes the Animal Kenneling record to remove the animal from the kennel.
        /// </summary>
        ///
        /// <remarks>
        /// Asa Armstrong
        /// Updated: 2023/02/24
        /// Added Comment.
        /// </remarks>
        /// <param name="kennelId">kennelId</param>
        /// <param name="animalId">animalId</param>
        /// <exception cref="SQLException">Delete fails.</exception>
        /// <returns>True if the record was removed</returns>
        bool RemoveAnimalKennelingByKennelIdAndAnimalId(int kennelId, int animalId);
    }
}
