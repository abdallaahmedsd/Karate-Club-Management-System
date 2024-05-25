using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    public static class clsEmergencyContactsDataAccess
    {
        public static int AddEmergencyContact(string name, string phone, string email)
        {
            int newEmergencyContactID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_EmergencyContacts_Add", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : (object)email);

                        SqlParameter newEmergencyContactIDParameter = new SqlParameter("@NewEmergencyContactID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(newEmergencyContactIDParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newEmergencyContactID = Convert.ToInt32(newEmergencyContactIDParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in EmergencyContact's Class: " + ex.Message);
            }

            return newEmergencyContactID;
        }

        public static bool UpdateEmergencyContact(int emergencyContactID, string name, string phone, string email)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_EmergencyContacts_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmergencyContactID", emergencyContactID);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : (object)email);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // If one or more rows were affected, consider the update successful
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in EmergencyContact's Class: " + ex.Message);
            }

            return success;
        }

        public static bool DeleteEmergencyContact(int emergencyContactID)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_EmergencyContacts_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmergencyContactID", emergencyContactID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // If one or more rows were affected, consider the update successful
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in EmergencyContact's Class: " + ex.Message);
            }

            return success;
        }

        public static bool FindEmergencyContactByID(int emergencyContactID, ref string name, ref string phone, ref string email)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_EmergencyContacts_FindByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmergencyContactID", emergencyContactID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                name = reader["Name"].ToString();
                                phone = reader["Phone"].ToString();
                                email = reader["Email"].ToString();
                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in EmergencyContact's Class: " + ex.Message);
            }

            return isFound;
        }

        public static DataTable GetAllEmergencyContacts()
        {
            DataTable dtEmergencyContacts = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_EmergencyContacts_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtEmergencyContacts.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in EmergencyContact's Class: " + ex.Message);
            }

            return dtEmergencyContacts;
        }
    }

}
