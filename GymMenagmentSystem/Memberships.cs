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
    public partial class Memberships : Form
    {
        Functions con;
        public Memberships()
        {
            InitializeComponent();
            con = new Functions();
            ShowMShips();
            showStatus();
        }
        private void ShowMShips()
        {
            
            string Query = "select * from MembershipsTbl";
            MShipList.DataSource = con.GetData(Query);
        }
        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Reset()
        {
            MShipName.Text = "";
            MShipDuration.Text = "";
            MShipGoal.Text = "";
            MShipCost.Text = "";
            
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MShipName.Text == "" || MShipDuration.Text == "" || MShipGoal.Text == "" || MShipCost.Text == "")
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    MembershipFrm Data = new MembershipFrm(MShipName.Text, Convert.ToInt32(MShipDuration.Text), MShipGoal.Text, Convert.ToInt32(MShipCost.Text));
                    string Query = "insert into MembershipsTbl values('{0}',{1},'{2}',{3})";
                    Query = string.Format(Query, MembershipFrm.MShName, MembershipFrm.MShDuration, MembershipFrm.MShGoal, MembershipFrm.MShCost);
                    con.setData(Query);
                    ShowMShips();
                    MessageBox.Show("Membership Added!!!");
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int key = 0;
        private void MShipList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MShipName.Text = MShipList.SelectedRows[0].Cells[1].Value.ToString();
            MShipDuration.Text = MShipList.SelectedRows[0].Cells[2].Value.ToString();
            MShipGoal.Text = MShipList.SelectedRows[0].Cells[3].Value.ToString();
            MShipCost.Text = MShipList.SelectedRows[0].Cells[4].Value.ToString();
           
            if (MShipName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MShipList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Membership!");
                }
                else
                {
                    string Query = "delete from MembershipsTbl where MShipId = {0}";
                    Query = string.Format(Query, key);
                    con.setData(Query);
                    ShowMShips();
                    MessageBox.Show("Membership Deleted");
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MShipName.Text == "" || MShipDuration.Text == "" || MShipGoal.Text == "" || MShipCost.Text == "" || key == 0)
                {
                    if(key == 0 && (MShipName.Text != "" && MShipDuration.Text != "" && MShipGoal.Text != "" && MShipCost.Text == ""))
                    {
                        MessageBox.Show("Please Select a Membership!");
                    }
                    else
                    {
                        MessageBox.Show("Missing Data!");
                    }
                }
                else
                {
                    MembershipFrm Data = new MembershipFrm(MShipName.Text, Convert.ToInt32(MShipDuration.Text), MShipGoal.Text, Convert.ToInt32(MShipCost.Text));
                    string Query = "update MembershipsTbl set MShipName = '{0}',MShipDuration = {1},MShipGoal = '{2}',MShipCost = {3} where MShipId = {4}";
                    Query = string.Format(Query, MembershipFrm.MShName, MembershipFrm.MShDuration, MembershipFrm.MShGoal, MembershipFrm.MShCost,key);
                    con.setData(Query);
                    ShowMShips();
                    MessageBox.Show("Membership Updated!!!");
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
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
        private void MemberLbl_Click(object sender, EventArgs e)
        {
            if (Login.Admin)
            {
                Members Obj = new Members();
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

        private void BillingLbl_Click(object sender, EventArgs e)
        {
            if (Login.Admin)
            {
                Billing Obj = new Billing();
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
        }

        private void SearchBox_Click(object sender, EventArgs e)
        {

        }

        private void AdminLbl_MouseHover(object sender, EventArgs e)
        {
            AdminLbl.BackColor = Color.LightGray;
        }

        private void AdminLbl_MouseLeave(object sender, EventArgs e)
        {
            AdminLbl.BackColor = Color.Transparent;
        }

        private void CoachLbl_MouseHover(object sender, EventArgs e)
        {
            CoachLbl.BackColor = Color.LightGray;
        }

        private void CoachLbl_MouseLeave(object sender, EventArgs e)
        {
            CoachLbl.BackColor = Color.Transparent;
        }

        private void MemberLbl_MouseHover(object sender, EventArgs e)
        {
            MemberLbl.BackColor = Color.LightGray;
        }

        private void MemberLbl_MouseLeave(object sender, EventArgs e)
        {
            MemberLbl.BackColor = Color.Transparent;
        }

        private void MShipLbl_MouseHover(object sender, EventArgs e)
        {
            MShipLbl.BackColor = Color.LightGray;
        }

        private void MShipLbl_MouseLeave(object sender, EventArgs e)
        {
            MShipLbl.BackColor = Color.Transparent;
        }

        private void RecepLbl_MouseLeave(object sender, EventArgs e)
        {
            RecepLbl.BackColor = Color.Transparent;
        }

        private void RecepLbl_MouseHover(object sender, EventArgs e)
        {
            RecepLbl.BackColor = Color.LightGray;
        }

        private void BillingLbl_MouseHover(object sender, EventArgs e)
        {
            BillingLbl.BackColor = Color.LightGray;
        }

        private void BillingLbl_MouseLeave(object sender, EventArgs e)
        {
            BillingLbl.BackColor = Color.Transparent;
        }

        private void LogoutLbl_MouseHover(object sender, EventArgs e)
        {
            LogoutLbl.BackColor = Color.LightGray;
            LogoutLbl.ForeColor = Color.Black;
        }

        private void LogoutLbl_MouseLeave(object sender, EventArgs e)
        {
            LogoutLbl.BackColor = Color.Transparent;
            LogoutLbl.ForeColor = Color.White;
        }
    }
}
