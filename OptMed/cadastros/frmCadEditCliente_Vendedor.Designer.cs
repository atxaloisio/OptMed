namespace optmed
{
    partial class frmCadEditCliente_Vendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadEditCliente_Vendedor));
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodCliIntegracao = new System.Windows.Forms.TextBox();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlJanela.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(3, 353);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Size = new System.Drawing.Size(115, 112);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Size = new System.Drawing.Size(605, 112);
            // 
            // pnlJanela
            // 
            this.pnlJanela.Controls.Add(this.txtIdCliente);
            this.pnlJanela.Controls.Add(this.txtId);
            this.pnlJanela.Controls.Add(this.label3);
            this.pnlJanela.Controls.Add(this.cbVendedor);
            this.pnlJanela.Controls.Add(this.btnPesquisa);
            this.pnlJanela.Controls.Add(this.label2);
            this.pnlJanela.Controls.Add(this.txtCodCliIntegracao);
            this.pnlJanela.Controls.Add(this.txtClienteNome);
            this.pnlJanela.Location = new System.Drawing.Point(66, 19);
            this.pnlJanela.Size = new System.Drawing.Size(605, 112);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(184, 9);
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
            this.txtCodCliIntegracao.Location = new System.Drawing.Point(83, 11);
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
            this.txtClienteNome.Location = new System.Drawing.Point(212, 11);
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
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Vendedor";
            // 
            // cbVendedor
            // 
            this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedor.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbVendedor, "Vendedor obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbVendedor, -1);
            this.cbVendedor.Location = new System.Drawing.Point(83, 39);
            this.cbVendedor.Name = "cbVendedor";
            this.epValidaDados.SetObrigatorio(this.cbVendedor, true);
            this.cbVendedor.Size = new System.Drawing.Size(306, 24);
            this.cbVendedor.TabIndex = 4;
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
            // frmCadEditCliente_Vendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(720, 112);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmCadEditCliente_Vendedor";
            this.Text = "Cliente x Vendedor";
            this.Activated += new System.EventHandler(this.frmCadEditCliente_Vendedor_Activated);
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlJanela.ResumeLayout(false);
            this.pnlJanela.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodCliIntegracao;
        private System.Windows.Forms.TextBox txtClienteNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtId;
    }
}
