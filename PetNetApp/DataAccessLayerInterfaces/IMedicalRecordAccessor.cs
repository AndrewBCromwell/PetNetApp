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

namespace DataAccessLayerInterfaces
{
    public interface IMedicalRecordAccessor
    {
<<<<<<< HEAD
        int SelectLastMedicalRecordIdByAnimalId(int animalId);
=======
        List<MedicalRecordVM> SelectMedicalRecordDiagnosisByAnimalId(int animalId);
>>>>>>> origin/main
    }
}
