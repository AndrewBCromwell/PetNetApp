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
    public class ReplyAccessor : IReplyAccessor
    {
        public List<ReplyVM> SelectActiveRepliesByPostId(int postId)
        {
            List<ReplyVM> replies = new List<ReplyVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_active_replies_by_postid";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PostId", SqlDbType.NVarChar, 25).Value = postId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ReplyVM reply = new ReplyVM();

                        reply.ReplyId = reader.GetInt32(0);
                        reply.PostId = reader.GetInt32(1);
                        reply.ReplyAuthor = reader.GetInt32(2);
                        reply.ReplyContent = reader.GetString(3);
                        reply.ReplyDate = reader.GetDateTime(4);
                        reply.ReplyVisibility = reader.GetBoolean(5);
                        reply.ReplierGivenName = reader.GetString(6);
                        reply.ReplierFamilyName = reader.GetString(7);

                        replies.Add(reply);
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
            return replies;
        }

        public List<ReplyVM> SelectAllRepliesByPostId(int postId)
        {
            List<ReplyVM> replies = new List<ReplyVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_active_replies_by_postid";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PostId", SqlDbType.NVarChar, 25).Value = postId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ReplyVM reply = new ReplyVM();

                        reply.ReplyId = reader.GetInt32(0);
                        reply.PostId = reader.GetInt32(1);
                        reply.ReplyAuthor = reader.GetInt32(2);
                        reply.ReplyContent = reader.GetString(3);
                        reply.ReplyDate = reader.GetDateTime(4);
                        reply.ReplyVisibility = reader.GetBoolean(5);
                        reply.ReplierGivenName = reader.GetString(6);
                        reply.ReplierFamilyName = reader.GetString(7);

                        replies.Add(reply);
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
            return replies;
        }

        public int SelectCountActiveRepliesByPostId(int postId)
        {
            int repliesCount = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_count_active_replies_by_postId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PostId", SqlDbType.NVarChar, 25).Value = postId;

            try
            {
                conn.Open();
                repliesCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return repliesCount;
        }

        public int SelectCountRepliesByPostId(int postId)
        {
            int repliesCount = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_count_replies_by_postId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PostId", SqlDbType.NVarChar, 25).Value = postId;

            try
            {
                conn.Open();
                repliesCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return repliesCount;
        }
    }
}
