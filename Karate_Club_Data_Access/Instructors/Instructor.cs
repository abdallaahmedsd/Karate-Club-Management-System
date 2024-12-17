using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
	}
}
