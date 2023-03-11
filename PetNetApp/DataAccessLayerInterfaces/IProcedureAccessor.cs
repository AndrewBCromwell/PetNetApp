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
        int UpdateProcedureByProcedureId(Procedure procedure, Procedure oldProcedure);
        List<ProcedureVM> SelectProceduresByAnimalId(int animalId);

        /// <summary>
        /// Molly Meister
        /// Created: 2023/03/10
        /// 
        /// Gets the procedure for a specified medical record
        /// </summary>
        /// <param name="medicalRecordId">The medical record ID to get the procedure for</param>
        /// <returns>A ProcedureVM object</returns>
        ProcedureVM SelectProcedureByMedicalRecordId(int medicalRecordId);
    }
}
