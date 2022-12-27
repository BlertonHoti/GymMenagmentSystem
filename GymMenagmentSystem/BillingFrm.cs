using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMenagmentSystem
{
    public class BillingFrm
    {
        public static int BAgent;
        public static string BMember;
        public static string BPeriod;
        public static string BDate;
        public static string BAmount;
        public BillingFrm(int bAgent, string bMember, string bPeriod, string bDate, string bAmount)
        {
            BAgent = bAgent;
            BMember = bMember;
            BPeriod = bPeriod;
            BDate = bDate;
            BAmount = bAmount;
        }
      
    }
}
