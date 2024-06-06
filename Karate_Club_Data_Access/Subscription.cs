using System;
using System.Data.SqlClient;
using System.Data;

namespace Karate_Club_Data_Access
{
    public static class clsSubscriptionDataAccess
    {
        public static int AddSubscription(int memberID, DateTime startDate, DateTime endDate, int subscriptionTypeID, decimal fees, int? createdByUserID)
        {
            int newSubscriptionID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Subscriptions_Add", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@SubscriptionTypeID", subscriptionTypeID);
                        command.Parameters.AddWithValue("@Fees", fees);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID.HasValue ? (object)createdByUserID : DBNull.Value);

                        SqlParameter newSubscriptionIDParameter = new SqlParameter("@NewSubscriptionID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(newSubscriptionIDParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newSubscriptionID = (int)command.Parameters["@NewSubscriptionID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Subscription's Data Access Layer: " + ex.Message);
            }

            return newSubscriptionID;
        }

        public static bool UpdateSubscription(int subscriptionID, int memberID, DateTime startDate, DateTime endDate, int subscriptionTypeID, decimal fees, int paymentID)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Subscriptions_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SubscriptionID", subscriptionID);
                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@SubscriptionTypeID", subscriptionTypeID);
                        command.Parameters.AddWithValue("@Feees", fees);
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Subscription's Data Access Layer: " + ex.Message);
            }

            return success;
        }

        public static bool FindSubscriptionByID(int subscriptionID, ref int memberID, ref DateTime startDate, ref DateTime endDate, ref int subscriptionTypeID, ref decimal fees, ref int paymentID, ref int? createdByUserID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Subscriptions_FindByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SubscriptionID", subscriptionID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                memberID = (int)reader["MemberID"];
                                startDate = (DateTime)reader["StartDate"];
                                endDate = (DateTime)reader["EndDate"];
                                subscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                paymentID = (int)reader["PaymentID"];
                                fees = (decimal)reader["Fees"];
                                createdByUserID = reader["CreatedByUserID"] as int?;
                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Subscription's Data Access Layer: " + ex.Message);
            }

            return isFound;
        }

        public static bool DeleteSubscription(int subscriptionID)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Subscriptions_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SubscriptionID", subscriptionID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Subscription's Data Access Layer: " + ex.Message);
            }

            return success;
        }

        public static DataTable GetAllSubscriptions()
        {
            DataTable dtSubscriptions = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Subscriptions_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dtSubscriptions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occur in Subscription's Data Access Layer: " + ex.Message);
            }

            return dtSubscriptions;
        }
    }
}