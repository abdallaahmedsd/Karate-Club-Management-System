using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Karate_Club_Data_Access.Instructors
{
	public static class InstructorDataAccess
	{
		public static int? Add(string personFirstName, string personLastName, char personGender, DateTime personBirthdate, string personPhone, string personEmail,
			string personAddress, string personImagePath, List<int> qualificationIDs, List<int> specializationIDs, byte instructorYearsOfExperience, bool instructorIsActive)
		{
			int? newInstructorID = null;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Instructors_Add", connection))
					{
						command.CommandType = CommandType.StoredProcedure;

						// **********************************  For People table  ********************************** \\
						command.Parameters.AddWithValue("@PersonFirstName", personFirstName);
						command.Parameters.AddWithValue("@PersonLastName", personLastName);
						command.Parameters.AddWithValue("@PersonGender", personGender);
						command.Parameters.AddWithValue("@PersonAddress", personAddress);
						command.Parameters.AddWithValue("@PersonPhone", personPhone);
						command.Parameters.AddWithValue("@PersonBirthdate", personBirthdate);

						// Handle nullable fields
						command.Parameters.AddWithValue("@PersonEmail", string.IsNullOrWhiteSpace(personEmail) ? DBNull.Value : (object)personEmail);
						command.Parameters.AddWithValue("@PersonImagePath", string.IsNullOrWhiteSpace(personImagePath) ? DBNull.Value : (object)personImagePath);

						// **********************************  For Qualifications TVP  ********************************** \\
						var tvpQualifications = new DataTable();
						tvpQualifications.Columns.Add("QualificationID", typeof(int));
						foreach (int qualificationID in qualificationIDs)
						{
							tvpQualifications.Rows.Add(qualificationID);
						}

						SqlParameter qualificationsParameter = command.Parameters.AddWithValue("@Qualifications", tvpQualifications);
						qualificationsParameter.SqlDbType = SqlDbType.Structured;
						qualificationsParameter.TypeName = "TVP_Qualifications";

						// **********************************  For Specializations TVP  ********************************** \\
						var tvpSpecializations = new DataTable();
						tvpSpecializations.Columns.Add("SpecializationID", typeof(int));
						foreach (int specializationID in specializationIDs)
						{
							tvpSpecializations.Rows.Add(specializationID);
						}

						SqlParameter specializationsParameter = command.Parameters.AddWithValue("@Specializations", tvpSpecializations);
						specializationsParameter.SqlDbType = SqlDbType.Structured;
						specializationsParameter.TypeName = "TVP_Specializations";

						// **********************************  For Instructors table  ********************************** \\
						command.Parameters.AddWithValue("@InstructorYearsOfExperience", instructorYearsOfExperience);
						command.Parameters.AddWithValue("@InstructorIsActive", instructorIsActive);

						// Output parameter for new Instructor ID
						SqlParameter newInstructorIDParameter = new SqlParameter("@NewInstructorID", SqlDbType.Int)
						{
							Direction = ParameterDirection.Output
						};
						command.Parameters.Add(newInstructorIDParameter);

						// Execute the command
						connection.Open();
						command.ExecuteNonQuery();

						newInstructorID = command.Parameters["@NewInstructorID"].Value as int?;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occurred in InstructorDataAccess.Add: " + ex.Message);
			}

			return newInstructorID;
		}

		public static bool Update(int instructorID, int personID, byte yearsOfExperience, bool isActive)
		{
			bool success = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Instructors_Update", connection))
					{
						command.CommandType = CommandType.StoredProcedure;

						command.Parameters.AddWithValue("@InstructorID", instructorID);
						command.Parameters.AddWithValue("@PersonID", personID);
						command.Parameters.AddWithValue("@YearsOfExperience", yearsOfExperience);
						command.Parameters.AddWithValue("@IsActive", isActive);

						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();

						success = rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occur in Instructor's Class: " + ex.Message);
			}

			return success;
		}

		public static bool FindByID(int instructorID, ref int personID, ref string personFirstName, ref string personLastName, ref char personGender,
			ref DateTime personBirthdate, ref string personPhone, ref string personEmail, ref string personAddress, ref string personImagePath,
			ref byte yearsOfExperience, ref int? createdByUserID, ref bool isActive, Dictionary<int, string> qualifications, Dictionary<int, string> specializations)
		{
			bool isFound = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
				{
					using (SqlCommand command = new SqlCommand("SP_Instructors_FindByID", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@InstructorID", instructorID);

						connection.Open();

						using (SqlDataReader reader = command.ExecuteReader())
						{
							// First Result Set: Instructor Info
							if (reader.HasRows && reader.Read())
							{
								personID = (int)reader["PersonID"];
								yearsOfExperience = (byte)reader["YearsOfExperience"];
								createdByUserID = reader["CreatedByUserId"] as int?;
								isActive = (bool)reader["IsActive"];
							}

							// Second Result Set: Personal Info
							if (reader.NextResult() && reader.HasRows && reader.Read())
							{
								personFirstName = reader["FirstName"].ToString();
								personLastName = reader["LastName"].ToString();
								personGender = reader["Gender"].ToString()[0];
								personBirthdate = (DateTime)reader["Birthdate"];
								personPhone = reader["Phone"].ToString();
								personEmail = reader["Email"].ToString();
								personAddress = reader["Address"].ToString();
								personImagePath = reader["ImagePath"].ToString();
							}

							// Third Result Set: Qualifications
							if (reader.NextResult() && reader.HasRows)
							{
								while (reader.Read())
								{
									qualifications.Add((int)reader["QualificationID"], reader["Title"].ToString());
								}
							}

							// Fourth Result Set: Specializations
							if (reader.NextResult() && reader.HasRows)
							{
								while (reader.Read())
								{
									specializations.Add((int)reader["SpecializationID"], reader["Title"].ToString());
								}
							}

							// Mark as found if all data was successfully processed
							isFound = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorsLogger.LogError("An error occurred in Instructor's Class: " + ex.Message);
			}

			return isFound;
		}

		public static async Task<DataTable> GetInstructorsPerPageAsync(ushort pageNumber, uint rowsPerPage)
			=> await DataAccessHelper.AllInPagesAsync(pageNumber, rowsPerPage, "SP_Instructors_GetInstructorsPerPage");

		public static uint Count() => DataAccessHelper.Count("SP_Instructors_GetTotalCount");
	}
}
