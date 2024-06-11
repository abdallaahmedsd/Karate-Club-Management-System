using Karate_Club_Data_Access;
using System;
using System.Data;

namespace Karate_Club_Business
{
    public class clsMember : clsPerson
    {
        public int MemberID { get; set; }
        public int CurrentBeltRankID { get; set; }
        public clsBeltRank BeltRankInfo { get; set; }
        public int EmergencyContactID { get; set; }
        public clsEmergencyContact EmergencyContactInfo { get; set; }
        public bool IsActive { get; set; }
        public clsSubscription SubscriptionInfo { get; set; }

        public new enum enMode : byte { add_new_mode, update_mode }
        public new enMode Mode { get; set; }
        
        private clsMember(int personID, string firstName, string lastName, char gender, DateTime birthdate, string phone, string email, string address,
                string imagePath, int? createdByUserID, int memberID, int currentBeltRankID, int emergencyContactID, bool isActive)
                :base(personID, firstName, lastName, gender, birthdate, phone, email, address, imagePath, createdByUserID)
        {
            MemberID = memberID;
            CurrentBeltRankID = currentBeltRankID;
            BeltRankInfo = clsBeltRank.Find(currentBeltRankID);
            EmergencyContactID = emergencyContactID;
            EmergencyContactInfo = clsEmergencyContact.Find(emergencyContactID);
            IsActive = isActive;
            Mode = enMode.update_mode;
        }

        public clsMember()
        {
            MemberID = -1;
            CurrentBeltRankID = -1;
            EmergencyContactID = -1;
            IsActive = false;
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
                        this.Mode = enMode.update_mode;
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
            int personID = -1, currentBeltRankID = -1, emergencyContactID = -1;
            bool isActive = true;

            if (clsMemberDataAccess.FindMemberByID(memberID, ref personID, ref currentBeltRankID, ref emergencyContactID, ref isActive))
            {
                clsPerson person = clsPerson.Find(personID);
                
                if(person == null) return null;

                return new clsMember(person.PersonID, person.FirstName, person.LastName, person.Gender, person.Birthdate, person.Phone, person.Email, 
                    person.Address, person.ImagePath, person.CreatedByUserID, memberID, currentBeltRankID, emergencyContactID, isActive);
            }
            else
                return null;
        }

        public static new bool Delete(int memberID)
        {
            return clsMemberDataAccess.DeleteMember(memberID);
        }

        public static DataTable GetAllMembers()
        {
            return clsMemberDataAccess.GetAllMembers();
        }

        public static DataTable GetMembersPerPage(ushort pageNumber, uint rowsPerPage)
        {
            return clsMemberDataAccess.GetMembersPerPage(pageNumber, rowsPerPage);
        }

        public static uint GetTotalMemberCount()
        {
            return clsMemberDataAccess.GetTotalMemberCount();
        }

        private bool _Add()
        {
            this.MemberID = clsMemberDataAccess.AddMember(FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath, CreatedByUserID,
                EmergencyContactInfo.Name, EmergencyContactInfo.Phone, EmergencyContactInfo.Email, CurrentBeltRankID, IsActive);

            return this.MemberID != -1;
        }

        private bool _Update()
        {
            return clsMemberDataAccess.UpdateMember(MemberID, PersonID, CurrentBeltRankID, EmergencyContactID, IsActive);
        }
    }
}