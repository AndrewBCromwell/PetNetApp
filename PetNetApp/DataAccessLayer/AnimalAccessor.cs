using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class AnimalAccessor : IAnimalAccessor
    {
        public List<Animal> SelectAllAnimals(string animalName)
        {
            List<Animal> animals = new List<Animal>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_animals";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AnimalName", SqlDbType.NVarChar, 50);

            cmd.Parameters["@AnimalName"].Value = animalName;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new Animal();
                        animal.AnimalId = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        // needs to be updated if we decide to link the animal table to the image table. to get animal image, left it out because the animal table doesn't have a link to the images table at the time of writing
                        animals.Add(animal);
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

            return animals;
        }
    }
}
