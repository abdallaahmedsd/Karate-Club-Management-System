using Karate_Club.Global_Classes;
using Karate_Club.Properties;
using Karate_Club_Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace Karate_Club.People.Controls
{
    public partial class ctrAddEditPerson : UserControl
    {
        public enum enMode { add_new, update }
        public enMode Mode = enMode.add_new;

        public ctrAddEditPerson()
        {
            InitializeComponent();
        }

        private clsPerson _person;

        public clsPerson PersonalInfo => _person;

        private void _FillPersonObject()
        {
            if(Mode == enMode.add_new)
                _person = new clsPerson();

            _person.FirstName = txtFirstName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.Phone = txtPhone.Text.Trim();
            _person.Email = txtEmail.Text.Trim();
            _person.Address = txtAddress.Text.Trim();
            _person.Birthdate = dtpBirthdate.Value;
            _person.Gender = radBtnMale.Checked ? 'M' : 'F';
            _person.ImagePath = pbPersonImage.ImageLocation;
        }

        private void _FillFormWithPersonInfo()
        {
            txtFirstName.Text = _person.FirstName;
            txtLastName.Text = _person.LastName;
            txtPhone.Text = _person.Phone;
            txtEmail.Text = _person.Email != null ? _person.Email : string.Empty;
            txtAddress.Text = _person.Address;
            dtpBirthdate.Value = (DateTime)_person.Birthdate;
            _ = _person.Gender == 'M' ? radBtnMale.Checked = true : radBtnFemale.Checked = true; // Search about the ' _ ' in the start of this line

            // Handle person image
            if (!string.IsNullOrWhiteSpace(_person.ImagePath))
                pbPersonImage.ImageLocation = _person.ImagePath;
            else
                pbPersonImage.Image = _person.Gender == 'M' ? Resources.male_512 : Resources.female_512;

            // hide/show the remove link incase there is no image for the person.
            llblRemoveImage.Visible = string.IsNullOrWhiteSpace(_person.ImagePath);
        }

        private void _DateSettings()
        {
            dtpBirthdate.MinDate = clsUtilities.MinimumValidAge;
            dtpBirthdate.MaxDate = clsUtilities.MaximumValidAge;
            dtpBirthdate.Value = dtpBirthdate.MaxDate;
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

        public bool HandlePersonImage()
        {
            /*
               this procedure will handle the person image,
                it will take care of deleting the old image from the folder
                in case the image changed. and it will rename the new image with guid and 
                place it in the images folder. 
            */


            //_person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_person.ImagePath != string.Empty)
                {
                    //first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Something went wront when trying to delete person's image!", "Cannot Delete Person Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                        //log it later   
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtilities.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        public void Reset()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            radBtnMale.Checked = true;
            pbPersonImage.Image = Resources.male_512;
            dtpBirthdate.Value = clsUtilities.MaximumValidAge;
        }

        public bool AreAllFieldsValid()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text)
                || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                _ValidateEmptyFields(txtFirstName);
                _ValidateEmptyFields(txtLastName);
                _ValidateEmptyFields(txtPhone);
                _ValidateEmptyFields(txtAddress);

                result = false;
            }

            if (!_ValidateEmail())
                result = false;

            if (!_isValidPhone())
                result = false;

            // incase all fileds are valid fill person class to return all person info
            if(result == true)
                _FillPersonObject();

            return result;
        }

        public bool LoadPersonInfo(int personId)
        {
            _person = clsPerson.Find(personId);

            if (_person == null)
            {
                MessageBox.Show($"There's no person with ID ({personId})", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Reset();
                return false;
            }

            Mode = enMode.update;
            _FillFormWithPersonInfo();
            return true;
        }

        public bool UpdatePersonInfo()
        {
            if (!AreAllFieldsValid())
            {
                MessageBox.Show("Some fields are not valid. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (MessageBox.Show("Are you sure you want to update personal info?", "Confirm Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (_person.Save())
                {
                    MessageBox.Show($"Personal info updated successfully", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show($"Cannot updated personal info, some thing went wrong.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        public void Foucs()
        {
            txtFirstName.Focus();
        }

        private void ctrAddEditPerson_Load(object sender, EventArgs e)
        {
            _DateSettings();
        }

        private void radBtnMale_Click(object sender, EventArgs e)
        {
            //change the default image to male incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.male_512;
        }

        private void radBtnFemale_Click(object sender, EventArgs e)
        {
            //change the default image to female incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.female_512;
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdSetImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdSetImage.FilterIndex = 1;
            ofdSetImage.RestoreDirectory = true;

            if (ofdSetImage.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = ofdSetImage.FileName;
                pbPersonImage.ImageLocation = selectedFilePath;
                llblRemoveImage.Visible = true;
            }
        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            llblRemoveImage.Visible = false;


            if (radBtnMale.Checked)
                pbPersonImage.Image = Resources.male_512;
            else
                pbPersonImage.Image = Resources.female_512;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtilities.IsNumber(e);
        }
    }
}