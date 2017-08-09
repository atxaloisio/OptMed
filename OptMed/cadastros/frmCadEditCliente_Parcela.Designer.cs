namespace optmed
{
    partial class frmCadEditCliente_Parcela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadEditCliente_Parcela));
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodCliIntegracao = new System.Windows.Forms.TextBox();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCondPagamento = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Size = new System.Drawing.Size(115, 112);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.txtIdCliente);
            this.pnlPrincipal.Controls.Add(this.txtId);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.cbCondPagamento);
            this.pnlPrincipal.Controls.Add(this.btnPesquisa);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtCodCliIntegracao);
            this.pnlPrincipal.Controls.Add(this.txtClienteNome);
            this.pnlPrincipal.Size = new System.Drawing.Size(619, 112);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(162, 12);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(27, 27);
            this.btnPesquisa.TabIndex = 2;
            this.btnPesquisa.TabStop = false;
            this.btnPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisa.UseVisualStyleBackColor = false;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cliente";
            // 
            // txtCodCliIntegracao
            // 
            this.epValidaDados.SetFraseErro(this.txtCodCliIntegracao, "");
            this.txtCodCliIntegracao.Location = new System.Drawing.Point(61, 14);
            this.txtCodCliIntegracao.Name = "txtCodCliIntegracao";
            this.epValidaDados.SetObrigatorio(this.txtCodCliIntegracao, false);
            this.txtCodCliIntegracao.Size = new System.Drawing.Size(100, 23);
            this.txtCodCliIntegracao.TabIndex = 0;
            this.txtCodCliIntegracao.TextChanged += new System.EventHandler(this.txtCodCliIntegracao_TextChanged);
            this.txtCodCliIntegracao.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCliIntegracao_Validating);
            // 
            // txtClienteNome
            // 
            this.epValidaDados.SetFraseErro(this.txtClienteNome, "Cliente obrigatório.");
            this.txtClienteNome.Location = new System.Drawing.Point(190, 14);
            this.txtClienteNome.Name = "txtClienteNome";
            this.epValidaDados.SetObrigatorio(this.txtClienteNome, true);
            this.txtClienteNome.ReadOnly = true;
            this.txtClienteNome.Size = new System.Drawing.Size(405, 23);
            this.txtClienteNome.TabIndex = 3;
            this.txtClienteNome.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Cond. de Pagamento";
            // 
            // cbCondPagamento
            // 
            this.cbCondPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondPagamento.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbCondPagamento, "Codição de pagamento obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbCondPagamento, -1);
            this.cbCondPagamento.Location = new System.Drawing.Point(162, 48);
            this.cbCondPagamento.Name = "cbCondPagamento";
            this.epValidaDados.SetObrigatorio(this.cbCondPagamento, true);
            this.cbCondPagamento.Size = new System.Drawing.Size(433, 24);
            this.cbCondPagamento.TabIndex = 4;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(46, 78);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 5;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtIdCliente, "");
            this.txtIdCliente.Location = new System.Drawing.Point(152, 78);
            this.txtIdCliente.Name = "txtIdCliente";
            this.epValidaDados.SetObrigatorio(this.txtIdCliente, false);
            this.txtIdCliente.Size = new System.Drawing.Size(100, 23);
            this.txtIdCliente.TabIndex = 7;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.Visible = false;
            // 
            // frmCadEditCliente_Parcela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(734, 112);
            this.Name = "frmCadEditCliente_Parcela";
            this.Text = "Cliente x Formas de Pagamento";
            this.pnlBotoes.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodCliIntegracao;
        private System.Windows.Forms.TextBox txtClienteNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCondPagamento;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtId;
    }
}
