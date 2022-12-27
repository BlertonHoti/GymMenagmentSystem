using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMenagmentSystem
{
    public class MembersFrm
    {
        public static string MName;
        public static string MGen;
        public static string MPhone;
        public static string MBirth;
        public static string MJoin;
        public static int MShip;
        public static int MCoach;
        public static string MTiming;
        public static string MStatus;

        public MembersFrm(string mName, string mGen, string mPhone, string mBirth, string mJoin, int mShip, int mCoach, string mTiming, string mStatus)
        {
            MName = mName;
            MGen = mGen;
            MPhone = mPhone;
            MBirth = mBirth;
            MJoin = mJoin;
            MShip = mShip;
            MCoach = mCoach;
            MTiming = mTiming;
            MStatus = mStatus;
        }
      
    }
}
