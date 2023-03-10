using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class MedicalRecordManager : IMedicalRecordManager
    {
        private IMedicalRecordAccessor _medicalRecordAccessor = null;

        public MedicalRecordManager()
        {
            _medicalRecordAccessor = new MedicalRecordAccessor();
        }

        public MedicalRecordManager(IMedicalRecordAccessor medicalRecordAccessor)
        {
            _medicalRecordAccessor = medicalRecordAccessor;
        }

        public int AddMedicalRecord(MedicalRecordVM medicalRecord)
        {
            int medicalRecordId = 0;
            try
            {
                medicalRecordId = _medicalRecordAccessor.InsertMedicalRecord(medicalRecord);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occored. The medical record could not be created.", ex);
            }
            return medicalRecordId;
        }

        public int RetrieveLastMedicalRecordIdByAnimalId(int animalId)
        {
            int medicalRecordId = 0;
            try
            {
                medicalRecordId = _medicalRecordAccessor.SelectLastMedicalRecordIdByAnimalId(animalId);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occored. The medical record could not be retreived.", ex);
            }
            return medicalRecordId;
        }

        public List<MedicalRecordVM> RetrieveMedicalRecordDiagnosisByAnimalId(int animalId)
        {
            List<MedicalRecordVM> medicalRecords = null;
            try
            {
                medicalRecords = _medicalRecordAccessor.SelectMedicalRecordDiagnosisByAnimalId(animalId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error retrieving data", ex);
            }
            return medicalRecords;
        }

        public int UpdateTreatmentByMedicalRecordId(int medicalRecordId, string diagnosis, string medicalNotes)
        {
            int result = 0;
            try
            {
                result = _medicalRecordAccessor.UpdateMedicalTreatmentByMedicalrecordId(medicalRecordId, diagnosis, medicalNotes);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error updating data", ex);
            }
            return result;
        }

        public bool EditQuarantineStatusByMedicalRecordId(int medicalRecordId, bool quarantineStatus, bool oldQuarantineStatus)
        {
            bool result = false;
            try
            {
                result = 1 == _medicalRecordAccessor.UpdateQuarantineStatusByMedicalRecordId(medicalRecordId, quarantineStatus, oldQuarantineStatus);
                if (!result)
                {
                    throw new ApplicationException("Concurrency Conflict");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int AddTestMedicalRecordByAnimalId(int animalId, string medicalNotes, bool test, string diagnosis)
        {
            int medicalRecordId;
            try
            {
                medicalRecordId = _medicalRecordAccessor.InsertTestMedicalRecordByAnimalId(animalId, medicalNotes, test, diagnosis);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return medicalRecordId;
        }
    }
}
