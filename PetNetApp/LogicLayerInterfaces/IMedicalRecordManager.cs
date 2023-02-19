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
        int getLastMedicalRecordIdByAnimalId(int animalId);
        List<MedicalRecordVM> RetrieveMedicalRecordDiagnosisByAnimalId(int animalId);
        int UpdateTreatmentByMedicalRecordId(int medicalRecordId, string diagnosis, string medicalNotes);
    }
}
