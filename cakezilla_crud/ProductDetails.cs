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
using System.IO;

namespace cakezilla_crud
{
    public partial class ProductDetails : Form
    {

      
        public ProductDetails()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Product ID is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }
            else if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Product name is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Focus();
            }
            else if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Price is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox3.Focus();
            }
            else if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("Description is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Focus();
            }
            else if (comboBox1.SelectedText == null)
            {
                MessageBox.Show("Category is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBox1.Focus();
            }
            else
            {
                Class1 NewConnection = new Class1();
                NewConnection.open_connection();

                SqlCommand cmd = new SqlCommand();
                NewConnection.open_connection();

                cmd.Connection = Class1.con;

                cmd.CommandText = "insert into Add_Product(Name,Description, Price, Category, Path)values(@Name,@Description,@Price,@Category, @Path)";
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Price", textBox3.Text);
                cmd.Parameters.AddWithValue("@Description", textBox4.Text);
                cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Path", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                GetID();

               
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

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            if (label6.Text != "update")
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

            cmd.CommandText = "select case when max(ID) is null then 1 else max(ID) + 1 end as ID from Add_Product";
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
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.Text = string.Empty;
            pictureBox4.Image = null;
            textBox2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(openFileDialog1.FileName);
                //textBox5.Text = Path.GetDirectoryName(openFileDialog1.FileName) + @"\" + openFileDialog1.FileName;
                textBox5.Text = openFileDialog1.FileName;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.Text = string.Empty;
            pictureBox4.Image = null;
           textBox5.Text = string.Empty;
           textBox2.Focus();
        }

        
        public void AddDisableButton()
        {
            button12.Enabled = false;
            button12.BackColor = Color.Gray;
        }
        public void UpdateDisableButton()
        {
            button1.Enabled = false;
            button1.BackColor = Color.Gray;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Product ID is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }

            else
            {

                Class1 NewConnection = new Class1();
                NewConnection.open_connection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Class1.con;

                cmd.CommandText = "update Add_Product set Name=@Name,Description=@Description,Price=@Price,Category=@Category,Path=@Path where ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Description", textBox4.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(textBox3.Text));
                cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Path", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record successfully updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
