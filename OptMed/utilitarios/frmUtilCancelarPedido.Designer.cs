namespace optmed
{
    partial class frmUtilCancelarPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUtilCancelarPedido));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCaixa = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNrPedCliente = new System.Windows.Forms.TextBox();
            this.txtDtFechamento = new System.Windows.Forms.MaskedTextBox();
            this.txtDtEmissao = new System.Windows.Forms.MaskedTextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbMotivoEntrega = new System.Windows.Forms.ComboBox();
            this.txtHrPrevEntrega = new System.Windows.Forms.MaskedTextBox();
            this.txtDtPrevEntrega = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTransportadora = new System.Windows.Forms.ComboBox();
            this.cbCondPagamento = new System.Windows.Forms.ComboBox();
            this.txtCodCliIntegracao = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMotivoCancelamento = new System.Windows.Forms.RichTextBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Size = new System.Drawing.Size(115, 220);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.groupBox2);
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Size = new System.Drawing.Size(1002, 220);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCaixa);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.cbVendedor);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtNrPedCliente);
            this.groupBox1.Controls.Add(this.txtDtFechamento);
            this.groupBox1.Controls.Add(this.txtDtEmissao);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbMotivoEntrega);
            this.groupBox1.Controls.Add(this.txtHrPrevEntrega);
            this.groupBox1.Controls.Add(this.txtDtPrevEntrega);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnPesquisa);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbTransportadora);
            this.groupBox1.Controls.Add(this.cbCondPagamento);
            this.groupBox1.Controls.Add(this.txtCodCliIntegracao);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtClienteNome);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Pedido";
            // 
            // cbCaixa
            // 
            this.cbCaixa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCaixa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbCaixa.Enabled = false;
            this.cbCaixa.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbCaixa, "Transportadora obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbCaixa, -1);
            this.cbCaixa.Location = new System.Drawing.Point(911, 110);
            this.cbCaixa.Name = "cbCaixa";
            this.epValidaDados.SetObrigatorio(this.cbCaixa, false);
            this.cbCaixa.Size = new System.Drawing.Size(75, 24);
            this.cbCaixa.TabIndex = 57;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 81);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 16);
            this.label25.TabIndex = 56;
            this.label25.Text = "Vendedor";
            // 
            // cbVendedor
            // 
            this.cbVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbVendedor.Enabled = false;
            this.cbVendedor.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbVendedor, "Transportadora obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbVendedor, -1);
            this.cbVendedor.Location = new System.Drawing.Point(82, 79);
            this.cbVendedor.Name = "cbVendedor";
            this.epValidaDados.SetObrigatorio(this.cbVendedor, false);
            this.cbVendedor.Size = new System.Drawing.Size(252, 24);
            this.cbVendedor.TabIndex = 55;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(814, 84);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 16);
            this.label23.TabIndex = 54;
            this.label23.Text = "Nr. Ped. Cliente";
            // 
            // txtNrPedCliente
            // 
            this.txtNrPedCliente.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtNrPedCliente, "Numero do pedido no Cliente obrigatório.");
            this.txtNrPedCliente.Location = new System.Drawing.Point(920, 79);
            this.txtNrPedCliente.Name = "txtNrPedCliente";
            this.epValidaDados.SetObrigatorio(this.txtNrPedCliente, false);
            this.txtNrPedCliente.Size = new System.Drawing.Size(67, 23);
            this.txtNrPedCliente.TabIndex = 9;
            // 
            // txtDtFechamento
            // 
            this.txtDtFechamento.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtDtFechamento, "Data de fechamento obrigatório");
            this.txtDtFechamento.Location = new System.Drawing.Point(660, 48);
            this.txtDtFechamento.Mask = "00/00/0000";
            this.txtDtFechamento.Name = "txtDtFechamento";
            this.epValidaDados.SetObrigatorio(this.txtDtFechamento, false);
            this.txtDtFechamento.Size = new System.Drawing.Size(87, 23);
            this.txtDtFechamento.TabIndex = 5;
            this.txtDtFechamento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.epValidaDados.SetTipoValidacao(this.txtDtFechamento, libComponente.TipoValidacao.Vazio);
            this.txtDtFechamento.ValidatingType = typeof(System.DateTime);
            // 
            // txtDtEmissao
            // 
            this.txtDtEmissao.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtDtEmissao, "Data de Emissão obrigatório");
            this.txtDtEmissao.Location = new System.Drawing.Point(250, 20);
            this.txtDtEmissao.Mask = "00/00/0000";
            this.txtDtEmissao.Name = "txtDtEmissao";
            this.epValidaDados.SetObrigatorio(this.txtDtEmissao, true);
            this.txtDtEmissao.Size = new System.Drawing.Size(87, 23);
            this.txtDtEmissao.TabIndex = 4;
            this.txtDtEmissao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.epValidaDados.SetTipoValidacao(this.txtDtEmissao, libComponente.TipoValidacao.Vazio);
            this.txtDtEmissao.ValidatingType = typeof(System.DateTime);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtIdCliente, "");
            this.txtIdCliente.Location = new System.Drawing.Point(887, 15);
            this.txtIdCliente.Name = "txtIdCliente";
            this.epValidaDados.SetObrigatorio(this.txtIdCliente, false);
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(100, 23);
            this.txtIdCliente.TabIndex = 52;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(815, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 16);
            this.label19.TabIndex = 51;
            this.label19.Text = "Número Caixa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 16);
            this.label9.TabIndex = 43;
            this.label9.Text = "Motivo Entrega";
            // 
            // cbMotivoEntrega
            // 
            this.cbMotivoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotivoEntrega.Enabled = false;
            this.cbMotivoEntrega.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbMotivoEntrega, "");
            this.epValidaDados.SetIndiceCombo(this.cbMotivoEntrega, -1);
            this.cbMotivoEntrega.Location = new System.Drawing.Point(449, 79);
            this.cbMotivoEntrega.Name = "cbMotivoEntrega";
            this.epValidaDados.SetObrigatorio(this.cbMotivoEntrega, false);
            this.cbMotivoEntrega.Size = new System.Drawing.Size(361, 24);
            this.cbMotivoEntrega.TabIndex = 8;
            // 
            // txtHrPrevEntrega
            // 
            this.txtHrPrevEntrega.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtHrPrevEntrega, "");
            this.txtHrPrevEntrega.Location = new System.Drawing.Point(942, 47);
            this.txtHrPrevEntrega.Mask = "00:00";
            this.txtHrPrevEntrega.Name = "txtHrPrevEntrega";
            this.epValidaDados.SetObrigatorio(this.txtHrPrevEntrega, false);
            this.txtHrPrevEntrega.Size = new System.Drawing.Size(46, 23);
            this.txtHrPrevEntrega.TabIndex = 7;
            this.epValidaDados.SetTipoValidacao(this.txtHrPrevEntrega, libComponente.TipoValidacao.Vazio);
            this.txtHrPrevEntrega.ValidatingType = typeof(System.DateTime);
            // 
            // txtDtPrevEntrega
            // 
            this.txtDtPrevEntrega.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtDtPrevEntrega, "Previsão de entrega obrigatório.");
            this.txtDtPrevEntrega.Location = new System.Drawing.Point(854, 47);
            this.txtDtPrevEntrega.Mask = "00/00/0000";
            this.txtDtPrevEntrega.Name = "txtDtPrevEntrega";
            this.epValidaDados.SetObrigatorio(this.txtDtPrevEntrega, false);
            this.txtDtPrevEntrega.Size = new System.Drawing.Size(87, 23);
            this.txtDtPrevEntrega.TabIndex = 6;
            this.txtDtPrevEntrega.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.epValidaDados.SetTipoValidacao(this.txtDtPrevEntrega, libComponente.TipoValidacao.Vazio);
            this.txtDtPrevEntrega.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(753, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 39;
            this.label8.Text = "Prev. Entrega";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPesquisa.Enabled = false;
            this.btnPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(163, 47);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(27, 27);
            this.btnPesquisa.TabIndex = 3;
            this.btnPesquisa.TabStop = false;
            this.btnPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisa.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(549, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "Dt. Fechamento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Dt. Emissão";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Transportadora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Cond. Pagamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Código";
            // 
            // cbTransportadora
            // 
            this.cbTransportadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTransportadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbTransportadora.Enabled = false;
            this.cbTransportadora.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbTransportadora, "Transportadora obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbTransportadora, -1);
            this.cbTransportadora.Location = new System.Drawing.Point(565, 110);
            this.cbTransportadora.Name = "cbTransportadora";
            this.epValidaDados.SetObrigatorio(this.cbTransportadora, false);
            this.cbTransportadora.Size = new System.Drawing.Size(245, 24);
            this.cbTransportadora.TabIndex = 11;
            // 
            // cbCondPagamento
            // 
            this.cbCondPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondPagamento.Enabled = false;
            this.cbCondPagamento.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbCondPagamento, "Codição de pagamento obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbCondPagamento, -1);
            this.cbCondPagamento.Location = new System.Drawing.Point(129, 110);
            this.cbCondPagamento.Name = "cbCondPagamento";
            this.epValidaDados.SetObrigatorio(this.cbCondPagamento, true);
            this.cbCondPagamento.Size = new System.Drawing.Size(318, 24);
            this.cbCondPagamento.TabIndex = 10;
            // 
            // txtCodCliIntegracao
            // 
            this.txtCodCliIntegracao.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtCodCliIntegracao, "");
            this.txtCodCliIntegracao.Location = new System.Drawing.Point(63, 49);
            this.txtCodCliIntegracao.Name = "txtCodCliIntegracao";
            this.epValidaDados.SetObrigatorio(this.txtCodCliIntegracao, false);
            this.txtCodCliIntegracao.Size = new System.Drawing.Size(100, 23);
            this.txtCodCliIntegracao.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(775, 14);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 26;
            this.txtId.Visible = false;
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtClienteNome, "Cliente obrigatório.");
            this.txtClienteNome.Location = new System.Drawing.Point(192, 49);
            this.txtClienteNome.Name = "txtClienteNome";
            this.epValidaDados.SetObrigatorio(this.txtClienteNome, true);
            this.txtClienteNome.ReadOnly = true;
            this.txtClienteNome.Size = new System.Drawing.Size(342, 23);
            this.txtClienteNome.TabIndex = 2;
            this.txtClienteNome.TabStop = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtCodigo, "");
            this.txtCodigo.Location = new System.Drawing.Point(63, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.epValidaDados.SetObrigatorio(this.txtCodigo, false);
            this.txtCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMotivoCancelamento);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1000, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Motivo do Cancelamento";
            // 
            // txtMotivoCancelamento
            // 
            this.txtMotivoCancelamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMotivoCancelamento.Location = new System.Drawing.Point(3, 19);
            this.txtMotivoCancelamento.Name = "txtMotivoCancelamento";
            this.txtMotivoCancelamento.Size = new System.Drawing.Size(994, 52);
            this.txtMotivoCancelamento.TabIndex = 0;
            this.txtMotivoCancelamento.Text = "";
            this.txtMotivoCancelamento.Validating += new System.ComponentModel.CancelEventHandler(this.txtMotivoCancelamento_Validating);
            // 
            // frmUtilCancelarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1117, 220);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmUtilCancelarPedido";
            this.Tag = "1007";
            this.Text = "Cancelamento de Pedido Ótica";
            this.pnlBotoes.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbCaixa;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNrPedCliente;
        private System.Windows.Forms.MaskedTextBox txtDtFechamento;
        private System.Windows.Forms.MaskedTextBox txtDtEmissao;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbMotivoEntrega;
        private System.Windows.Forms.MaskedTextBox txtHrPrevEntrega;
        private System.Windows.Forms.MaskedTextBox txtDtPrevEntrega;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTransportadora;
        private System.Windows.Forms.ComboBox cbCondPagamento;
        private System.Windows.Forms.TextBox txtCodCliIntegracao;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtClienteNome;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtMotivoCancelamento;
    }
}
