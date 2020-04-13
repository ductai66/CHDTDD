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
    public partial class MatHang : Form
    {
        public MatHang()
        {
            InitializeComponent();
        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            Load_Grid();
            Load_combo();
            textbox();
        }
        void textbox()
        {
            txtMaMH.MaxLength = 10;
            txtTenMH.MaxLength = 30;
        }
        void Load_Grid()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from ds_mathang", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dgvMH.DataSource = tb;
                    }
                }
            }
        }
        private void Load_combo()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblLoaiHang", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("LoaiHang");
                        ad.Fill(tb);
                        cboTenLH.DataSource = tb;
                        cboTenLH.DisplayMember = "sTenLH";
                        cboTenLH.ValueMember = "sMaLH";
                    }
                }
            }
        }
        private int kiemtra()
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string k = txtMaMH.Text;
                string sql = "Select * from tblMatHang where sMaMH = N' " + k.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        if (tb.Rows.Count > 0) return 1;
                        else return 0;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaMH.Enabled = true;
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã mặt hàng này đã tồn tại");
                        txtMaMH.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "them_mathang";
                            cmd.Parameters.AddWithValue("@mamh", txtMaMH.Text);
                            cmd.Parameters.AddWithValue("@tenmh", txtTenMH.Text);
                            cmd.Parameters.AddWithValue("@sl", txtSoluong.Text);
                            cmd.Parameters.AddWithValue("@TGBH", cboTGBH.SelectedItem);
                            cmd.Parameters.AddWithValue("@giahang", txtGiahang.Text);
                            cmd.Parameters.AddWithValue("@malh", cboTenLH.SelectedValue);

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
            txtMaMH.Enabled = true;
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                try
                {
                    if (kiemtra() == 0)
                    {
                        MessageBox.Show("Mã mặt hàng này không tồn tại");
                        txtMaMH.Focus();
                    }
                    else
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sua_mathang";
                            cmd.Parameters.AddWithValue("@mamh", txtMaMH.Text);
                            cmd.Parameters.AddWithValue("@tenmh", txtTenMH.Text);
                            cmd.Parameters.AddWithValue("@sl", txtSoluong.Text);
                            cmd.Parameters.AddWithValue("@TGBH", cboTGBH.SelectedItem);
                            cmd.Parameters.AddWithValue("@giahang", txtGiahang.Text);
                            cmd.Parameters.AddWithValue("@malh", cboTenLH.SelectedValue);

                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Sua thanh cong");
                                cnn.Close();
                                Load_Grid(); //load lai sau khi sua
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
            txtMaMH.Enabled = true;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    try
                    {
                        if (kiemtra() == 0)
                        {
                            MessageBox.Show("Mã mặt hàng này không tồn tại");
                        }
                        else
                        {
                            using (SqlCommand cmd = cnn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "xoa_mathang";
                                cmd.Parameters.AddWithValue("@mamh", txtMaMH.Text);
                                cnn.Open();
                                cmd.ExecuteNonQuery();
                                Load_Grid(); //load lai sau khi xoa 
                            }
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Error Connection"+ex);
                    }
                }
            }
        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMH.Text = dgvMH.CurrentRow.Cells["Mã mặt hàng"].Value.ToString();
            txtTenMH.Text = dgvMH.CurrentRow.Cells["Tên mặt hàng"].Value.ToString();
            txtSoluong.Text = dgvMH.CurrentRow.Cells["Số lượng"].Value.ToString();
            txtGiahang.Text = dgvMH.CurrentRow.Cells["Giá hàng"].Value.ToString();
            txtMaMH.Enabled = false;
        }

        private void dgvMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMH_CellClick(sender, e);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security = True";
            string tim_sql = null;
            try
            {
                
                if (txtNhapmaMH.Text != null)
                {
                    tim_sql = tim_sql + "select * from tblMatHang where sMaMH = N'" + txtNhapmaMH.Text + "' " +
                        "or sTenMH LIKE N'%" + txtNhapmaMH.Text + "%' ";
                }
                if (txtNhapmaMH.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập dữ liệu !");
                }
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(tim_sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMH.DataSource = dt;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối"+ex);
            }
        }

        private void txtMaMH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IndexOfAny(@"!@#$%^&*()-+_=:'<>?,./;".ToCharArray()) != -1)
            {
                e.Handled = true;
                MessageBox.Show("Không chứa kí tự đặc biệt", "Thông báo");
            }
            else
                e.Handled = false;
        }

        private void txtMaMH_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaMH.Text == "")
            {
                error.SetError(txtMaMH, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtMaMH, "");
            }
        }

        private void txtTenMH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IndexOfAny(@"!@#$%^&*()-+_=:'<>?,./;".ToCharArray()) != -1)
            {
                e.Handled = true;
                MessageBox.Show("Không chứa kí tự đặc biệt", "Thông báo");
            }
            else
                e.Handled = false;
        }

        private void txtTenMH_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenMH.Text == "")
            {
                error.SetError(txtTenMH, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtTenMH, "");
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ nhập số");
                e.Handled = true;
            }
        }

        private void txtSoluong_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoluong.Text == "")
            {
                error.SetError(txtSoluong, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtSoluong, "");
            }
        }

        private void txtGiahang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ nhập số");
                e.Handled = true;
            }
        }

        private void txtGiahang_Validated(object sender, EventArgs e)
        {
            if (txtGiahang.Text == "")
            {
                error.SetError(txtGiahang, "Bạn không được bỏ trống ô này");
            }
            else
            {
                error.SetError(txtGiahang, "");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InDSMH inDSMH = new InDSMH();
            inDSMH.ShowDialog();
        }

        private void cboTenLH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtSoluong.Clear();
            txtGiahang.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình ? ", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Close();
        }

        private void MatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn đóng Form lại hay không ? ", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    e.Cancel = false;
            //else
            //    e.Cancel = true;//Không đóng Form nữa
        }
    }
}
