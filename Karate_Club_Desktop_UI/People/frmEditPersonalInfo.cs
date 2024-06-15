using System;
using System.Windows.Forms;

namespace Karate_Club.Members
{

    public partial class frmEditPersonalInfo : Form
    {
        // Declare an event that will be raised when perosnal info updated successfully
        // Apply Publisher Subscriber Desgin Pattern => Observer Design Pattern
        public  event Action PersonalInfoUpdated;

        protected virtual void OnPersonalInfoUpdated()
        {
            PersonalInfoUpdated?.Invoke();
        }

        int? _personID;

        public frmEditPersonalInfo(int? personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void frmEditPersonalInfo_Load(object sender, EventArgs e)
        {
            if(!ctrAddEditPerson1.LoadPersonInfo(_personID))
                this.Close();

            ctrAddEditPerson1.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrAddEditPerson1.UpdatePersonInfo())
            {
                // Notify Subscribers
                OnPersonalInfoUpdated();

                btnSave.Enabled = false;
                ctrAddEditPerson1.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
