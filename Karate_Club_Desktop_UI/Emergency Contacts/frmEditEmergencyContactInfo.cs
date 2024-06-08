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
        int _emergencyContactID;

        public frmEditEmergencyContactInfo(int emergencyContactID)
        {
            InitializeComponent();
            _emergencyContactID = emergencyContactID;
        }

        private void frmEditEmergencyContactInfo_Load(object sender, EventArgs e)
        {
            if(!ctrAddEditEmergencyContact1.LoadEmergencyContactInfo(_emergencyContactID))
                this.Close();
        } 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrAddEditEmergencyContact1.UpdateEmergencyContactInfo();
        }

    }
}
