using Karate_Club_Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Club_Business
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public enum enMode { AddNew, Update }
        public enMode Mode { get; set; }

        private clsUser(int userID, int personID, string userName, string password, bool isActive, int createdByUserID)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = null;
            Password = null;
            IsActive = true;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddUser())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateUser();
                default:
                    return false;
            }
        }

        public static clsUser Find(int userID)
        {
            int personID = -1, createdByUserID = -1;
            string userName = null, password = null;
            bool isActive = false;

            if (clsUserDataAccess.GetUserByID(userID, ref personID, ref userName, ref password, ref isActive, ref createdByUserID))
                return new clsUser(userID, personID, userName, password, isActive, createdByUserID);
            else
                return null;
        }

        public static bool Delete(int userID)
        {
            return clsUserDataAccess.DeleteUser(userID);
        }

        public static bool IsExists(int userID)
        {
            return clsUserDataAccess.IsUserExists(userID);
        }

        private bool _AddUser()
        {
            this.UserID = clsUserDataAccess.AddUser(PersonID, UserName, Password, IsActive, CreatedByUserID);
            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(UserID, PersonID, UserName, Password, IsActive);
        }
    }
}
