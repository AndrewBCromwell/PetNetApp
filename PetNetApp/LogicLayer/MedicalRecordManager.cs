using DataAccessLayer;
using DataAccessLayerFakes;
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
    }
}
