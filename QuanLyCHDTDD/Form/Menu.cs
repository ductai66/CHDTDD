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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nhanvien = new NhanVien();
            nhanvien.MdiParent = this;
            nhanvien.Show(); 
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang khachhang = new KhachHang();
            khachhang.MdiParent = this;
            khachhang.Show();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatHang mathang = new MatHang();
            mathang.MdiParent = this;
            mathang.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon hoadon = new HoaDon();
            hoadon.MdiParent = this;
            hoadon.Show();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon chitiethoadon = new ChiTietHoaDon();
            chitiethoadon.MdiParent = this;
            chitiethoadon.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (XuLiUser.type == "A")
            {
                quảnLýToolStripMenuItem.Enabled = true;
            }
            else if (XuLiUser.type == "U")
            {
                quảnLýToolStripMenuItem.Enabled = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doimatkhau dmk = new Doimatkhau();
            dmk.Show();
        }

        //private void inBáoCáoToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    InCTHDvaMH inCTHDvaMH = new InCTHDvaMH();
        //    inCTHDvaMH.MdiParent = this;
        //    inCTHDvaMH.Show();
        //}

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thôngtin thongtin = new Thôngtin();
            thongtin.MdiParent = this;
            thongtin.Show();
        }
    }
}
