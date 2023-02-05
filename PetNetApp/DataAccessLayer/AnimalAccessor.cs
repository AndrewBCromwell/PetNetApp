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
                        animal.ReceivedDate = reader.GetDateTime(10);
                        animal.MicrochipSerialNumber = reader.GetString(11);
                        animal.Aggressive = reader.GetBoolean(12);
                        animal.AggressionDescription = reader.GetString(13);
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
    }
}
