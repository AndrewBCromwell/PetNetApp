using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IImagesAccessor
    {
        List<Images> SelectImagesByAnimalId(int animalId);
        int InsertMedicalImageByAnimalId(int animalId, string imageFileName);
    }
}
