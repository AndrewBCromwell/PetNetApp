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
        List<KennelVM> RetrieveKennels(int ShelterId);
        Kennel RetrieveKennelIdByAnimalId(int AnimalId);
        bool AddAnimalIntoKennelByAnimalId(int KennelId, int AnimalId);
        List<Animal> RetrieveAllAnimalsForKennel(int ShelterId);
        List<string> RetrieveAnimalTypes();
        bool AddKennel(Kennel kennel);
        bool EditKennelStatusByKennelId(int KennelId);
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
