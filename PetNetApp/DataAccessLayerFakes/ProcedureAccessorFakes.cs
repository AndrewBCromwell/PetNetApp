using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class ProcedureAccessorFakes : IProcedureAccessor
    {
        private int expectedProcedureIdForTest = 0;
        private int expectedMedicalRecordIdForTest = 0;
        private int expectedUserIdForTest = 0;
        public int InsetProcedureByMedicalRecordId(Procedure procedure, int medicalRecordId)
        {
            if(procedure.ProcedureId == expectedProcedureIdForTest || medicalRecordId == expectedMedicalRecordIdForTest
                || procedure.UserId == expectedUserIdForTest)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
