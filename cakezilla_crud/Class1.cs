using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cakezilla_crud
{
    class Class1
    {
        public static SqlConnection con = null;
        public void open_connection()
        {
            con = new SqlConnection("Data Source=DESKTOP-LDAMHSD;Initial Catalog=cakezilla_crud;Integrated Security=True");
            con.Open();
        }
    }
}
