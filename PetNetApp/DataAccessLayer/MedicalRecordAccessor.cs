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
    public class MedicalRecordAccessor : IMedicalRecordAccessor
    {
        public int SelectLastMedicalRecordIdByAnimalId(int animalId)
        {
            int medicalRecordId = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
                           
            var cmdText = "sp_get_last_medical_record_by_animal_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalId", animalId);
            
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    medicalRecordId = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return medicalRecordId;
        }
    }
}
