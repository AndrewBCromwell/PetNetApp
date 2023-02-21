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
        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/02/16
        /// 
        /// Selects all medical records for a specific animal
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="animalId">animal's animalId number</param>
        /// <exception cref="Exception">Select Fails</exception>
        /// <returns>All medicalrecord rows where animalId equals the param</returns>
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
                        medicalRecord.IsPrescription = reader.GetBoolean(3);
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

        /// <summary>
        /// Matthew Meppelink
        /// Created: 2023/02/16
        /// 
        /// updates a medicalrecord's treatment and diagnosis by medicalrecordid
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="medicalRecordId">medical record id</param>
        /// <param name="diagnosis">A name of an animal's diagnosis</param>
        /// <param name="medicalNotes">Notes about an animal's treatment/diagnosis</param>
        /// <exception cref="Exception">Update Fails</exception>
        /// <returns>Rows affected</returns>	
        public int UpdateMedicalTreatmentByMedicalrecordId(int medicalRecordId, string diagnosis, string medicalNotes)
        {
            int rows = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_update_medical_treatment";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@recordId", SqlDbType.Int);
            cmd.Parameters.Add("@newDiagnosis", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@newMedicalNotes", SqlDbType.NVarChar, 250);

            cmd.Parameters["@recordId"].Value = medicalRecordId;
            cmd.Parameters["@newDiagnosis"].Value = diagnosis;
            cmd.Parameters["@newMedicalNotes"].Value = medicalNotes;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rows = cmd.ExecuteNonQuery();
                    }
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
            return rows;
        }
    }
}
