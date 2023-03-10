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
        /// Nathan Zumsande
        /// Created: 2023/02/01
        /// 
        /// Updates the quarantineStatus of the passed medical record
        /// </summary>
        /// 
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example:
        /// </remarks>
        /// <param name="medicalRecordId"></param>
        /// <param name="quarantineStatus"></param>
        /// <param name="oldQuarantineStatus"></param>
        /// <exception cref="SQLException">Update Fails</exception>
        /// <returns>Rows edited</returns>
        int UpdateQuarantineStatusByMedicalRecordId(int medicalRecordId, bool quarantineStatus, bool oldQuarantineStatus);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/02/09
        /// 
        /// Inserts a new medical record with the given animalId
        /// medicalNotes and diagnosis and sets the test to true 
        /// and returns the Id of the created medical record
        /// </summary>
        /// 
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="animalId"></param>
        /// <param name="medicalNotes"></param>
        /// <param name="test"></param>
        /// <param name="diagnosis"></param>
        /// <exception cref="SQLException">Insert Fails</exception>
        /// <returns>Created medical record id</returns>
        int InsertTestMedicalRecordByAnimalId(int animalId, string medicalNotes, bool test, string diagnosis);

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

        /// <summary>
        /// Ethan Kline 
        /// Created: 2023/02/18
        /// </summary>
        /// <param name="animalId">animalId to find the Medical record associated with it</param>
        /// <exception cref="SQLException">Select Fails</exception>
        /// <returns>MedicalRecordVMs that have a medicalRecordId that is associated with the animalId</returns>
        List<MedicalRecordVM> SelectMedicalRecordByAnimal(int animalId);

        /// <summary>
        /// Ethan Kline 
        /// Created: 2023/02/18
        /// </summary>
        /// <param name="medicalRecord">medical record that will overwrite an existing record</param>
        /// <param name="oldmedicalRecord">medical record that will be overwriten</param>
        /// <exception cref="SQLException">Update Fails</exception>
        /// <returns>rows efected</returns>
        int UpdateMedicalRecord(MedicalRecord oldmedicalRecord, MedicalRecord medicalRecord);

        /// <summary>
        /// Ethan Kline 
        /// Created: 2023/03/10
        /// </summary>
        /// <param name="medicalRecord">medical record to add</param>
        /// <exception cref="SQLException">add Fails</exception>
        /// <returns>rows efected</returns>
        int AddMedicalNotes(MedicalRecord medicalRecord);
    }
}
