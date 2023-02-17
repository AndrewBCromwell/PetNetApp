/// <summary>
/// Andrew Cromwell
/// Created: 2023/02/08
/// 
/// Interface that lists methods that ProcedureAccessor and ProcedureAccessorInterfaces must implament.
/// </summary>
/// 
/// < remarks >
/// Andrew Cromwell
/// Updated: 2023/02/15
/// Added UpdateProcedureByMedicalRecordIdAndProcedureId and SelectProceduresByAnimalId
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IProcedureAccessor
    {
        int InsetProcedureByMedicalRecordId(Procedure procedure, int medicalRecordId);
        int UpdateProcedureByMedicalRecordIdAndProcedureId(Procedure procedure, Procedure oldProcedure, int medicalRecordId);
        List<ProcedureVM> SelectProceduresByAnimalId(int animalId);
    }
}
