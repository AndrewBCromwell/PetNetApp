using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IAnimalUpdatesAccessor
    {
        int InsertAnimalUpdatesByAnimalId(int animalId, string animalRecordNotes);
        string SelectAnimalUpdatesByAnimal(int animalId);
    }
}
