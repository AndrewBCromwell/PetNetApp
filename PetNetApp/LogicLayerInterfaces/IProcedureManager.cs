/// <summary>
/// Andrew Cromwell
/// Created: 2023/02/08
/// 
/// Interface that lists methods that ProcedureManager must implament.
/// </summary>
/// 
/// <remarks>
/// Andrew Cromwell
/// Updated: 2023/02/14
/// Added EditProcedureByMedicalRecordIdAndProcedureId and GetProceduresByAnimalId
/// </remarks>

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
        bool EditProcedureByProcedureId(Procedure procedure, Procedure oldProcedure);
        List<ProcedureVM> RetrieveProceduresByAnimalId(int animalId);
    }
}
