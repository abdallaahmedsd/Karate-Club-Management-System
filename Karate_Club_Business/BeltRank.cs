﻿using Karate_Club_Data_Access;
using System.Data;

namespace Karate_Club_Business
{
    public class clsBeltRank
    {
        public int? RankID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public enum enMode : byte { add_new_mode, update_mode }
        public enMode Mode { get; set; }

        private clsBeltRank(int rankID, string title, decimal fees)
        {
            RankID = rankID;
            Title = title;
            Fees = fees;
            Mode = enMode.update_mode;
        }

        public clsBeltRank()
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

        public static clsBeltRank Find(int rankID)
        {
            string title = null;
            decimal fees = 0;

            if (BeltRankDataAccess.FindBeltRankByID(rankID, ref title, ref fees))
                return new clsBeltRank(rankID, title, fees);
            else
                return null;
        }

        public static bool Delete(int rankID)
        {
            return BeltRankDataAccess.DeleteBeltRank(rankID);
        }

        public static DataTable GetAllBeltRanks()
        {
            return BeltRankDataAccess.GetAllBeltRanks();
        }

        private bool _Add()
        {
            this.RankID = BeltRankDataAccess.AddBeltRank(Title, Fees);
            return this.RankID != -1;
        }

        private bool _Update()
        {
            return BeltRankDataAccess.UpdateBeltRank((int)RankID, Title, Fees);
        }
    }

}
