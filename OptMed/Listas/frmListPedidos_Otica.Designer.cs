namespace optmed
{
    partial class frmListPedidos_Otica
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.SetChildIndex(this.btnEditar, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnIncluir, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnExcluir, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnFechar, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnUltimo, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnProximo, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnAnterior, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnPrimeiro, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.lblNumeroPagina, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.lblTotalPaginas, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.lblTotalRegistros, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnImprimir, 0);
            this.pnlBotoes.Controls.SetChildIndex(this.btnCancelar, 0);
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
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(4, 139);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Image = global::optmed.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(4, 105);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 33);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmListPedidos_Otica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(731, 405);
            this.Name = "frmListPedidos_Otica";
            this.Text = "Listar Pedidos de Venda";
            this.Activated += new System.EventHandler(this.frmPedidoOtica_Activated);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnCancelar;
    }
}
