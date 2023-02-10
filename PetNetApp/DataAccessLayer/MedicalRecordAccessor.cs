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

            var cmdText = "sp_select_last_medical_record_by_animal_id";

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
        public List<MedicalRecordVM> SelectMedicalRecordDiagnosisByAnimalId(int animalId)
        {
            List<MedicalRecordVM> medicalRecords = new List<MedicalRecordVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_medical_record_diagnosis_by_animalid";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AnimalId", SqlDbType.Int);

            cmd.Parameters["@AnimalId"].Value = animalId;

            try
            {
                // open a connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();

                // process the results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var medicalRecord = new MedicalRecordVM();
                        medicalRecord.MedicalRecordId = reader.GetInt32(0);
                        medicalRecord.Diagnosis = reader.GetString(1);
                        medicalRecord.QuarantineStatus = reader.GetBoolean(2);
                        medicalRecord.PrescriptionStatus = reader.GetBoolean(3);
                        medicalRecord.MedicalNotes = reader.GetString(4);
                        medicalRecord.Date = reader.GetDateTime(5);
                        medicalRecords.Add(medicalRecord);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return medicalRecords;
        }
    }
}
