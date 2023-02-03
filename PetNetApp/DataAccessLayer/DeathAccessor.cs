using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DeathAccessor : IDeathAccessor
    {
        public int AddAnimalDOD(Death death)
        {
            int rowsAffected = 0;

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_add_animal_dod_by_medical_record_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsersId", death.UsersId);
            cmd.Parameters.AddWithValue("@AnimalId", death.AnimalId);
            cmd.Parameters.AddWithValue("@DeathDate", death.DeathDate);
            cmd.Parameters.AddWithValue("@DeathCause", death.DeathCause);
            cmd.Parameters.AddWithValue("@DeathDisposal", death.DeathDisposal);
            cmd.Parameters.AddWithValue("@DeathDisposalDate", death.DeathDisposalDate);
            cmd.Parameters.AddWithValue("@DeathNotes", death.DeathNotes);

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public int EditAnimalDOD(Death oldDeath, Death newDeath)
        {
            throw new NotImplementedException();
        }
    }
}
