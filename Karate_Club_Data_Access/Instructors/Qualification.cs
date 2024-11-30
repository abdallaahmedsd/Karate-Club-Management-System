using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access.Instructors
{
	public class QualificationDataAccess
	{
		public static int? Add(string title)
		{
			int? newQualificationID = null;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Qualifications_Add", connection))
					{
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddWithValue("@Title", title);

						SqlParameter newQualificationIDParameter = new SqlParameter("@NewQualificationID", SqlDbType.Int)
						{
							Direction = ParameterDirection.Output
						};
						command.Parameters.Add(newQualificationIDParameter);

						connection.Open();
						command.ExecuteNonQuery();

						newQualificationID = command.Parameters["@NewQualificationID"].Value as int?;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in Qualification's Class: " + ex.Message);
			}

			return newQualificationID;
		}

		public static bool Update(int qualificationID, string title)
		{
			bool success = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Qualifications_Update", connection))
					{
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddWithValue("@QualificationID", qualificationID);
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
				ErrorsLogger.LogError("An error occur in Qualification's Class: " + ex.Message);
			}

			return success;
		}

		public static bool FindByID(int qualificationID, ref string title)
		{
			bool isFound = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Qualifications_FindByID", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@QualificationID", qualificationID);

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
				ErrorsLogger.LogError("An error occur in Qualification's Class: " + ex.Message);
			}

			return isFound;
		}

		public static bool Delete(int qualificationID)
			=> DataAccessHelper.Delete(qualificationID, "QualificationID", "SP_Qualifications_Delete");

		public static DataTable GetAll()
			=> DataAccessHelper.All("SP_Qualifications_GetAll");
	}
}
