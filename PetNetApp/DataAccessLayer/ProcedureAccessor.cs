using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class ProcedureAccessor : IProcedureAccessor
    {
        public int InsetProcedureByMedicalRecordId(Procedure procedure, int medicalRecordId)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_procedure_by_medical_record_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MedicalRecordId", medicalRecordId);
            cmd.Parameters.AddWithValue("@UserId", procedure.UserId);
            cmd.Parameters.AddWithValue("@ProcedureName", procedure.ProcedureName);
            cmd.Parameters.AddWithValue("@MedicationsAdministered", procedure.MedictationsAdministered);
            cmd.Parameters.AddWithValue("@ProcedureNotes", procedure.ProcedureNotes);
            cmd.Parameters.AddWithValue("@ProcedureDate", procedure.ProcedureDate.Date);
            cmd.Parameters.AddWithValue("@ProcedureTime", procedure.ProcedureDate.TimeOfDay);


            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
    }
}
