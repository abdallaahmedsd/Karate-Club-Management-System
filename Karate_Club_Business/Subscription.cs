using Karate_Club_Data_Access;
using System;
using System.Data;

namespace Karate_Club_Business
{
    public class clsSubscription
    {
        public int? SubscriptionID { get; set; }
        public int MemberID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get { return _endDate; } }
        public decimal Fees { get; set; }
        public int PaymentID { get; set; }
        public clsPayment PaymentInfo { get; set; }
        public int SubscriptionTypeID { get; set; }
        public clsSubscriptionType SubscriptionTypeInfo { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }

        private DateTime _endDate;

        public enum enMode : byte { add_new_mode, update_mode }
        public enMode Mode { get; set; }

        // Must indicate subscription period unit to calculate endDate automaticlly 
        public enum enPeriodUnit : byte 
        {
            onr_day = 1,
            three_days,
            one_week,
            two_weeks,
            one_month, 
            three_month,
            six_month,
            one_year,
            two_year,
            lifeTime
        };

        private enPeriodUnit _periodUnit { get; set; }

        private clsSubscription(int? subscriptionID, int memberID, DateTime startDate, DateTime endDate, int subscriptionTypeID, decimal fees, int paymentID, int? createdByUserID)
        {
            SubscriptionID = subscriptionID;
            MemberID = memberID;
            StartDate = startDate;
            _endDate = endDate;
            SubscriptionTypeID = subscriptionTypeID;
            SubscriptionTypeInfo = clsSubscriptionType.Find(subscriptionTypeID);
            Fees = fees;
            PaymentID = paymentID;
            PaymentInfo = clsPayment.Find(paymentID);
            CreatedByUserID = createdByUserID;
            if (createdByUserID != null) UserInfo = clsUser.Find((int)createdByUserID);
            Mode = enMode.update_mode;
        }

        public clsSubscription()
        {
            Mode = enMode.add_new_mode;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.add_new_mode:
                    if (_Add())
                    {
                        Mode = enMode.update_mode;
                        return true;
                    }
                    return false;
                case enMode.update_mode:
                    return _Update();
                default:
                    return false;
            }
        }

        public static clsSubscription Find(int subscriptionID)
        {
            int memberID = -1;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            int subscriptionTypeID = -1;
            decimal fees = 0;
            int paymentID = 0;
            int? createdByUserID = null;

            if (clsSubscriptionDataAccess.FindSubscriptionByID(subscriptionID, ref memberID, ref startDate, ref endDate, ref subscriptionTypeID, ref fees, ref paymentID, ref createdByUserID))
            {
                return new clsSubscription(subscriptionID, memberID, startDate, endDate, subscriptionTypeID, fees, paymentID, createdByUserID);
            }
            return null;
        }

        public static bool Delete(int subscriptionID)
        {
            return clsSubscriptionDataAccess.DeleteSubscription(subscriptionID);
        }

        public static DataTable GetAllSubscriptions()
        {
            return clsSubscriptionDataAccess.GetAllSubscriptions();
        }

        private void _CalcEndDate()
        {
            // Get the the subscription period unif from SubscriptionTypeID
            _periodUnit = (enPeriodUnit)SubscriptionTypeID;

            switch (_periodUnit)
            {
                case enPeriodUnit.onr_day:
                    _endDate = StartDate.AddDays(1);
                    break;
                case enPeriodUnit.three_days:
                    _endDate = StartDate.AddDays(3);
                    break;
                case enPeriodUnit.one_week:
                    _endDate = StartDate.AddDays(7);
                    break;
                case enPeriodUnit.two_weeks:
                    _endDate = StartDate.AddDays(14);
                    break;
                case enPeriodUnit.one_month:
                    _endDate = StartDate.AddMonths(1);
                    break;
                case enPeriodUnit.three_month:
                    _endDate = StartDate.AddMonths(3);
                    break;
                case enPeriodUnit.six_month:
                    _endDate = StartDate.AddMonths(6);
                    break;
                case enPeriodUnit.one_year:
                    _endDate = StartDate.AddYears(1);
                    break;
                case enPeriodUnit.lifeTime:
                    _endDate = StartDate.AddYears(50); // add 50 years for the lifetime offer
                    break;
                default:
                    _endDate = StartDate;
                    break;
            }
        }

        private bool _Add()
        {
            // first clac the end date
            _CalcEndDate();

            SubscriptionID = clsSubscriptionDataAccess.AddSubscription(MemberID, StartDate, _endDate, SubscriptionTypeID, Fees, CreatedByUserID);
            return this.SubscriptionID.HasValue;
        }

        private bool _Update()
        {
            // first clac the end date
            _CalcEndDate();

            return clsSubscriptionDataAccess.UpdateSubscription((int)SubscriptionID, MemberID, StartDate, _endDate, SubscriptionTypeID, Fees, PaymentID);
        }
    }
}