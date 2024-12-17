using Karate_Club_Data_Access.Members;
using System.Data;

namespace Karate_Club_Business.Members
{
	public class clsEmergencyContact
	{
		public int? EmergencyContactID { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public enum enMode : byte { add_new_mode, update_mode }
		public enMode Mode { get; set; }

		// Constructor for creating a new Emergency Contact
		public clsEmergencyContact()
		{
			Mode = enMode.add_new_mode;
		}

		// Constructor for retrieving an existing Emergency Contact
		private clsEmergencyContact(int emergencyContactID, string name, string phone, string email)
		{
			EmergencyContactID = emergencyContactID;
			Name = name;
			Phone = phone;
			Email = email;
			Mode = enMode.update_mode;
		}

		public bool Save()
		{
			switch (Mode)
			{
				case enMode.add_new_mode:
					if (_AddEmergencyContact())
					{
						Mode = enMode.update_mode;
						return true;
					}
					return false;
				case enMode.update_mode:
					return _UpdateEmergencyContact();
				default:
					return false;
			}
		}

		public static clsEmergencyContact Find(int emergencyContactID)
		{
			string name = null, phone = null, email = null;

			if (EmergencyContactsDataAccess.FindEmergencyContactByID(emergencyContactID, ref name, ref phone, ref email))
				return new clsEmergencyContact(emergencyContactID, name, phone, email);
			else
				return null;
		}

		public static bool Delete(int emergencyContactID)
		{
			return EmergencyContactsDataAccess.DeleteEmergencyContact(emergencyContactID);
		}

		public static DataTable GetAllEmergencyContacts()
		{
			return EmergencyContactsDataAccess.GetAllEmergencyContacts();
		}

		private bool _AddEmergencyContact()
		{
			EmergencyContactID = EmergencyContactsDataAccess.AddEmergencyContact(Name, Phone, Email);
			return EmergencyContactID.HasValue;
		}

		private bool _UpdateEmergencyContact()
		{
			return EmergencyContactsDataAccess.UpdateEmergencyContact((int)EmergencyContactID, Name, Phone, Email);
		}

	}

}
