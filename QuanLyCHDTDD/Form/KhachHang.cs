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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            Load_Grid();
            radiobtnNam.Select();
            textBox();
        }
        void textBox()
        {
            txtMaKH.MaxLength = 10;
            txtTenKH.MaxLength = 30;
            txtDiachi.MaxLength = 30;
            txtSdt.MaxLength = 12;
        }
        void Load_Grid()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from vv_khachhang", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvKH.DataSource = tb;
                    }
                }
            }
        }

        private int kiemtra()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = txtMaKH.Text;
                string sql = "Select * from tblKhachHang where sMaKH=N' " + k.ToString() + "'";
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
            txtMaKH.Enabled = true;
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại");
                        txtMaKH.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_them_kh";
                            if (radiobtnNam.Checked)
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNam.Text);
                            else
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNu.Text);
                            try
                            {
                                if (txtMaKH.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập mã khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (txtTenKH.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập tên khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (txtDiachi.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (txtSdt.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập số điện thoại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@makh", txtMaKH.Text);
                                    cmd.Parameters.AddWithValue("@tenkh", txtTenKH.Text);
                                    cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                                    cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                                    cnn.Open();
                                    int i = cmd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        MessageBox.Show("Thêm thành công");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi: " + ex);
                            }
                            cnn.Close();
                            Load_Grid();
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
            txtMaKH.Enabled = true;
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã khách hàng này tồn tại");
                        txtMaKH.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_update_kh";
                            cmd.Parameters.AddWithValue("@makh", txtMaKH.Text);
                            cmd.Parameters.AddWithValue("@tenkh", txtTenKH.Text);
                            if (radiobtnNam.Checked)
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNam.Text);
                            else
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNu.Text);
                            cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                            cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Sua thanh cong");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = true;
            DialogResult kq = MessageBox.Show("Ban muon xoa khong ?", "Thong bao", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD ; Integrated Security = True";
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    try
                    {
                        if (kiemtra() == 0)
                        {
                            MessageBox.Show("Mã khách hàng này không tồn tại");
                        }
                        else
                        {
                            using (SqlCommand cmd = cnn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "sp_remove_kh";
                                cmd.Parameters.AddWithValue("@makh", txtMaKH.Text);
                                cnn.Open();
                                cmd.ExecuteNonQuery();
                                Load_Grid(); //load lai sau khi xoa 
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error Connection" + ex);
                    }
                }
            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dgvKH.CurrentRow.Cells["Ma khach hang"].Value.ToString();
            txtMaKH.Enabled = false;
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvKH_CellClick(sender, e);
        }

        private void txtMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IndexOfAny(@"!@#$%^&*()-+_=:'<>?,./".ToCharArray()) != -1 && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Không chứa ký tự đặc biệt", "Thông báo");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtMaKH_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                error.SetError(txtMaKH, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtMaKH, "");
            }
        }

        private void txtTenKH_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenKH.Text == "")
            {
                error.SetError(txtTenKH, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtTenKH, "");
            }
        }

        private void txtDiachi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiachi.Text == "")
            {
                error.SetError(txtDiachi, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtDiachi, "");
            }
        }

        private void txtSdt_Validating(object sender, CancelEventArgs e)
        {
            if (txtSdt.Text == "")
            {
                error.SetError(txtSdt, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtSdt, "");
            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IndexOfAny(@"!@#$%^&*()-+_=:'<>?,./".ToCharArray()) != -1)
            {
                e.Handled = true;
                MessageBox.Show("Không được nhập ký tự", "Thông báo");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ nhập số");
                e.Handled = true;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string constr = "Data Source = DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            string tim_sql = null;
            string a = txtNhapMaKH.Text;
            try
            {
                if (txtNhapMaKH.Text != null)
                {
                    tim_sql = tim_sql + "select * from vv_khachhang where [Ma khach hang] = N'" + txtNhapMaKH.Text + "' " +
                        "or [Ten khach hang] LIKE N'%" + txtNhapMaKH.Text + "%' ";
                }
                if (txtNhapMaKH.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập dữ liệu !");
                }
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(tim_sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKH.DataSource = dt;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối"+ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiachi.Clear();
            txtSdt.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình ? ", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Close();
        }
    }
}
