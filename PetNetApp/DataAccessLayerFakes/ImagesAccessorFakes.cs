using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DataAccessLayerFakes
{
    public class ImagesAccessorFakes : IImagesAccessor
    {
        List<Images> fakeImages = new List<Images>();
        List<MedicalRecordVM> fakeMedicalRecords = new List<MedicalRecordVM>();
        List<Images> stephenFakeImages = new List<Images>();

        public ImagesAccessorFakes()
        {
            fakeImages.Add(new Images 
            {
               ImageId = "unique-1",
               ImageFileName = "oreo_arm_scratch.png"
            });

            fakeImages.Add(new Images
            {
                ImageId = "unique-2",
                ImageFileName = "orea_scratch_healing.png"
            });

            fakeImages.Add(new Images
            {
                ImageId = "unique-3",
                ImageFileName = "frank_mites.jpeg"
            });

            fakeImages.Add(new Images
            {
                ImageId = "unique-4",
                ImageFileName = "frank_mites2.jpeg"
            });

            fakeMedicalRecords.Add(new MedicalRecordVM
            {
                MedicalRecordId = 1,
                AnimalId = 1,
                Date = DateTime.Now,
                MedicalNotes = "Oreo scratched their arm.",
                IsProcedure = false,
                IsTest = false,
                IsVaccination = false,
                IsPrescription = false,
                Images = true,
                QuarantineStatus = false,
                Diagnosis = "Tis but a flesh wound",
                AnimalImages = new List<Images>
                {
                    fakeImages[0]
                }

            });

            fakeMedicalRecords.Add(new MedicalRecordVM
            {
                MedicalRecordId = 3,
                AnimalId = 2,
                Date = DateTime.Now,
                MedicalNotes = "Oreo's scratch is healing",
                IsProcedure = false,
                IsTest = false,
                IsVaccination = false,
                IsPrescription = false,
                Images = true,
                QuarantineStatus = false,
                Diagnosis = "Tis but even less than a flesh wound",
                AnimalImages = new List<Images>
                {
                    fakeImages[1]
                }
            });

            fakeMedicalRecords.Add(new MedicalRecordVM
            {
                MedicalRecordId = 10,
                AnimalId = 5,
                Date = DateTime.Now,
                MedicalNotes = "pictures of skin condition",
                IsProcedure = false,
                IsTest = false,
                IsVaccination = false,
                IsPrescription = true,
                Images = true,
                QuarantineStatus = false,
                Diagnosis = "lice",
                AnimalImages = new List<Images>
                {
                    fakeImages[2],
                    fakeImages[3]
                }
            });

        }

        public Images InsertImageByUri(string imageUri)
        {
            string fileName = imageUri.Substring((imageUri.LastIndexOf("/") > 0 ? imageUri.LastIndexOf("/") : imageUri.LastIndexOf("\\")) + 1);
            Images image = new Images() { ImageFileName = fileName, ImageId = Guid.NewGuid().ToString() };
            stephenFakeImages.Add(image);
            return image;
        }

        public List<Images> InsertImagesByUris(IEnumerable<string> imageUris)
        {
            List<Images> newImages = new List<Images>();
            foreach (string imageUri in imageUris)
            {
                string fileName = imageUri.Substring((imageUri.LastIndexOf("/") > 0 ? imageUri.LastIndexOf("/") : imageUri.LastIndexOf("\\")) + 1);
                Images image = new Images() { ImageFileName = fileName, ImageId = Guid.NewGuid().ToString() };
                stephenFakeImages.Add(image);
                newImages.Add(image);
            }
            return newImages;
        }

        public int InsertMedicalImageByAnimalId(int animalId, string imageFileName)
        {
            int rows = 0;
            Images _image = new Images();
            _image.ImageId = "unique-15";
            _image.ImageFileName = imageFileName;

            for (int i = 0; i < fakeMedicalRecords.Count; i++)
            {
                if(fakeMedicalRecords[i].AnimalId == animalId)
                {
                    fakeMedicalRecords[i].AnimalImages.Add(_image);
                    rows = 3;
                }
            }
            
            return rows;
        }

        public int InsertMedicalImagesByAnimalId(int animalId, IEnumerable<string> imageFileNames)
        {
            int rows = 0;
            List<Images> newImages = new List<Images>();
            foreach (string imageFileName in imageFileNames)
            {
                Images _image = new Images();
                _image.ImageId = "unique-15";
                _image.ImageFileName = imageFileName;
                newImages.Add(_image);
                stephenFakeImages.Add(_image);
                fakeMedicalRecords.Where(rec => rec.AnimalId == animalId).ToList().ForEach(rec => rec.AnimalImages.Add(_image));
                rows++;
            }
            fakeMedicalRecords.First(record => record.AnimalId == animalId).AnimalImages.Concat(newImages);
            return rows;
        }

        public BitmapImage SelectImageByImages(Images images)
        {
            return new BitmapImage();
        }

        public List<Images> SelectMedicalImagesByAnimalId(int animalId)
        {
            //var animalImages = fakeMedicalRecords.Where((x) => x.AnimalId == animalId && x.Images).Select((x) => x.AnimalImages);
            //return fakeImages.Where((x) => animalImages

            List<Images> _images = new List<Images>();
            foreach (var record in fakeMedicalRecords)
            {
                if(record.AnimalId == animalId)
                {
                    foreach(var image in record.AnimalImages)
                    {
                        _images.Add(image);
                    }
                }
            }
            return _images;
        }
    }
}
