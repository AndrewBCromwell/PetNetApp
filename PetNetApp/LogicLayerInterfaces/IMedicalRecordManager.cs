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
    }
}
