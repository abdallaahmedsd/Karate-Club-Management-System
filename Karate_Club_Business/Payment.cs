using Karate_Club_Data_Access;
using System;
using System.Data;

namespace Karate_Club_Business
{
    public class clsPayment
    {
        public int? PaymentID { get; set; }
        public decimal Amount { get; set; }
        public int MemberID { get; set; }

        private DateTime _date;
        public DateTime Date { get; }
        public int? CreatedByUserID { get; set; }

        public enum enMode : byte { add_new_mode, update_mode }
        public enMode Mode { get; set; }

        private clsPayment(int? paymentID, decimal amount, int memberID, DateTime date, int? createdByUserID)
        {
            PaymentID = paymentID;
            Amount = amount;
            MemberID = memberID;
            _date = date;
            CreatedByUserID = createdByUserID;
            Mode = enMode.update_mode;
        }

        public clsPayment()
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

        public static clsPayment Find(int paymentID)
        {
            decimal amount = 0;
            int memberID = -1;
            DateTime date = DateTime.Now;
            int? createdByUserID = null;

            if (clsPaymentDataAccess.FindPaymentByID(paymentID, ref amount, ref memberID, ref date, ref createdByUserID))
            {
                return new clsPayment(paymentID, amount, memberID, date, createdByUserID);
            }
            return null;
        }

        public static bool Delete(int paymentID)
        {
            return clsPaymentDataAccess.DeletePayment(paymentID);
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentDataAccess.GetAllPayments();
        }

        private bool _Add()
        {
            PaymentID = clsPaymentDataAccess.AddPayment(Amount, MemberID, Date, CreatedByUserID);

            return this.PaymentID.HasValue;
        }

        private bool _Update()
        {
            return clsPaymentDataAccess.UpdatePayment(PaymentID, Amount, MemberID, Date);
        }
    }
}