using System;
using System.Data;
using System.Data.SqlClient;

namespace Karate_Club_Data_Access
{
    public static class clsPaymentDataAccess
    {
        public static int AddPayment(decimal amount, int memberID, DateTime date, int? createdByUserID)
        {
            int newPaymentID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_Add", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)createdByUserID ?? DBNull.Value);

                        SqlParameter newPaymentIDParameter = new SqlParameter("@NewPaymentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(newPaymentIDParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newPaymentID = (int)command.Parameters["@NewPaymentID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occurred in PaymentDataAccess.AddPayment: " + ex.Message);
            }

            return newPaymentID;
        }

        public static bool UpdatePayment(int paymentID, decimal amount, int memberID, DateTime date)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", paymentID);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.Parameters.AddWithValue("@Date", date);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occurred in PaymentDataAccess.UpdatePayment: " + ex.Message);
            }

            return success;
        }

        public static bool FindPaymentByID(int paymentID, ref decimal amount, ref int memberID, ref DateTime date, ref int? createdByUserID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_FindByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                amount = (decimal)reader["Amount"];
                                memberID = (int)reader["MemberID"];
                                date = (DateTime)reader["Date"];
                                createdByUserID = reader["CreatedByUserID"] as int?;
                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occurred in PaymentDataAccess.FindPaymentByID: " + ex.Message);
            }

            return isFound;
        }

        public static bool DeletePayment(int paymentID)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occurred in PaymentDataAccess.DeletePayment: " + ex.Message);
            }

            return success;
        }

        public static DataTable GetAllPayments()
        {
            DataTable paymentsTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            paymentsTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorsLogger.LogError("An error occurred in PaymentDataAccess.GetAllPayments: " + ex.Message);
            }

            return paymentsTable;
        }
    }

}
