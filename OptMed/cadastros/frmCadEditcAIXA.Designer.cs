namespace optmed
{
    partial class frmCadEditCaixa
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
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkInativo = new System.Windows.Forms.CheckBox();
            this.pnlBotoes.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnFechar.TabIndex = 1;
            // 
            // btnIncluir
            // 
            this.btnIncluir.TabIndex = 2;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Size = new System.Drawing.Size(115, 114);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.chkInativo);
            this.pnlPrincipal.Controls.Add(this.txtNumero);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtId);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Size = new System.Drawing.Size(176, 114);
            // 
            // txtNumero
            // 
            this.epValidaDados.SetFraseErro(this.txtNumero, "Nome do Caixa obrigatório.");
            this.txtNumero.Location = new System.Drawing.Point(62, 36);
            this.txtNumero.Name = "txtNumero";
            this.epValidaDados.SetObrigatorio(this.txtNumero, true);
            this.txtNumero.Size = new System.Drawing.Size(100, 23);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Número";
            // 
            // txtId
            // 
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(62, 9);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 0;
            this.txtId.TabStop = false;
            this.txtId.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Código";
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInativo.Location = new System.Drawing.Point(3, 60);
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Size = new System.Drawing.Size(73, 20);
            this.chkInativo.TabIndex = 1;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.UseVisualStyleBackColor = true;
            // 
            // frmCadEditCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(291, 114);
            this.Name = "frmCadEditCaixa";
            this.Text = "Caixa";
            this.pnlBotoes.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkInativo;
    }
}
