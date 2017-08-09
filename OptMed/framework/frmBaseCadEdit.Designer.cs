namespace optmed
{
    partial class frmBaseCadEdit 
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
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.epValidaDados = new libComponente.ValidaObrigatorio(this.components);
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrincipal.Location = new System.Drawing.Point(115, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(495, 386);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnIncluir);
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(115, 386);
            this.pnlBotoes.TabIndex = 1;
            // 
            // btnIncluir
            // 
            this.btnIncluir.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncluir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIncluir.Image = global::optmed.Properties.Resources.novo;
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluir.Location = new System.Drawing.Point(3, 75);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(109, 33);
            this.btnIncluir.TabIndex = 11;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Visible = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnFechar.CausesValidation = false;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFechar.Image = global::optmed.Properties.Resources.fechar;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFechar.Location = new System.Drawing.Point(3, 40);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(109, 33);
            this.btnFechar.TabIndex = 10;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            // frmBaseCadEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(610, 386);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlBotoes);
            this.KeyPreview = true;
            this.Name = "frmBaseCadEdit";
            this.Load += new System.EventHandler(this.frmBaseCadEdit_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBaseCadEdit_KeyPress);
            this.pnlBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epValidaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.Button btnIncluir;
        protected System.Windows.Forms.Panel pnlBotoes;
        protected System.Windows.Forms.Panel pnlPrincipal;
        protected libComponente.ValidaObrigatorio epValidaDados;
    }
}
