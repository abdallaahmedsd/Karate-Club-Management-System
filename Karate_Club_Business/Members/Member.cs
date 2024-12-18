﻿using Karate_Club_Data_Access.Members;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Karate_Club_Business.Members
{
	public class clsMember : clsPerson
	{
		public int? MemberID { get; set; }
		public int CurrentBeltRankID { get; set; }
		public bool IsActive { get; set; }

		private int _emergencyContactID;
		public int EmergencyContactID => _emergencyContactID;

		private clsBeltRank _beltRankInfo;

		private clsSubscription _subscriptionInfo;
		public clsBeltRank BeltRankInfo => _beltRankInfo;
		public clsSubscription SubscriptionInfo => _subscriptionInfo;
		public clsEmergencyContact EmergencyContactInfo { get; set; }

		public new enum enMode : byte { add_new_mode, update_mode }
		public new enMode Mode { get; set; }

		private clsMember(int personID, string firstName, string lastName, char gender, DateTime birthdate, string phone, string email, string address,
				string imagePath, int memberID, int currentBeltRankID, int emergencyContactID, int subscriptionID, bool isActive)
				: base(personID, firstName, lastName, gender, birthdate, phone, email, address, imagePath)
		{
			MemberID = memberID;
			CurrentBeltRankID = currentBeltRankID;
			_beltRankInfo = clsBeltRank.Find(currentBeltRankID);
			_emergencyContactID = emergencyContactID;
			EmergencyContactInfo = clsEmergencyContact.Find(emergencyContactID);
			_subscriptionInfo = clsSubscription.FindBySubscriptionID(subscriptionID);
			IsActive = isActive;
			Mode = enMode.update_mode;
		}

		public clsMember()
		{
			EmergencyContactInfo = new clsEmergencyContact();
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

		public static new clsMember Find(int memberID)
		{
			int personID = -1, currentBeltRankID = -1, emergencyContactID = -1, subscriptionID = -1;
			string fName = null, lName = null, phone = null, email = null, address = null, imagePath = null;
			DateTime birthdate = DateTime.Now;
			char gender = ' ';
			bool isActive = true, isFound = false;


			isFound = MemberDataAccess.FindMemberByID(memberID, ref personID, ref fName, ref lName, ref gender, ref birthdate, ref phone, ref email, ref address,
														ref imagePath, ref currentBeltRankID, ref emergencyContactID, ref subscriptionID, ref isActive);

			if (isFound)
				return new clsMember(personID, fName, lName, gender, birthdate, phone, email, address, imagePath,
										memberID, currentBeltRankID, emergencyContactID, subscriptionID, isActive);
			else
				return null;
		}

		public static bool Activate(int memberID) => MemberDataAccess.Activate(memberID);

		public static bool Deactivate(int memberID) => MemberDataAccess.Deactivate(memberID);

		public static bool DeletePermanently(int memberID) => MemberDataAccess.DeletePermanently(memberID);

		public static DataTable GetAllMembers()
		{
			return MemberDataAccess.GetAllMembers();
		}

		public static async Task<DataTable> GetMembersPerPageAsync(ushort pageNumber, uint rowsPerPage)
		{
			return await MemberDataAccess.GetMembersPerPageAsync(pageNumber, rowsPerPage);
		}

		public static uint Count()
		{
			return MemberDataAccess.Count();
		}

		public static bool HasAcriveSubscription(int memberID) => MemberDataAccess.HasAcriveSubscription(memberID);

		private bool _Add()
		{
			MemberID = MemberDataAccess.AddMember(FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath,
				EmergencyContactInfo.Name, EmergencyContactInfo.Phone, EmergencyContactInfo.Email, CurrentBeltRankID, IsActive);

			return MemberID.HasValue;
		}

		private bool _Update()
		{
			return MemberDataAccess.UpdateMember((int)MemberID, (int)PersonID, CurrentBeltRankID, _emergencyContactID, IsActive);
		}
	}
}