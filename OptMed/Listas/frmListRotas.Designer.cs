namespace optmed
{
    partial class frmListRotas
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
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(4, 372);
            // 
            // lblTotalPaginas
            // 
            this.lblTotalPaginas.Location = new System.Drawing.Point(70, 329);
            // 
            // lblNumeroPagina
            // 
            this.lblNumeroPagina.Location = new System.Drawing.Point(9, 329);
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.Location = new System.Drawing.Point(6, 345);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(34, 345);
            // 
            // btnProximo
            // 
            this.btnProximo.Location = new System.Drawing.Point(60, 345);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(86, 345);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Location = new System.Drawing.Point(72, 293);
            // 
            // frmListRotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(731, 405);
            this.Name = "frmListRotas";
            this.Text = "Transportadora x Localidade (Rotas)";
            this.Activated += new System.EventHandler(this.frmListRotas_Activated);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
