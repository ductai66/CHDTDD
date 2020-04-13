namespace QuanLyCHDTDD
{
    partial class InDSMH
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
            this.crDSMH = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crDSMH
            // 
            this.crDSMH.ActiveViewIndex = -1;
            this.crDSMH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crDSMH.Cursor = System.Windows.Forms.Cursors.Default;
            this.crDSMH.DisplayStatusBar = false;
            this.crDSMH.DisplayToolbar = false;
            this.crDSMH.Location = new System.Drawing.Point(42, 52);
            this.crDSMH.Name = "crDSMH";
            this.crDSMH.Size = new System.Drawing.Size(976, 536);
            this.crDSMH.TabIndex = 0;
            this.crDSMH.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InDSMH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 632);
            this.Controls.Add(this.crDSMH);
            this.Name = "InDSMH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InDSMH";
            this.Load += new System.EventHandler(this.InDSMH_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crDSMH;
    }
}