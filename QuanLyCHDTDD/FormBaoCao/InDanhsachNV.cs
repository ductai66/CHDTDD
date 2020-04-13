using QuanLyCHDTDD.CrystalRepost;
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
    public partial class InDanhsachNV : Form
    {
        public InDanhsachNV()
        {
            InitializeComponent();
        }

        private void InDanhsachNV_Load(object sender, EventArgs e)
        {
            string sql = "select * from vv_nhanvien";
            string constr = " Data Source = DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security=True ";
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            DataTable datatable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(datatable);
            CRdanhsachNV cr = new CRdanhsachNV();
            cr.SetDataSource(datatable);
            crDSNV.ReportSource = cr;
        }
    }
}
