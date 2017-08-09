namespace optmed
{
    partial class frmRelReciboVenda
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SuspendLayout();
            // 
            // rvRelatorios
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = null;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = null;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = null;
            reportDataSource5.Name = "DataSet1";
            reportDataSource5.Value = null;
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = null;
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = null;
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource1);
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource2);
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource3);
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource4);
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource5);
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource6);
            this.rvRelatorios.LocalReport.DataSources.Add(reportDataSource7);
            this.rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relRota.rdlc";
            this.rvRelatorios.Size = new System.Drawing.Size(738, 644);
            // 
            // frmRelReciboVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(738, 644);
            this.Name = "frmRelReciboVenda";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
