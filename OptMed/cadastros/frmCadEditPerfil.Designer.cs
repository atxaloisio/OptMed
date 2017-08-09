namespace optmed
{
    partial class frmCadEditPerfil
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.pnlPrincipal.Controls.Add(this.txtDescricao);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.txtNome);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtId);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Size = new System.Drawing.Size(438, 114);
            // 
            // txtNome
            // 
            this.epValidaDados.SetFraseErro(this.txtNome, "Nome do perfil obrigatório.");
            this.txtNome.Location = new System.Drawing.Point(81, 39);
            this.txtNome.Name = "txtNome";
            this.epValidaDados.SetObrigatorio(this.txtNome, true);
            this.txtNome.Size = new System.Drawing.Size(336, 23);
            this.txtNome.TabIndex = 1;
            this.txtNome.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome";
            // 
            // txtId
            // 
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(81, 9);
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
            // txtDescricao
            // 
            this.epValidaDados.SetFraseErro(this.txtDescricao, "");
            this.txtDescricao.Location = new System.Drawing.Point(81, 68);
            this.txtDescricao.Name = "txtDescricao";
            this.epValidaDados.SetObrigatorio(this.txtDescricao, false);
            this.txtDescricao.Size = new System.Drawing.Size(336, 23);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Descrição";
            // 
            // frmCadEditPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(553, 114);
            this.Name = "frmCadEditPerfil";
            this.Text = "Perfil";
            this.Shown += new System.EventHandler(this.frmCadEditPerfil_Shown);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
    }
}
