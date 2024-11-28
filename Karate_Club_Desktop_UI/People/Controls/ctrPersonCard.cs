using Karate_Club.Members;
using Karate_Club_Business;
using System;
using System.Windows.Forms;

namespace Karate_Club.People
{
    public partial class ctrPersonCard : UserControl
    {
        public event Action PersonalInfoUpdated;

        protected virtual void OnPersonalInfoUpdated()
        {
            PersonalInfoUpdated?.Invoke();
        }

        private clsPerson _person;

        public ctrPersonCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            lblPersonID.Text = "????";
            lblFullName.Text = "????";
            lblGender.Text = "????";
            lblPhone.Text = "????";
            lblEmail.Text = "????";
            lblAge.Text = "????";
            lblAddress.Text = "????";
            pbPersonImage.ImageLocation = null;
        }

        public void LoadPersonalInfo(int id)
        {
            _person = clsPerson.Find(id);

            if( _person == null ) 
            {
                Reset();
                MessageBox.Show($"There's no person with ID ({id})", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void RefreshPersonalInfo()
        {
            LoadPersonalInfo((int)_person.PersonID);
            OnPersonalInfoUpdated();
        }

        private void _FillPersonInfo()
        {
            lblPersonID.Text = _person.PersonID.ToString();
            lblFullName.Text = _person.FullName;
            lblGender.Text = _person.Gender == 'M' ? "Male" : "Female";
            lblPhone.Text = _person.Phone;
            lblEmail.Text = _person.Email;
            lblAge.Text = _CalculateAge((DateTime)_person.Birthdate).ToString();
            lblAddress.Text = _person.Address;
            pbPersonImage.ImageLocation = _person.ImagePath ?? null;
        }

        private int _CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }

        private void _Subscribe(frmEditPersonalInfo frm) => frm.PersonalInfoUpdated += RefreshPersonalInfo;

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_person != null)
            {
                frmEditPersonalInfo frm = new frmEditPersonalInfo((int)_person.PersonID);
                _Subscribe(frm);
                frm.ShowDialog();
            }
        }
    }
}
