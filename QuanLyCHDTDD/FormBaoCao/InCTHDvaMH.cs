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
    public partial class InCTHDvaMH : Form
    {
        public InCTHDvaMH()
        {
            InitializeComponent();
        }

        private void InCTHDvaMH_Load(object sender, EventArgs e)
        {
            string sql = "SELECT tblChiTietHoaDon.sMaHD, tblChiTietHoaDon.sMaMH, tblChiTietHoaDon.iSoluong, tblChiTietHoaDon.fGiaban, tblMatHang.sTenMH " +
                "FROM tblChiTietHoaDon INNER JOIN tblMatHang ON tblChiTietHoaDon.sMaMH = tblMatHang.sMaMH";
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS;Initial Catalog=QuanLyCHDTDD;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            CrCTHDvaMH cr = new CrCTHDvaMH();
            cr.SetDataSource(dt);
            crCTHDvaMH.ReportSource = cr;
        }
    }
}
