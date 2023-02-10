using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    public class MedicalRecordAccessorFakes : IMedicalRecordAccessor
    {
        List<MedicalRecordVM> medicalRecords = new List<MedicalRecordVM>();

        public MedicalRecordAccessorFakes()
        {
            medicalRecords.Add(new MedicalRecordVM
            {
                AnimalId = 100000,
                Date = DateTime.Now,
                MedicalNotes = "These are sample medical notes",
                Procedure = true,
                Test = true,
                Vaccination = true,
                PrescriptionStatus = false,
                Images = false,
                QuarantineStatus = false,
                Diagnosis = "Sample Diagnosis 1"
            });
        }

        public List<MedicalRecordVM> SelectMedicalRecordDiagnosisByAnimalId(int animalId)
        {
            return medicalRecords.Where(m => m.AnimalId == animalId).ToList();
        }
    }
}
