namespace QuanLyCHDTDD
{
    partial class InDSNV
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
            this.crystalReportDSNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportDSNV
            // 
            this.crystalReportDSNV.ActiveViewIndex = -1;
            this.crystalReportDSNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportDSNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportDSNV.DisplayStatusBar = false;
            this.crystalReportDSNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportDSNV.Location = new System.Drawing.Point(0, 0);
            this.crystalReportDSNV.Name = "crystalReportDSNV";
            this.crystalReportDSNV.Size = new System.Drawing.Size(1044, 615);
            this.crystalReportDSNV.TabIndex = 0;
            this.crystalReportDSNV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InDSNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 615);
            this.Controls.Add(this.crystalReportDSNV);
            this.Name = "InDSNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhân viên";
            this.Load += new System.EventHandler(this.InDSNV_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportDSNV;
    }
}