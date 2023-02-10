using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;

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

        public int getLastMedicalRecordIdByAnimalId(int animalId)
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
    }
}
