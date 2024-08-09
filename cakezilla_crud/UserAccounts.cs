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
    public partial class UserAccounts : Form
    {
        public UserAccounts()
        {
            InitializeComponent();
        }
        public static string IDUserAccounts = "";
        public static string NameUserAccounts = "";
        public static string Sex = "";
        public static string Address = "";
        public static string PhoneNumber = "";
        public static string Username = "";
        public static string Password = "";
        public static string UserType = "";

        private void button12_Click(object sender, EventArgs e)
        {
            AddUser frm = new AddUser();
            frm.UpdateDisableButton();
            frm.Show();
            this.Hide();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserAccounts_Load(object sender, EventArgs e)
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
            cmd.CommandText = "select ID, Name, Sex, Address, PhoneNumber, Username, Password, User_Type from User_Accounts";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
     
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                int row = dataGridView1.CurrentRow.Index;
                IDUserAccounts = Convert.ToString(dataGridView1[0, row].Value);
                NameUserAccounts = Convert.ToString(dataGridView1[1, row].Value);
                Sex = Convert.ToString(dataGridView1[2, row].Value);
                Address = Convert.ToString(dataGridView1[3, row].Value);
                PhoneNumber = Convert.ToString(dataGridView1[4, row].Value);
                Username = Convert.ToString(dataGridView1[5, row].Value);
                Password = Convert.ToString(dataGridView1[6, row].Value);
                UserType = Convert.ToString(dataGridView1[7, row].Value);

                AddUser frm = new AddUser();
                frm.textBox1.Text = IDUserAccounts;
                frm.textBox2.Text = NameUserAccounts;
               
                if (Sex == "Female")
                {
                    frm.FemaleChecked();
                }
                else if (Sex == "Male")
                {
                    frm.MaleChecked();
                }
                
                frm.textBox4.Text = Address;
                frm.textBox5.Text = PhoneNumber;
                frm.textBox6.Text = Username;
                frm.textBox7.Text = Password;
                frm.comboBox1.Text = UserType;
                frm.label1.Text = "wow";
                frm.DisableButton();
                frm.AddDisableButton();
                frm.ShowDialog();
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = dataGridView1.CurrentRow.Index;
                    IDUserAccounts = Convert.ToString(dataGridView1[0, row].Value);

                    Class1 NewConnection = new Class1();
                    NewConnection.open_connection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Class1.con;

                    cmd.CommandText = "delete from User_Accounts where ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", IDUserAccounts);
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
            string strReportPath = Application.StartupPath + @"\UserAccountsReport.rpt";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            da.SelectCommand = cmd;
            cmd.Connection = cmd.Connection = Class1.con;
            cmd.CommandText = "select ID, Name, Sex, Address, PhoneNumber, Username, Password, User_Type from User_Accounts";
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

        private void label8_Click(object sender, EventArgs e)
        {
            UserAccounts frm = new UserAccounts();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashboard frm = new dashboard();
            frm.Show();
            this.Hide();
        }
    }
}
