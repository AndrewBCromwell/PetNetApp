using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class MedicalRecordAccessorFakes : IMedicalRecordAccessor
    {
        private Dictionary<int, int> medicalRecordRepresentation = new Dictionary<int, int>()
        {
            {50, 60 },
            {51, 61 }
        };


        public int SelectLastMedicalRecordIdByAnimalId(int animalId)
        {
            int medicalRecordId = 0;
            if (medicalRecordRepresentation.ContainsKey(animalId))
            {
                medicalRecordId = medicalRecordRepresentation[animalId];
            }
            return medicalRecordId;
        }
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
