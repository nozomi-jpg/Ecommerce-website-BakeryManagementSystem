using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using cakezilla_crud;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string UserType = "";

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text == "username" && txtpassword.Text == "password")

            {
                new Menu().Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("Incorrect username and password");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select User_Type from User_Accounts where Username=@Username and Password=@Password";
            cmd.Parameters.AddWithValue("Username", txtUserName.Text);
            cmd.Parameters.AddWithValue("Password", txtpassword.Text);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {
                UserType = rdr.GetValue(0).ToString();
            }
            else
                    {
                MessageBox.Show("Invalid Username and Password");
            }

            if (UserType == "Administrator")
            {
                dashboard frm = new dashboard();
                frm.Show();
                this.Hide();
            }
            else if (UserType == "Cashier")
            {
                MenuList frm = new MenuList();
                frm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '\0')
            {
                button4.BringToFront();
                txtpassword.PasswordChar = '*';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '*')
            {
                button3.BringToFront();
                txtpassword.PasswordChar = '\0';
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
