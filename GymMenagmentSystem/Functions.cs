using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMenagmentSystem
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand Command;
        private DataTable dt;
        private string conStr;
        private SqlDataAdapter Sda;

        public Functions()
        {
            conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\blert\\OneDrive\\Documents\\FitnessDB.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(conStr);
            Command = new SqlCommand();
            Command.Connection = Con;
        }
        public int setData(string Query)
        {
            int cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Command.CommandText = Query;
            cnt = Command.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            Sda = new SqlDataAdapter(Query, conStr);
            Sda.Fill(dt);
            return dt;
        }
    }
}
