using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    public static class PersonDataAccess
    {
        public static int? AddPerson(string firstName, string lastName, char gender, DateTime birthdate,
                                        string phone, string email, string address, string imagePath)
        {
            int newPersonID = default;

            try
            {
                // Create SqlConnection object within a using statement
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    // Create SqlCommand object within a using statement
                    using (SqlCommand command = new SqlCommand("SP_People_AddPerson", connection))
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Birthdate", birthdate);

                        // Handle nullable fields
                        if (!string.IsNullOrWhiteSpace(email))
                            command.Parameters.AddWithValue("@Email", email);
                        else
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        if (!string.IsNullOrWhiteSpace(imagePath))
                            command.Parameters.AddWithValue("@ImagePath", imagePath);
                        else
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

                        // Add output parameter for the new person ID
                        SqlParameter newPersonIDParameter = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(newPersonIDParameter);

                        // Open connection and execute the command within the same using statement
                        connection.Open();

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Retrieve the new person ID from the output parameter
                        newPersonID = (int)command.Parameters["@NewPersonID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in Person's Class: " + ex.Message);
            }

            return newPersonID;
        }

        public static bool UpdatePerson(int? personID, string firstName, string lastName, char gender, DateTime birthdate,
                                            string phone, string email, string address, string imagePath)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_People_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Birthdate", birthdate);

                        // Handle nullable fields
                        command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@ImagePath", string.IsNullOrWhiteSpace(imagePath) ? DBNull.Value : (object)imagePath);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // If one or more rows were affected, consider the update successful
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in Person's Class: " + ex.Message);
            }

            return success;
        }

        public static bool GetPersonByID(int personID, ref string firstName, ref string lastName, ref char gender, ref DateTime birthdate,
                                    ref string phone, ref string email, ref string address, ref string imagePath)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_People_FindPersonByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for PersonID
                        command.Parameters.AddWithValue("@PersonID", personID);

                        // Execute the command
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if a row is returned
                            {
                                // Assign retrieved values to the ref parameters
                                firstName = reader["FirstName"].ToString();
                                lastName = reader["LastName"].ToString();
                                gender = reader["Gender"].ToString()[0];
                                birthdate = (DateTime)reader["Birthdate"];
                                phone = reader["Phone"].ToString();
                                email = reader["Email"].ToString();
                                address = reader["Address"].ToString();
                                imagePath = reader["ImagePath"].ToString();

                                isFound = true; // Set to true as a row is found
                            }
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorsLogger.LogError("An error occur in Person's Class: " + ex.Message);
            }

            return isFound;
        }

        public static bool DeletePerson(int personID) => DataAccessHelper.Delete(personID, "PersonID", "SP_People_DeletePerson");

        public static bool IsPersonExists(int personID) => DataAccessHelper.IsExists(personID, "PersonID", "SP_People_IsPersonExists");

        public static DataTable GetAllPeople() => DataAccessHelper.All("SP_People_GetAll");

    }
}
