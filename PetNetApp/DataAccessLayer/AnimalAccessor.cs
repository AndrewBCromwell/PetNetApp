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
        public List<Animal> SelectAllAnimals(string animalName)
        {
            List<Animal> animals = new List<Animal>();

            // connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_animals";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AnimalName", SqlDbType.NVarChar, 50);

            cmd.Parameters["@AnimalName"].Value = animalName;

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

        public AnimalVM SelectAnimalByAnimalId(int animalId)
        {
            AnimalVM animal = new AnimalVM();

            // connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_animal_by_animalId";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.AddWithValue("@AnimalId", animalId);

            // try-catch-finally
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
                        /*
                         *[AnimalId], [AnimalName], [AnimalGender], [AnimalTypeId], [AnimalBreedId], [KennelName], [Personality],
                         *[Description], [Animal].[AnimalStatusId], [AnimalStatus].[AnimalStatusDescription], [RecievedDate],
                         *[MicrochipSerialNumber], [Aggressive], [AggressiveDescription], [ChildFriendly], [NeuterStatus], [Notes]
                        */

                        animal.AnimalId = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        animal.AnimalGender = reader.GetString(2);
                        animal.AnimalTypeId = reader.GetString(3);
                        animal.AnimalBreedId = reader.GetString(4);
                        animal.KennelName = reader.GetString(5);
                        animal.Personality = reader.GetString(6);
                        animal.Description = reader.GetString(7);
                        animal.AnimalStatusId = reader.GetString(8);
                        animal.AnimalStatusDescription = reader.GetString(9);
                        animal.BroughtIn = reader.GetDateTime(10);
                        animal.MicrochipNumber = reader.GetString(11);
                        animal.Aggressive = reader.GetBoolean(12);
                        animal.AggressiveDescription = reader.GetString(13);
                        animal.ChildFriendly = reader.GetBoolean(14);
                        animal.NeuterStatus = reader.GetBoolean(15);
                        animal.Notes = reader.GetString(16);
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

            return animal;
        }

        public int UpdateAnimal(AnimalVM oldAnimal, AnimalVM newAnimal)
        {
            throw new NotImplementedException();
        }

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
                        if (reader.IsDBNull(10))
                        {
                            animal.AggressiveDescription = null;
                        }
                        animal.ChildFriendly = reader.GetBoolean(11);
                        animal.NeuterStatus = reader.GetBoolean(12);
                        if (reader.IsDBNull(13))
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
