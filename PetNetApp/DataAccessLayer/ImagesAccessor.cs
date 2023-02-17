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
    public class ImagesAccessor : IImagesAccessor
    {
        public int InsertMedicalImageByAnimalId(int animalId, string imageFileName)
        {
            int rows = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_animal_medical_images_by_animal_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@animalId", SqlDbType.Int);
            cmd.Parameters.Add("@imageFileName", SqlDbType.NVarChar, 50);

            cmd.Parameters["@animalId"].Value = animalId;
            cmd.Parameters["@imageFileName"].Value = imageFileName;

            try
            {
                conn.Open();

                rows = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception up)
            {

                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        public List<Images> SelectImagesByAnimalId(int animalId)
        {
            List<Images> images = new List<Images>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_images_by_animal_id";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AnimalId", SqlDbType.NVarChar, 50);
            cmd.Parameters["@AnimalId"].Value = animalId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var image = new Images();
                        image.ImageId = reader.GetInt32(0);   // pulling med record id currently in SP
                        image.ImageFileName = reader.GetString(1);
                        images.Add(image);
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

            return images;
        }

        
    }
}
