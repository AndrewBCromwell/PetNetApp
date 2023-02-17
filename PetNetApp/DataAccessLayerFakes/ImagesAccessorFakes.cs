using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    public class ImagesAccessorFakes : IImagesAccessor
    {
        List<Images> fakeImages = new List<Images>();
        List<MedicalRecordVM> fakeMedicalRecords = new List<MedicalRecordVM>();

        public ImagesAccessorFakes()
        {
            fakeImages.Add(new Images 
            {
               ImageId = 200000,
               ImageFileName = "oreo_arm_scratch.png"
            });

            fakeImages.Add(new Images
            {
                ImageId = 200001,
                ImageFileName = "orea_scratch_healing.png"
            });

            fakeImages.Add(new Images
            {
                ImageId = 200002,
                ImageFileName = "frank_mites.jpeg"
            });

            fakeImages.Add(new Images
            {
                ImageId = 200003,
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
        public int InsertMedicalImageByAnimalId(int animalId, string imageFileName)
        {
            int rows = 0;
            Images _image = new Images();
            _image.ImageId = 6;
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

        public List<Images> SelectImagesByAnimalId(int animalId)
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
