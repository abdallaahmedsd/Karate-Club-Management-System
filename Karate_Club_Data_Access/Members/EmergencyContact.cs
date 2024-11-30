using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access.Members
{
	public static class clsEmergencyContactsDataAccess
	{
		public static int? AddEmergencyContact(string name, string phone, string email)
		{
			int? newEmergencyContactID = null;

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

						newEmergencyContactID = command.Parameters["@NewEmergencyContactID"].Value as int?;
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

		public static bool DeleteEmergencyContact(int emergencyContactID)
			=> clsDataAccessHelper.Delete(emergencyContactID, "EmergencyContactID", "SP_EmergencyContacts_Delete");

		public static DataTable GetAllEmergencyContacts()
			=> clsDataAccessHelper.All("SP_EmergencyContacts_GetAll");
	}
}