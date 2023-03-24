/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Item Accessor
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
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ItemAccessor : IItemAccessor
    {
        public Item SelectItemByItemId(string ItemId)
        {
            Item item = new Item();
            List<string> categoryIds = new List<string>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            //command text
            var cmdText = "sp_select_categoryid_by_itemId";

            //command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;
            //parameter
            cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar, 50);

            //Value
            cmd.Parameters["@ItemId"].Value = ItemId;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        item.ItemId = reader.GetString(0);
                        categoryIds.Add(reader.GetString(1));
                        item.CategoryId = categoryIds;
                    }


                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Could not find Items", ex);
            }
            finally
            {
                conn.Close();
            }
            return item;

        }
    }
}
