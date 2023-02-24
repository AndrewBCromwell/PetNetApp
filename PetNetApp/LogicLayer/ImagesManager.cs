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

        /// <summary>
        /// Molly Meister
        /// Created: 2023/02/13
        /// 
        /// Passes new image to ImagesAccessor to insert, recieves response from accessor 
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: yyyy/mm/dd
        /// 
        /// </remarks>
        /// <param name='animalId'>the id of the animal</param>
        /// <param name='imageFileName'>file name of the image being uploaded</param>
        /// <exception cref='ApplicationException'>Insert Fails</exception>
        /// <returns>boolean based on response from accessor</returns>
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

        /// <summary>
        /// Molly Meister
        /// Created: 2023/02/13
        /// 
        /// Makes request to ImagesAccessor to get images for an animal, recieves response from accessor
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: yyyy/mm/dd
        /// 
        /// </remarks>
        /// <param name='animalId'>the id of the animal</param>
        /// <exception cref='ApplicationException'>Insert Fails</exception>
        /// <returns>list of images</returns>
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
