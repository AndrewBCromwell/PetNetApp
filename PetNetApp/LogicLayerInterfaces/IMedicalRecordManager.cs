using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IMedicalRecordManager
    {
        int RetrieveLastMedicalRecordIdByAnimalId(int animalId);
        List<MedicalRecordVM> RetrieveMedicalRecordDiagnosisByAnimalId(int animalId);
        int UpdateTreatmentByMedicalRecordId(int medicalRecordId, string diagnosis, string medicalNotes);

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/25
        /// 
        /// Passes a MedicalRecord to the MedicalRecordAccessor to add to the database. Returns
        /// the Id of the record that was just added
        /// </summary>
        /// <param name="medicalRecord">the MedicalRecord to be added</param>
        /// <exception cref="ApplicationException">Insert Fails</exception>
        /// <returns>MeidicalRecordId of the inserted record</returns>
        int AddMedicalRecord(MedicalRecordVM medicalRecord);

        /// <summary>
        /// Ethan Kline 
        /// Created: 2023/02/18
        /// </summary>
        /// <param name="animalId">the id of the animal to return the medical record of</param>
        /// <exception cref="ApplicationException">Faild to retrieve medical records</exception>
        /// <returns>List of the medical record associated with the animal</returns>
        List<MedicalRecordVM> SelectMedicalRecordByAnimal(int animalId);

        /// <summary>
        /// Ethan Kline 
        /// Created: 2023/02/18
        /// 
        /// Takes two medical notes, passes them to the MedicalRecordAccessor, receives a response 
        /// from the accessor, and returns a respnonse about whether the old medical record was
        /// updated to be the new medical record.
        /// </summary>
        /// <param name="medicalRecord">the medical record to replace the old medical record in the db</param>
        /// <param name="oldmedicalRecord">the medical record to be overwriten</param>
        /// <exception cref="ApplicationException">Update Fails</exception>
        /// <returns>Rows affected</returns>
        bool EditMedicalRecord(MedicalRecord oldmedicalRecord, MedicalRecord medicalRecord);

        /// <summary>
        /// Ethan Kline 
        /// Created: 2023/03/10
        /// 
        /// Takes a medical record, passes it to the MedicalRecordAccessor, receives a response 
        /// from the accessor, and returns a respnonse about whether the  medical record was added
        /// </summary>
        /// <param name="medicalRecord">the medical record to be added</param>
        /// <exception cref="ApplicationException">add Failed</exception>
        /// <returns>Rows affected</returns>
        bool AddMedicalNote(MedicalRecord medicalRecord);
    }
}
