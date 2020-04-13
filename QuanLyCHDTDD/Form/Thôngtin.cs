using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCHDTDD
{
    public partial class Thôngtin : Form
    {
        public Thôngtin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Thôngtin_Load(object sender, EventArgs e)
        {
            string constr = "Data Source = DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            string tim_sql = "pr_info ";
            tim_sql = tim_sql + " @username='" + DangNhap.temp + "'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(tim_sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvThongtin.DataSource = tb;
                    }
                }
            }
        }
    }
}
