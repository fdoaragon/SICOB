namespace CasaCambio
{
    partial class frmReporte
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
            this.CrViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrViewer1
            // 
            this.CrViewer1.ActiveViewIndex = -1;
            this.CrViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrViewer1.DisplayGroupTree = false;
            this.CrViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrViewer1.Location = new System.Drawing.Point(0, 0);
            this.CrViewer1.Name = "CrViewer1";
            this.CrViewer1.SelectionFormula = "";
            this.CrViewer1.Size = new System.Drawing.Size(342, 252);
            this.CrViewer1.TabIndex = 0;
            this.CrViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 252);
            this.Controls.Add(this.CrViewer1);
            this.Name = "frmReporte";
            this.Text = "frmReporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer1;

    }
}