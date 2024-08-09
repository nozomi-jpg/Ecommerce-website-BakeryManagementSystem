using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cakezilla_crud
{
    public partial class ProductBuy : Form
    {
        MenuList frm1;
        public ProductBuy(MenuList fg)
        {
            InitializeComponent();
            this.frm1 = fg;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Size is empty!", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(numericUpDown1.Text) == 0)
            {
                MessageBox.Show("Quantity is empty!", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.SelectedItem.ToString() == "Box of 6")
            {
                frm1.dataGridView2.Rows.Add(textBox3.Text, textBox1.Text, comboBox1.Text, numericUpDown1.Text, (Convert.ToDecimal(textBox2.Text)*6) * Convert.ToDecimal(numericUpDown1.Text), textBox4.Text);
            } 
            else
            { 

                //MenuList frm = new MenuList();
                frm1.dataGridView2.Rows.Add(textBox3.Text, textBox1.Text, comboBox1.Text, numericUpDown1.Text, Convert.ToDecimal(textBox2.Text) * Convert.ToDecimal(numericUpDown1.Text), textBox4.Text);
                //frm.Hide();
                //frm.ShowDialog();
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (textBox4.Text == "Cake")
            {
                
                comboBox1.Items.Add("Small");
                comboBox1.Items.Add("Medium");
                comboBox1.Items.Add("Large");
            }
            else if (textBox4.Text == "Cupcake" || textBox4.Text == "Pastry")
            {
                
                comboBox1.Items.Add("Each");
                comboBox1.Items.Add("Box of 6");
            }
        }

    }
}



