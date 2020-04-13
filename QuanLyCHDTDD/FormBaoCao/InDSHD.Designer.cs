namespace QuanLyCHDTDD
{
    partial class InDSHD
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
            this.crystalReportHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportHD
            // 
            this.crystalReportHD.ActiveViewIndex = -1;
            this.crystalReportHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportHD.DisplayStatusBar = false;
            this.crystalReportHD.DisplayToolbar = false;
            this.crystalReportHD.Location = new System.Drawing.Point(25, 36);
            this.crystalReportHD.Name = "crystalReportHD";
            this.crystalReportHD.Size = new System.Drawing.Size(1098, 608);
            this.crystalReportHD.TabIndex = 0;
            this.crystalReportHD.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InDSHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 668);
            this.Controls.Add(this.crystalReportHD);
            this.Name = "InDSHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InDSHD";
            this.Load += new System.EventHandler(this.InDSHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportHD;
    }
}