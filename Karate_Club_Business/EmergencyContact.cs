using Karate_Club_Data_Access;
using System.Data;

namespace Karate_Club_Business
{
    public class clsEmergencyContact
    {
        public int EmergencyContactID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public enum enMode : byte { add_new_mode, update_mode }
        public enMode Mode { get; set; }

        // Constructor for creating a new Emergency Contact
        public clsEmergencyContact()
        {
            EmergencyContactID = -1;
            Name = null;
            Phone = null;
            Email = null;
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
                        this.Mode = enMode.update_mode;
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

            if (clsEmergencyContactsDataAccess.FindEmergencyContactByID(emergencyContactID, ref name, ref phone, ref email))
                return new clsEmergencyContact(emergencyContactID, name, phone, email);
            else
                return null;
        }

        public static bool Delete(int emergencyContactID)
        {
            return clsEmergencyContactsDataAccess.DeleteEmergencyContact(emergencyContactID);
        }

        public static DataTable GetAllEmergencyContacts()
        {
            return clsEmergencyContactsDataAccess.GetAllEmergencyContacts();
        }

        private bool _AddEmergencyContact()
        {
            this.EmergencyContactID = clsEmergencyContactsDataAccess.AddEmergencyContact(Name, Phone, Email);
            return this.EmergencyContactID != -1;
        }

        private bool _UpdateEmergencyContact()
        {
            return clsEmergencyContactsDataAccess.UpdateEmergencyContact(EmergencyContactID, Name, Phone, Email);
        }

    }

}
