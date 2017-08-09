namespace optmed
{
    partial class frmAlteraSenha
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
            this.components = new System.ComponentModel.Container();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.txtSenhaAtual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.ckVisualizarSenha = new System.Windows.Forms.CheckBox();
            this.txtConfPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.epValidaDados = new libComponente.ValidaObrigatorio(this.components);
            this.pnlPrincipal.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.txtSenhaAtual);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.lblUsuario);
            this.pnlPrincipal.Controls.Add(this.ckVisualizarSenha);
            this.pnlPrincipal.Controls.Add(this.txtConfPassword);
            this.pnlPrincipal.Controls.Add(this.label6);
            this.pnlPrincipal.Controls.Add(this.txtPassword);
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtId);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrincipal.Location = new System.Drawing.Point(115, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(441, 155);
            this.pnlPrincipal.TabIndex = 2;
            // 
            // txtSenhaAtual
            // 
            this.epValidaDados.SetFraseErro(this.txtSenhaAtual, "Senha atual obrigatória.");
            this.txtSenhaAtual.Location = new System.Drawing.Point(95, 32);
            this.txtSenhaAtual.Name = "txtSenhaAtual";
            this.epValidaDados.SetObrigatorio(this.txtSenhaAtual, true);
            this.txtSenhaAtual.PasswordChar = '*';
            this.txtSenhaAtual.Size = new System.Drawing.Size(322, 23);
            this.txtSenhaAtual.TabIndex = 0;
            this.txtSenhaAtual.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Senha atual";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(67, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(29, 16);
            this.lblUsuario.TabIndex = 24;
            this.lblUsuario.Text = "xxx";
            // 
            // ckVisualizarSenha
            // 
            this.ckVisualizarSenha.AutoSize = true;
            this.ckVisualizarSenha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckVisualizarSenha.Location = new System.Drawing.Point(4, 120);
            this.ckVisualizarSenha.Name = "ckVisualizarSenha";
            this.ckVisualizarSenha.Size = new System.Drawing.Size(132, 20);
            this.ckVisualizarSenha.TabIndex = 3;
            this.ckVisualizarSenha.Text = "Visualizar senha";
            this.ckVisualizarSenha.UseVisualStyleBackColor = true;
            this.ckVisualizarSenha.CheckedChanged += new System.EventHandler(this.ckVisualizarSenha_CheckedChanged);
            this.ckVisualizarSenha.MarginChanged += new System.EventHandler(this.ckVisualizarSenha_CheckedChanged);
            // 
            // txtConfPassword
            // 
            this.epValidaDados.SetFraseErro(this.txtConfPassword, "Confirmação de senha obrigatória.");
            this.txtConfPassword.Location = new System.Drawing.Point(95, 91);
            this.txtConfPassword.Name = "txtConfPassword";
            this.epValidaDados.SetObrigatorio(this.txtConfPassword, true);
            this.txtConfPassword.PasswordChar = '*';
            this.txtConfPassword.Size = new System.Drawing.Size(322, 23);
            this.txtConfPassword.TabIndex = 2;
            this.txtConfPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfPassword_Validating);
            this.txtConfPassword.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Conf. Senha";
            // 
            // txtPassword
            // 
            this.epValidaDados.SetFraseErro(this.txtPassword, "Nova senha obrigatoria.");
            this.txtPassword.Location = new System.Drawing.Point(95, 61);
            this.txtPassword.Name = "txtPassword";
            this.epValidaDados.SetObrigatorio(this.txtPassword, true);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(322, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Validated += new System.EventHandler(this.Ctrls_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nova senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Usuário";
            // 
            // txtId
            // 
            this.epValidaDados.SetFraseErro(this.txtId, "");
            this.txtId.Location = new System.Drawing.Point(317, 117);
            this.txtId.Name = "txtId";
            this.epValidaDados.SetObrigatorio(this.txtId, false);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 17;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(115, 155);
            this.pnlBotoes.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Image = global::optmed.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(3, 40);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 33);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalvar.Image = global::optmed.Properties.Resources.salvar;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(3, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(109, 33);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // epValidaDados
            // 
            this.epValidaDados.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epValidaDados.ContainerControl = this;
            // 
            // frmAlteraSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(556, 155);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlBotoes);
            this.KeyPreview = true;
            this.Name = "frmAlteraSenha";
            this.Text = "Alterar Senha";
            this.Load += new System.EventHandler(this.frmAlteraSenha_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAlteraSenha_KeyPress);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlPrincipal;
        protected System.Windows.Forms.Panel pnlBotoes;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtSenhaAtual;
        private libComponente.ValidaObrigatorio epValidaDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.CheckBox ckVisualizarSenha;
        private System.Windows.Forms.TextBox txtConfPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
    }
}
