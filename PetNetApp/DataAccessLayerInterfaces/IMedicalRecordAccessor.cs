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

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/09
        /// 
        /// Retireves all medical records for a specified animalId.
        /// Returns a list of MedicalRecordVM.
        /// </summary>
        /// <param name="animalId">the animal to retrieve medical records for</param>
        /// <exception cref="SQLException">retrieval fails</exception>
        /// <returns>List of MedicalRecordVM for the specified animalId</returns>
        List<MedicalRecordVM> SelectAllMedicalRecordsByAnimald(int animalId);
    }
}
