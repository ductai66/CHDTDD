using QuanLyCHDTDD.CrystalRepost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCHDTDD
{
    public partial class InDSNV : Form
    {
        public InDSNV()
        {
            InitializeComponent();
        }

        private void InDSNV_Load(object sender, EventArgs e)
        {
            CachedCrystalReportDSNV cr = new CachedCrystalReportDSNV();
            crystalReportDSNV.ReportSource = cr;
        }
    }
}
