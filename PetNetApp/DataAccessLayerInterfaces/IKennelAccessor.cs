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
        List<KennelVM> SelectKennels(int ShelterId);
        List<string> SelectAnimalTypes();
        int InsertKennel(Kennel kennel);
        int UpdateKennelStatusByKennelId(int KennelId);
        int DeleteAnimalKennelingByKennelId(int KennelId);
        Kennel SelectKennelIdByAnimalId(int AnimalId);
        int InsertAnimalIntoKennelByAnimalId(int KennelId, int AnimalId);
        List<Animal> SelectAllAnimalsForKennel(int ShelterId);
        
        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/02/24
        /// 
        /// Deletes the Animal Kenneling record to remove the animal from the kennel.
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
        /// <returns>Rows edited</returns>
        int DeleteAnimalKennelingByKennelIdAndAnimalId(int kennelId, int animalId);
    }
}
