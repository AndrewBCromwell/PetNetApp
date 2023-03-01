﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LogicLayerInterfaces
{
    public interface IImagesManager
    {
        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/26
        /// 
        /// Calls the accessor method to store images and return their unique Id's
        /// </summary>
        /// <param name="imageUris">The list of images to store</param>
        /// <returns>List of Images Objects</returns>
        List<Images> AddImagesByUris(IEnumerable<string> imageUris);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/26
        /// 
        /// Calls the accessor method to store the image and return its unique Id
        /// </summary>
        /// <param name="imageUri">The full path where the image is located</param>
        /// <returns>An Images object with the ImageId and Image File Name</returns>
        Images AddImageByUri(string imageUri);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/26
        /// 
        /// Uses the Accessor method to retrieve the actual file from its storage location
        /// </summary>
        /// <param name="images">The images object to fetch the displayable bitmap for</param>
        /// <returns>A displayable bitmap image</returns>
        BitmapImage RetrieveImageByImages(Images images);

        /// <summary>
        /// Molly Meister
        /// Created: 2023/02/18
        /// 
        /// Uses the accessors method to retrieve a list of images objects for the specified animals medical records
        /// </summary>
        /// <param name="animalId">The id of the animal to get the medical record images for</param>
        /// <returns>A list of Images objects</returns>
        List<Images> RetrieveMedicalImagesByAnimalId(int animalId);

        /// <summary>
        /// Molly Meister
        /// Created: 2023/02/18
        /// 
        /// Adds the selected image to a medical record for the selected animal
        /// </summary>
        /// <param name="animalId">The id of the animal to get the medical record images for</param>
        /// <returns>A list of Images objects</returns>
        bool AddMedicalImageByAnimalId(int animalId, string imageFileName);

        /// <summary>
        /// Stephen Jaurigue
        /// Created: 2023/02/26
        /// 
        /// 
        /// </summary>
        /// <param name="animalId">The id of the animal to get the medical record images for</param>
        /// <param name="imageFileNames">The list of Uri where the images are located</param>
        /// <returns></returns>
        bool AddMedicalImagesByAnimalId(int animalId, IEnumerable<string> imageFileNames);
    }
}