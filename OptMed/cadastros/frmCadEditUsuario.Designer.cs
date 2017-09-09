namespace optmed
{
    partial class frmCadEditUsuario
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDtCriacao = new System.Windows.Forms.MaskedTextBox();
            this.txtDtAlteracao = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPerfil = new System.Windows.Forms.ComboBox();
            this.txtConfPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckVisualizarSenha = new System.Windows.Forms.CheckBox();
            this.chkInativo = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFilial = new System.Windows.Forms.ComboBox();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlJanela.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(3, 296);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Size = new System.Drawing.Size(115, 329);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Size = new System.Drawing.Size(514, 329);
            // 
            // pnlJanela
            // 
            this.pnlJanela.Controls.Add(this.label7);
            this.pnlJanela.Controls.Add(this.cbFilial);
            this.pnlJanela.Controls.Add(this.txtEmail);
            this.pnlJanela.Controls.Add(this.chkInativo);
            this.pnlJanela.Controls.Add(this.ckVisualizarSenha);
            this.pnlJanela.Controls.Add(this.txtConfPassword);
            this.pnlJanela.Controls.Add(this.label6);
            this.pnlJanela.Controls.Add(this.label5);
            this.pnlJanela.Controls.Add(this.cbPerfil);
            this.pnlJanela.Controls.Add(this.txtDtAlteracao);
            this.pnlJanela.Controls.Add(this.txtDtCriacao);
            this.pnlJanela.Controls.Add(this.txtPassword);
            this.pnlJanela.Controls.Add(this.label4);
            this.pnlJanela.Controls.Add(this.label3);
            this.pnlJanela.Controls.Add(this.txtNome);
            this.pnlJanela.Controls.Add(this.label2);
            this.pnlJanela.Controls.Add(this.txtId);
            this.pnlJanela.Controls.Add(this.label1);
            this.pnlJanela.Location = new System.Drawing.Point(41, 14);
            this.pnlJanela.Size = new System.Drawing.Size(449, 268);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // txtId
            // 
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(57, 9);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 0;
            this.txtId.TabStop = false;
            // 
            // txtNome
            // 
            this.epValidaDados.SetFraseErro(this.txtNome, "Nome do usuário obrigatório.");
            this.txtNome.Location = new System.Drawing.Point(57, 39);
            this.txtNome.Name = "txtNome";
            this.epValidaDados.SetObrigatorio(this.txtNome, true);
            this.txtNome.Size = new System.Drawing.Size(360, 23);
            this.txtNome.TabIndex = 1;
            this.txtNome.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "e-Mail";
            // 
            // txtPassword
            // 
            this.epValidaDados.SetFraseErro(this.txtPassword, "Senha do usuário obrigatório");
            this.txtPassword.Location = new System.Drawing.Point(95, 131);
            this.txtPassword.Name = "txtPassword";
            this.epValidaDados.SetObrigatorio(this.txtPassword, true);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(322, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Senha";
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtDtCriacao, "");
            this.txtDtCriacao.Location = new System.Drawing.Point(285, 190);
            this.txtDtCriacao.Name = "txtDtCriacao";
            this.epValidaDados.SetObrigatorio(this.txtDtCriacao, false);
            this.txtDtCriacao.ReadOnly = true;
            this.txtDtCriacao.Size = new System.Drawing.Size(132, 23);
            this.txtDtCriacao.TabIndex = 8;
            this.epValidaDados.SetTipoValidacao(this.txtDtCriacao, libComponente.TipoValidacao.Vazio);
            this.txtDtCriacao.Visible = false;
            // 
            // txtDtAlteracao
            // 
            this.txtDtAlteracao.Enabled = false;
            this.epValidaDados.SetFraseErro(this.txtDtAlteracao, "");
            this.txtDtAlteracao.Location = new System.Drawing.Point(147, 190);
            this.txtDtAlteracao.Name = "txtDtAlteracao";
            this.epValidaDados.SetObrigatorio(this.txtDtAlteracao, false);
            this.txtDtAlteracao.ReadOnly = true;
            this.txtDtAlteracao.Size = new System.Drawing.Size(132, 23);
            this.txtDtAlteracao.TabIndex = 9;
            this.epValidaDados.SetTipoValidacao(this.txtDtAlteracao, libComponente.TipoValidacao.Vazio);
            this.txtDtAlteracao.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Perfil";
            // 
            // cbPerfil
            // 
            this.cbPerfil.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbPerfil, "Perfil do usuário obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbPerfil, -1);
            this.cbPerfil.Location = new System.Drawing.Point(57, 98);
            this.cbPerfil.Name = "cbPerfil";
            this.epValidaDados.SetObrigatorio(this.cbPerfil, true);
            this.cbPerfil.Size = new System.Drawing.Size(360, 24);
            this.cbPerfil.TabIndex = 3;
            this.cbPerfil.Text = "Perfil";
            this.cbPerfil.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // txtConfPassword
            // 
            this.epValidaDados.SetFraseErro(this.txtConfPassword, "confirmação de senha do usuário obrigatório");
            this.txtConfPassword.Location = new System.Drawing.Point(95, 161);
            this.txtConfPassword.Name = "txtConfPassword";
            this.epValidaDados.SetObrigatorio(this.txtConfPassword, true);
            this.txtConfPassword.PasswordChar = '*';
            this.txtConfPassword.Size = new System.Drawing.Size(322, 23);
            this.txtConfPassword.TabIndex = 5;
            this.txtConfPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfPassword_Validating);
            this.txtConfPassword.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Conf. Senha";
            // 
            // ckVisualizarSenha
            // 
            this.ckVisualizarSenha.AutoSize = true;
            this.ckVisualizarSenha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckVisualizarSenha.Location = new System.Drawing.Point(5, 190);
            this.ckVisualizarSenha.Name = "ckVisualizarSenha";
            this.ckVisualizarSenha.Size = new System.Drawing.Size(132, 20);
            this.ckVisualizarSenha.TabIndex = 6;
            this.ckVisualizarSenha.Text = "Visualizar senha";
            this.ckVisualizarSenha.UseVisualStyleBackColor = true;
            this.ckVisualizarSenha.CheckedChanged += new System.EventHandler(this.ckVisualizarSenha_CheckedChanged);
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInativo.Location = new System.Drawing.Point(4, 213);
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Size = new System.Drawing.Size(133, 20);
            this.chkInativo.TabIndex = 7;
            this.chkInativo.Text = "Inativo               ";
            this.chkInativo.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.epValidaDados.SetFraseErro(this.txtEmail, "e-mail do usuário obrigatório ");
            this.txtEmail.Location = new System.Drawing.Point(58, 68);
            this.txtEmail.Name = "txtEmail";
            this.epValidaDados.SetObrigatorio(this.txtEmail, true);
            this.txtEmail.Size = new System.Drawing.Size(359, 23);
            this.txtEmail.TabIndex = 2;
            this.epValidaDados.SetTipoValidacao(this.txtEmail, libComponente.TipoValidacao.Email);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Filial";
            // 
            // cbFilial
            // 
            this.cbFilial.FormattingEnabled = true;
            this.epValidaDados.SetFraseErro(this.cbFilial, "Filial do usuário obrigatório");
            this.epValidaDados.SetIndiceCombo(this.cbFilial, -1);
            this.cbFilial.Location = new System.Drawing.Point(57, 234);
            this.cbFilial.Name = "cbFilial";
            this.epValidaDados.SetObrigatorio(this.cbFilial, false);
            this.cbFilial.Size = new System.Drawing.Size(360, 24);
            this.cbFilial.TabIndex = 14;
            this.cbFilial.Text = "Filial";
            // 
            // frmCadEditUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(629, 329);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCadEditUsuario";
            this.Text = "Usuário";
            this.Activated += new System.EventHandler(this.frmCadEditUsuario_Activated);
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlJanela.ResumeLayout(false);
            this.pnlJanela.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtDtAlteracao;
        private System.Windows.Forms.MaskedTextBox txtDtCriacao;
        private System.Windows.Forms.CheckBox ckVisualizarSenha;
        private System.Windows.Forms.TextBox txtConfPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPerfil;
        private System.Windows.Forms.CheckBox chkInativo;
        private System.Windows.Forms.MaskedTextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFilial;
    }
}
