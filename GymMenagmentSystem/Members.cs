using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GymMenagmentSystem
{
    public partial class Members : Form
    {
        Functions con;
        bool mouseDown;
        private Point Offset;
        public Members()
        {
            InitializeComponent();
            con = new Functions();
            ShowMemList();
            GetCoaches();
            GetMShips();
            showStatus();
        }
        private void showStatus()
        {
            if (Login.Admin)
            {
                StatusLbl.Text = "Admin";
            }
            else
            {
                StatusLbl.Text = "Receptionist";
            }
            
        }
        private void ShowMemList()
        {
            string Query = "select * from MembersTbl";
            MemList.DataSource = con.GetData(Query);
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CoachLbl_Click(object sender, EventArgs e)
        {
            if (Login.Admin)
            {
                Coachs Obj = new Coachs();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not Admin!");
            }

        }
        private void GetCoaches()
        {
            string Query = "Select * from CoachTbl";
            MemCoach.DisplayMember = con.GetData(Query).Columns["CName"].ToString();
            MemCoach.ValueMember = con.GetData(Query).Columns["CId"].ToString();
            MemCoach.DataSource = con.GetData(Query);
        }
        private void GetMShips()
        {
            string Query = "Select * from MembershipsTbl";
            MemShips.DisplayMember = con.GetData(Query).Columns["MShipName"].ToString();
            MemShips.ValueMember = con.GetData(Query).Columns["MShipId"].ToString();
            MemShips.DataSource = con.GetData(Query);
        }
        private void Reset()
        {
            MemName.Text = "";
            MemPhone.Text = "";
            MemCoach.SelectedIndex = -1;
            MemGen.SelectedIndex = -1;
            MemShips.SelectedIndex = -1;
            MemStatus.SelectedIndex = -1;
            MemTiming.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemName.Text == "" || MemPhone.Text == "" || MemCoach.SelectedIndex == -1 || MemGen.SelectedIndex == -1 || MemShips.SelectedIndex == -1 || MemStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    MembersFrm Data = new MembersFrm(MemName.Text, MemGen.SelectedItem.ToString(), MemPhone.Text, MemBirth.Value.Date.ToString(), MemJoinDate.Value.Date.ToString(), Convert.ToInt32(MemShips.SelectedValue.ToString()), Convert.ToInt32(MemCoach.SelectedValue.ToString()), MemTiming.SelectedItem.ToString(), MemStatus.SelectedItem.ToString());
                    string Query = "insert into MembersTbl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
                    Query = string.Format(Query, MembersFrm.MName, MembersFrm.MGen, MembersFrm.MBirth, MembersFrm.MJoin, MembersFrm.MShip, MembersFrm.MCoach, MembersFrm.MPhone, MembersFrm.MTiming, MembersFrm.MStatus);
                    con.setData(Query);                    
                    ShowMemList();
                    Reset();
                    MessageBox.Show("Member Added!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int key = 0;
        private void MemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MemName.Text = MemList.SelectedRows[0].Cells[1].Value.ToString();
            MemGen.SelectedItem = MemList.SelectedRows[0].Cells[2].Value.ToString();
            MemBirth.Text = MemList.SelectedRows[0].Cells[3].Value.ToString();
            MemJoinDate.Text = MemList.SelectedRows[0].Cells[4].Value.ToString();
            MemShips.Text = MemList.SelectedRows[0].Cells[5].Value.ToString();
            MemCoach.Text = MemList.SelectedRows[0].Cells[6].Value.ToString();
            MemPhone.Text = MemList.SelectedRows[0].Cells[7].Value.ToString();
            MemTiming.Text = MemList.SelectedRows[0].Cells[8].Value.ToString();
            MemStatus.Text = MemList.SelectedRows[0].Cells[9].Value.ToString();

            if (MemName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MemList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemName.Text == "" || MemPhone.Text == "" || MemCoach.SelectedIndex == -1 || MemGen.SelectedIndex == -1 || MemShips.SelectedIndex == -1 || MemStatus.SelectedIndex == -1 || key == 0)
                {
                    if(key == 0 && (MemName.Text == "" || MemPhone.Text != "" && MemCoach.SelectedIndex != -1 && MemGen.SelectedIndex != -1 && MemShips.SelectedIndex != -1 && MemStatus.SelectedIndex != -1))
                    {
                        MessageBox.Show("Please Select a Member!");
                    }
                    else
                    {
                        MessageBox.Show("Missing Data!");
                    }
                }
                else
                {
                    MembersFrm Data = new MembersFrm(MemName.Text, MemGen.SelectedItem.ToString(), MemPhone.Text, MemBirth.Value.Date.ToString(), MemJoinDate.Value.Date.ToString(), Convert.ToInt32(MemShips.SelectedValue.ToString()), Convert.ToInt32(MemCoach.SelectedValue.ToString()), MemTiming.SelectedItem.ToString(), MemStatus.SelectedItem.ToString());
                    string Query = "update MembersTbl set MName = '{0}',MGen = '{1}',MDOB = '{2}',MDate = '{3}',MMembership = '{4}',MCoach = '{5}',MPhone = '{6}',MTiming = '{7}',MStatus = '{8}' where MId = {9}";
                    Query = string.Format(Query, MembersFrm.MName, MembersFrm.MGen, MembersFrm.MBirth, MembersFrm.MJoin, MembersFrm.MShip, MembersFrm.MCoach, MembersFrm.MPhone, MembersFrm.MTiming, MembersFrm.MStatus, key);
                    con.setData(Query);
                    ShowMemList();
                    Reset();
                    MessageBox.Show("Member Updated!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Member!");
                }
                else
                {
                    string Query = "delete from MembersTbl where MId = {0}";
                    Query = string.Format(Query, key);
                    con.setData(Query);
                    ShowMemList();
                    MessageBox.Show("Member Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BillingLbl_Click(object sender, EventArgs e)
        {
            
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
            
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
            Login.Admin = false;
        }

        private void MemShipLbl_Click(object sender, EventArgs e)
        {
            if (Login.Admin)
            {
                Memberships Obj = new Memberships();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not Admin!");
            }
        }

        private void RecepLbl_Click(object sender, EventArgs e)
        {
            if (Login.Admin)
            {
                Receptionist Obj = new Receptionist();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not Admin!");
            }
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminLbl_Click(object sender, EventArgs e)
        {
            if (Login.Admin)
            {
                Admin Obj = new Admin();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not Admin!");
            }
        }

        private void AdminLbl_MouseHover(object sender, EventArgs e)
        {
            AdminLbl.BackColor = Color.DarkSeaGreen;
            AdminLbl.ForeColor = Color.White;
        }

        private void AdminLbl_MouseLeave(object sender, EventArgs e)
        {
            AdminLbl.BackColor = Color.WhiteSmoke;
            AdminLbl.ForeColor = Color.Teal;
        }

        private void CoachLbl_MouseHover(object sender, EventArgs e)
        {
            CoachLbl.BackColor = Color.DarkSeaGreen;
            CoachLbl.ForeColor = Color.White;
        }

        private void CoachLbl_MouseLeave(object sender, EventArgs e)
        {
            CoachLbl.BackColor = Color.WhiteSmoke;
            CoachLbl.ForeColor = Color.Teal;
        }

        private void MemberLbl_MouseHover(object sender, EventArgs e)
        {
            MemberLbl.BackColor = Color.DarkSeaGreen;
            MemberLbl.ForeColor = Color.White;
        }

        private void MemberLbl_MouseLeave(object sender, EventArgs e)
        {
            MemberLbl.BackColor = Color.LightGray;
            MemberLbl.ForeColor = Color.Teal;
        }

        private void MemShipLbl_MouseHover(object sender, EventArgs e)
        {
            MemShipLbl.BackColor = Color.DarkSeaGreen;
            MemShipLbl.ForeColor = Color.White;
        }

        private void MemShipLbl_MouseLeave(object sender, EventArgs e)
        {
            MemShipLbl.BackColor = Color.WhiteSmoke;
            MemShipLbl.ForeColor = Color.Teal;
        }

        private void RecepLbl_MouseHover(object sender, EventArgs e)
        {
            RecepLbl.BackColor = Color.DarkSeaGreen;
            RecepLbl.ForeColor = Color.White;
        }

        private void RecepLbl_MouseLeave(object sender, EventArgs e)
        {
            RecepLbl.BackColor = Color.WhiteSmoke;
            RecepLbl.ForeColor = Color.Teal;
        }

        private void BillingLbl_MouseHover(object sender, EventArgs e)
        {
            BillingLbl.BackColor = Color.DarkSeaGreen;
            BillingLbl.ForeColor = Color.White;
        }

        private void BillingLbl_MouseLeave(object sender, EventArgs e)
        {
            BillingLbl.BackColor = Color.WhiteSmoke;
            BillingLbl.ForeColor = Color.Teal;
        }

        private void LogoutLbl_MouseHover(object sender, EventArgs e)
        {
            LogoutLbl.BackColor = Color.DarkSeaGreen;
            LogoutLbl.ForeColor = Color.White;
        }

        private void LogoutLbl_MouseLeave(object sender, EventArgs e)
        {
            LogoutLbl.BackColor = Color.Transparent;
            LogoutLbl.ForeColor = Color.White;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
            Login.Admin = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.LightGray;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.LightGray;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.WhiteSmoke;
        }

        private void Members_MouseDown(object sender, MouseEventArgs e)
        {
            Offset.X = (int)e.X;
            Offset.Y = (int)e.Y;
            mouseDown = true;
        }

        private void Members_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point CurrentScreen = PointToScreen(e.Location);
                Location = new Point(CurrentScreen.X - Offset.X, CurrentScreen.Y - Offset.Y);
            }
        }

        private void Members_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
