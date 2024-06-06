using Karate_Club_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Karate_Club.Subscriptions
{
    public partial class ctrAddEditSubscription : UserControl
    {
        public clsSubscription.enPeriodUnit enPeriodUnit;

        DataTable _dtSubscriptionTypes;

        private clsSubscription _subscription;

        public clsSubscription SubscriptionInfo => _subscription; 

        public ctrAddEditSubscription()
        {
            InitializeComponent();
        }

        private void _LoadSubscriptionTypesToComboBox()
        {
            cbSubscriptionType.Items.Add("Select Subscription Type");

            // Select the first item in the ComboBox
            cbSubscriptionType.SelectedIndex = 0;

            _dtSubscriptionTypes = clsSubscriptionType.GetAllSubscriptionTypes();

            if(_dtSubscriptionTypes == null)
            {
                MessageBox.Show("Something went wrong when trying to get subscription types from the database.", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            foreach (DataRow row in _dtSubscriptionTypes.Rows)
            {
                string type = $"{row["PeriodLength"]} {row["PeriodUnit"]}";
                cbSubscriptionType.Items.Add(type);
            }
        }

        public void _DateSettings()
        {
            dtpEndDate.MaxDate = DateTime.Today.AddYears(50).AddMonths(3); // Becasue the lifetime subscription offer can be for 50 years
            dtpEndDate.MinDate = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            dtpStartDate.MaxDate = DateTime.Today.AddMonths(3); // You can set a subscription start date up to three months in future
            dtpStartDate.MinDate = DateTime.Today;
            dtpStartDate.Value = DateTime.Today;

        }

        private void _CalculateEndDate()
        {
            switch(enPeriodUnit) 
            { 
                case clsSubscription.enPeriodUnit.onr_day:
                    dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
                    break;
                case clsSubscription.enPeriodUnit.three_days:
                    dtpEndDate.Value = dtpStartDate.Value.AddDays(3);
                    break;
                case clsSubscription.enPeriodUnit.one_week:
                    dtpEndDate.Value = dtpStartDate.Value.AddDays(7);
                    break;
                case clsSubscription.enPeriodUnit.two_weeks:
                    dtpEndDate.Value = dtpStartDate.Value.AddDays(14);
                    break;
                case clsSubscription.enPeriodUnit.one_month:
                    dtpEndDate.Value = dtpStartDate.Value.AddMonths(1);
                    break;
                case clsSubscription.enPeriodUnit.three_month:
                    dtpEndDate.Value = dtpStartDate.Value.AddMonths(3);
                    break;
                case clsSubscription.enPeriodUnit.six_month:
                    dtpEndDate.Value = dtpStartDate.Value.AddMonths(6);
                    break;
                case clsSubscription.enPeriodUnit.one_year:
                    dtpEndDate.Value = dtpStartDate.Value.AddYears(1);
                    break;
                case clsSubscription.enPeriodUnit.two_year:
                    dtpEndDate.Value = dtpStartDate.Value.AddYears(2);
                    break;
                case clsSubscription.enPeriodUnit.lifeTime:
                    dtpEndDate.Value = dtpStartDate.Value.AddYears(50);
                    break;
                default:
                    dtpEndDate.Value = dtpStartDate.Value;
                    break;
            }    
        }

        private void _FillSubscriptionObject()
        {
            _subscription = new clsSubscription();

            // Get the subscription type id and its fees
            for(int i  = 0; i < _dtSubscriptionTypes?.Rows.Count;  i++)
            {
                DataRow row = _dtSubscriptionTypes.Rows[i];

                // I used two columns because in the ComboBox for selecting a subscription type contains of these two columns
                if ($"{row["PeriodLength"]} {row["PeriodUnit"]}" == cbSubscriptionType.Text) 
                {
                    _subscription.SubscriptionTypeID = (int)row["SubscriptionTypeID"];
                    _subscription.Fees = (decimal)row["Fees"];
                    break;  
                }
            }

            _subscription.StartDate = dtpStartDate.Value;
            _subscription.CreatedByUserID = null;
        }

        private void _FillFormWithSubscriptionInfo()
        {
            cbSubscriptionType.SelectedIndex = cbSubscriptionType.FindString($"{_subscription.SubscriptionTypeInfo.PeriodLength} {_subscription.SubscriptionTypeInfo.PeriodUnit}");
            dtpStartDate.Value = _subscription.StartDate;
            dtpEndDate.Value = _subscription.EndDate;
            lblFees.Text = $"{_subscription.SubscriptionTypeInfo.Fees:c}";
        }

        private bool HasChooseSubscriptionType()
        {
            if (cbSubscriptionType.Text == "Select Subscription Type")
            {
                errorProvider1.SetError(cbSubscriptionType, "Please select a subscription type.");
                return false;
            }
            else
            {
                errorProvider1.SetError(cbSubscriptionType, null);
                return true;
            }
        }

        public bool AreAllFieldsValid()
        {
            if(!HasChooseSubscriptionType())
            {
                return false;
            }

            _FillSubscriptionObject();
            return true;
        }

        public void Reset()
        {
            cbSubscriptionType.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today.Date;
        }

        public void LoadSubscriptionInfo(int subscriptionID)
        {
            _subscription = clsSubscription.Find(subscriptionID);

            if (_subscription == null)
            {
                MessageBox.Show($"There's no subscribtion with ID ({subscriptionID})", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }

            _FillFormWithSubscriptionInfo();
        }

        private void ctrAddEditSubscription_Load(object sender, EventArgs e)
        {
            _LoadSubscriptionTypesToComboBox();
            _DateSettings();
        }

        private void cbSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal fees = 0;

            if(cbSubscriptionType.Text == "Select Subscription Type")
            { 
                fees = 0;
                enPeriodUnit = 0;
            }
            else
            {
                foreach (DataRow row in _dtSubscriptionTypes.Rows)
                {
                    if ($"{row["PeriodLength"]} {row["PeriodUnit"]}" == cbSubscriptionType.Text)
                    {
                        fees = (decimal)row["Fees"];
                        enPeriodUnit = (clsSubscription.enPeriodUnit)(int)row["SubscriptionTypeID"];
                        _CalculateEndDate();
                    }
                }

                // Remove the error provider
                errorProvider1.SetError(cbSubscriptionType, null);
            }

            lblFees.Text = $"{fees:c}";
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            _CalculateEndDate();
        }
    }
}
