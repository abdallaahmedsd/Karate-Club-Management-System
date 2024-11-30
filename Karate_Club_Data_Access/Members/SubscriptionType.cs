using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access.Members
{
	public static class SubscriptionTypeDataAccess
	{
		public static int? AddSubscriptionType(int periodLength, string periodUnit, decimal fees)
		{
			int? newSubscriptionTypeID = null;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_SubscriptionTypes_Add", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@PeriodLength", periodLength);
						command.Parameters.AddWithValue("@PeriodUnit", periodUnit);
						command.Parameters.AddWithValue("@Fees", fees);

						SqlParameter newSubscriptionTypeIDParameter = new SqlParameter("@NewSubscriptionTypeID", SqlDbType.Int)
						{
							Direction = ParameterDirection.Output
						};
						command.Parameters.Add(newSubscriptionTypeIDParameter);

						connection.Open();
						command.ExecuteNonQuery();

						newSubscriptionTypeID = command.Parameters["@NewSubscriptionTypeID"].Value as int?;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in SubscriptionType's Class: " + ex.Message);
			}

			return newSubscriptionTypeID;
		}

		public static bool UpdateSubscriptionType(int? subscriptionTypeID, int periodLength, string periodUnit, decimal fees)
		{
			bool success = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_SubscriptionTypes_Update", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@SubscriptionTypeID", subscriptionTypeID);
						command.Parameters.AddWithValue("@PeriodLength", periodLength);
						command.Parameters.AddWithValue("@PeriodUnit", periodUnit);
						command.Parameters.AddWithValue("@Fees", fees);

						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();

						success = rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in SubscriptionType's Class: " + ex.Message);
			}

			return success;
		}

		public static bool FindSubscriptionTypeByID(int? subscriptionTypeID, ref int periodLength, ref string periodUnit, ref decimal fees)
		{
			bool isFound = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_SubscriptionTypes_FindByID", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@SubscriptionTypeID", subscriptionTypeID);

						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								periodLength = (int)reader["PeriodLength"];
								periodUnit = reader["PeriodUnit"].ToString();
								fees = (decimal)reader["Fees"];
								isFound = true;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in SubscriptionType's Class: " + ex.Message);
			}

			return isFound;
		}

		public static bool DeleteSubscriptionType(int subscriptionTypeID)
			=> DataAccessHelper.Delete(subscriptionTypeID, "SubscriptionTypeID", "SP_SubscriptionTypes_Delete");

		public static DataTable GetAllSubscriptionTypes() => DataAccessHelper.All("SP_SubscriptionTypes_GetAll");
	}
}