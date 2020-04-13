using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCHDTDD
{
    public partial class InDSHD : Form
    {
        public InDSHD()
        {
            InitializeComponent();
        }

        private void InDSHD_Load(object sender, EventArgs e)
        {
            //string sql = "select * from tblHoaDon";
            //string constr = " Data Source = DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security=True ";
            //SqlConnection cnn = new SqlConnection(constr);
            //SqlCommand cmd = new SqlCommand(sql, cnn);
            //DataTable datatable = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(datatable);
            //CrystalReportHD cr = new CrystalReportHD();
            //cr.SetDataSource(datatable);
            //crystalReportHD.ReportSource = cr;

            //CRhoadon cRhoadon = new CRhoadon();
            //crystalReportHD.ReportSource = cRhoadon;
        }
    }
}
