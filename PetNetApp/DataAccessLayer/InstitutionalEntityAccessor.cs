/// <summary>
/// Asa Armstrong
/// Created: 2023/03/01
/// 
/// Data Accessor class to CRUD Institutional Entity objects.
/// </summary>
///
/// <remarks>
/// Asa Armstrong
/// Updated: 2023/03/01
/// Created
/// </remarks>
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
    public class InstitutionalEntityAccessor : IInstitutionalEntityAccessor
    {
        public List<InstitutionalEntity> SelectAllInstitutionalEntitiesByShelterIdAndContactType(int shelterId, string contactType)
        {
            List<InstitutionalEntity> institutionalEntities = new List<InstitutionalEntity>();

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_select_all_institutionalEntities_by_shelterId_and_contactType";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShelterId", shelterId);
            cmd.Parameters.AddWithValue("@ContactType", contactType);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        institutionalEntities.Add(new InstitutionalEntity
                        {
                            InstitutionalEntityId = reader.GetInt32(0),
                            CompanyName = (reader.IsDBNull(1) ? null : reader.GetString(1)),
                            GivenName = reader.GetString(2),
                            FamilyName = reader.GetString(3),
                            Email = reader.GetString(4),
                            Phone = reader.GetString(5),
                            Address = reader.GetString(6),
                            AddressTwo = (reader.IsDBNull(7) ? null : reader.GetString(7)),
                            Zipcode = reader.GetString(8),
                            ContactType = reader.GetString(9),
                            ShelterId = reader.GetInt32(10)
                        });
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

            return institutionalEntities;
        }

        public InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId)
        {
            throw new NotImplementedException();
        }
    }
}
