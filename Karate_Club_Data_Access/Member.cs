using System;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Security.Policy;

namespace Karate_Club_Data_Access
{
    public static class clsMemberDataAccess
    {
        public static int? AddMember(string personFirstName, string personLastName, char personGender, DateTime personBirthdate, string personPhone,
            string personEmail, string personAddress, string personImagePath, int? createdByUserID, string emergencyContactName, string emergencyContactPhone,
            string emergencyContactEmail, int memberCurrentBeltRankID, bool memberIsActive)
        {
            int? newMemberID = null;

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
                        command.Parameters.AddWithValue("@PersonBirthdate", personBirthdate);
                        // Handle nullable fields
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

                        newMemberID = command.Parameters["@NewMemberID"].Value as int?;
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

        public static bool FindMemberByID(int memberID, ref int personID, ref string personFirstName, ref string personLastName, ref char personGender,
                        ref DateTime personBirthdate, ref string personPhone,  ref string personEmail, ref string personAddress, ref string personImagePath,
                        ref int? createdByUserID, ref int currentBeltRankID, ref int emergencyContactID, ref int subscriptionID, ref bool isActive)
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
                                        if (reader.HasRows)
                                        {
                                            // Read first result set
                                            if (reader.Read())
                                            {
                                                personID = (int)reader["PersonID"];
                                                currentBeltRankID = (int)reader["CurrentBeltRankID"];
                                                emergencyContactID = (int)reader["EmergencyContactID"];
                                                subscriptionID = (int)reader["SubscriptionID"];
                                                isActive = (bool)reader["IsActive"];
                                            }

                                            // Read the seocnd result set
                                            reader.NextResult();
                                            if (reader.Read())
                                            {
                                                personFirstName = reader["FirstName"].ToString();
                                                personLastName = reader["LastName"].ToString();
                                                personGender = reader["Gender"].ToString()[0];
                                                personBirthdate = (DateTime)reader["Birthdate"];
                                                personPhone = reader["Phone"].ToString();
                                                personEmail = reader["Email"].ToString();
                                                personAddress = reader["Address"].ToString();
                                                personImagePath = reader["ImagePath"].ToString();
                                                createdByUserID = reader["CreatedByUserID"] as int?;

                                                isFound = true; // Set to true as a row is found
                                            }
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

        public static bool DeleteMember(int memberID) => clsDataAccessHelper.Delete(memberID, "MemberID", "SP_Members_Delete");
         

        public static DataTable GetAllMembers() => clsDataAccessHelper.All("SP_Members_GetAll");

        public static DataTable GetMembersPerPage(ushort pageNumber, uint rowsPerPage)
            => clsDataAccessHelper.AllInPages(pageNumber, rowsPerPage, "SP_Members_GetMembersPerPage");

        public static uint Count() => clsDataAccessHelper.Count("SP_Members_GetTotalCount");
    }
}
