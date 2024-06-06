﻿using Karate_Club.Global_Classes;
using Karate_Club_Business;
using System;
using System.Windows.Forms;

namespace Karate_Club.Emergency_Contacts
{
    public partial class ctrAddEditEmergencyContact : UserControl
    {
        public ctrAddEditEmergencyContact()
        {
            InitializeComponent();
        }

        private clsEmergencyContact _emergencyContact;

        public clsEmergencyContact EmergencyContactalInfo => _emergencyContact;

        private void _FillEmergencyContactObject()
        {
            _emergencyContact = new clsEmergencyContact();
            _emergencyContact.Name = txtFullName.Text.Trim();
            _emergencyContact.Phone = txtPhone.Text.Trim();
            _emergencyContact.Email = txtEmail.Text.Trim();
        }

        private void _FillFormWithEmergencyContactInfo()
        {
            txtFullName.Text = _emergencyContact.Name;
            txtPhone.Text = _emergencyContact.Phone;
            txtEmail.Text = _emergencyContact.Email != null ? _emergencyContact.Email : string.Empty;
        }

        private bool _ValidateEmail()
        {
            string email = txtEmail.Text.Trim();

            if (!string.IsNullOrWhiteSpace(email) && !clsUtilities.IsValidEmail(email))
            {
                errorProvider1.SetError(txtEmail, "Invalid format for an email!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
                return true;
            }
        }

        private bool _ValidateEmptyFields(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, "This field is required!");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, null);
                return true;
            }
        }

        private bool _isValidPhone()
        {
            // Phone number must be greater than or equals to 7
            if (txtPhone.Text.Trim().Length < 7)
            {
                errorProvider1.SetError(txtPhone, "Phone number must be at least 7 numbers!");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
                return true;
            }
        }

        private void _ValidateEmptyTextBox_TextChanged(object sender, EventArgs e)
        {
            _ValidateEmptyFields((TextBox)sender);  
        }

        public bool AreAllFieldsValid()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                _ValidateEmptyFields(txtFullName);
                _ValidateEmptyFields(txtPhone);

                result = false;
            }

            if (!_ValidateEmail())
                result = false;

            if (!_isValidPhone())
                result = false;

            // incase all fileds are valid fill emergency contact class to return all emergency contact info
            if(result == true)
                _FillEmergencyContactObject();

            return result;
        }

        public void LoadEmergencyContactInfo(int emergencyContactID)
        {
            _emergencyContact = clsEmergencyContact.Find(emergencyContactID);

            if (_emergencyContact == null)
            {
                MessageBox.Show($"There's no emergency contact with ID ({emergencyContactID})", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Reset();
                return;
            }

            _FillFormWithEmergencyContactInfo();
        }

        public new void Focus()
        {
            txtFullName.Focus();
        }

        public void Reset()
        {
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }
    }
}
