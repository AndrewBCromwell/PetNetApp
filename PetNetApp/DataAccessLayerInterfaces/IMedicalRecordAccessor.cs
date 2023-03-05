using System;
﻿using DataObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IMedicalRecordAccessor
    {
        int SelectLastMedicalRecordIdByAnimalId(int animalId);
        List<MedicalRecordVM> SelectMedicalRecordDiagnosisByAnimalId(int animalId);

        int UpdateMedicalTreatmentByMedicalrecordId(int medicalRecordId, string diagnosis, string medicalNotes);

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/25
        /// 
        /// Inserts a MedicalRecord to the database. Returns
        /// the Id of the record that was just added
        /// </summary>
        /// <param name="medicalRecord">the MedicalRecord to be added</param>
        /// <exception cref="SQLException">Insert Fails</exception>
        /// <returns>MeidicalRecordId of the inserted record</returns>
        int InsertMedicalRecord(MedicalRecordVM medicalRecord);
    }
}
