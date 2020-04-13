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
    public partial class Doimatkhau : Form
    {
        public Doimatkhau()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sql = "select * from tblLogin Where Username='" + txtTenTK.Text + "' AND Password='" + txtMKC.Text + "'";
            string constr = "Data Source = DESKTOP-JQNQUR1\\SQLEXPRESS; Initial Catalog = QuanLyCHDTDD; Integrated Security= True";
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();

            error.Clear();
            if (txtTenTK.Text == "")
            {
                error.SetError(txtTenTK,"Bạn chưa nhập tên tài khoản!");
            }
            else if (txtMKC.Text == "")
            {
                error.SetError(txtMKC, "!");
                txtMKC.Focus();
            }
            else if (txtMKM.Text == "")
            {
                error.SetError(txtMKM, "!");
                txtMKM.Focus();
            }
            else if (txtNhapLaiMK.Text == "")
            {
                error.SetError(txtNhapLaiMK, "!");
                txtNhapLaiMK.Focus();
            }
            else if (txtNhapLaiMK.Text != txtMKM.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (reader.Read())
            {
                cmd.Dispose();
                reader.Dispose();
                string update = "Update tblLogin Set Password ='"+ txtMKM.Text + "' where Username='" + txtTenTK.Text + "'";
                SqlCommand cmd1 = new SqlCommand(update,cnn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo!");
                txtMKC.Clear();
                txtMKM.Clear();
                txtNhapLaiMK.Clear();
                cmd1.Dispose();
            }
            else
            {
                MessageBox.Show("Tên tài khoản không tồn tại hoặc mật khẩu sai! ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTK.Focus();
            }
            cmd.Dispose();
            reader.Dispose();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void checkMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMK.Checked)
            {
                txtMKC.UseSystemPasswordChar = false;
                txtMKM.UseSystemPasswordChar = false;
                txtNhapLaiMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMKC.UseSystemPasswordChar = true;
                txtMKM.UseSystemPasswordChar = true;
                txtNhapLaiMK.UseSystemPasswordChar = true;
            }
        }
    }
}
