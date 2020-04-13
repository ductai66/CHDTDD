namespace QuanLyCHDTDD
{
    partial class InThanhToanHD
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
            this.crTTHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crTTHD
            // 
            this.crTTHD.ActiveViewIndex = -1;
            this.crTTHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crTTHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crTTHD.DisplayStatusBar = false;
            this.crTTHD.DisplayToolbar = false;
            this.crTTHD.Location = new System.Drawing.Point(12, 12);
            this.crTTHD.Name = "crTTHD";
            this.crTTHD.Size = new System.Drawing.Size(1203, 679);
            this.crTTHD.TabIndex = 0;
            this.crTTHD.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crTTHD.Load += new System.EventHandler(this.crTTHD_Load);
            // 
            // InThanhToanHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 696);
            this.Controls.Add(this.crTTHD);
            this.Name = "InThanhToanHD";
            this.Text = "InThanhToanHD";
            this.Load += new System.EventHandler(this.InThanhToanHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crTTHD;
    }
}