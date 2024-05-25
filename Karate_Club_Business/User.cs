using Karate_Club_Data_Access;

namespace Karate_Club_Business
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public enum enMode : byte { AddNew, Update }
        public enMode Mode { get; set; }

        private clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Mode = enMode.Update;
        }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = null;
            Password = null;
            IsActive = true;
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

            if (clsUserDataAccess.GetUserByID(userID, ref personID, ref userName, ref password, ref isActive))
                return new clsUser(userID, personID, userName, password, isActive);
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
            this.UserID = clsUserDataAccess.AddUser(PersonID, UserName, Password, IsActive);
            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(UserID, PersonID, UserName, Password, IsActive);
        }
    }
}
