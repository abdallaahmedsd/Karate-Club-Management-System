using System;
using System.Windows.Forms;

namespace Karate_Club.Members
{
    public partial class frmEditPersonalInfo : Form
    {
        int _personID;

        public frmEditPersonalInfo(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrAddEditPerson1.UpdatePersonInfo();
        }

        private void frmEditPersonalInfo_Load(object sender, EventArgs e)
        {
            if(!ctrAddEditPerson1.LoadPersonInfo(_personID))
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
