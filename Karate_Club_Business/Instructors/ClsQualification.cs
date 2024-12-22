using Karate_Club_Data_Access.Instructors;
using System.Data;

namespace Karate_Club_Business.Instructors
{
	public class ClsQualification
	{
		public int QualificationID { get; set; }
		public string Title { get; set; }
		public ClsQualification() { }

		public static DataTable GetAll() => QualificationDataAccess.GetAll();
	}
}