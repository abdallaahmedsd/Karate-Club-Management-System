﻿using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    public static class clsBeltRankDataAccess
    {
        public static int AddBeltRank(string title, decimal fees)
        {
            int newRankID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_BeltRanks_Add", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Fees", fees);

                        SqlParameter newRankIDParameter = new SqlParameter("@NewRankID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(newRankIDParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newRankID = (int)command.Parameters["@NewRankID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in BeltRank's Class: " + ex.Message);
            }

            return newRankID;
        }

        public static bool UpdateBeltRank(int rankID, string title, decimal fees)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_BeltRanks_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RankID", rankID);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Fees", fees);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in BeltRank's Class: " + ex.Message);
            }

            return success;
        }

        public static bool FindBeltRankByID(int rankID, ref string title, ref decimal fees)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_BeltRanks_FindByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RankID", rankID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                title = reader["Title"].ToString();
                                fees = (decimal)reader["Fees"];
                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in BeltRank's Class: " + ex.Message);
            }

            return isFound;
        }

        public static bool DeleteBeltRank(int rankID)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_BeltRanks_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RankID", rankID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in BeltRank's Class: " + ex.Message);
            }

            return success;
        }

        public static DataTable GetAllBeltRanks()
        {
            DataTable dtBeltRanks = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_BeltRanks_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dtBeltRanks);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in BeltRank's Class: " + ex.Message);
            }

            return dtBeltRanks;
        }
    }

}
