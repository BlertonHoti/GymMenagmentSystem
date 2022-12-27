using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMenagmentSystem
{
    public class MembershipFrm
    {
        public static string MShName;
        public static int MShDuration;
        public static string MShGoal;
        public static int MShCost;

        public MembershipFrm(string mShName, int mShDuration, string mShGoal, int mShCost)
        {
            MShName = mShName;
            MShDuration = mShDuration;
            MShGoal = mShGoal;
            MShCost = mShCost;
        }
    }
}
