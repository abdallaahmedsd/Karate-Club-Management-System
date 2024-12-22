using Karate_Club_Data_Access.Instructors;
using System.Data;

namespace Karate_Club_Business.Instructors
{
	public class ClsSpecialization
	{
		public int SpecializationID { get; set; }
		public string Title { get; set; }
		public ClsSpecialization() { }

		public static DataTable GetAll() => SpecializationDataAccess.GetAll();
	}
}