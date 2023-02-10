using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class MedicalRecordAccessorFakes : IMedicalRecordAccessor
    {
        private Dictionary<int, int> medicalRecordRepresentation = new Dictionary<int, int>()
        {
            {50, 60 },
            {51, 61 }
        };
        

        public int SelectLastMedicalRecordIdByAnimalId(int animalId)
        {
            int medicalRecordId = 0;
            if (medicalRecordRepresentation.ContainsKey(animalId))
            {
                medicalRecordId = medicalRecordRepresentation[animalId];
            }
            return medicalRecordId;
        }
    }
}
