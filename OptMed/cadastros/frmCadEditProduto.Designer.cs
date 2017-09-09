namespace optmed
{
    partial class frmCadEditProduto
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
            this.txtNCM = new System.Windows.Forms.TextBox();
            this.txtCodigoOmie = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodInt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEAN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecoUnitario = new System.Windows.Forms.TextBox();
            this.tpInscrCnae = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cbFamiliaProduto = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescDetProd = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPesoBruto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPesoLiquido = new System.Windows.Forms.TextBox();
            this.tpEstoque = new System.Windows.Forms.TabPage();
            this.dgvMovEstoque = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditarMovimento = new System.Windows.Forms.Button();
            this.btnNovoMovimento = new System.Windows.Forms.Button();
            this.tcProduto = new System.Windows.Forms.TabControl();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlJanela.SuspendLayout();
            this.tpInscrCnae.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovEstoque)).BeginInit();
            this.panel1.SuspendLayout();
            this.tcProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(3, 353);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Size = new System.Drawing.Size(115, 309);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Size = new System.Drawing.Size(813, 309);
            // 
            // pnlJanela
            // 
            this.pnlJanela.Controls.Add(this.txtCodigo);
            this.pnlJanela.Controls.Add(this.label6);
            this.pnlJanela.Controls.Add(this.txtPrecoUnitario);
            this.pnlJanela.Controls.Add(this.label5);
            this.pnlJanela.Controls.Add(this.txtEAN);
            this.pnlJanela.Controls.Add(this.label4);
            this.pnlJanela.Controls.Add(this.cbUnidade);
            this.pnlJanela.Controls.Add(this.label2);
            this.pnlJanela.Controls.Add(this.txtNCM);
            this.pnlJanela.Controls.Add(this.txtCodigoOmie);
            this.pnlJanela.Controls.Add(this.txtId);
            this.pnlJanela.Controls.Add(this.label1);
            this.pnlJanela.Controls.Add(this.txtDescricao);
            this.pnlJanela.Controls.Add(this.txtCodInt);
            this.pnlJanela.Controls.Add(this.label3);
            this.pnlJanela.Controls.Add(this.tcProduto);
            this.pnlJanela.Location = new System.Drawing.Point(66, 20);
            this.pnlJanela.Size = new System.Drawing.Size(813, 309);
            // 
            // txtNCM
            // 
            this.epValidaDados.SetFraseErro(this.txtNCM, "NCM do produto obrigatório.");
            this.txtNCM.Location = new System.Drawing.Point(84, 61);
            this.txtNCM.Name = "txtNCM";
            this.epValidaDados.SetObrigatorio(this.txtNCM, true);
            this.txtNCM.Size = new System.Drawing.Size(154, 23);
            this.txtNCM.TabIndex = 3;
            // 
            // txtCodigoOmie
            // 
            this.txtCodigoOmie.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtCodigoOmie, "");
            this.txtCodigoOmie.Location = new System.Drawing.Point(341, 9);
            this.txtCodigoOmie.Name = "txtCodigoOmie";
            this.epValidaDados.SetObrigatorio(this.txtCodigoOmie, false);
            this.txtCodigoOmie.Size = new System.Drawing.Size(100, 23);
            this.txtCodigoOmie.TabIndex = 68;
            this.txtCodigoOmie.TabStop = false;
            this.txtCodigoOmie.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(447, 9);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 67;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.epValidaDados.SetFraseErro(this.txtDescricao, "Descrição do produto obrigatório.");
            this.txtDescricao.Location = new System.Drawing.Point(84, 35);
            this.txtDescricao.Name = "txtDescricao";
            this.epValidaDados.SetObrigatorio(this.txtDescricao, true);
            this.txtDescricao.Size = new System.Drawing.Size(394, 23);
            this.txtDescricao.TabIndex = 1;
            // 
            // txtCodInt
            // 
            this.txtCodInt.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtCodInt, "");
            this.txtCodInt.Location = new System.Drawing.Point(235, 9);
            this.txtCodInt.Name = "txtCodInt";
            this.epValidaDados.SetObrigatorio(this.txtCodInt, false);
            this.txtCodInt.Size = new System.Drawing.Size(100, 23);
            this.txtCodInt.TabIndex = 62;
            this.txtCodInt.TabStop = false;
            this.txtCodInt.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 74;
            this.label2.Text = "Código NCM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "Unidade";
            // 
            // cbUnidade
            // 
            this.cbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUnidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbUnidade.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbUnidade, "Unidade do produto obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbUnidade, -1);
            this.cbUnidade.Location = new System.Drawing.Point(567, 61);
            this.cbUnidade.MaxLength = 2;
            this.cbUnidade.Name = "cbUnidade";
            this.epValidaDados.SetObrigatorio(this.cbUnidade, true);
            this.cbUnidade.Size = new System.Drawing.Size(48, 24);
            this.cbUnidade.TabIndex = 5;
            this.cbUnidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 78;
            this.label5.Text = "Código EAN";
            // 
            // txtEAN
            // 
            this.epValidaDados.SetFraseErro(this.txtEAN, "");
            this.txtEAN.Location = new System.Drawing.Point(342, 61);
            this.txtEAN.Name = "txtEAN";
            this.epValidaDados.SetObrigatorio(this.txtEAN, false);
            this.txtEAN.Size = new System.Drawing.Size(154, 23);
            this.txtEAN.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(497, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 16);
            this.label6.TabIndex = 80;
            this.label6.Text = "Preço Unitário de Venda";
            // 
            // txtPrecoUnitario
            // 
            this.epValidaDados.SetFraseErro(this.txtPrecoUnitario, "Preço Unitário de Venda Obrigatório");
            this.txtPrecoUnitario.Location = new System.Drawing.Point(664, 35);
            this.txtPrecoUnitario.Name = "txtPrecoUnitario";
            this.epValidaDados.SetObrigatorio(this.txtPrecoUnitario, true);
            this.txtPrecoUnitario.Size = new System.Drawing.Size(127, 23);
            this.txtPrecoUnitario.TabIndex = 2;
            this.txtPrecoUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumber_KeyPress);
            this.txtPrecoUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.OnlyNumber_Validating);
            // 
            // tpInscrCnae
            // 
            this.tpInscrCnae.Controls.Add(this.label9);
            this.tpInscrCnae.Controls.Add(this.cbFamiliaProduto);
            this.tpInscrCnae.Controls.Add(this.groupBox1);
            this.tpInscrCnae.Controls.Add(this.label8);
            this.tpInscrCnae.Controls.Add(this.txtPesoBruto);
            this.tpInscrCnae.Controls.Add(this.label7);
            this.tpInscrCnae.Controls.Add(this.txtPesoLiquido);
            this.tpInscrCnae.Location = new System.Drawing.Point(4, 25);
            this.tpInscrCnae.Name = "tpInscrCnae";
            this.tpInscrCnae.Padding = new System.Windows.Forms.Padding(3);
            this.tpInscrCnae.Size = new System.Drawing.Size(803, 180);
            this.tpInscrCnae.TabIndex = 2;
            this.tpInscrCnae.Text = "Informações Adicionais";
            this.tpInscrCnae.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(491, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 81;
            this.label9.Text = "Família";
            // 
            // cbFamiliaProduto
            // 
            this.cbFamiliaProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbFamiliaProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbFamiliaProduto.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbFamiliaProduto, "UF obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbFamiliaProduto, -1);
            this.cbFamiliaProduto.Location = new System.Drawing.Point(541, 5);
            this.cbFamiliaProduto.MaxLength = 2;
            this.cbFamiliaProduto.Name = "cbFamiliaProduto";
            this.epValidaDados.SetObrigatorio(this.cbFamiliaProduto, true);
            this.cbFamiliaProduto.Size = new System.Drawing.Size(248, 24);
            this.cbFamiliaProduto.TabIndex = 80;
            this.cbFamiliaProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescDetProd);
            this.groupBox1.Location = new System.Drawing.Point(7, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 139);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descrição Detalhada do Produto";
            // 
            // txtDescDetProd
            // 
            this.txtDescDetProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescDetProd.Location = new System.Drawing.Point(3, 19);
            this.txtDescDetProd.Name = "txtDescDetProd";
            this.txtDescDetProd.Size = new System.Drawing.Size(775, 117);
            this.txtDescDetProd.TabIndex = 0;
            this.txtDescDetProd.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "Peso Bruto";
            // 
            // txtPesoBruto
            // 
            this.epValidaDados.SetFraseErro(this.txtPesoBruto, "Nome Fantasia / Nome Abreviado obrigatório.");
            this.txtPesoBruto.Location = new System.Drawing.Point(333, 5);
            this.txtPesoBruto.Name = "txtPesoBruto";
            this.epValidaDados.SetObrigatorio(this.txtPesoBruto, true);
            this.txtPesoBruto.Size = new System.Drawing.Size(154, 23);
            this.txtPesoBruto.TabIndex = 77;
            this.txtPesoBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumber_KeyPress);
            this.txtPesoBruto.Validating += new System.ComponentModel.CancelEventHandler(this.OnlyNumber_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 76;
            this.label7.Text = "Peso Liquido";
            // 
            // txtPesoLiquido
            // 
            this.epValidaDados.SetFraseErro(this.txtPesoLiquido, "Nome Fantasia / Nome Abreviado obrigatório.");
            this.txtPesoLiquido.Location = new System.Drawing.Point(95, 5);
            this.txtPesoLiquido.Name = "txtPesoLiquido";
            this.epValidaDados.SetObrigatorio(this.txtPesoLiquido, true);
            this.txtPesoLiquido.Size = new System.Drawing.Size(154, 23);
            this.txtPesoLiquido.TabIndex = 75;
            this.txtPesoLiquido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumber_KeyPress);
            this.txtPesoLiquido.Validating += new System.ComponentModel.CancelEventHandler(this.OnlyNumber_Validating);
            // 
            // tpEstoque
            // 
            this.tpEstoque.Controls.Add(this.dgvMovEstoque);
            this.tpEstoque.Controls.Add(this.panel1);
            this.tpEstoque.Location = new System.Drawing.Point(4, 25);
            this.tpEstoque.Name = "tpEstoque";
            this.tpEstoque.Padding = new System.Windows.Forms.Padding(3);
            this.tpEstoque.Size = new System.Drawing.Size(803, 180);
            this.tpEstoque.TabIndex = 0;
            this.tpEstoque.Text = "Estoque";
            this.tpEstoque.UseVisualStyleBackColor = true;
            // 
            // dgvMovEstoque
            // 
            this.dgvMovEstoque.AllowUserToAddRows = false;
            this.dgvMovEstoque.AllowUserToDeleteRows = false;
            this.dgvMovEstoque.AllowUserToOrderColumns = true;
            this.dgvMovEstoque.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMovEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovEstoque.Location = new System.Drawing.Point(3, 42);
            this.dgvMovEstoque.MultiSelect = false;
            this.dgvMovEstoque.Name = "dgvMovEstoque";
            this.dgvMovEstoque.RowHeadersVisible = false;
            this.dgvMovEstoque.Size = new System.Drawing.Size(797, 135);
            this.dgvMovEstoque.TabIndex = 2;
            this.dgvMovEstoque.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovEstoque_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditarMovimento);
            this.panel1.Controls.Add(this.btnNovoMovimento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 39);
            this.panel1.TabIndex = 0;
            // 
            // btnEditarMovimento
            // 
            this.btnEditarMovimento.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEditarMovimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarMovimento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarMovimento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditarMovimento.Image = global::optmed.Properties.Resources.Editar;
            this.btnEditarMovimento.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEditarMovimento.Location = new System.Drawing.Point(473, 3);
            this.btnEditarMovimento.Name = "btnEditarMovimento";
            this.btnEditarMovimento.Size = new System.Drawing.Size(158, 33);
            this.btnEditarMovimento.TabIndex = 11;
            this.btnEditarMovimento.Text = "&Editar Movimento";
            this.btnEditarMovimento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarMovimento.UseVisualStyleBackColor = false;
            this.btnEditarMovimento.Visible = false;
            this.btnEditarMovimento.Click += new System.EventHandler(this.btnEditarMovimento_Click);
            // 
            // btnNovoMovimento
            // 
            this.btnNovoMovimento.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNovoMovimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoMovimento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoMovimento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNovoMovimento.Image = global::optmed.Properties.Resources.movimento;
            this.btnNovoMovimento.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovoMovimento.Location = new System.Drawing.Point(634, 3);
            this.btnNovoMovimento.Name = "btnNovoMovimento";
            this.btnNovoMovimento.Size = new System.Drawing.Size(158, 33);
            this.btnNovoMovimento.TabIndex = 10;
            this.btnNovoMovimento.Text = "&Novo Movimento";
            this.btnNovoMovimento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoMovimento.UseVisualStyleBackColor = false;
            this.btnNovoMovimento.Click += new System.EventHandler(this.btnNovoMovimento_Click);
            // 
            // tcProduto
            // 
            this.tcProduto.Controls.Add(this.tpEstoque);
            this.tcProduto.Controls.Add(this.tpInscrCnae);
            this.tcProduto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcProduto.Location = new System.Drawing.Point(0, 98);
            this.tcProduto.Name = "tcProduto";
            this.tcProduto.SelectedIndex = 0;
            this.tcProduto.Size = new System.Drawing.Size(811, 209);
            this.tcProduto.TabIndex = 7;
            // 
            // txtCodigo
            // 
            this.epValidaDados.SetFraseErro(this.txtCodigo, "Código do produto Obrigatório.");
            this.txtCodigo.Location = new System.Drawing.Point(84, 9);
            this.txtCodigo.Name = "txtCodigo";
            this.epValidaDados.SetObrigatorio(this.txtCodigo, true);
            this.txtCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            // 
            // frmCadEditProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(928, 309);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmCadEditProduto";
            this.Text = "Produto";
            this.Activated += new System.EventHandler(this.frmCadEditProduto_Activated);
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlJanela.ResumeLayout(false);
            this.pnlJanela.PerformLayout();
            this.tpInscrCnae.ResumeLayout(false);
            this.tpInscrCnae.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tpEstoque.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovEstoque)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tcProduto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNCM;
        private System.Windows.Forms.TextBox txtCodigoOmie;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodInt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecoUnitario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEAN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tcProduto;
        private System.Windows.Forms.TabPage tpEstoque;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnEditarMovimento;
        public System.Windows.Forms.Button btnNovoMovimento;
        private System.Windows.Forms.TabPage tpInscrCnae;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtDescDetProd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPesoBruto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPesoLiquido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbFamiliaProduto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView dgvMovEstoque;
    }
}
