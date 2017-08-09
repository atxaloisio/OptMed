namespace optmed
{
    partial class frmPesquisaClientes
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
            this.pnlBotoes.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // cbFiltro
            // 
            this.cbFiltro.SelectionChangeCommitted += new System.EventHandler(this.cbFiltro_SelectionChangeCommitted);
            this.cbFiltro.SelectedValueChanged += new System.EventHandler(this.cbFiltro_SelectedValueChanged);
            // 
            // frmPesquisaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(689, 298);
            this.Name = "frmPesquisaClientes";
            this.Load += new System.EventHandler(this.frmPesquisaClientes_Load);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
