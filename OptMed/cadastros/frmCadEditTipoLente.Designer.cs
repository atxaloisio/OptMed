namespace optmed
{
    partial class frmCadEditTipo_Lente
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
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlJanela.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(3, 353);
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
            this.pnlPrincipal.Size = new System.Drawing.Size(457, 114);
            // 
            // pnlJanela
            // 
            this.pnlJanela.Controls.Add(this.chkInativo);
            this.pnlJanela.Controls.Add(this.txtNumero);
            this.pnlJanela.Controls.Add(this.label2);
            this.pnlJanela.Controls.Add(this.txtId);
            this.pnlJanela.Controls.Add(this.label1);
            this.pnlJanela.Location = new System.Drawing.Point(66, 19);
            this.pnlJanela.Size = new System.Drawing.Size(457, 114);
            // 
            // txtNumero
            // 
            this.epValidaDados.SetFraseErro(this.txtNumero, "Nome do Tipo_Lente obrigatório.");
            this.txtNumero.Location = new System.Drawing.Point(77, 36);
            this.txtNumero.Name = "txtNumero";
            this.epValidaDados.SetObrigatorio(this.txtNumero, true);
            this.txtNumero.Size = new System.Drawing.Size(364, 23);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descrição";
            // 
            // txtId
            // 
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(77, 9);
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
            this.chkInativo.Location = new System.Drawing.Point(3, 64);
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Size = new System.Drawing.Size(73, 20);
            this.chkInativo.TabIndex = 1;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.UseVisualStyleBackColor = true;
            // 
            // frmCadEditTipo_Lente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(572, 114);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmCadEditTipo_Lente";
            this.Text = "Tipo de Lente";
            this.Activated += new System.EventHandler(this.frmCadEditTipo_Lente_Activated);
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlJanela.ResumeLayout(false);
            this.pnlJanela.PerformLayout();
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
