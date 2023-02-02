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
    }
}
