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
        int DeleteAnimalKennelingByKennelIdAndAnimalId(int kennelId, int animalId);
    }
}
