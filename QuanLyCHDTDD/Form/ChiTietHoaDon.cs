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
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            Load_Grid();
        }
        public void Load_Grid()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from ds_ChitietHD", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvCTHD.DataSource = tb;
                    }
                }
            }
        }

        /*private void btnTim_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string tim_sql = "select * from tblChiTietHoaDon where sMaHD is not null";
                if (txtNhapma.Text != "")
                    tim_sql = tim_sql + " and sMaHD = N'" + txtNhapma.Text + "'";

                using (SqlCommand cmd = new SqlCommand(tim_sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvCTHD.DataSource = tb;
                    }
                }
            }
        }

        private void btnTinhtong_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "tongtien_hd";
                    cmd.Parameters.AddWithValue("@mahd", txtNhapma.Text);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvCTHD.DataSource = tb;
                    }
                }
            }
        }*/
        private int kiemtraHD()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = textMaHD.Text;
                string sql = "Select hd.sMaHD from tblHoaDon as hd where hd.sMaHD=N'" + k.ToString() + "'";
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
        private int kiemtraMH()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = textMaMH.Text;
                string sql = "Select mh.sMaMH from tblMatHang as mh where mh.sMaMH=N'" + k.ToString() + "'";
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

        private int kiemtraHDMH()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = textMaHD.Text;
                string h = textMaMH.Text;
                string sql = "Select cthd.sMaHD,cthd.sMaMH from tblChiTietHoaDon as cthd where cthd.sMaHD=N'" + k.ToString() + "' and cthd.sMaMH=N'"+ h.ToString() +"'";
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
                    if (kiemtraHD() == 0)
                    {
                        MessageBox.Show("Mã hóa đơn này không tồn tại");
                        textMaHD.Focus();
                    }
                    else if (kiemtraMH() == 0)
                    {
                        MessageBox.Show("Mã mặt hàng này không tồn tại");
                        textMaMH.Focus();
                    }
                    else if (kiemtraHDMH() == 1)
                    {
                        MessageBox.Show("Chi tiết hóa đơn này đã tồn tại bạn chỉ có thể sửa hoặc tạo mới !");
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_them_cthd";
                            cmd.Parameters.AddWithValue("@mahd", textMaHD.Text);
                            cmd.Parameters.AddWithValue("@mamh", textMaMH.Text);
                            cmd.Parameters.AddWithValue("@soluong", textSoluong.Text);
                            cmd.Parameters.AddWithValue("@giaban", textGiaban.Text);
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
                    if (kiemtraHD() == 0)
                    {
                        MessageBox.Show("Mã hóa đơn này không tồn tại");
                        textMaHD.Focus();
                    }
                    else if (kiemtraMH() == 0)
                    {
                        MessageBox.Show("Mã mặt hàng này không tồn tại");
                        textMaMH.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_update_cthd";
                            cmd.Parameters.AddWithValue("@mahd", textMaHD.Text);
                            cmd.Parameters.AddWithValue("@mamh", textMaMH.Text);
                            cmd.Parameters.AddWithValue("@soluong", textSoluong.Text);
                            cmd.Parameters.AddWithValue("@giaban", textGiaban.Text);
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error Connection"+ex);
                }
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textMaHD.Text = dgvCTHD.CurrentRow.Cells["Mã hóa đơn"].Value.ToString();
            textMaMH.Text = dgvCTHD.CurrentRow.Cells["Mã mặt hàng"].Value.ToString();
        }

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCTHD_CellClick(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textMaHD.Clear();
            textMaMH.Clear();
            textSoluong.Clear();
            textGiaban.Clear();
        }
    }
}
