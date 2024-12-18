﻿using Karate_Club_Data_Access;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace Karate_Club_Business
{
    public class clsPerson
    {
        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {   
            get { return FirstName + ' ' + LastName; }
        }
        public char Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

        public enum enMode : byte { add_new_mode, update_mode }
        public enMode Mode {get; set;}

        protected clsPerson(int? personID, string firstName, string lastName, char gender, DateTime birthdate, string phone, string email, string address, string imagePath)
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
            Mode = enMode.update_mode;
        }

        public clsPerson()
        {
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
            string firstName = null, lastName = null, phone = null, email = null, address = null, imagePath = null;
            char gender = ' ';
            DateTime birthdate = DateTime.Now;

            if (PersonDataAccess.GetPersonByID(personID, ref firstName, ref lastName, ref gender, ref birthdate, ref phone, ref email, ref address, ref imagePath))
                return new clsPerson(personID, firstName, lastName, gender, birthdate, phone, email, address, imagePath);
            else
                return null;

        }

        public static bool Delete(int personID)
        {
            return PersonDataAccess.DeletePerson(personID);
        }

        public static bool IsExists(int personID)
        {
            return PersonDataAccess.IsPersonExists(personID);
        }

        public static DataTable GetAllPeople()
        {
            return PersonDataAccess.GetAllPeople();
        }

        private bool _Add()
        {
            PersonID = PersonDataAccess.AddPerson(FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath);
            return PersonID.HasValue;
        }

        private bool _Update() 
        {
            return PersonDataAccess.UpdatePerson(PersonID, FirstName, LastName, Gender, Birthdate, Phone, Email, Address, ImagePath);
        }
    }
}
