namespace optmed
{
    partial class frmCadEditVendedor
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
            this.txtCodInt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkInativo = new System.Windows.Forms.CheckBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
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
            this.pnlPrincipal.Size = new System.Drawing.Size(419, 112);
            // 
            // pnlJanela
            // 
            this.pnlJanela.Controls.Add(this.txtCodigo);
            this.pnlJanela.Controls.Add(this.txtId);
            this.pnlJanela.Controls.Add(this.chkInativo);
            this.pnlJanela.Controls.Add(this.label1);
            this.pnlJanela.Controls.Add(this.txtNome);
            this.pnlJanela.Controls.Add(this.txtCodInt);
            this.pnlJanela.Controls.Add(this.label3);
            this.pnlJanela.Location = new System.Drawing.Point(66, 19);
            this.pnlJanela.Size = new System.Drawing.Size(419, 112);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Código";
            // 
            // txtCodInt
            // 
            this.txtCodInt.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtCodInt, "");
            this.txtCodInt.Location = new System.Drawing.Point(314, 9);
            this.txtCodInt.Name = "txtCodInt";
            this.epValidaDados.SetObrigatorio(this.txtCodInt, false);
            this.txtCodInt.Size = new System.Drawing.Size(100, 23);
            this.txtCodInt.TabIndex = 3;
            this.txtCodInt.TabStop = false;
            this.txtCodInt.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "Nome";
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInativo.Location = new System.Drawing.Point(3, 64);
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Size = new System.Drawing.Size(73, 20);
            this.chkInativo.TabIndex = 42;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            this.epValidaDados.SetFraseErro(this.txtNome, "Nome do vendedor obrigatório.");
            this.txtNome.Location = new System.Drawing.Point(62, 38);
            this.txtNome.Name = "txtNome";
            this.epValidaDados.SetObrigatorio(this.txtNome, true);
            this.txtNome.Size = new System.Drawing.Size(351, 23);
            this.txtNome.TabIndex = 0;
            this.txtNome.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(62, 9);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 43;
            this.txtId.TabStop = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtCodigo, "");
            this.txtCodigo.Location = new System.Drawing.Point(178, 9);
            this.txtCodigo.Name = "txtCodigo";
            this.epValidaDados.SetObrigatorio(this.txtCodigo, false);
            this.txtCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtCodigo.TabIndex = 44;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.Visible = false;
            // 
            // frmCadEditVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(534, 112);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmCadEditVendedor";
            this.Text = "Vendedor";
            this.Activated += new System.EventHandler(this.frmCadEditVendedor_Activated);
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlJanela.ResumeLayout(false);
            this.pnlJanela.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodInt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.CheckBox chkInativo;
        private System.Windows.Forms.TextBox txtNome;
    }
}
