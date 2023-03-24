/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// ShelterInventoryItemAccessor
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ShelterInventoryItemAccessor : IShelterInventoryItemAccessor
    {
        public List<ShelterInventoryItemVM> SelectInventoryByShelter(int shelterId)
        {
            List<ShelterInventoryItemVM> _shelterInventoryItemVMs = new List<ShelterInventoryItemVM>();

            //Connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            //cmdText
            var cmdText = "sp_select_shelterinventoryitem_by_shelterId";
            //cmd 
            var cmd = new SqlCommand(cmdText, conn);
            //cmd type
            cmd.CommandType = CommandType.StoredProcedure;
            //parameters
            cmd.Parameters.Add("@ShelterId", SqlDbType.Int);
            //Value
            cmd.Parameters["@ShelterId"].Value = shelterId;
            //try-catch
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var shelterInventoryItemVM = new ShelterInventoryItemVM();

                        shelterInventoryItemVM.ShelterId = reader.GetInt32(0);
                        shelterInventoryItemVM.ItemId = reader.GetString(1);
                        shelterInventoryItemVM.Quantity = reader.GetInt32(2);
                        shelterInventoryItemVM.UseStatistic = reader.IsDBNull(3) ? null : (decimal?)reader.GetDecimal(3);
                        shelterInventoryItemVM.LastUpdated = reader.GetDateTime(4);
                        shelterInventoryItemVM.LowInventoryThreshold = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        shelterInventoryItemVM.HighInventoryThreshold = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                        shelterInventoryItemVM.InTransit = reader.GetBoolean(7);
                        shelterInventoryItemVM.Urgent = reader.GetBoolean(8);
                        shelterInventoryItemVM.Processing = reader.GetBoolean(9);
                        shelterInventoryItemVM.DoNotOrder = reader.GetBoolean(10);
                        shelterInventoryItemVM.CustomFlag = reader.IsDBNull(11) ? null : reader.GetString(11);
                        shelterInventoryItemVM.ShelterName = reader.GetString(12);

                        _shelterInventoryItemVMs.Add(shelterInventoryItemVM);

                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Could not retrieve inventory information", ex);
            }
            finally
            {
                conn.Close();
            }


            return _shelterInventoryItemVMs;
        }

        public ShelterInventoryItemVM SelectShelterInventoryItemByShelterIdAndItemId(int shelterId, string itemId)
        {
            ShelterInventoryItemVM _shelterInventoryItemVMs = new ShelterInventoryItemVM();

            //Connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            //cmdText
            var cmdText = "sp_select_shelterinventoryitem_by_shelterId_and_itemId";
            //cmd 
            var cmd = new SqlCommand(cmdText, conn);
            //cmd type
            cmd.CommandType = CommandType.StoredProcedure;
            //parameters
            cmd.Parameters.Add("@ShelterId", SqlDbType.Int);
            cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar, 50);
            //Value
            cmd.Parameters["@ShelterId"].Value = shelterId;
            cmd.Parameters["@ItemId"].Value = itemId;
            //try-catch
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var shelterInventoryItemVM = new ShelterInventoryItemVM();

                        shelterInventoryItemVM.ShelterId = reader.GetInt32(0);
                        shelterInventoryItemVM.ItemId = reader.GetString(1);
                        shelterInventoryItemVM.Quantity = reader.GetInt32(2);
                        shelterInventoryItemVM.UseStatistic = reader.IsDBNull(3) ? null : (decimal?)reader.GetDecimal(3);
                        shelterInventoryItemVM.LastUpdated = reader.GetDateTime(4);
                        shelterInventoryItemVM.LowInventoryThreshold = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        shelterInventoryItemVM.HighInventoryThreshold = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                        shelterInventoryItemVM.InTransit = reader.GetBoolean(7);
                        shelterInventoryItemVM.Urgent = reader.GetBoolean(8);
                        shelterInventoryItemVM.Processing = reader.GetBoolean(9);
                        shelterInventoryItemVM.DoNotOrder = reader.GetBoolean(10);
                        shelterInventoryItemVM.CustomFlag = reader.IsDBNull(11) ? null : reader.GetString(11);
                        shelterInventoryItemVM.ShelterName = reader.GetString(12);

                        _shelterInventoryItemVMs = shelterInventoryItemVM;

                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Could not retrieve inventory information", ex);
            }
            finally
            {
                conn.Close();
            }


            return _shelterInventoryItemVMs;
        }

        public int UpdateShelterInventoryItem(ShelterInventoryItemVM oldShelterInventoryItemVM, ShelterInventoryItemVM newShelterInventoryItemVM)
        {
            int rows;
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_update_shelterInventoryItem";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ShelterId", newShelterInventoryItemVM.ShelterId);
            cmd.Parameters.AddWithValue("@ItemId", newShelterInventoryItemVM.ItemId);
            cmd.Parameters.AddWithValue("@Quantity", newShelterInventoryItemVM.Quantity);
            cmd.Parameters.AddWithValue("@UseStatistic", newShelterInventoryItemVM.UseStatistic);
            cmd.Parameters.AddWithValue("@LastUpdated", newShelterInventoryItemVM.LastUpdated);
            cmd.Parameters.AddWithValue("@LowInventoryThreshold", newShelterInventoryItemVM.LowInventoryThreshold);
            cmd.Parameters.AddWithValue("@HighInventoryThreshold", newShelterInventoryItemVM.HighInventoryThreshold);
            cmd.Parameters.AddWithValue("@InTransit", newShelterInventoryItemVM.InTransit);
            cmd.Parameters.AddWithValue("@Urgent", newShelterInventoryItemVM.Urgent);
            cmd.Parameters.AddWithValue("@Processing", newShelterInventoryItemVM.Processing);
            cmd.Parameters.AddWithValue("@DoNotOrder", newShelterInventoryItemVM.DoNotOrder);
            cmd.Parameters.AddWithValue("@CustomFlag", newShelterInventoryItemVM.CustomFlag);

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
    }
}
