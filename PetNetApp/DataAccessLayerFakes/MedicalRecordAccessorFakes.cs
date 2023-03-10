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
        public MedicalRecord oldmedicalRecord = new MedicalRecord();
        public MedicalRecord newmedicalRecord = new MedicalRecord();
        public MedicalRecord addmedicalRecord = new MedicalRecord();

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
                MedicalRecordId = 100000,
                AnimalId = 100000,
                Date = DateTime.Now,
                MedicalNotes = "These are sample medical notes",
                IsProcedure = true,
                IsTest = true,
                IsVaccination = true,
                IsPrescription = false,
                Images = false,
                QuarantineStatus = false,
                Diagnosis = "Sample Diagnosis 1"
            });
            oldmedicalRecord.MedicalRecordId = 100000;
            newmedicalRecord.MedicalRecordId = 100000;
            addmedicalRecord.Diagnosis = "good";
            addmedicalRecord.AnimalId = 100000;
            addmedicalRecord.MedicalNotes = "this is a add note";
            
        }

        public List<MedicalRecordVM> SelectMedicalRecordDiagnosisByAnimalId(int animalId)
        {
            return medicalRecords.Where(m => m.AnimalId == animalId).ToList();
        }

        public int UpdateMedicalTreatmentByMedicalrecordId(int medicalRecordId, string diagnosis, string medicalNotes)
        {
            int result = 0;

            for (int i = 0; i < medicalRecords.Count; i++)
            {
                if (medicalRecords[i].MedicalRecordId == medicalRecordId)
                {
                    medicalRecords[i].Diagnosis = diagnosis;
                    medicalRecords[i].MedicalNotes = medicalNotes;

                    result++;
                }
            }
            return result;
        }

        public int InsertMedicalRecord(MedicalRecordVM medicalRecord)
        {
            int medicalRecordId = 0;
            medicalRecords.Add(medicalRecord);
            medicalRecordId = medicalRecord.MedicalRecordId;
            return medicalRecordId;
        }
        public List<MedicalRecordVM> SelectMedicalRecordByAnimal(int animalId)
        {
            return medicalRecords.Where(m => m.AnimalId == animalId).ToList();
        }

        public int UpdateMedicalRecord(MedicalRecord oldmedicalRecord, MedicalRecord medicalRecord)
        {
            int result = 0;

            if (oldmedicalRecord.MedicalRecordId == medicalRecord.MedicalRecordId)
            {
                result = 1;
            }
            return result;
        }

        public int AddMedicalNotes(MedicalRecord medicalRecord)
        {
            if (addmedicalRecord.AnimalId >= 100000)
            {
                return  1;
            }
            else
            {
                return 2;
            }
        }
    }
}
