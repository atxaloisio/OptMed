namespace optmed
{
    partial class frmReportBase
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvRelatorios = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvRelatorios
            // 
            this.rvRelatorios.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource1);
            this.rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relPedido_Otica.rdlc";
            this.rvRelatorios.Location = new System.Drawing.Point(0, 0);
            this.rvRelatorios.Name = "rvRelatorios";
            this.rvRelatorios.Size = new System.Drawing.Size(723, 644);
            this.rvRelatorios.TabIndex = 0;
            // 
            // frmReportBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(723, 644);
            this.Controls.Add(this.rvRelatorios);
            this.Name = "frmReportBase";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmReportBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer rvRelatorios;
    }
}
