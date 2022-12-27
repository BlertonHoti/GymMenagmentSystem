using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GymMenagmentSystem
{
    public class CoachFrm
    {
        public static string CName;
        public static string CGender;
        public static string CPhone;
        public static int CExperience;
        public static string CAddress;
        public static string CPassword;

        public CoachFrm(string cName, string cGender, string cPhone, int cExperience, string cAddress, string cPassword)
        {
            CName = cName;
            CGender = cGender;
            CPhone = cPhone;
            CExperience = cExperience;
            CAddress = cAddress;
            CPassword = cPassword;
        }
    }
}
