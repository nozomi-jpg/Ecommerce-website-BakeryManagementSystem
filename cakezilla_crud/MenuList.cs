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
    public partial class MenuList : Form
    {
        public MenuList()
        {
            InitializeComponent();
        }
        public static string IDOrder = "";
        public static string OrderName = "";
        public static string Price = "";
        public static string Category = "";
        public static string Path = "";

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Class1 NewConnection = new Class1();
            NewConnection.open_connection();


            SqlCommand cmd = new SqlCommand();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                cmd.Connection = cmd.Connection = Class1.con;
                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO Orders (Transaction_No, ID,Name,SizeOrSet,Quantity,Price,Category, Date) values (@Transaction_No,@ID,@Name,@SizeOrSet,@Quantity,@Price,@Category, @Date)";



                //var row = dataGridView2.Rows[i];

                //if (!row.IsNewRow)
                //{
                cmd.Parameters.AddWithValue("@Transaction_No", Convert.ToInt32(label3.Text));
                cmd.Parameters.AddWithValue("@ID", Convert.ToString(row.Cells[0].Value));
                cmd.Parameters.AddWithValue("@Name", Convert.ToString(row.Cells[1].Value));
                cmd.Parameters.AddWithValue("@SizeOrSet", Convert.ToString(row.Cells[2].Value));
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToString(row.Cells[3].Value));
                cmd.Parameters.AddWithValue("@Price", Convert.ToString(row.Cells[4].Value));
                cmd.Parameters.AddWithValue("@Category", Convert.ToString(row.Cells[5].Value));
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                // }


            }
            MessageBox.Show("Record successfully inserted");
            GetID();
            dataGridView2.Rows.Clear();
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

        private void MenuList_Load(object sender, EventArgs e)
        {
            LoadGrid();
            GetID();

        }

        public void GetID()
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class1.con;

            cmd.CommandText = "select case when max(Transaction_No) is null then 1 else max(Transaction_No) + 1 end as Transaction_No from Orders";
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {
                label3.Text = rdr.GetValue(0).ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                int row = dataGridView1.CurrentRow.Index;
                IDOrder = Convert.ToString(dataGridView1[0, row].Value);
                OrderName = Convert.ToString(dataGridView1[1, row].Value);
                Price = Convert.ToString(dataGridView1[3, row].Value);
                Category = Convert.ToString(dataGridView1[4, row].Value);
                Path = Convert.ToString(dataGridView1[5, row].Value);

                ProductBuy frm = new ProductBuy(this);
                frm.textBox4.Text = Category;
                frm.textBox3.Text = IDOrder;
                frm.textBox1.Text = OrderName;
                frm.textBox2.Text = Price;
                frm.pictureBox7.Image = Image.FromFile(Path);
                frm.textBox5.Text = Path;

                frm.Show();

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

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            decimal sum = 0;
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                sum = sum + Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value.ToString());
            }

            textBox3.Text = sum.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(textBox5.Text))
            {
                decimal sum = 0;

                sum = Convert.ToDecimal(textBox5.Text) - Convert.ToDecimal(textBox3.Text);
                textBox4.Text = sum.ToString();

            }
            else
            {
                Decimal sum = 0;
                textBox4.Text = sum.ToString();

            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1 NewConnection = new Class1();
            NewConnection.open_connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmd.Connection = Class1.con; ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID, Name, Description, Price, Category, Path from Add_Product where Category = @Category";
            cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
    string.Format("Name LIKE '{0}%' OR Name LIKE '% {0}%'", textBox1.Text);
        }
    }
}


