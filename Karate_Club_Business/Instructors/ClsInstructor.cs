using Karate_Club_Data_Access.Instructors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Karate_Club_Business.Instructors
{
	public class ClsInstructor : clsPerson
	{
		public int? InstructorID { get; set; }
        public byte  YearsOfExperience { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedByUserID { get; set; }
		public clsUser UserInfo { get; set; }
        public List<ClsQualification> Qualifications { get; set; } = new List<ClsQualification>();
		public List<ClsSpecialization> Specializations { get; set; } = new List<ClsSpecialization>();
		public new enum enMode : byte { add_new_mode, update_mode }
		public new enMode Mode { get; set; }

		private ClsInstructor(int personID, string firstName, string lastName, char gender, DateTime birthdate, string phone, string email, string address,
				string imagePath, int memberID, int currentBeltRankID, int emergencyContactID, int subscriptionID, bool isActive)
				: base(personID, firstName, lastName, gender, birthdate, phone, email, address, imagePath)
		{
			InstructorID = memberID;
			IsActive = isActive;
			Mode = enMode.update_mode;
		}

		public ClsInstructor()
		{
			Mode = enMode.add_new_mode;
		}

		public new bool Save()
		{
			switch (Mode)
			{
				case enMode.add_new_mode:
					if (_Add())
					{
						Mode = enMode.update_mode;
						return true;
					}
					return false;
				case enMode.update_mode:
					return _Update();
				default:
					return false;
			}
		}

		public static new ClsInstructor Find(int memberID)
		{
			//int personID = -1, currentBeltRankID = -1, emergencyContactID = -1, subscriptionID = -1;
			//string fName = null, lName = null, phone = null, email = null, address = null, imagePath = null;
			//DateTime birthdate = DateTime.Now;
			//char gender = ' ';
			//bool isActive = true, isFound = false;


			//isFound = InstructorDataAccess.FindInstructorByID(memberID, ref personID, ref fName, ref lName, ref gender, ref birthdate, ref phone, ref email, ref address,
			//											ref imagePath, ref currentBeltRankID, ref emergencyContactID, ref subscriptionID, ref isActive);

			//if (isFound)
			//	return new ClsInstructor(personID, fName, lName, gender, birthdate, phone, email, address, imagePath,
			//							memberID, currentBeltRankID, emergencyContactID, subscriptionID, isActive);
			//else
			//	return null;
			throw new NotImplementedException();
		}

		public static bool Activate(int memberID) => throw new NotImplementedException();

		public static bool Deactivate(int memberID) => throw new NotImplementedException();

		public static bool DeletePermanently(int memberID) => throw new NotImplementedException();

		public static DataTable GetAllInstructors()
		{
			throw new NotImplementedException();
		}

		public static async Task<DataTable> GetInstructorsPerPageAsync(ushort pageNumber, uint rowsPerPage)
		{
			throw new NotImplementedException();
		}

		public static uint Count()
		{
			throw new NotImplementedException();
		}

		private bool _Add()
		{
			InstructorID = InstructorDataAccess.Add(FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath,
														_qualificationIDs, _specializationsIDs, YearsOfExperience, IsActive);

			return InstructorID.HasValue;
		}

		private bool _Update()
		{
			throw new NotImplementedException();
		}

		private List<int> _qualificationIDs
		{
			get
			{
				List<int> ids = new List<int>();
				foreach (var qualification in Qualifications)
					ids.Add(qualification.QualificationID);

				return ids;
			}
		}

		private List<int> _specializationsIDs
		{
			get
			{
				List<int> ids = new List<int>();
				foreach (var specialization in Specializations)
					ids.Add(specialization.SpecializationID);

				return ids;
			}
		}
	}
}