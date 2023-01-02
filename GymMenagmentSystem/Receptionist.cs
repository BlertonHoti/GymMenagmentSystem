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
    public partial class Receptionist : Form
    {
        Functions con;
        public Receptionist()
        {
            InitializeComponent();
            con = new Functions();
            ShowRecepList();
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
        private void ShowRecepList()
        {
            string Query = "select * from ReceptionistTbl";
            RecepList.DataSource = con.GetData(Query);
        }
        private void Reset()
        {
            RecepName.Text = "";
            RecepPhone.Text = "";
            RecepPass.Text = "";
            RecepAdd.Text = "";
            RecepGen.SelectedIndex = -1;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecepName.Text == "" || RecepPhone.Text == "" || RecepAdd.Text == "" || RecepPass.Text == "" || RecepGen.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    ReceptionistFrm Data = new ReceptionistFrm(RecepName.Text, RecepGen.SelectedItem.ToString(), RecepDateBirth.Value.Date.ToString(), RecepAdd.Text, RecepPhone.Text, RecepPass.Text);
                    string Query = "insert into ReceptionistTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, ReceptionistFrm.RName, ReceptionistFrm.RGender, ReceptionistFrm.RBirth, ReceptionistFrm.RAddress, ReceptionistFrm.RPhone, ReceptionistFrm.RPassword);
                    con.setData(Query);
                    ShowRecepList();
                    MessageBox.Show("Receptionist Added!!!");
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int key = 0;
        private void RecepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RecepName.Text = RecepList.SelectedRows[0].Cells[1].Value.ToString();
            RecepGen.SelectedItem = RecepList.SelectedRows[0].Cells[2].Value.ToString();
            RecepDateBirth.Text = RecepList.SelectedRows[0].Cells[3].Value.ToString();
            RecepAdd.Text = RecepList.SelectedRows[0].Cells[4].Value.ToString();
            RecepPhone.Text = RecepList.SelectedRows[0].Cells[5].Value.ToString();
            RecepPass.Text = RecepList.SelectedRows[0].Cells[6].Value.ToString();

            if (RecepName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RecepList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Receptionist!");
                }
                else
                {
                    
                    string Query = "delete from ReceptionistTbl where RecepId = {0}";
                    Query = string.Format(Query, key);
                    con.setData(Query);
                    ShowRecepList();
                    MessageBox.Show("Receptionist Deleted");
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
                if (RecepName.Text == "" || RecepPhone.Text == "" || RecepAdd.Text == "" || RecepPass.Text == "" || RecepGen.SelectedIndex == -1 || key == 0)
                {
                    if(key == 0 && (RecepName.Text != "" && RecepPhone.Text != "" && RecepAdd.Text != "" && RecepPass.Text != "" && RecepGen.SelectedIndex != -1))
                    {
                        MessageBox.Show("Please Select a Receptionist!");
                    }
                    else
                    {
                        MessageBox.Show("Missing Data!");
                    }   
                }
                else
                {
                    ReceptionistFrm Data = new ReceptionistFrm(RecepName.Text, RecepGen.SelectedItem.ToString(), RecepDateBirth.Value.Date.ToString(), RecepAdd.Text, RecepPhone.Text, RecepPass.Text);
                    string Query = "update ReceptionistTbl set RecepName = '{0}',RecepGen = '{1}',RecepDOB = '{2}',RecepAdd = '{3}',RecepPhone = '{4}',RecepPass = '{5}' where RecepId = {6}";
                    Query = string.Format(Query, ReceptionistFrm.RName, ReceptionistFrm.RGender, ReceptionistFrm.RBirth, ReceptionistFrm.RAddress, ReceptionistFrm.RPhone, ReceptionistFrm.RPassword, key);
                    con.setData(Query);
                    ShowRecepList();
                    MessageBox.Show("Receptionist Updated!!!");
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
            Login.Admin = false;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
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
            MemberLbl.BackColor = Color.WhiteSmoke;
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
    }
}
