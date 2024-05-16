using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    public static class clsPersonDataAccess
    {
        public static int AddPerson(string firstName, string lastName, char gender, DateTime? birthdate,
                                        string phone, string email, string address, string imagePath, int? createdByUserID)
        {
            int newPersonID = -1;

            try
            {
                // Create SqlConnection object within a using statement
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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

                        // Handle nullable fields
                        command.Parameters.AddWithValue("@Birthdate", birthdate.HasValue ? (object)birthdate : DBNull.Value);
                        if (!string.IsNullOrWhiteSpace(email))
                            command.Parameters.AddWithValue("@Email", email);
                        else
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        if (!string.IsNullOrWhiteSpace(imagePath))
                            command.Parameters.AddWithValue("@ImagePath", imagePath);
                        else
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

                        // handle it later
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID.HasValue ? (object)createdByUserID : DBNull.Value);


                        // Add output parameter for the new person ID
                        SqlParameter newPersonIDParameter = new SqlParameter("@NewPersonID", SqlDbType.Int);
                        newPersonIDParameter.Direction = ParameterDirection.Output;
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
                // log the errors later on
            }
            return newPersonID;
        }

        public static bool UpdatePerson(int personID, string firstName, string lastName, char gender, DateTime? birthdate,
                                            string phone, string email, string address, string imagePath)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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

                        // Handle nullable fields
                        command.Parameters.AddWithValue("@Birthdate", birthdate.HasValue ? (object)birthdate : DBNull.Value);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)email : DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrWhiteSpace(imagePath) ? (object)imagePath : DBNull.Value);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // If one or more rows were affected, consider the update successful
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // log the exception later on
            }

            return success;
        }

        public static bool GetPersonByID(int personID, ref string firstName, ref string lastName, ref char gender, ref DateTime? birthdate,
                                    ref string phone, ref string email, ref string address, ref string imagePath, ref int? createdByUserID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                                birthdate = reader["Birthdate"] as DateTime?;
                                phone = reader["Phone"].ToString();
                                email = reader["Email"].ToString();
                                address = reader["Address"].ToString();
                                imagePath = reader["ImagePath"].ToString();
                                createdByUserID = reader["CreatedByUserID"] as int?;

                                isFound = true; // Set to true as a row is found
                            }
                        } // SqlDataReader is disposed here automatically
                    }
                }
            }
            catch (Exception ex)
            {
                // log it later
            }

            return isFound;
        }

        public static bool DeletePerson(int personID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_People_DeletePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for PersonID
                        command.Parameters.AddWithValue("@PersonID", personID);

                        // Add output parameter for rows affected
                        SqlParameter rowsAffectedParameter = new SqlParameter("@RowsAffected", SqlDbType.Int);
                        rowsAffectedParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(rowsAffectedParameter);

                        // Open connection and execute the command within the same using statement
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the number of rows affected from the output parameter
                        if (rowsAffectedParameter.Value != DBNull.Value)
                        {
                            rowsAffected = Convert.ToInt32(rowsAffectedParameter.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions/log errors
            }

            return rowsAffected > 0;
        }

        public static bool IsPersonExists(int personID)
        {
            bool personExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_People_IsPersonExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for PersonID
                        command.Parameters.AddWithValue("@PersonID", personID);

                        // Add output parameter for person existence
                        SqlParameter personExistsParameter = new SqlParameter("@PersonExists", SqlDbType.Bit);
                        personExistsParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(personExistsParameter);

                        // Open connection and execute the command within the same using statement
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the value of the output parameter
                        if (personExistsParameter.Value != DBNull.Value)
                        {
                            personExists = Convert.ToBoolean(personExistsParameter.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions/log errors
            }

            return personExists;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();

            try
            {
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    // Create a SqlCommand object with the stored procedure name
                    using (SqlCommand command = new SqlCommand("SP_People_GetAll", connection))
                    {
                        // Set the command type as stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Open the connection
                        connection.Open();

                        // Create a SqlDataReader to execute the command and fill the DataTable
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtPeople.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log, or throw them as needed later on
            }

            return dtPeople;
        }

    }
}
