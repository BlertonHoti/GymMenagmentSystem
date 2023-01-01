﻿using System;
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

        private void MembersLbl_MouseHover(object sender, EventArgs e)
        {
            MembersLbl.BackColor = Color.LightGray;
        }

        private void MembersLbl_MouseLeave(object sender, EventArgs e)
        {
            MembersLbl.BackColor = Color.Transparent;
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