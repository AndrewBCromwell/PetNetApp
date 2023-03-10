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
        /// Nathan Zumsande
        /// Created: 2023/02/01
        /// 
        /// Updates the Quarantine Status of a medical record
        /// </summary>
        /// 
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="medicalRecordId"></param>
        /// <param name="quarantineStatus"></param>
        /// <param name="oldQuarantineStatus"></param>
        /// <returns>True or false if row was edited</returns>
        bool EditQuarantineStatusByMedicalRecordId(int medicalRecordId, bool quarantineStatus, bool oldQuarantineStatus);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/09/02
        /// 
        /// Creates a new medical record and returns the Id
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
        /// <returns>Id of the created medical record</returns>
        int AddTestMedicalRecordByAnimalId(int animalId, string medicalNotes, bool test, string diagnosis);
    }
}
