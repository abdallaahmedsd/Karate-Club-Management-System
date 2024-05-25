using Karate_Club_Data_Access;
using System;
using System.Data;

namespace Karate_Club_Business
{
    public class clsPerson
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {   
            get { return FirstName + ' ' + LastName; }
        }
        public char Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }
        public enum enMode : byte { add_new_mode, update_mode }
        public enMode Mode {get; set;}

        protected clsPerson(int personID, string firstName, string lastName, char gender, DateTime? birthdate, string phone, string email, string address, string imagePath, int? createdByUserID)
        {
            PersonID = personID;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Birthdate = birthdate;
            Phone = phone;
            Email = email;
            Address = address;
            ImagePath = imagePath;
            CreatedByUserID = createdByUserID;
            if (createdByUserID.HasValue) UserInfo = clsUser.Find(createdByUserID.Value);
            Mode = enMode.update_mode;
        }

        public clsPerson()
        {
            PersonID = -1;
            FirstName = null;
            LastName = null;
            Gender = ' ';
            Birthdate = null;
            Phone = null;
            Email = null;
            Address = null;
            ImagePath = null;
            CreatedByUserID = null;
            Mode = enMode.add_new_mode;
        }

        public bool Save()
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

        public static clsPerson Find(int personID)
        {
            string firstName = null,lastName = null, phone = null, email = null, address = null, imagePath = null;
            char gender = ' ';
            DateTime? birthdate = null;
            int? createdByUserID = null;

            if (clsPersonDataAccess.GetPersonByID(personID, ref firstName, ref lastName, ref gender, ref birthdate, ref phone, ref email, ref address, ref imagePath, ref createdByUserID))
                return new clsPerson(personID, firstName, lastName, gender, birthdate, phone, email, address, imagePath, createdByUserID);
            else
                return null;

        }

        public static bool Delete(int personID)
        {
            return clsPersonDataAccess.DeletePerson(personID);
        }

        public static bool IsExists(int personID)
        {
            return clsPersonDataAccess.IsPersonExists(personID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.GetAllPeople();
        }

        private bool _Add()
        {
            this.PersonID = clsPersonDataAccess.AddPerson(FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath, CreatedByUserID);
            return this.PersonID != -1;
        }

        private bool _Update() 
        {
            return clsPersonDataAccess.UpdatePerson(PersonID, FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath);
        }

    }
}
