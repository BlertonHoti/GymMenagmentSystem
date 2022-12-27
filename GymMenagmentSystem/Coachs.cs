﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMenagmentSystem
{
    public partial class Coachs : Form
    {
        Functions con;
        public Coachs()
        {
            InitializeComponent();
            con = new Functions();
            ShowCoach();
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

        private void CGenT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ShowCoach()
        {
            string Query = "select * from CoachTbl";
            ChList.DataSource = con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(ChName.Text == "" || ChPhone.Text == "" || ChExperience.Text == "" || ChPass.Text == "" || ChGen.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    CoachFrm Data = new CoachFrm(ChName.Text, ChGen.SelectedItem.ToString(), ChPhone.Text, Convert.ToInt32(ChExperience.Text), ChAddress.Text, ChPass.Text);
                    string Query = "insert into CoachTbl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                    Query = string.Format(Query, CoachFrm.CName, CoachFrm.CGender, ChDateBirth.Value.Date, CoachFrm.CPhone, CoachFrm.CExperience, CoachFrm.CAddress, CoachFrm.CPassword);
                    con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Added!!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }
        int key = 0;
        private void ChList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ChName.Text = ChList.SelectedRows[0].Cells[1].Value.ToString();
            ChGen.SelectedItem = ChList.SelectedRows[0].Cells[2].Value.ToString();
            ChDateBirth.Text = ChList.SelectedRows[0].Cells[3].Value.ToString();
            ChPhone.Text = ChList.SelectedRows[0].Cells[4].Value.ToString();
            ChExperience.Text = ChList.SelectedRows[0].Cells[5].Value.ToString();
            ChAddress.Text = ChList.SelectedRows[0].Cells[6].Value.ToString();
            ChPass.Text = ChList.SelectedRows[0].Cells[7].Value.ToString();
            if(ChName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ChList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Coach!");
                }
                else
                {
                    string CName = ChName.Text;
                    string CGender = ChGen.SelectedItem.ToString();
                    string CPhone = ChPhone.Text;
                    int CExperience = Convert.ToInt32(ChExperience.Text);
                    string CAddress = ChAddress.Text;
                    string CPassword = ChPass.Text;
                    string Query = "delete from CoachTbl where CId = {0}";
                    Query = string.Format(Query, key);
                    con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Deleted");
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
                if (ChName.Text == "" || ChPhone.Text == "" || ChExperience.Text == "" || ChPass.Text == "" || ChGen.SelectedIndex == -1 || key == 0)
                {
                    if(key == 0 && (ChName.Text != "" && ChPhone.Text != "" && ChExperience.Text != "" && ChPass.Text != "" && ChGen.SelectedIndex != -1))
                    {
                        MessageBox.Show("Please Select a Coach!");
                    }
                    else
                    {
                        MessageBox.Show("Missing Data!");
                    }
                    
                }
                else
                {
                    string CName = ChName.Text;
                    string CGender = ChGen.SelectedItem.ToString();
                    string CPhone = ChPhone.Text;
                    int CExperience = Convert.ToInt32(ChExperience.Text);
                    string CAddress = ChAddress.Text;
                    string CPassword = ChPass.Text;
                    string Query = "update CoachTbl set CName = '{0}',CGen = '{1}',CDOB = '{2}',CPhone = '{3}',CExperience = '{4}',CAddress = '{5}',CPass = '{6}' where CId = {7}";
                    Query = string.Format(Query, CName, CGender, ChDateBirth.Value.Date, CPhone, CExperience, CAddress, CPassword, key);
                    con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Updated!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                Memberships Obj1 = new Memberships();
                Obj1.Show();
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
                Receptionist Obj2 = new Receptionist();
                Obj2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not Admin!");
            }
        }

        private void MemberLbl_Click_1(object sender, EventArgs e)
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

        private void ExitImg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
            Login.Admin = false;
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

        private void Status_Click(object sender, EventArgs e)
        {

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
            AdminLbl.BackColor = Color.LightGray;
        }

        private void AdminLbl_MouseLeave(object sender, EventArgs e)
        {
            AdminLbl.BackColor = Color.Transparent;
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            label10.BackColor = Color.LightGray;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.BackColor = Color.Transparent;
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

        private void RecepLbl_MouseHover(object sender, EventArgs e)
        {
            RecepLbl.BackColor = Color.LightGray;
        }

        private void RecepLbl_MouseLeave(object sender, EventArgs e)
        {
            RecepLbl.BackColor = Color.Transparent;
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
