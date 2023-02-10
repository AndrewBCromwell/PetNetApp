<<<<<<< HEAD
﻿using System;
=======
﻿using DataObjects;
using System;
>>>>>>> origin/main
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IMedicalRecordManager
    {
<<<<<<< HEAD
        int getLastMedicalRecordIdByAnimalId(int animalId);
=======
        List<MedicalRecordVM> RetrieveMedicalRecordDiagnosisByAnimalId(int animalId);
>>>>>>> origin/main
    }
}
