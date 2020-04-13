namespace QuanLyCHDTDD
{
    partial class InDanhsachNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crDSNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crDSNV
            // 
            this.crDSNV.ActiveViewIndex = -1;
            this.crDSNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crDSNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.crDSNV.DisplayStatusBar = false;
            this.crDSNV.DisplayToolbar = false;
            this.crDSNV.Location = new System.Drawing.Point(25, 59);
            this.crDSNV.Name = "crDSNV";
            this.crDSNV.Size = new System.Drawing.Size(816, 528);
            this.crDSNV.TabIndex = 0;
            this.crDSNV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InDanhsachNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 648);
            this.Controls.Add(this.crDSNV);
            this.Name = "InDanhsachNV";
            this.Text = "InDanhsachNV";
            this.Load += new System.EventHandler(this.InDanhsachNV_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crDSNV;
    }
}