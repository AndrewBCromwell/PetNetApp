using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ImagesManager : IImagesManager
    {
        private IImagesAccessor _imagesAccessor = null;

        public ImagesManager()
        {
            _imagesAccessor = new ImagesAccessor();
        }

        public ImagesManager(IImagesAccessor ia)
        {
            _imagesAccessor = ia;
        }

        public bool AddMedicalImageByAnimalId(int animalId, string imageFileName)
        {
            try
            {
                return 3 == _imagesAccessor.InsertMedicalImageByAnimalId(animalId, imageFileName);
            }
            catch (Exception up)
            {
                throw new ApplicationException("Failed to add image.", up);
            }
        }

        public List<Images> RetrieveImagesByAnimalId(int animalId)
        {
            List<Images> images;
            try
            {
                images = _imagesAccessor.SelectImagesByAnimalId(animalId);
            }
            catch (Exception up)
            {
                throw new ApplicationException("Failed to retrieve images", up);
            }

            return images;
        }
    }
}
