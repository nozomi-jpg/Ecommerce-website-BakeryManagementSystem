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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddProduct frm = new AddProduct();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserAccounts frm = new UserAccounts();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

            SalesToday();
            MonthlySales();
            YearlySales();
            Customers();
            TotalCakes();
            TotalCupcakes();
            TotalPastry();
            TotalUsers();
            SoldCake();
            SoldCupcake();
            SoldPastry();

        }

        public void SalesToday()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select case when SUM(Price) is null then 0 else SUM(Price) end from Orders where convert(varchar,Date,101)=@Date";
            cmd.Parameters.AddWithValue("Date", DateTime.Now.ToString("MM/dd/yyyy"));
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label23.Text = rdr1.GetValue(0).ToString();
            }
        }


        public void MonthlySales()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select case when SUM(Price) is null then 0 else SUM(Price) end from Orders where month(Date)=month(@Date)";
            cmd.Parameters.AddWithValue("Date", DateTime.Now.ToString("MM/dd/yyyy"));
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label22.Text = rdr1.GetValue(0).ToString();
            }
        }

        public void YearlySales()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select case when SUM(Price) is null then 0 else SUM(Price) end from Orders where year(Date)=year(@Date)";
            cmd.Parameters.AddWithValue("Date", DateTime.Now.ToString("MM/dd/yyyy"));
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label21.Text = rdr1.GetValue(0).ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        public void Customers()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT COALESCE(COUNT(A.Transaction_No), 0) FROM(SELECT DISTINCT Transaction_NO FROM[dbo].[Orders]) A";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label27.Text = rdr1.GetValue(0).ToString();
            }
        }

        public void TotalCakes()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT Count(*) FROM[dbo].[Add_Product] Where Category = 'Cake' ";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label17.Text = rdr1.GetValue(0).ToString();
            }
        }
        public void TotalCupcakes()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT Count(*) FROM[dbo].[Add_Product] Where Category = 'Cupcake' ";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label15.Text = rdr1.GetValue(0).ToString();
            }
        }
        public void TotalPastry()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT Count(*) FROM[dbo].[Add_Product] Where Category = 'Pastry' ";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label16.Text = rdr1.GetValue(0).ToString();
            }

        }
        public void TotalUsers()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT Count(ID) FROM[dbo].[User_Accounts]";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label28.Text = rdr1.GetValue(0).ToString();
            }
        }
        public void SoldCake()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT COALESCE(SUM(Quantity), 0) FROM [dbo].[Orders] where Category = 'Cake' ";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label20.Text = rdr1.GetValue(0).ToString();
            }
        }
        public void SoldPastry()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT COALESCE(SUM(Quantity), 0) FROM [dbo].[Orders] where Category = 'Pastry' ";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label19.Text = rdr1.GetValue(0).ToString();
            }
        }
        public void SoldCupcake()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "SELECT COALESCE(SUM(Quantity), 0) FROM [dbo].[Orders] where Category = 'Cupcake' ";
            SqlDataReader rdr1 = cmd.ExecuteReader();

            if (rdr1.Read() == true)
            {
                label18.Text = rdr1.GetValue(0).ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashboard frm = new dashboard();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TotalSales frm = new TotalSales();
            frm.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
