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

namespace cakezilla_crud
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("User ID is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }

            else if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Name is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Focus();
            }

            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Sex is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("Address is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Focus();
            }

            else if (textBox5.Text == string.Empty)
            {
                MessageBox.Show("Phone number is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox5.Focus();
            }

            else if (textBox6.Text == string.Empty)
            {
                MessageBox.Show("Username is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox6.Focus();
            }
            else if (textBox7.Text == string.Empty)
            {
                MessageBox.Show("Password is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Focus();
            }
            else if (comboBox1.SelectedText == null)
            {
                MessageBox.Show("User Type is Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBox1.Focus();
            }
            else
            {

                Class1 NewConnection = new Class1();
                NewConnection.open_connection();

                SqlCommand cmd = new SqlCommand();
                //cmd.Connection = Class1.con;

                //cmd.CommandText = "select ID from User_Accounts where ID=@a";
                //cmd.Parameters.AddWithValue("@a", textBox1.Text);
                //SqlDataReader rdr = cmd.ExecuteReader();

                //if (rdr.Read() == true)
                //{
                //    MessageBox.Show("ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    textBox1.Focus();
                //}
                //else

                //{


                NewConnection.open_connection();

                cmd.Connection = Class1.con;

                cmd.CommandText = "insert into User_Accounts(Name,Sex,Address,PhoneNumber,Username,Password, User_Type)values(@Name,@Sex,@Address,@PhoneNumber,@Username,@Password,@User_Type)";
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);

                if (radioButton1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Sex", radioButton1.Text);
                }
                else if (radioButton2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Sex", radioButton2.Text);
                }

                cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Username", textBox6.Text);
                cmd.Parameters.AddWithValue("@Password", textBox7.Text);
                cmd.Parameters.AddWithValue("@User_Type", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                GetID();

                //}
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            if (label1.Text != "wow")
            {
                GetID();
            }
            
        }

        public void GetID()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select case when max(ID) is null then 1 else max(ID) + 1 end as ID from User_Accounts";
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {
                textBox1.Text = rdr.GetValue(0).ToString();
            }
        }

        public void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox2.Focus();
        }

       
        public void AddDisableButton()
        {
            button12.Enabled = false;
            button12.BackColor = Color.Gray;
        }
        public void UpdateDisableButton()
        {
            button7.Enabled = false;
            button7.BackColor = Color.Gray;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("ID is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }

            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();

                SqlCommand cmd = new SqlCommand();

                NewConnection.open_connection();

                cmd.Connection = Class1.con;

                cmd.CommandText = "update User_Accounts set Name=@Name,Sex=@Sex,Address=@Address,PhoneNumber=@PhoneNumber,Username=@Username,Password=@Password, User_Type=@User_Type where ID=@ID";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);

                if (radioButton1.Checked == true)
                {
                   cmd.Parameters.AddWithValue("@Sex", radioButton1.Text);
                }
               else if (radioButton2.Checked == true)
                {
                   cmd.Parameters.AddWithValue("@Sex", radioButton2.Text);
               }

                cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Username", textBox6.Text);
                cmd.Parameters.AddWithValue("@Password", textBox7.Text);
                cmd.Parameters.AddWithValue("@User_Type", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableButton();
                AddDisableButton();
                clear();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void DisableButton()
        {
            button10.Enabled = false;
            button10.BackColor = Color.Gray;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            comboBox1.Text = string.Empty;
            textBox2.Focus();
        }

        public void MaleChecked()
        {
            radioButton2.Checked = true;
        }

        public void FemaleChecked()
        {
            radioButton1.Checked = true;
        }
    }
}
