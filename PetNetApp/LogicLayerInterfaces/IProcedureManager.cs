using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IProcedureManager
    {
        bool AddProcedureByMedicalRecordId(Procedure procedure, int medicalRecordId);
    }
}
