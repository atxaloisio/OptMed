namespace optmed
{
    partial class frmCadEditRota
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
            this.cbTransportadora = new System.Windows.Forms.ComboBox();
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
            this.pnlPrincipal.Size = new System.Drawing.Size(495, 112);
            // 
            // pnlJanela
            // 
            this.pnlJanela.Controls.Add(this.label4);
            this.pnlJanela.Controls.Add(this.cbTransportadora);
            this.pnlJanela.Controls.Add(this.label1);
            this.pnlJanela.Controls.Add(this.cbCidade);
            this.pnlJanela.Controls.Add(this.txtIdCliente);
            this.pnlJanela.Controls.Add(this.txtId);
            this.pnlJanela.Controls.Add(this.label3);
            this.pnlJanela.Controls.Add(this.cbUF);
            this.pnlJanela.Location = new System.Drawing.Point(66, 19);
            this.pnlJanela.Size = new System.Drawing.Size(495, 112);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 37);
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
            this.cbUF.Location = new System.Drawing.Point(121, 34);
            this.cbUF.MaxLength = 2;
            this.cbUF.Name = "cbUF";
            this.epValidaDados.SetObrigatorio(this.cbUF, true);
            this.cbUF.Size = new System.Drawing.Size(48, 24);
            this.cbUF.TabIndex = 1;
            this.cbUF.SelectedIndexChanged += new System.EventHandler(this.cbUF_SelectedIndexChanged);
            this.cbUF.SelectionChangeCommitted += new System.EventHandler(this.cbUF_SelectionChangeCommitted);
            this.cbUF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTransportadora_KeyPress);
            this.cbUF.Validating += new System.ComponentModel.CancelEventHandler(this.cbUF_Validating);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(266, 34);
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
            this.txtIdCliente.Location = new System.Drawing.Point(372, 34);
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
            this.label1.Location = new System.Drawing.Point(39, 65);
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
            this.cbCidade.Location = new System.Drawing.Point(121, 62);
            this.cbCidade.Name = "cbCidade";
            this.epValidaDados.SetObrigatorio(this.cbCidade, true);
            this.cbCidade.Size = new System.Drawing.Size(351, 24);
            this.cbCidade.TabIndex = 2;
            this.cbCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTransportadora_KeyPress);
            this.cbCidade.Validating += new System.ComponentModel.CancelEventHandler(this.cbUF_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Transportadora";
            // 
            // cbTransportadora
            // 
            this.cbTransportadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTransportadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbTransportadora.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbTransportadora, "Transportadora obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbTransportadora, -1);
            this.cbTransportadora.Location = new System.Drawing.Point(121, 6);
            this.cbTransportadora.Name = "cbTransportadora";
            this.epValidaDados.SetObrigatorio(this.cbTransportadora, true);
            this.cbTransportadora.Size = new System.Drawing.Size(351, 24);
            this.cbTransportadora.TabIndex = 0;
            this.cbTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTransportadora_KeyPress);
            // 
            // frmCadEditRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(610, 112);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmCadEditRota";
            this.Text = "Transportadora x Localidade";
            this.Activated += new System.EventHandler(this.frmCadEditRota_Activated);
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlJanela.ResumeLayout(false);
            this.pnlJanela.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbTransportadora;
    }
}
