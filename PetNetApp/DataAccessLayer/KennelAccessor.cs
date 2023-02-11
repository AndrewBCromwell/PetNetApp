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
    public class KennelAccessor : IKennelAccessor
    {

        public int InsertKennel(Kennel kennel)
        {
            int rows = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_insert_kennel";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ShelterId", SqlDbType.Int);
            cmd.Parameters.Add("@KennelName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@AnimalTypeId", SqlDbType.NVarChar, 50);
            cmd.Parameters["@ShelterId"].Value = kennel.ShelterId;
            cmd.Parameters["@KennelName"].Value = kennel.KennelName;
            cmd.Parameters["@AnimalTypeId"].Value = kennel.AnimalTypeId;

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

        public List<string> SelectAnimalTypes()
        {
            List<string> animalTypes = new List<string>();
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_animal_types";
            var cmd = new SqlCommand(cmdText, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string animalType = null;

                        animalType = reader.GetString(0);

                        animalTypes.Add(animalType);
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
            return animalTypes;
        }

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods retrieves kennels from the database with the associated shelter id
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="ShelterId">A description of the parameter that this method takes</param>
        /// <exception cref="SQLException"></exception>
        /// <returns>List<KennelVM></returns>
        public List<KennelVM> SelectKennels(int ShelterId)
        {
            List<KennelVM> kennelVMs = new List<KennelVM>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_kennels";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ShelterId", ShelterId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        KennelVM kennelVM = new KennelVM();
                        Animal animal = new Animal();

                        kennelVM.KennelId = reader.GetInt32(0);
                        kennelVM.ShelterId = reader.GetInt32(1);
                        kennelVM.KennelName = reader.GetString(2);
                        kennelVM.AnimalTypeId = reader.GetString(3);
                        kennelVM.KennelActive = reader.GetBoolean(4);
                        
                        if(reader.IsDBNull(5) || reader.IsDBNull(6) || reader.IsDBNull(7))
                        {
                            animal = null;
                        } else
                        {
                            animal.AnimalName = reader.GetString(5);
                            animal.BroughtIn = reader.GetDateTime(6);
                            animal.Notes = reader.GetString(7);
                        }
                        

                        kennelVM.Animal = animal;
                        kennelVMs.Add(kennelVM);
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
            return kennelVMs;
        }

        public int UpdateKennelStatusByKennelId(int KennelId)
        {
            int rows = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_update_kennel_status_by_kennelid";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@KennelId", SqlDbType.Int);
            cmd.Parameters["@KennelId"].Value = KennelId;

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

        public int DeleteAnimalKennelingByKennelId(int KennelId)
        {
            int rows = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_delete_animal_kenneling_by_kennelid";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@KennelId", SqlDbType.Int);
            cmd.Parameters["@KennelId"].Value = KennelId;

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
