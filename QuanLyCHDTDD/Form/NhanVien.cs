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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            Load_Grid();
            radiobtnNam.Select();
            radioDanglam.Select();
            textBox();
        }

        void textBox()
        {
            txtMaNV.MaxLength = 10;
            txtTenNV.MaxLength = 30;
            txtDiachi.MaxLength = 30;
            txtSdt.MaxLength = 12;
        }

        void Load_Grid()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from vv_nhanvien", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvNV.DataSource = tb;
                    }
                }
            }
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                error.SetError(txtMaNV, "Không được để trống");
            }
            else
            {
                error.SetError(txtMaNV, "");
            }
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IndexOfAny(@"0123456789!@#$%^&*()-+_=:'<>?,./".ToCharArray()) != -1)
            {
                e.Handled = true;
                MessageBox.Show("Không được chứa ký tự và số", "Thông báo");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtTenNV_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenNV.Text == "")
            {
                error.SetError(txtTenNV, "Không được để trống");
            }
            else
            {
                error.SetError(txtTenNV, "");
            }
        }

        private void txtLcb_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (e.KeyChar.ToString().IndexOfAny(@"0123456789.".ToCharArray()) != 0 )
            {
                e.Handled = true;
                MessageBox.Show("Chỉ nhập số nguyên và thập phân", "Thông báo");
            }
            else
            {
                e.Handled = false;
            }
            */
            // kiểm tra số nhập vào & kiểm tra phím mũi tên ,phím backspace
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ nhập số");
                e.Handled = true;
            }
        }

        private void txtLcb_Validating(object sender, CancelEventArgs e)
        {
            if (txtLcb.Text == "")
            {
                error.SetError(txtLcb, "Không được để trống");
            }
            else
            {
                error.SetError(txtLcb, "");
            }
        }

        private void txtDiachi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiachi.Text == "")
            {
                error.SetError(txtDiachi, "Không được để trống");
            }
            else
            {
                error.SetError(txtDiachi, "");
            }
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IndexOfAny(@"0123456789".ToCharArray()) != 0 && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ nhập số nguyên", "Thông báo");
            }
            else
            {
                e.Handled = false;
            }
        }
        private int kiemtra()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = txtMaNV.Text;
                string sql = "Select * from tblNHANVIEN where sMaNV=N'" + k.ToString() + "'";
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
            txtMaNV.Enabled = true;
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại");
                        txtMaNV.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_them_nv";
                            if (radiobtnNam.Checked)
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNam.Text);
                            else if (radiobtnNu.Checked)
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNu.Text);

                            if (radioDanglam.Checked)
                                cmd.Parameters.AddWithValue("@trangthai", radioDanglam.Text);
                            else if (radioNghi.Checked)
                                cmd.Parameters.AddWithValue("@trangthai", radioNghi.Text);
                            cmd.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(mtxtNgaysinh.Text));
                            try
                            {
                                if (txtMaNV.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập ma nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (txtTenNV.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập tên nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                else if (txtDiachi.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                else if (txtLcb.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập lương cơ bản", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                else if (txtSdt.Text == string.Empty)
                                {
                                    MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //else if (txtTrangthai.Text == string.Empty)
                                //{
                                //    MessageBox.Show("Bạn chưa nhập trạng thái", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                else
                                {
                                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                                    cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                                    cmd.Parameters.AddWithValue("@luong", txtLcb.Text);
                                    cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                                    //cmd.Parameters.AddWithValue("@trangthai", txtTrangthai.Text);
                                    cnn.Open();
                                    int i = cmd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        MessageBox.Show(" Thêm thành công ");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(" Lỗi: " + ex);
                            }
                            cnn.Close();
                            Load_Grid();
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error Connection" + ex);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại");
                        txtMaNV.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_update_nv";
                            cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                            cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                            if (radiobtnNam.Checked)
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNam.Text);
                            else
                                cmd.Parameters.AddWithValue("@gioitinh", radiobtnNu.Text);
                            cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                            cmd.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(mtxtNgaysinh.Text));
                            cmd.Parameters.AddWithValue("@luong", txtLcb.Text);
                            cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                            //cmd.Parameters.AddWithValue("@trangthai", txtTrangthai.Text);
                            if (radioDanglam.Checked)
                                cmd.Parameters.AddWithValue("@trangthai", radioDanglam.Text);
                            else
                                cmd.Parameters.AddWithValue("@trangthai", radioNghi.Text);
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
                }catch(Exception ex)
                {
                    MessageBox.Show("Error Connection" + ex);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
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
                            MessageBox.Show("Mã nhân viên này không tồn tại");
                            txtMaNV.Focus();
                        }
                        else
                        {
                            using (SqlCommand cmd = cnn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "sp_remove_status";
                                cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            string constr = "Data Source = DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            //string tim_sql = "select * from tblNHANVIEN where sTenNV LIKE N'%"+ txtNhapMaNV.Text + "%'";

            string tim_sql = null;

            try
            {
                if (txtNhapMaNV.Text != null)
                {
                    tim_sql = tim_sql + "select * from vv_nhanvien where [Mã Nhân Viên] = N'" + txtNhapMaNV.Text + "' " +
                        "or [Tên Nhân Viên] LIKE N'%" + txtNhapMaNV.Text + "%'";
                }
                if(txtNhapMaNV.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập dữ liệu !");
                }
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(tim_sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNV.DataSource = dt;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi"+ex);
            }
        }

        private void dgvNV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNV.CurrentRow.Cells["Mã nhân viên"].Value.ToString();
            txtMaNV.Enabled = false;
        }

        private void dgvNV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dgvNV_CellClick_1(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình ? ", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Close();
        }

        private void txtNhapMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InDanhsachNV inDanhsach = new InDanhsachNV();
            inDanhsach.Show();
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtLcb.Clear();
            txtDiachi.Clear();
            txtSdt.Clear();
        }
    }
}
