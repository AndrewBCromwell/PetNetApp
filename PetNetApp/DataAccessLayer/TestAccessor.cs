using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TestAccessor : ITestAccessor
    {
        public List<Test> SelectTestsByAnimalId(int animalId)
        {
            List<Test> tests = new List<Test>();

            var conn = new DBConnection().GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_tests_by_animal_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AnimalID", SqlDbType.Int).Value = animalId;

            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tests.Add(new Test()
                            {
                                TestId = reader.GetInt32(0),
                                MedicalRecordId = reader.GetInt32(1),
                                UserId = reader.GetInt32(2),
                                TestName = reader.GetString(3),
                                TestAcceptableRange = reader.GetString(4),
                                TestResult = reader.GetString(5),
                                TestNotes = reader.GetString(6),
                                TestDate = reader.GetDateTime(7)
                            });
                        }
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

            return tests;
        }
    }
}
