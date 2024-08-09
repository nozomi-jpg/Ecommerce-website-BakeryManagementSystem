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
    public partial class TotalSales : Form
    {
        public TotalSales()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void LoadGrid()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID, Name, Size, Quantity, Price, Category from Orders where Format(Date, 'yyyy-MM-dd') between Format(@FromDate,'yyyy-MM-dd') and Format(@ToDate, 'yyyy-MM-dd')";
            cmd.Parameters.AddWithValue("@FromDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ToDate", dateTimePicker2.Value);
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView2.DataSource = dtRecord;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            print frm = new print();

            //Class1 NewConnection = new Class1();
            //NewConnection.open_connection();

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cmd.Connection = Class1.con; ;
            //cmd.CommandText = "select select ID, Name, Size, Quantity, Price, Category from Orders where Format(Date, 'yyyy-MM-dd') between Format(@FromDate,'yyyy-MM-dd') and Format(@ToDate, 'yyyy-MM-dd')";
            //cmd.Parameters.AddWithValue("@FromDate", dateTimePicker1.Value);
            //cmd.Parameters.AddWithValue("@ToDate", dateTimePicker2.Value);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //da.SelectCommand = cmd;
            //dt.Clear();
            //da.Fill(dt);
            //frm.crystalReportViewer1.ReportSource=dt;

            ReportDocument cryRpt = new ReportDocument();
            string strReportPath = Application.StartupPath +  @"\OrdersReport.rpt";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            da.SelectCommand = cmd;
            cmd.Connection = cmd.Connection = Class1.con;
            cmd.CommandText = "select ID, Name, Size, Quantity, Price, Category from Orders where Format(Date, 'yyyy-MM-dd') between Format(@FromDate,'yyyy-MM-dd') and Format(@ToDate, 'yyyy-MM-dd')";

          cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@FromDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ToDate", dateTimePicker2.Value);
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

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            decimal total = 0;
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                total = total + Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value.ToString());
            }

            label7.Text = total.ToString();

            decimal quantity = 0;
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                quantity = quantity + Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value.ToString());
            }

            label6.Text = quantity.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            dashboard frm = new dashboard();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dashboard frm = new dashboard();
            frm.Show();
            this.Hide();
        }
    }
    }
    

