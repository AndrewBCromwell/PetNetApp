using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DonationAccessor : IDonationAccessor
    {
        public List<DonationVM> SelectAllDonations()
        {
            List<DonationVM> donationVMs = new List<DonationVM>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_all_donations";
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
                        DonationVM donation = new DonationVM();
                        UsersVM user = new UsersVM();

                        donation.DonationId = reader.GetInt32(0);
                        donation.UserId = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
                        user.GivenName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        user.FamilyName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        donation.ShelterId = reader.GetInt32(4);
                        donation.Amount = reader.IsDBNull(5) ? null : (decimal?)reader.GetDecimal(5);
                        donation.Message = reader.IsDBNull(6) ? null : reader.GetString(6);
                        donation.DateDonated = reader.IsDBNull(7) ? null : (DateTime?)reader.GetDateTime(7);
                        donation.GivenName = reader.IsDBNull(8) ? null : reader.GetString(8);
                        donation.FamilyName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        donation.HasInKindDonation = reader.GetBoolean(10);
                        donation.Anonymous = reader.GetBoolean(11);
                        donation.Target = reader.IsDBNull(12) ? null : reader.GetString(12);
                        donation.PaymentMethod = reader.IsDBNull(13) ? null : reader.GetString(13);
                        donation.ScheduledDonationId = reader.IsDBNull(14) ? null : (int?)reader.GetInt32(14);
                        donation.FundraisingEventId = reader.IsDBNull(15) ? null : (int?)reader.GetInt32(15);
                        donation.ShelterName = reader.GetString(16);
                        donation.User = user;

                        donationVMs.Add(donation);
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

            return donationVMs;
        }

        public DonationVM SelectDonationByDonationId(int donationID)
        {
            DonationVM donation = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_donation_by_donationId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DonationId", donationID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        donation = new DonationVM();
                        UsersVM user = new UsersVM();

                        donation.DonationId = reader.GetInt32(0);
                        donation.UserId = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
                        user.GivenName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        user.FamilyName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        donation.ShelterId = reader.GetInt32(4);
                        donation.Amount = reader.IsDBNull(5) ? null : (decimal?)reader.GetDecimal(5);
                        donation.Message = reader.IsDBNull(6) ? null : reader.GetString(6);
                        donation.DateDonated = reader.IsDBNull(7) ? null : (DateTime?)reader.GetDateTime(7);
                        donation.GivenName = reader.IsDBNull(8) ? null : reader.GetString(8);
                        donation.FamilyName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        donation.HasInKindDonation = reader.GetBoolean(10);
                        donation.Anonymous = reader.GetBoolean(11);
                        donation.Target = reader.IsDBNull(12) ? null : reader.GetString(12);
                        donation.PaymentMethod = reader.IsDBNull(13) ? null : reader.GetString(13);
                        donation.ScheduledDonationId = reader.IsDBNull(14) ? null : (int?)reader.GetInt32(14);
                        donation.FundraisingEventId = reader.IsDBNull(15) ? null : (int?)reader.GetInt32(15);
                        donation.User = user;
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

            return donation;
        }

        public List<DonationVM> SelectDonationsByShelterId(int ShelterId)
        {
            List<DonationVM> donationVMs = new List<DonationVM>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_donations";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShelterId", ShelterId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DonationVM donation = new DonationVM();
                        UsersVM user = new UsersVM();

                        donation.DonationId = reader.GetInt32(0);
                        donation.UserId = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
                        user.GivenName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        user.FamilyName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        donation.ShelterId = reader.GetInt32(4);
                        donation.Amount = reader.IsDBNull(5) ? null : (decimal?)reader.GetDecimal(5);
                        donation.Message = reader.IsDBNull(6) ? null : reader.GetString(6);
                        donation.DateDonated = reader.IsDBNull(7) ? null : (DateTime?)reader.GetDateTime(7);
                        donation.GivenName = reader.IsDBNull(8) ? null : reader.GetString(8);
                        donation.FamilyName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        donation.HasInKindDonation = reader.GetBoolean(10);
                        donation.Anonymous = reader.GetBoolean(11);
                        donation.Target = reader.IsDBNull(12) ? null : reader.GetString(12);
                        donation.PaymentMethod = reader.IsDBNull(13) ? null : reader.GetString(13);
                        donation.ScheduledDonationId = reader.IsDBNull(14) ? null : (int?)reader.GetInt32(14);
                        donation.FundraisingEventId = reader.IsDBNull(15) ? null : (int?)reader.GetInt32(15);
                        donation.User = user;

                        donationVMs.Add(donation);
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

            return donationVMs;
        }

        public List<InKind> SelectInKindsByDonationId(int donationId)
        {
            List<InKind> inKinds = new List<InKind>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_inkind_donations_by_donationId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DonationId", donationId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        InKind inKind = new InKind();

                        inKind.InKindId = reader.GetInt32(0);
                        inKind.DonationId = reader.GetInt32(1);
                        inKind.Description = reader.GetString(2);
                        inKind.Quanity = reader.GetInt32(3);
                        inKind.Target = reader.IsDBNull(4) ? null : reader.GetString(4);
                        inKind.Recieved = reader.GetBoolean(5);

                        inKinds.Add(inKind);
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
            return inKinds;
        }

        public List<DonationVM> SelectDonationsByEventId(int eventId)
        {

            List<DonationVM> donationVMs = new List<DonationVM>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_donations_by_event_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FundraisingEventId", eventId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DonationVM donation = new DonationVM();
                        UsersVM user = new UsersVM();

                        donation.DonationId = reader.GetInt32(0);
                        donation.UserId = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
                        user.GivenName = reader.IsDBNull(2) ? null : reader.GetString(2);
                        user.FamilyName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        donation.ShelterId = reader.GetInt32(4);
                        donation.Amount = reader.IsDBNull(5) ? null : (decimal?)reader.GetDecimal(5);
                        donation.Message = reader.IsDBNull(6) ? null : reader.GetString(6);
                        donation.DateDonated = reader.IsDBNull(7) ? null : (DateTime?)reader.GetDateTime(7);
                        donation.GivenName = reader.IsDBNull(8) ? null : reader.GetString(8);
                        donation.FamilyName = reader.IsDBNull(9) ? null : reader.GetString(9);
                        donation.HasInKindDonation = reader.GetBoolean(10);
                        donation.Anonymous = reader.GetBoolean(11);
                        donation.Target = reader.IsDBNull(12) ? null : reader.GetString(12);
                        donation.PaymentMethod = reader.IsDBNull(13) ? null : reader.GetString(13);
                        donation.ScheduledDonationId = reader.IsDBNull(14) ? null : (int?)reader.GetInt32(14);
                        donation.FundraisingEventId = reader.IsDBNull(15) ? null : (int?)reader.GetInt32(15);
                        donation.User = user;

                        donationVMs.Add(donation);
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

            return donationVMs;
        }

        public decimal SelectSumDonationsByEventId(int eventId)
        {
            decimal donationTotal = 0.00m;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_sum_donation_amount_by_event_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FundraisingEventId", eventId);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteScalar();
                donationTotal = (decimal)reader;

            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return donationTotal;
        }
    }
}
