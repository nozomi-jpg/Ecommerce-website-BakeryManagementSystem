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
using CrystalDecisions.CrystalReports.Engine;

namespace cakezilla_crud
{

   
    public partial class AddProduct : Form
    {
        

        public AddProduct()
        {
            InitializeComponent();
        }
        public static string IDProduct = "";
        public static string NameOfProduct = "";
        public static string Price = "";
        public static string Description = "";
        public static string Category = "";
        public static string Path = "";
        

        private void button12_Click(object sender, EventArgs e)
        {
            ProductDetails frm = new ProductDetails();
            frm.UpdateDisableButton();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                {


                int row = dataGridView1.CurrentRow.Index;
                IDProduct = Convert.ToString(dataGridView1[0, row].Value);
                NameOfProduct = Convert.ToString(dataGridView1[1, row].Value);
                Description = Convert.ToString(dataGridView1[2, row].Value);
                Price = Convert.ToString(dataGridView1[3, row].Value);
                Category = Convert.ToString(dataGridView1[4, row].Value);
                Path = Convert.ToString(dataGridView1[5, row].Value);

                ProductDetails frm = new ProductDetails();
                frm.textBox1.Text = IDProduct;
                frm.textBox2.Text = NameOfProduct;
                frm.textBox3.Text = Price;
                frm.textBox4.Text = Description;
                frm.comboBox1.Text = Category;
                frm.pictureBox4.Image = Image.FromFile(Path);  
                frm.textBox5.Text = Path;
                frm.label6.Text = "update";
                //MessageBox.Show(Path);
                frm.AddDisableButton();
                
                frm.ShowDialog();
            }
        }



        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               

                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = dataGridView1.CurrentRow.Index;
                    IDProduct = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;

                    cmd.CommandText = "delete from Add_Product where ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", IDProduct);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record successfully deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            print frm = new print();

            ReportDocument cryRpt = new ReportDocument();
            string strReportPath = Application.StartupPath + @"\ProductReport.rpt";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            da.SelectCommand = cmd;
            cmd.Connection = cmd.Connection = Class1.con;
            cmd.CommandText = "select ID, Name, Description, Price, Category, Path from Add_Product";
            cmd.CommandTimeout = 0;
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                cryRpt.Load(strReportPath);
                cryRpt.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource = cryRpt;
                frm.crystalReportViewer1.Refresh();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("No records found.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        public void LoadGrid()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID, Name, Description, Price, Category, Path from Add_Product";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            dashboard frm = new dashboard();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashboard frm = new dashboard();
            frm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
    string.Format("Name LIKE '{0}%' OR Name LIKE '% {0}%'", textBox1.Text);
        }
    }
}
