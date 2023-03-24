using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class RequestAccessor : IRequestAccessor
    {
        public List<RequestVM> SelectRequestsByShelterSentTo(int ShelterId)
        {
            List<RequestVM> requests = new List<RequestVM>();

            var conn = new DBConnection().GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_request_by_shelter_sent_to", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@shelterid", SqlDbType.Int).Value = ShelterId;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RequestVM request = new RequestVM();
                        request.RequestId = reader.GetInt32(0);
                        request.RecievingShelterId = reader.GetInt32(1);
                        request.RequestedByUserId = reader.GetInt32(2);
                        request.GivenName = reader.GetString(3);
                        request.FamilyName = reader.GetString(4);
                        request.RequestingShelterName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        request.RequestDate = reader.GetDateTime(6);
                        request.Acknowledged = reader.GetBoolean(7);
                        requests.Add(request);
                    }
                }
                reader.Close();

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return requests;
        }

        public RequestVM SelectRequestResourceLinesByRequestId(RequestVM request)
        {
            List<RequestResourceLine> lines = new List<RequestResourceLine>();

            var conn = new DBConnection().GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_RequestResourceLine_by_RequestId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = request.RequestId;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RequestResourceLine line = new RequestResourceLine();
                        line.RequestId = reader.GetInt32(0);
                        line.ItemId = reader.GetString(1);
                        line.QuantityRequested = reader.GetInt32(2);
                        line.QuantityAvailable = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        line.Notes = reader.GetString(4);
                        lines.Add(line);
                    }
                }
                reader.Close();
                request.RequestLines = lines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return request;
        }
    }
}
