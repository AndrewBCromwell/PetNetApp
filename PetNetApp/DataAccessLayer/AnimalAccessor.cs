using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;


namespace DataAccessLayer
{
    public class AnimalAccessor : IAnimalAccessor
    {
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
                         *[AnimalId], [AnimalName], [AnimalGender], [AnimalTypeId], [AnimalBreedId], [Personality],
                         *[Description], [Animal].[AnimalStatusId], [AnimalStatus].[AnimalStatusDescription], [RecievedDate],
                         *[MicrochipSerialNumber], [Aggressive], [AggressiveDescription], [ChildFriendly], [NeuterStatus], [Notes]
                        */

                        animal.AnimalId = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        animal.AnimalGender = reader.GetString(2);
                        animal.AnimalTypeId = reader.GetString(3);
                        animal.AnimalBreedId = reader.GetString(4);
                        animal.Personality = reader.GetString(5);
                        animal.Description = reader.GetString(6);
                        animal.AnimalStatusId = reader.GetString(7);
                        animal.AnimalStatusDescription = reader.GetString(8);
                        animal.ReceivedDate = reader.GetDateTime(9);
                        animal.MicrochipSerialNumber = reader.GetString(10);
                        animal.Aggressive = reader.GetBoolean(11);
                        animal.AggressionDescription = reader.GetString(12);
                        animal.ChildFriendly = reader.GetBoolean(13);
                        animal.NeuterStatus = reader.GetBoolean(14);
                        animal.Notes = reader.GetString(15);
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

        public int UpdateAnimal(Animal oldAnimal, Animal newAnimal)
        {
            throw new NotImplementedException();
        }
    }
}
