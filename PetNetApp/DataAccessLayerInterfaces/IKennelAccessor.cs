using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IKennelAccessor
    {
        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods retrieves kennels from the database with the associated shelter id
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="ShelterId">A description of the parameter that this method takes</param>
        /// <exception cref="SQLException"></exception>
        /// <returns>List<KennelVM></returns>
        List<KennelVM> SelectKennels(int ShelterId);

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods selects animal types from the database
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <exception cref="SQLException"></exception>
        /// <returns>List<KennelVM></returns>
        List<string> SelectAnimalTypes();

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods inserts a kennel
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="kennel">A description of the parameter that this method takes</param>
        /// <exception cref="SQLException"></exception>
        /// <returns>List<KennelVM></returns>
        int InsertKennel(Kennel kennel);

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods updates kennel status from the database with the associated kennel id
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="KennelId">A description of the parameter that this method takes</param>
        /// <exception cref="SQLException"></exception>
        /// <returns>List<KennelVM></returns>
        int UpdateKennelStatusByKennelId(int KennelId);

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods delete animalkennel from the database with the associated kennel id
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="KennelId">A description of the parameter that this method takes</param>
        /// <exception cref="SQLException"></exception>
        /// <returns>List<KennelVM></returns>
        int DeleteAnimalKennelingByKennelId(int KennelId);
        Kennel SelectKennelIdByAnimalId(int AnimalId);
        int InsertAnimalIntoKennelByAnimalId(int KennelId, int AnimalId);
        List<Animal> SelectAllAnimalsForKennel(int ShelterId);
        int DeleteAnimalKennelingByKennelIdAndAnimalId(int kennelId, int animalId);
    }
}
