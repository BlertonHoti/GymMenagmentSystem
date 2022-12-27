using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace GymMenagmentSystem
{
    public class AdminFrm
    {
        public static string AName;
        public static string APass;
        public static string AGen;
        public static string APhone;
        public AdminFrm(string aName, string aPass, string aGen, string aPhone)
        {
            AName = aName;
            APass = aPass;
            AGen = aGen;
            APhone = aPhone;
        }
    }
}
