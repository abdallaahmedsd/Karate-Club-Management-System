using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    public static class clsMemberDataAccess
    {
        public static int AddMember(string personFirstName, string personLastName, char personGender, DateTime? personBirthdate, string personPhone,
            string personEmail, string personAddress, string personImagePath, int? createdByUserID, string emergencyContactName, string emergencyContactPhone,
            string emergencyContactEmail, int memberCurrentBeltRankID, bool memberIsActive)
        {
            int newMemberID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Members_Add", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //**********************************  For people table  **********************************\\
                        command.Parameters.AddWithValue("@PersonFirstName", personFirstName);
                        command.Parameters.AddWithValue("@PersonLastName", personLastName);
                        command.Parameters.AddWithValue("@PersonGender", personGender);
                        command.Parameters.AddWithValue("@PersonAddress", personAddress);
                        command.Parameters.AddWithValue("@PersonPhone", personPhone);
                        // Handle nullable fields
                        command.Parameters.AddWithValue("@PersonBirthdate", personBirthdate.HasValue ? (object)personBirthdate : DBNull.Value);
                        command.Parameters.AddWithValue("@PersonEmail", string.IsNullOrWhiteSpace(personEmail) ? DBNull.Value : (object)personEmail);
                        command.Parameters.AddWithValue("@PersonImagePath", string.IsNullOrWhiteSpace(personImagePath) ? DBNull.Value : (object)personImagePath);
                        // handle it later
                        command.Parameters.AddWithValue("@PersonCreatedByUserID", createdByUserID.HasValue ? (object)createdByUserID : DBNull.Value);

                        //**********************************  For EmergencyContacts table  **********************************\\
                        command.Parameters.AddWithValue("@EmergencyContactName", emergencyContactName);
                        command.Parameters.AddWithValue("@EmergencyContactPhone", emergencyContactPhone);
                        command.Parameters.AddWithValue("@EmergencyContactEmail", string.IsNullOrWhiteSpace(emergencyContactEmail) ? DBNull.Value : (object)emergencyContactEmail);

                        //**********************************  For Members table  //**********************************\\
                        command.Parameters.AddWithValue("@MemberCurrentBeltRankID", memberCurrentBeltRankID);
                        command.Parameters.AddWithValue("@MemberIsActive", memberIsActive);

                        SqlParameter newMemberIDParameter = new SqlParameter("@NewMemberID", SqlDbType.Int);
                        newMemberIDParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(newMemberIDParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newMemberID = (int)command.Parameters["@NewMemberID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return newMemberID;
        }

        public static bool UpdateMember(int memberID, int personID, int currentBeltRankID, int emergencyContactID, bool isActive)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Members_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@CurrentBeltRankID", currentBeltRankID);
                        command.Parameters.AddWithValue("@EmergencyContactID", emergencyContactID);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return success;
        }

        public static bool FindMemberByID(int memberID, ref int personID, ref int currentBeltRankID, ref int emergencyContactID, ref int subscriptionID, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Members_FindByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", memberID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personID = (int)reader["PersonID"];
                                currentBeltRankID = (int)reader["CurrentBeltRankID"];
                                emergencyContactID = (int)reader["EmergencyContactID"];
                                subscriptionID = (int)reader["SubscriptionID"];
                                isActive = (bool)reader["IsActive"];
                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return isFound;
        }

        public static bool DeleteMember(int memberID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Members_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", memberID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllMembers()
        {
            DataTable dtMembers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Members_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtMembers.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return dtMembers;
        }

        public static DataTable GetMembersPerPage(ushort pageNumber, uint rowsPerPage)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Members_GetMembersPerPage", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PageNumber", SqlDbType.Int) { Value = pageNumber });
                        command.Parameters.Add(new SqlParameter("@RowsPerPage", SqlDbType.Int) { Value = rowsPerPage });

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return dataTable;
        }

        public static uint GetTotalMemberCount()
        {
            int totalMembers = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Members_GetTotalCount", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        // Execute the command and get the total members count
                        totalMembers = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Memeber's Class: " + ex.Message);
            }

            return (uint)totalMembers;
        }
    }
}
