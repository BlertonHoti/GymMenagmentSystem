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
    public partial class Billing : Form
    {
        Functions con;
        bool mouseDown;
        private Point Offset;
        public Billing()
        {
            InitializeComponent();
            con = new Functions();
            ShowBilling();
            GetMembers();
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
        private void ShowBilling()
        {
            string Query = "select * from FinanceTbl";
            BillingList.DataSource = con.GetData(Query);
        }
        private void GetMembers()
        {
            string Query = "Select * from MembersTbl";
            BillMember.DisplayMember = con.GetData(Query).Columns["MName"].ToString();
            BillMember.ValueMember = con.GetData(Query).Columns["MId"].ToString();
            BillMember.DataSource = con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BillMember.Text == "" || BillAmount.Text == "")
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    BillingFrm Data = new BillingFrm(Login.UserId, BillMember.SelectedValue.ToString(), BillPeriod.Value.Date.Month + "-" + BillPeriod.Value.Date.Year, BillDate.Value.Date.ToString(), BillAmount.Text);
                    string Query = "insert into FinanceTbl values({0},'{1}','{2}','{3}', '{4}')";
                    Query = string.Format(Query, BillingFrm.BAgent, BillingFrm.BMember, BillingFrm.BPeriod, BillingFrm.BDate, BillingFrm.BAmount);
                    con.setData(Query);
                    ShowBilling();
                    MessageBox.Show("Bill Added!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MembersLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            BillAmount.Text = "";
            BillMember.SelectedIndex = -1;
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
            Login.Admin = false;
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

        private void MShipLbl_Click(object sender, EventArgs e)
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

        private void pictureBox8_Click(object sender, EventArgs e)
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

        private void MembersLbl_MouseHover(object sender, EventArgs e)
        {
            MembersLbl.BackColor = Color.DarkSeaGreen;
            MembersLbl.ForeColor = Color.White;
        }

        private void MembersLbl_MouseLeave(object sender, EventArgs e)
        {
            MembersLbl.BackColor = Color.WhiteSmoke;
            MembersLbl.ForeColor = Color.Teal;
        }

        private void MShipLbl_MouseHover(object sender, EventArgs e)
        {
            MShipLbl.BackColor = Color.DarkSeaGreen;
            MShipLbl.ForeColor = Color.White;
        }

        private void MShipLbl_MouseLeave(object sender, EventArgs e)
        {
            MShipLbl.BackColor = Color.WhiteSmoke;
            MShipLbl.ForeColor = Color.Teal;
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
            BillingLbl.BackColor = Color.LightGray;
            BillingLbl.ForeColor = Color.Teal;
        }

        private void LogoutLbl_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.DarkSeaGreen;
            pictureBox7.BackColor = Color.DarkSeaGreen;
            LogoutLbl.BackColor = Color.DarkSeaGreen;
        }

        private void LogoutLbl_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.SeaGreen;
            pictureBox7.BackColor = Color.Transparent;
            LogoutLbl.BackColor = Color.Transparent;
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

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.LightGray;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.LightGray;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.WhiteSmoke;
        }

        private void Billing_MouseDown(object sender, MouseEventArgs e)
        {
            Offset.X = (int)e.X;
            Offset.Y = (int)e.Y;
            mouseDown = true;
        }

        private void Billing_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point CurrentScreen = PointToScreen(e.Location);
                Location = new Point(CurrentScreen.X - Offset.X, CurrentScreen.Y - Offset.Y);
            }
        }

        private void Billing_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
            Login.Admin = false;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.DarkSeaGreen;
            pictureBox7.BackColor = Color.DarkSeaGreen;
            LogoutLbl.BackColor = Color.DarkSeaGreen;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.SeaGreen;
            pictureBox7.BackColor = Color.Transparent;
            LogoutLbl.BackColor = Color.Transparent;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.DarkSeaGreen;
            pictureBox7.BackColor = Color.DarkSeaGreen;
            LogoutLbl.BackColor = Color.DarkSeaGreen;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.SeaGreen;
            pictureBox7.BackColor = Color.Transparent;
            LogoutLbl.BackColor = Color.Transparent;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
            Login.Admin = false;
        }
    }
}
