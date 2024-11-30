using Karate_Club_Data_Access.Members;
using System.Data;

namespace Karate_Club_Business
{
	public class clsSubscriptionType
    {
        public int? SubscriptionTypeID { get; set; }
        public int PeriodLength { get; set; }
        public string PeriodUnit { get; set; }
        public decimal Fees { get; set; }

        public enum enMode { add_new_mode, update_mode }
        public enMode Mode { get; set; }

        private clsSubscriptionType(int subscriptionTypeID, int periodLength, string periodUnit, decimal fees)
        {
            SubscriptionTypeID = subscriptionTypeID;
            PeriodLength = periodLength;
            PeriodUnit = periodUnit;
            Fees = fees;
            Mode = enMode.update_mode;
        }

        public clsSubscriptionType()
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
                        this.Mode = enMode.update_mode;
                        return true;
                    }
                    return false;
                case enMode.update_mode:
                    return _Update();
                default:
                    return false;
            }
        }

        public static clsSubscriptionType Find(int subscriptionTypeID)
        {
            int periodLength = 0;
            string periodUnit = null;
            decimal fees = 0;

            if (clsSubscriptionTypeDataAccess.FindSubscriptionTypeByID(subscriptionTypeID, ref periodLength, ref periodUnit, ref fees))
                return new clsSubscriptionType(subscriptionTypeID, periodLength, periodUnit, fees);
            else
                return null;
        }

        public static bool Delete(int subscriptionTypeID)
        {
            return clsSubscriptionTypeDataAccess.DeleteSubscriptionType(subscriptionTypeID);
        }

        public static DataTable GetAllSubscriptionTypes()
        {
            return clsSubscriptionTypeDataAccess.GetAllSubscriptionTypes();
        }

        private bool _Add()
        {
            SubscriptionTypeID = clsSubscriptionTypeDataAccess.AddSubscriptionType(PeriodLength, PeriodUnit, Fees);
            return this.SubscriptionTypeID.HasValue;
        }

        private bool _Update()
        {
            return clsSubscriptionTypeDataAccess.UpdateSubscriptionType(SubscriptionTypeID, PeriodLength, PeriodUnit, Fees);
        }
    }

}
