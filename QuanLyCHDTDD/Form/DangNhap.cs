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
    public partial class DangNhap : Form
    {
        XuLiUser xuli = new XuLiUser();
        public static string temp;
        public DangNhap()
        {
            InitializeComponent();
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            
        }
       
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (xuli.cnn)
                {
                    SqlCommand cmd = new SqlCommand("sp_login",xuli.cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    xuli.cnn.Open();
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtMatkhau.Text);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        if (rd[3].ToString() == "Admin")
                        {
                            XuLiUser.type = "A";
                        }
                        else if (rd[3].ToString()=="User")
                        {
                            XuLiUser.type = "U";
                        }
                        Menu menu = new Menu();
                        menu.Show();
                        this.Hide();
                        temp = txtUsername.Text;
                        lbError.Text = "Đăng nhập thành công!";
                    }
                    else
                    {
                        lbError.Text = "Đăng nhập không thành công!";
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối"+ex);
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkHien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHien.Checked)
            {
                txtMatkhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatkhau.UseSystemPasswordChar = true;
            }
        }
    }
}
