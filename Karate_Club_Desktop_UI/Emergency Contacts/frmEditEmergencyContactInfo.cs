using Karate_Club.People.Controls;
using Karate_Club_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_Club.Emergency_Contacts
{
    public partial class frmEditEmergencyContactInfo : Form
    {
        // Declare an event that will be raised when emergency contact info updated successfully
        // Apply Publisher Subscriber Desgin Pattern => Observer Design Pattern
        public event Action EmergencyContactInfoUpdated;

        protected virtual void OnEmergencyContactInfoUpdated()
        {
            EmergencyContactInfoUpdated?.Invoke();
        }

        int? _emergencyContactID;

        public frmEditEmergencyContactInfo(int? emergencyContactID)
        {
            InitializeComponent();
            _emergencyContactID = emergencyContactID;
        }

        private void frmEditEmergencyContactInfo_Load(object sender, EventArgs e)
        {
            if(!ctrAddEditEmergencyContact1.LoadEmergencyContactInfo(_emergencyContactID))
                this.Close();

            ctrAddEditEmergencyContact1.Focus();
        } 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrAddEditEmergencyContact1.UpdateEmergencyContactInfo()) 
            {
                // Notify Subscribers
                OnEmergencyContactInfoUpdated();

                btnSave.Enabled = false;
                ctrAddEditEmergencyContact1.Enabled = false;
            }
        }

    }
}
