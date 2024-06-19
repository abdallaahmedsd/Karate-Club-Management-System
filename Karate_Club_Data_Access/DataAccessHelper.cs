using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    internal static class clsDataAccessHelper
    {
        public static DataTable All(string storedProcedure)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError($"An error occured in {storedProcedure}: " + ex.Message);
            }

            return dt;
        }

        public static DataTable AllInPages(ushort pageNumber, uint rowsPerPage, string storedProcedure) 
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PageNumber", SqlDbType.Int) { Value = pageNumber });
                        command.Parameters.Add(new SqlParameter("@RowsPerPage", SqlDbType.Int) { Value = rowsPerPage });

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return dt;
        }

        public static bool Delete(int ID, string pramamterName, string storedProcedure)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@{pramamterName}", ID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError($"An error occured in {storedProcedure}: " + ex.Message);
                return false;
            }

            return rowsAffected > 0;
        }

        public static bool Deactivate(int ID, string pramamterName, string storedProcedure)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@{pramamterName}", ID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError($"An error occured in {storedProcedure}: " + ex.Message);
                return false;
            }

            return rowsAffected > 0;
        }

        public static bool Activate(int ID, string pramamterName, string storedProcedure)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@{pramamterName}", ID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError($"An error occured in {storedProcedure}: " + ex.Message);
                return false;
            }

            return rowsAffected > 0;
        }

        public static bool IsExists<T>(T pramamterValue, string pramamterName, string storedProcedure)
        {
            bool Exists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@{pramamterName}", pramamterValue);

                        SqlParameter ExistsParameter = new SqlParameter("@Exists", SqlDbType.Bit);
                        ExistsParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ExistsParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (ExistsParameter.Value != DBNull.Value)
                            Exists = Convert.ToBoolean(ExistsParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError($"An error occured in {storedProcedure}: " + ex.Message);
                return false;
            }

            return Exists;
        }

        public static uint Count(string storedProcedure)
        {
            uint totalMembers = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        // Execute the command and get the total members count
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            totalMembers = Convert.ToUInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError($"An error occurred in {storedProcedure}: " + ex.Message);
            }

            return totalMembers;
        }

    }
}
