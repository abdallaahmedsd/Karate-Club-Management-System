using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    public static class UserDataAccess
    {
        public static int AddUser(int personID, string userName, string password, bool isActive)
        {
            int newUserID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_AddUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        SqlParameter newUserIDParameter = new SqlParameter("@NewUserID", SqlDbType.Int);
                        newUserIDParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(newUserIDParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newUserID = (int)command.Parameters["@NewUserID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in User's Class: " + ex.Message);
            }

            return newUserID;
        }

        public static bool UpdateUser(int userID, int personID, string userName, string password, bool isActive)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in User's Class: " + ex.Message);
            }

            return success;
        }

        public static bool GetUserByID(int userID, ref int personID, ref string userName, ref string password, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_User_GetUserByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personID = (int)reader["PersonID"];
                                userName = reader["UserName"].ToString();
                                password = reader["Password"].ToString();
                                isActive = (bool)reader["IsActive"];

                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in User's Class: " + ex.Message);
            }

            return isFound;
        }

        public static bool DeleteUser(int userID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", userID);

                        SqlParameter rowsAffectedParameter = new SqlParameter("@RowsAffected", SqlDbType.Int);
                        rowsAffectedParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(rowsAffectedParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (rowsAffectedParameter.Value != DBNull.Value)
                        {
                            rowsAffected = Convert.ToInt32(rowsAffectedParameter.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in User's Class: " + ex.Message);
            }

            return rowsAffected > 0;
        }

        public static bool IsUserExists(int userID)
        {
            bool userExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_IsUserExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", userID);

                        SqlParameter userExistsParameter = new SqlParameter("@UserExists", SqlDbType.Bit);
                        userExistsParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(userExistsParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (userExistsParameter.Value != DBNull.Value)
                        {
                            userExists = Convert.ToBoolean(userExistsParameter.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in User's Class: " + ex.Message);
            }

            return userExists;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_User_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtUsers.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in User's Class: " + ex.Message);
            }

            return dtUsers;
        }

    }
}
