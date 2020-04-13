using QuanLyCHDTDD.CrystalRepost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCHDTDD
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            Load_Grid();
            btnThanhtoan.Enabled = false;
            btnCTHD.Enabled = false;
        }
        public void Load_Grid()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from ds_hoadon", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvHD.DataSource = tb;
                    }
                }
            }
        }
        private void btnThongke_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "thongkehd_ngay";
                    cmd.Parameters.AddWithValue("@ngaydat", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@ngay", dateTimePicker2.Value);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvHD.DataSource = tb;
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình ? ", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Close();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            //InDSHD indshd = new InDSHD();
            //indshd.Show();
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanlyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "thongkehd_ngay";
                        cmd.Parameters.AddWithValue("@ngaydat", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@ngay", dateTimePicker2.Value);

                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            DataTable tb = new DataTable();
                            ad.Fill(tb);
                            CRthongkeDSHD cr = new CRthongkeDSHD();
                            cr.SetDataSource(tb);
                            InDSHD f = new InDSHD();
                            f.crystalReportHD.ReportSource = cr;
                            f.ShowDialog();
                        }
                    }
                }
            }
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dgvHD.CurrentRow.Cells["Mã hóa đơn"].Value.ToString();
            textMaHD.Text = dgvHD.CurrentRow.Cells["Mã hóa đơn"].Value.ToString();
            textMaHD.Enabled = false;
        }

        private void dgvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvHD_CellClick(sender, e);
            
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanlyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_hd";
                        cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text);

                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            DataTable tb = new DataTable();
                            ad.Fill(tb);
                            CRthanhtoanHD cr = new CRthanhtoanHD();
                            cr.SetDataSource(tb);
                            InThanhToanHD f = new InThanhToanHD();
                            f.crTTHD.ReportSource = cr;
                            f.ShowDialog();
                        }
                    }
                }
            }
        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanlyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_chitietTTHD";
                        cmd.Parameters.AddWithValue("@mahd",txtMaHD.Text);
                        cnn.Open();
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            DataTable tb = new DataTable();
                            ad.Fill(tb);
                            dgvHD.DataSource = tb;
                        }
                    }
                }
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            btnThanhtoan.Enabled = !string.IsNullOrEmpty(txtMaHD.Text);
            btnCTHD.Enabled = !string.IsNullOrEmpty(txtMaHD.Text);
        }
        private int kiemtra()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = textMaHD.Text;
                string sql = "Select * from tblHoaDon where sMaHD=N'" + k.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        if (tb.Rows.Count > 0)
                            return 1;
                        else
                            return 0;
                    }
                }
            }
        }
        private int kiemtraNV()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = textMaNV.Text;
                string sql = "Select nv.sMaNV from tblNhanVien as nv where nv.sMaNV=N'" + k.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        if (tb.Rows.Count > 0)
                            return 1;
                        else
                            return 0;
                    }
                }
            }
        }
        private int kiemtraKH()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = textMaKH.Text;
                string sql = "Select kh.sMaKH from tblKhachHang as kh where kh.sMaKH=N'" + k.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        if (tb.Rows.Count > 0)
                            return 1;
                        else
                            return 0;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã hóa đơn này đã tồn tại");
                        textMaHD.Focus();
                    }
                    else if (kiemtraNV() == 0)
                    {
                        MessageBox.Show("Mã NV này không tồn tại");
                        textMaNV.Focus();
                    }
                    else if (kiemtraKH() == 0)
                    {
                        MessageBox.Show("Mã KH này không tồn tại");
                        textMaKH.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_them_hd";
                            cmd.Parameters.AddWithValue("@mahd", textMaHD.Text);
                            cmd.Parameters.AddWithValue("@manv", textMaNV.Text);
                            cmd.Parameters.AddWithValue("@makh", textMaKH.Text);
                            cmd.Parameters.AddWithValue("@ngaydat", Convert.ToDateTime(mNgaydat.Text));
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Thêm thành công");
                                cnn.Close();
                                Load_Grid();
                            }
                        }

                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Error Connection" + ex);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã hóa đơn này đã tồn tại");
                        textMaHD.Focus();
                    }
                    else if (kiemtraNV() == 0)
                    {
                        MessageBox.Show("Mã NV này không tồn tại");
                        textMaNV.Focus();
                    }
                    else if (kiemtraKH() == 0)
                    {
                        MessageBox.Show("Mã KH này không tồn tại");
                        textMaNV.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_update_hd";
                            cmd.Parameters.AddWithValue("@mahd", textMaHD.Text);
                            cmd.Parameters.AddWithValue("@manv", textMaNV.Text);
                            cmd.Parameters.AddWithValue("@makh", textMaKH.Text);
                            cmd.Parameters.AddWithValue("@ngaydat", Convert.ToDateTime(mNgaydat.Text));
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Sửa thành công");
                                cnn.Close();
                                Load_Grid();
                            }
                        }

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error Connection" + ex);
                }
            }
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
            chiTietHoaDon.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textMaHD.Clear();
            textMaNV.Clear();
            textMaKH.Clear();
            mNgaydat.Clear();
        }
    }
}
