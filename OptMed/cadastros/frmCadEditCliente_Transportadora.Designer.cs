namespace optmed
{
    partial class frmCadEditCliente_Transportadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadEditCliente_Transportadora));
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodCliIntegracao = new System.Windows.Forms.TextBox();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTransportadora = new System.Windows.Forms.ComboBox();
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
            this.pnlPrincipal.Controls.Add(this.cbTransportadora);
            this.pnlPrincipal.Controls.Add(this.btnPesquisa);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtCodCliIntegracao);
            this.pnlPrincipal.Controls.Add(this.txtClienteNome);
            this.pnlPrincipal.Size = new System.Drawing.Size(570, 112);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(161, 12);
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
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cliente";
            // 
            // txtCodCliIntegracao
            // 
            this.epValidaDados.SetFraseErro(this.txtCodCliIntegracao, "");
            this.txtCodCliIntegracao.Location = new System.Drawing.Point(60, 14);
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
            this.txtClienteNome.Location = new System.Drawing.Point(189, 14);
            this.txtClienteNome.Name = "txtClienteNome";
            this.epValidaDados.SetObrigatorio(this.txtClienteNome, true);
            this.txtClienteNome.ReadOnly = true;
            this.txtClienteNome.Size = new System.Drawing.Size(358, 23);
            this.txtClienteNome.TabIndex = 3;
            this.txtClienteNome.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Transportadora";
            // 
            // cbTransportadora
            // 
            this.cbTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransportadora.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbTransportadora, "Codição de pagamento obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbTransportadora, -1);
            this.cbTransportadora.Location = new System.Drawing.Point(121, 41);
            this.cbTransportadora.Name = "cbTransportadora";
            this.epValidaDados.SetObrigatorio(this.cbTransportadora, true);
            this.cbTransportadora.Size = new System.Drawing.Size(426, 24);
            this.cbTransportadora.TabIndex = 4;
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
            // frmCadEditCliente_Transportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(685, 112);
            this.Name = "frmCadEditCliente_Transportadora";
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
        private System.Windows.Forms.ComboBox cbTransportadora;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtId;
    }
}
