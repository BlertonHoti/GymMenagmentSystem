using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMenagmentSystem
{
    public class ReceptionistFrm
    {
        public static string RName;
        public static string RGender;
        public static string RBirth;
        public static string RAddress;
        public static string RPhone;
        public static string RPassword;

        public ReceptionistFrm(string rName, string rGender, string rBirth, string rAddress, string rPhone, string rPassword)
        {
            RName = rName;
            RGender = rGender;
            RBirth = rBirth;
            RAddress = rAddress;
            RPhone = rPhone;
            RPassword = rPassword;
        }
    }
}
