<<<<<<< HEAD
﻿using System;
=======
﻿using DataAccessLayer;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
>>>>>>> origin/main
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
=======
>>>>>>> origin/main

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

<<<<<<< HEAD
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
=======
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
>>>>>>> origin/main
        }
    }
}
