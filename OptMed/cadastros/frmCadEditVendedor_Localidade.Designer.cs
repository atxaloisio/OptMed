namespace optmed
{
    partial class frmCadEditVendedor_Localidade
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbUF = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCidade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
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
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.cbVendedor);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.cbCidade);
            this.pnlPrincipal.Controls.Add(this.txtIdCliente);
            this.pnlPrincipal.Controls.Add(this.txtId);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.cbUF);
            this.pnlPrincipal.Size = new System.Drawing.Size(459, 112);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "UF";
            // 
            // cbUF
            // 
            this.cbUF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbUF.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbUF, "UF obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbUF, -1);
            this.cbUF.Location = new System.Drawing.Point(83, 35);
            this.cbUF.MaxLength = 2;
            this.cbUF.Name = "cbUF";
            this.epValidaDados.SetObrigatorio(this.cbUF, true);
            this.cbUF.Size = new System.Drawing.Size(48, 24);
            this.cbUF.TabIndex = 1;
            this.cbUF.SelectedIndexChanged += new System.EventHandler(this.cbUF_SelectedIndexChanged);
            this.cbUF.SelectionChangeCommitted += new System.EventHandler(this.cbUF_SelectionChangeCommitted);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(228, 35);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 3;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtIdCliente, "");
            this.txtIdCliente.Location = new System.Drawing.Point(334, 35);
            this.txtIdCliente.Name = "txtIdCliente";
            this.epValidaDados.SetObrigatorio(this.txtIdCliente, false);
            this.txtIdCliente.Size = new System.Drawing.Size(100, 23);
            this.txtIdCliente.TabIndex = 4;
            this.txtIdCliente.TabStop = false;
            this.txtIdCliente.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "Localidade";
            // 
            // cbCidade
            // 
            this.cbCidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbCidade.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbCidade, "Loclidade obrigatório.");
            this.epValidaDados.SetIndiceCombo(this.cbCidade, -1);
            this.cbCidade.Location = new System.Drawing.Point(83, 63);
            this.cbCidade.Name = "cbCidade";
            this.epValidaDados.SetObrigatorio(this.cbCidade, true);
            this.cbCidade.Size = new System.Drawing.Size(351, 24);
            this.cbCidade.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Vendedor";
            // 
            // cbVendedor
            // 
            this.cbVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbVendedor.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbVendedor, "Vendedor obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbVendedor, -1);
            this.cbVendedor.Location = new System.Drawing.Point(83, 7);
            this.cbVendedor.Name = "cbVendedor";
            this.epValidaDados.SetObrigatorio(this.cbVendedor, true);
            this.cbVendedor.Size = new System.Drawing.Size(351, 24);
            this.cbVendedor.TabIndex = 0;
            this.cbVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbVendedor_KeyPress);
            // 
            // frmCadEditVendedor_Localidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(574, 112);
            this.Name = "frmCadEditVendedor_Localidade";
            this.Text = "Vendedor x Localidade";
            this.pnlBotoes.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUF;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbVendedor;
    }
}
