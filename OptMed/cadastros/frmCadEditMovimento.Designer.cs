namespace optmed
{
    partial class frmCadEditMovimento
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoMov = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtObservacao = new System.Windows.Forms.RichTextBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::optmed.Properties.Resources.cancelar;
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "&Cancelar";
            // 
            // btnIncluir
            // 
            this.btnIncluir.TabIndex = 2;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Size = new System.Drawing.Size(115, 183);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.txtValorUnitario);
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.txtQuantidade);
            this.pnlPrincipal.Controls.Add(this.cbTipoMov);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtData);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.txtDescricao);
            this.pnlPrincipal.Size = new System.Drawing.Size(550, 183);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Produto";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtDescricao, "Descrição do produto obrigatório.");
            this.txtDescricao.Location = new System.Drawing.Point(91, 4);
            this.txtDescricao.Name = "txtDescricao";
            this.epValidaDados.SetObrigatorio(this.txtDescricao, true);
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(434, 23);
            this.txtDescricao.TabIndex = 0;
            this.txtDescricao.TabStop = false;
            // 
            // txtData
            // 
            this.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtData.Location = new System.Drawing.Point(91, 31);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(105, 23);
            this.txtData.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 70;
            this.label2.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 16);
            this.label3.TabIndex = 71;
            this.label3.Text = "Tipo do Movimento de Estoque";
            // 
            // cbTipoMov
            // 
            this.cbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMov.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbTipoMov, "Tipo do Movimento de Estoque Obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbTipoMov, -1);
            this.cbTipoMov.Items.AddRange(new object[] {
            "Entrada",
            "Saida"});
            this.cbTipoMov.Location = new System.Drawing.Point(428, 31);
            this.cbTipoMov.Name = "cbTipoMov";
            this.epValidaDados.SetObrigatorio(this.cbTipoMov, false);
            this.cbTipoMov.Size = new System.Drawing.Size(97, 24);
            this.cbTipoMov.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.epValidaDados.SetFraseErro(this.txtQuantidade, "Quantidade do Produto Obrigatório");
            this.txtQuantidade.Location = new System.Drawing.Point(91, 58);
            this.txtQuantidade.Name = "txtQuantidade";
            this.epValidaDados.SetObrigatorio(this.txtQuantidade, true);
            this.txtQuantidade.Size = new System.Drawing.Size(132, 23);
            this.txtQuantidade.TabIndex = 3;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 76;
            this.label5.Text = "Valor Unitário";
            // 
            // txtValorUnitario
            // 
            this.epValidaDados.SetFraseErro(this.txtValorUnitario, "Valor Unitário do produto Obrigatório");
            this.txtValorUnitario.Location = new System.Drawing.Point(393, 58);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.epValidaDados.SetObrigatorio(this.txtValorUnitario, true);
            this.txtValorUnitario.Size = new System.Drawing.Size(132, 23);
            this.txtValorUnitario.TabIndex = 4;
            this.txtValorUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumber_KeyPress);
            this.txtValorUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.OnlyNumber_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Location = new System.Drawing.Point(6, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 91);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descrição Detalhada do Produto";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacao.Location = new System.Drawing.Point(3, 19);
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(513, 69);
            this.txtObservacao.TabIndex = 0;
            this.txtObservacao.Text = "";
            // 
            // frmCadEditMovimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(665, 183);
            this.Name = "frmCadEditMovimento";
            this.Text = "Movimento";
            this.pnlBotoes.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.ComboBox cbTipoMov;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtObservacao;
    }
}
