using Karate_Club_Data_Access.Instructors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

		private ClsInstructor(int personID, string firstName, string lastName, char gender, DateTime birthdate, string phone,
			string email, string address, string imagePath, int instructorID, byte yearsOfExperience, bool isActive,
			int? createdByUserID, List<ClsQualification> qualifications, List<ClsSpecialization> specializations)
				: base(personID, firstName, lastName, gender, birthdate, phone, email, address, imagePath)
		{
			InstructorID = instructorID;
			IsActive = isActive;
			CreatedByUserID = createdByUserID;
			Qualifications = qualifications;	
			Specializations = specializations;

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

		public static new ClsInstructor Find(int instructorID)
		{
			int personID = default;
			byte yearsOfExperience = default;
			int? createdByUserID = default;
			string fName = null, lName = null, phone = null, email = null, address = null, imagePath = null;
			DateTime birthdate = DateTime.Now;
			char gender = default;
			bool isActive = default, isFound = default;
			Dictionary<int, string> qualifications = new Dictionary<int, string>(), specializations = new Dictionary<int, string>();

			isFound = InstructorDataAccess.FindByID(instructorID, ref personID, ref fName, ref lName, ref gender, ref birthdate, ref phone, ref email, ref address,
														ref imagePath, ref yearsOfExperience, ref createdByUserID, ref isActive, qualifications, specializations);

			if (isFound)
			{
				List<ClsQualification> qualificationsList = qualifications.Select(qual => new ClsQualification()
				{
					QualificationID = qual.Key,
					Title = qual.Value,
				}).ToList();

				List<ClsSpecialization> specializationsList = specializations.Select(qual => new ClsSpecialization()
				{
					SpecializationID = qual.Key,
					Title = qual.Value,
				}).ToList();

				return new ClsInstructor(personID, fName, lName, gender, birthdate, phone, email, address, imagePath, instructorID,
					yearsOfExperience, isActive, createdByUserID, qualificationsList, specializationsList);
			}
			
			return null;
		}

		public static bool Activate(int instructorID) => throw new NotImplementedException();

		public static bool Deactivate(int instructorID) => throw new NotImplementedException();

		public static bool DeletePermanently(int instructorID) => throw new NotImplementedException();

		public static DataTable GetAllInstructors()
		{
			throw new NotImplementedException();
		}

		public static async Task<DataTable> GetInstructorsPerPageAsync(ushort pageNumber, uint rowsPerPage)
		{
			return await InstructorDataAccess.GetInstructorsPerPageAsync(pageNumber, rowsPerPage);
		}

		public static uint Count() => InstructorDataAccess.Count();

		private bool _Add()
		{
			InstructorID = InstructorDataAccess.Add(FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath,
														_qualificationIDs, _specializationsIDs, YearsOfExperience, IsActive);

			return InstructorID.HasValue;
		}

		private bool _Update()
		{
			return InstructorDataAccess.Update(InstructorID.Value, PersonID.Value, YearsOfExperience, IsActive);
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