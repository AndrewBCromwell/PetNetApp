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

        public List<string> SelectAllAnimalBreeds()
        {
            List<string> breeds = new List<string>();

            // connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_all_animal_breeds";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

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
                        string breed = "";
                        breed = reader.GetString(0);
                        breeds.Add(breed);
                        
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
            return breeds;
        }

        public List<string> SelectAllAnimalGenders()
        {
            List<string> genders = new List<string>();

            // connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_all_animal_genders";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

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
                        string gender = "";
                        gender = reader.GetString(0);
                        genders.Add(gender);

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
            return genders;
        }

        public List<string> SelectAllAnimalStatuses()
        {
            List<string> statuses = new List<string>();

            // connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_all_animal_statuses";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

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
                        string status = "";
                        status = reader.GetString(0);
                        statuses.Add(status);

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
            return statuses;
        }

        public List<string> SelectAllAnimalTypes()
        {
            List<string> types = new List<string>();

            // connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_all_animal_types";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

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
                        string type = "";
                        type = reader.GetString(0);
                        types.Add(type);

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
            return types;
        }

        public int UpdateAnimal(AnimalVM oldAnimal, AnimalVM newAnimal)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // cmdText
            var cmdText = "sp_update_animal";

            //command
            var cmd = new SqlCommand(cmdText, conn);

            // type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.AddWithValue("@AnimalId", oldAnimal.AnimalId);
            cmd.Parameters.AddWithValue("@OldAnimalName", oldAnimal.AnimalName);
            cmd.Parameters.AddWithValue("@OldAnimalGender", oldAnimal.AnimalGender);
            cmd.Parameters.AddWithValue("@OldAnimalTypeId", oldAnimal.AnimalTypeId);
            cmd.Parameters.AddWithValue("@OldAnimalBreedId", oldAnimal.AnimalBreedId);
            cmd.Parameters.AddWithValue("@OldPersonality", oldAnimal.Personality);
            cmd.Parameters.AddWithValue("@OldDescription", oldAnimal.Description);
            cmd.Parameters.AddWithValue("@OldAnimalStatusId", oldAnimal.AnimalStatusId);
            cmd.Parameters.AddWithValue("@OldReceivedDate", oldAnimal.BroughtIn); // "ReceivedDate" in the DB
            cmd.Parameters.AddWithValue("@OldMicrochipSerialNumber", oldAnimal.MicrochipNumber);
            cmd.Parameters.AddWithValue("@OldAggressive", oldAnimal.Aggressive);
            cmd.Parameters.AddWithValue("@OldAggressiveDescription", oldAnimal.AggressiveDescription);
            cmd.Parameters.AddWithValue("@OldChildFriendly", oldAnimal.ChildFriendly);
            cmd.Parameters.AddWithValue("@OldNeuterStatus", oldAnimal.NeuterStatus);
            cmd.Parameters.AddWithValue("@OldNotes", oldAnimal.Notes);

            cmd.Parameters.AddWithValue("NewAnimalName", newAnimal.AnimalName);
            cmd.Parameters.AddWithValue("NewAnimalGender", newAnimal.AnimalGender);
            cmd.Parameters.AddWithValue("NewAnimalTypeId", newAnimal.AnimalTypeId);
            cmd.Parameters.AddWithValue("NewAnimalBreedId", newAnimal.AnimalBreedId);
            cmd.Parameters.AddWithValue("NewPersonality", newAnimal.Personality);
            cmd.Parameters.AddWithValue("NewDescription", newAnimal.Description);
            cmd.Parameters.AddWithValue("NewAnimalStatusId", newAnimal.AnimalStatusId);
            cmd.Parameters.AddWithValue("NewReceivedDate", newAnimal.BroughtIn); // "ReceivedDate" in the DB
            cmd.Parameters.AddWithValue("NewMicrochipSerialNumber", newAnimal.MicrochipNumber);
            cmd.Parameters.AddWithValue("NewAggressive", newAnimal.Aggressive);
            cmd.Parameters.AddWithValue("NewAggressiveDescription", newAnimal.AggressiveDescription);
            cmd.Parameters.AddWithValue("NewChildFriendly", newAnimal.ChildFriendly);
            cmd.Parameters.AddWithValue("NewNeuterStatus", newAnimal.NeuterStatus);
            cmd.Parameters.AddWithValue("NewNotes", newAnimal.Notes);

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

        public List<Animal> SelectAllAnimals()  // add shelterId
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
                        animal.Personality = reader.IsDBNull(4) ? null : reader.GetString(4);
                        animal.Description = reader.IsDBNull(5) ? null : reader.GetString(5);
                        animal.AnimalStatusId = reader.GetString(6);
                        animal.BroughtIn = reader.GetDateTime(7);
                        animal.MicrochipNumber = reader.GetString(8);
                        animal.Aggressive = reader.GetBoolean(9);
                        animal.AggressiveDescription = reader.IsDBNull(10) ? null : reader.GetString(10);
                        animal.ChildFriendly = reader.GetBoolean(11);
                        animal.NeuterStatus = reader.GetBoolean(12);
                        animal.Notes = reader.IsDBNull(13) ? null : reader.GetString(13);
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

        public List<Animal> SelectAllAnimalsNotInKennel()
        {
            throw new NotImplementedException();
        }
        public AnimalVM SelectAnimalMedicalProfileByAnimalId(int animalId)
        {
            AnimalVM animalVM = new AnimalVM();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_animal_record_by_animal_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AnimalId", SqlDbType.Int);
            cmd.Parameters["@AnimalId"].Value = animalId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //[AnimalId], [AnimalName], [AnimalGender], [AnimalTypeId], [AnimalBreedId], [Personality], [Description],
                        //[AnimalStatusId],[RecievedDate], [MicrochipSerialNumber], [Aggressive], [AggressiveDescription],
                        //[ChildFriendly], [NeuterStatus],[Notes]

                        animalVM.AnimalId = reader.GetInt32(0);
                        animalVM.AnimalName = reader.GetString(1);
                        animalVM.AnimalGender = reader.GetString(2);
                        animalVM.AnimalTypeId = reader.GetString(3);
                        animalVM.AnimalBreedId = reader.GetString(4);
                        animalVM.Personality = reader.GetString(5);
                        animalVM.Description = reader.GetString(6);
                        animalVM.AnimalStatusId = reader.GetString(7);
                        animalVM.BroughtIn = reader.GetDateTime(8);
                        animalVM.MicrochipNumber = reader.GetString(9);
                        animalVM.Aggressive = reader.GetBoolean(10);
                        animalVM.AggressiveDescription = reader.GetString(11);
                        animalVM.ChildFriendly = reader.GetBoolean(12);
                        animalVM.NeuterStatus = reader.GetBoolean(13);
                        animalVM.Notes = reader.GetString(14);
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

            return animalVM;
        }
    }
}
