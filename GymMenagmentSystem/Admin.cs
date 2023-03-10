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
using System.Windows.Input;
using System.Xml.Linq;

namespace GymMenagmentSystem
{
    public partial class Admin : Form
    {
        Functions con;
        bool mouseDown;
        private Point Offset;
        public Admin()
        {
            InitializeComponent();
            con = new Functions();
            ShowAdmin();
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
        private void ShowAdmin()
        {
            string Query = "select * from AdminTbl";
            AdminList.DataSource = con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdName.Text == "" || AdPass.Text == "" || AdGen.SelectedIndex == -1 || AdPhone.Text == "")
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    AdminFrm Data = new AdminFrm(AdName.Text, AdPass.Text, AdGen.SelectedItem.ToString(), AdPhone.Text);
                    string Query = "insert into AdminTbl values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, AdminFrm.AName, AdminFrm.APass, AdminFrm.AGen, AdminFrm.APhone);
                    con.setData(Query);
                    ShowAdmin();
                    MessageBox.Show("Admin Added!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int key = 0;
        private void AdminList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AdName.Text = AdminList.SelectedRows[0].Cells[1].Value.ToString();
            AdPass.Text = AdminList.SelectedRows[0].Cells[2].Value.ToString();
            AdGen.SelectedItem = AdminList.SelectedRows[0].Cells[3].Value.ToString();
            AdPhone.Text = AdminList.SelectedRows[0].Cells[4].Value.ToString();
        
            if (AdName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AdminList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Admins!");
                }
                else
                {
                    string Query = "delete from AdminTbl where AId = {0}";
                    Query = string.Format(Query, key);
                    con.setData(Query);
                    ShowAdmin();
                    MessageBox.Show("Membership Deleted");
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
                if (AdName.Text == "" || AdPass.Text == "" || AdGen.SelectedIndex == -1 || AdPhone.Text == "" || key == 0)
                {
                    if(key == 0 && (AdName.Text != "" && AdPass.Text != "" && AdGen.SelectedIndex != -1 && AdPhone.Text != ""))
                    {
                        MessageBox.Show("Please Select Admins");
                    }
                    else
                    {
                        MessageBox.Show("Missing Data!");
                    }
                }
                else
                {
                    AdminFrm Data = new AdminFrm(AdName.Text, AdPass.Text, AdGen.SelectedItem.ToString(), AdPhone.Text);
                    string Query = "update AdminTbl set AName = '{0}',APass = '{1}',AGen = '{2}',APhone = '{3}' where AId = {4}";
                    Query = string.Format(Query, AdminFrm.AName, AdminFrm.APass, AdminFrm.AGen, AdminFrm.APhone, key);
                    con.setData(Query);
                    ShowAdmin();
                    MessageBox.Show("Admin Updated!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdminLbl_Click(object sender, EventArgs e)
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

        private void AdminLbl_MouseHover(object sender, EventArgs e)
        {
            AdminLbl.BackColor = Color.DarkSeaGreen;
            AdminLbl.ForeColor = Color.White;
        }

        private void AdminLbl_MouseLeave(object sender, EventArgs e)
        {
            AdminLbl.BackColor = Color.LightGray;
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
            BillingLbl.BackColor = Color.WhiteSmoke;
            BillingLbl.ForeColor = Color.Teal;

        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
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
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if(WindowState == FormWindowState.Maximized)
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

        private void Admin_MouseDown(object sender, MouseEventArgs e)
        {
            Offset.X = (int)e.X;
            Offset.Y = (int)e.Y;
            mouseDown = true;
        }

        private void Admin_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown == true)
            {
                Point CurrentScreen = PointToScreen(e.Location);
                Location = new Point(CurrentScreen.X - Offset.X, CurrentScreen.Y - Offset.Y);
            }
        }

        private void Admin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Panel_MouseHover(object sender, EventArgs e)
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
            Login.Admin = false;
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
