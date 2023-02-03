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
    public class AnimalAccessor : IAnimalAccessor
    {
        public List<Animal> SelectAllAnimals()
        {
            List<Animal> animals = new List<Animal>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_view_all_animals";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

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
                        animal.AnimalTypeId = reader.GetString(2);
                        animal.AnimalBreedId = reader.GetString(3);
                        animal.Personality = reader.GetString(4);
                        animal.Description = reader.GetString(5);
                        animal.AnimalStatusId = reader.GetString(6);
                        animal.BroughtIn = reader.GetDateTime(7);
                        animal.MicrochipNumber = reader.GetString(8);
                        animal.Aggressive = reader.GetBoolean(9);
                        if(reader.IsDBNull(10))
                        {
                            animal.AggressiveDescription = null;
                        }
                        animal.ChildFriendly = reader.GetBoolean(11);
                        animal.NeuterStatus = reader.GetBoolean(12);
                        if(reader.IsDBNull(13))
                        {
                            animal.Notes = null;
                        }
                        animals.Add(animal);
                    }
                }

            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return animals;
        }
    }
}
