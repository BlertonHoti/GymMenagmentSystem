using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMenagmentSystem
{
    public partial class Login : Form
    {
        Functions con;
        bool mouseDown;
        private Point Offset;
        public Login()
        {
            InitializeComponent();
            con = new Functions();
        }
        public static int UserId;
        public static bool Admin = false;


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            
            if(UsName.Text == "" || PassName.Text == "" || RecepGen.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                if(RecepGen.SelectedIndex == 1)
                {
                    try
                    {
                        string Query = "Select * from ReceptionistTbl where RecepName = '{0}' and RecepPass = '{1}'";
                        Query = string.Format(Query, UsName.Text, PassName.Text);
                        DataTable dt = con.GetData(Query);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Invalid Receptionist!");
                        }
                        else
                        {
                            Admin = false;
                            UserId = Convert.ToInt32(dt.Rows[0][0].ToString());
                            Members Obj = new Members();
                            Obj.Show();
                            this.Hide();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        string Query = "Select * from AdminTbl where AName = '{0}' and APass = '{1}'";
                        Query = string.Format(Query, UsName.Text, PassName.Text);
                        DataTable dt = con.GetData(Query);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Invalid Admin!");
                        }
                        else
                        {
                            UserId = Convert.ToInt32(dt.Rows[0][0].ToString());
                            Admin = true;
                            Receptionist Obj = new Receptionist();
                            Obj.Show();
                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
             
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RecepGen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.LightGray;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.WhiteSmoke;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            Offset.X = (int)e.X;
            Offset.Y = (int)e.Y;
            mouseDown = true;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point CurrentScreen = PointToScreen(e.Location);
                Location = new Point(CurrentScreen.X - Offset.X, CurrentScreen.Y - Offset.Y);
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
