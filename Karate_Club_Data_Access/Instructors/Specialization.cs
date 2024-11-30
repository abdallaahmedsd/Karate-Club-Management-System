using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access.Instructors
{
	public class SpecializationDataAccess
	{
		public static int? Add(string title)
		{
			int? newSpecializationID = null;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Specializations_Add", connection))
					{
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddWithValue("@Title", title);

						SqlParameter newSpecializationIDParameter = new SqlParameter("@NewSpecializationID", SqlDbType.Int)
						{
							Direction = ParameterDirection.Output
						};
						command.Parameters.Add(newSpecializationIDParameter);

						connection.Open();
						command.ExecuteNonQuery();

						newSpecializationID = command.Parameters["@NewSpecializationID"].Value as int?;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in Specialization's Class: " + ex.Message);
			}

			return newSpecializationID;
		}

		public static bool Update(int specializationID, string title)
		{
			bool success = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Specializations_Update", connection))
					{
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddWithValue("@SpecializationID", specializationID);
						command.Parameters.AddWithValue("@Title", title);

						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();

						// If one or more rows were affected, consider the update successful
						success = rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in Specialization's Class: " + ex.Message);
			}

			return success;
		}

		public static bool FindByID(int specializationID, ref string title)
		{
			bool isFound = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Specializations_FindByID", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@SpecializationID", specializationID);

						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								title = reader["Title"].ToString();
								isFound = true;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in Specialization's Class: " + ex.Message);
			}

			return isFound;
		}

		public static bool Delete(int specializationID)
			=> DataAccessHelper.Delete(specializationID, "SpecializationID", "SP_Specializations_Delete");

		public static DataTable GetAll()
			=> DataAccessHelper.All("SP_Specializations_GetAll");
	}
}
