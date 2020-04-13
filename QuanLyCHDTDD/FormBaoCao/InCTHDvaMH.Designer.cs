namespace QuanLyCHDTDD
{
    partial class InCTHDvaMH
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
            this.crCTHDvaMH = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crCTHDvaMH
            // 
            this.crCTHDvaMH.ActiveViewIndex = -1;
            this.crCTHDvaMH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crCTHDvaMH.Cursor = System.Windows.Forms.Cursors.Default;
            this.crCTHDvaMH.DisplayStatusBar = false;
            this.crCTHDvaMH.DisplayToolbar = false;
            this.crCTHDvaMH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crCTHDvaMH.Location = new System.Drawing.Point(0, 0);
            this.crCTHDvaMH.Name = "crCTHDvaMH";
            this.crCTHDvaMH.Size = new System.Drawing.Size(1078, 700);
            this.crCTHDvaMH.TabIndex = 0;
            this.crCTHDvaMH.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InCTHDvaMH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 700);
            this.Controls.Add(this.crCTHDvaMH);
            this.Name = "InCTHDvaMH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InCTHDvaMH";
            this.Load += new System.EventHandler(this.InCTHDvaMH_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crCTHDvaMH;
    }
}