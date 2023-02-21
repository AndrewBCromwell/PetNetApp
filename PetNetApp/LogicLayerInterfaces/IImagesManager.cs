using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IImagesManager
    {
        List<Images> RetrieveImagesByAnimalId(int animalId);
        bool AddMedicalImageByAnimalId(int animalId, string imageFileName);
    }
}
