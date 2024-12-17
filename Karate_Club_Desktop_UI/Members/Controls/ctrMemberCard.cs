using Karate_Club.People;
using Karate_Club_Business.Instructors;
using Karate_Club_Business.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_Club.Members.Controls
{
	public partial class ctrMemberCard : UserControl
    {
        public event Action MemberInfoUpdated;

        protected virtual void OnMemberInfoUpdated()
        {
            MemberInfoUpdated?.Invoke();
        }


        private clsMember _member;

        public ctrMemberCard()
        {
            InitializeComponent();
        }

        private void _Subscribe(ctrPersonCard personCard)
        {
            personCard.PersonalInfoUpdated += OnMemberInfoUpdated;
        }

        private void _FillPersonInfo()
        {
            _Subscribe(ctrPersonCard1); // Subscribe to the event in person card 

            ctrPersonCard1.LoadPersonalInfo((int)_member.PersonID);

            lblMemberID.Text = _member.MemberID.ToString();
            lblCurrentBelt.Text = _member.BeltRankInfo.Title;
            lblECName.Text = _member.EmergencyContactInfo.Name;
            lblECPhone.Text = _member.EmergencyContactInfo.Phone;
            lblECEmail.Text = _member.EmergencyContactInfo.Email;
            lblSubscriptionType.Text = _GetSubscriptionType();
            lblStartDate.Text = _member.SubscriptionInfo.StartDate.ToShortDateString();
            lblEndDate.Text = _member.SubscriptionInfo.EndDate.ToShortDateString();

            // Handle Instructors List
            
        }

        private string _GetSubscriptionType()
        {
            return _member.SubscriptionInfo.SubscriptionTypeInfo.PeriodUnit == "Lifetime" ? "Lifetime" 
                : _member.SubscriptionInfo.SubscriptionTypeInfo.PeriodLength + " " + _member.SubscriptionInfo.SubscriptionTypeInfo.PeriodUnit;
        }

        public void Reset()
        {
            ctrPersonCard1.Reset();
            lblMemberID.Text = "????";
            lblCurrentBelt.Text = "????";
            lblECName.Text = "????";
            lblECPhone.Text = "????";
            lblECEmail.Text = "????";
            lblSubscriptionType.Text = "????";
            lblStartDate.Text = "????";
            lblEndDate.Text = "????";
            lvInstructors.Items.Clear();
        }

        public void LoadMemberInfo(int id)
        {
            _member = clsMember.Find((int)id);

            if (_member == null)
            {
                Reset();
                MessageBox.Show($"There's no member with ID ({id})", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void RefreshMemberInfo()
        {
            LoadMemberInfo((int)_member.PersonID);
            OnMemberInfoUpdated();
        }
    }
}
