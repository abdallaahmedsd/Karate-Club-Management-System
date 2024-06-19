using System;
using System.Windows.Forms;

namespace Karate_Club.Subscriptions
{
    public partial class frmAddSubscription : Form
    {
        public event Action SubscriptionAdded;
        private int _memberID;

        protected virtual void OnSubscriptionAdded() => SubscriptionAdded?.Invoke();

        public frmAddSubscription(int memberID)
        {
            InitializeComponent();
            _memberID = memberID;   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrAddEditSubscription1.AddNewSubscribtion(_memberID))
            {
                OnSubscriptionAdded();
                btnSave.Enabled = false;
                ctrAddEditSubscription1.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
