using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class ProcedureManager : IProcedureManager
    {
        private IProcedureAccessor _procedureAccessor = null;
        

        public ProcedureManager()
        {
            _procedureAccessor = new ProcedureAccessor();
        }

        public ProcedureManager(IProcedureAccessor procedureAccessor)
        {
            _procedureAccessor = procedureAccessor;
        }

        public bool AddProcedureByMedicalRecordId(Procedure procedure, int medicalRecordId)
        {
            bool success = false;
            int expectedRowsAffected = 2;
            try
            {
                int result = _procedureAccessor.InsetProcedureByMedicalRecordId(procedure, medicalRecordId);
                if(result == expectedRowsAffected)
                {
                    success = true;
                }
            } catch(Exception ex)
            {
                throw new ApplicationException("An error occored. The procedure was not saved.", ex);
            }
            return success;
            
        }
    }
}
