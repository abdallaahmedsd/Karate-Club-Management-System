using Karate_Club_Business;
using Karate_Club_Business.Instructors;
using Karate_Club_Business.Members;
using System;
using System.Data;
using System.Windows.Forms;

namespace Karate_Club
{
	public partial class frmAddMember : Form
    {
        // This event will be raised when a new member added successfully
        // Apply Publisher Subscriber Desgin Pattern => Observer Design Pattern
        public event EventHandler<MemberAddedEventArgs> NewMemberAdded;

        private void OnNewMemberAdded(int? memberID)
        {
            OnNewMemberAdded(this, new MemberAddedEventArgs(memberID));
        }

        // Raise the event and call all subscribers from different places
        protected virtual void OnNewMemberAdded(object sender, MemberAddedEventArgs e) 
        {
            NewMemberAdded?.Invoke(this, e);
        }

        clsMember _member;
        clsSubscription _subscription;
        DataTable _dtBeltRanks;
        public frmAddMember()
        {
            InitializeComponent();
        }

        private void _LoadBeltRanksToComboBox()
        {
            cbCurrentBelt.Items.Add("Select Belt Rank");

            // Select the first item in the ComboBox
            cbCurrentBelt.SelectedIndex = 0;

            _dtBeltRanks = clsBeltRank.GetAllBeltRanks();

            if (_dtBeltRanks == null)
            {
                MessageBox.Show("Something went wrong when trying to get belt ranks from the database.", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            foreach (DataRow row in _dtBeltRanks?.Rows)
            {
                cbCurrentBelt.Items.Add(row["Title"]);
            }
        }

        private void _FillMemberObject()
        {
            _member = new clsMember();

            // Get personal info from the ctrAddEditPerson1 and set it to _member class
            _member.FirstName = ctrAddEditPerson1.PersonalInfo.FirstName;
            _member.LastName = ctrAddEditPerson1.PersonalInfo.LastName;
            _member.Gender = ctrAddEditPerson1.PersonalInfo.Gender;
            _member.Birthdate = ctrAddEditPerson1.PersonalInfo.Birthdate;
            _member.Phone = ctrAddEditPerson1.PersonalInfo.Phone;
            _member.Email = ctrAddEditPerson1.PersonalInfo.Email;
            _member.Address = ctrAddEditPerson1.PersonalInfo.Address;
            _member.ImagePath = ctrAddEditPerson1.PersonalInfo.ImagePath;

            // Get emegency conatct info from the ctrAddEditEmergencyContact1 and set it to _member class
            _member.EmergencyContactInfo.Name = ctrAddEditEmergencyContact1.EmergencyContactalInfo.Name;
            _member.EmergencyContactInfo.Phone = ctrAddEditEmergencyContact1.EmergencyContactalInfo.Phone;
            _member.EmergencyContactInfo.Email = ctrAddEditEmergencyContact1.EmergencyContactalInfo.Email;

            // Get the selected belt rank by looping over the _dtBeltRanks
            for(int i = 0; i < _dtBeltRanks?.Rows.Count; i++)
            {
                if (_dtBeltRanks.Rows[i]["Title"].ToString() == cbCurrentBelt.Text)
                {
                    _member.CurrentBeltRankID = (int)_dtBeltRanks.Rows[i]["RankID"];
                    break;
                }
            }
            
            _member.IsActive = true;
        }

        private void _FillSubscriptionObject()
        {
            _subscription = new clsSubscription();

            _subscription.MemberID = (int)_member.MemberID;
            _subscription.SubscriptionTypeID = ctrAddEditSubscription1.SubscriptionInfo.SubscriptionTypeID;
            _subscription.StartDate = ctrAddEditSubscription1.SubscriptionInfo.StartDate; // Note!!!  EndDate will be calculated automatically by the business layer
            _subscription.Fees = ctrAddEditSubscription1.SubscriptionInfo.Fees;
            _subscription.CreatedByUserID = null; // Handle it later and set it to the current user
        }

        private bool _AreAllDataValid()
        {
            // Check if all personal data are provided correctly 
            if (!ctrAddEditPerson1.AreAllFieldsValid())
            {
                MessageBox.Show("Some fields are not valid in the personal info tab. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if all emergency conatct data are provided correctly
            if (!ctrAddEditEmergencyContact1.AreAllFieldsValid())
            {
                MessageBox.Show("Some fields are not valid in the emergency contact info tab. Hover over the red icons to see the message provided.", "Not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the user has selected a subscription type
            if (!ctrAddEditSubscription1.AreAllFieldsValid())
            {
                MessageBox.Show("You have to choose a subscription type", "Select a subscription type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the user has selected a belt rank
            if (cbCurrentBelt.Text == "Select Belt Rank")
            {
                MessageBox.Show("You have to choose a belt rank", "Select a belt rank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void frmAddMember_Load(object sender, EventArgs e)
        {
            _LoadBeltRanksToComboBox();
        }

        private void btnGoToEmergencyContactfo_Click(object sender, EventArgs e)
        {
            // first check if all required fields are specified
            if(!ctrAddEditPerson1.AreAllFieldsValid())
            {
                MessageBox.Show("Some fields are not valid. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            tcMemberInfo.SelectTab("tpEmergencyContactInfo");
        }

        private void btnGoToSubscriptionInfo_Click(object sender, EventArgs e)
        {
            // first check if all required fields are specified
            if (!ctrAddEditEmergencyContact1.AreAllFieldsValid())
            {
                MessageBox.Show("Some fields are not valid. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tcMemberInfo.SelectTab("tpSubscriptionInfo");
        }

        private void btnGoToCurrentBelt_Click(object sender, EventArgs e)
        {
            if (!ctrAddEditSubscription1.AreAllFieldsValid())
            {
                MessageBox.Show("You must choose a subscription tabe.", "Choose Subscription Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tcMemberInfo.SelectTab("tpCurrentBelt");
        }

        private void btnBackToEmergencyContactInfo_Click(object sender, EventArgs e)
        {
            tcMemberInfo.SelectTab("tpEmergencyContactInfo");
        }

        private void btnBackToPersonalInfo_Click(object sender, EventArgs e)
        {
            tcMemberInfo.SelectTab("tpPersonalInfo");
        }

        private void tcMemberInfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage == tpEmergencyContactInfo)
            {
                // first check if all required fields are specified
                if (!ctrAddEditPerson1.AreAllFieldsValid())
                {
                    MessageBox.Show("Some fields are not valid. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tcMemberInfo.SelectTab("tpPersonalInfo");
                    return;
                }

                ctrAddEditEmergencyContact1.Focus();
            }
            else if(e.TabPage == tpSubscriptionInfo)
            {
                // first check if all required fields are specified
                if (!ctrAddEditEmergencyContact1.AreAllFieldsValid())
                {
                    MessageBox.Show("Some fields are not valid. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tcMemberInfo.SelectTab("tpEmergencyContactInfo");
                    return;
                }
            }
            else if (e.TabPage == tpCurrentBelt)
            {
                // first check if all required fields are specified
                if (!ctrAddEditSubscription1.AreAllFieldsValid())
                {
                    MessageBox.Show("You must choose a subscription tabe.", "Choose Subscription Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tcMemberInfo.SelectTab("tpSubscriptionInfo");
                    return;
                }
            }
        }

        private void btnBackToSubscriptionInfo_Click(object sender, EventArgs e)
        {
            tcMemberInfo.SelectTab("tpSubscriptionInfo");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_AreAllDataValid())
                return;

            _FillMemberObject();

            if (MessageBox.Show("Are you sure you want to add a member?", "Confirm Adding New Member", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (_member.Save())
                {
                    _FillSubscriptionObject();
                    if (_subscription.Save())
                        MessageBox.Show($"Member has been added successfully with ID ({_member.MemberID}).", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Member has been added with ID ({_member.MemberID}), but failed to add subscription.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // To prevent the user from adding member mulitiple times 
                    tpPersonalInfo.Enabled = false;
                    tpEmergencyContactInfo.Enabled = false;
                    tpSubscriptionInfo.Enabled = false;
                    tpCurrentBelt.Enabled = false;
                    btnSave.Enabled = false;

                    // Raise the MemberAddedEvent
                    OnNewMemberAdded(_member.MemberID);
                }
                else
                {
                    MessageBox.Show($"Cannot add new member. Something went wrong.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public class MemberAddedEventArgs : EventArgs
    {
        public int? MemberID { get; }

        public MemberAddedEventArgs(int? memberID)
        {
            MemberID = memberID;
        }
    }
}
