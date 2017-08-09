namespace optmed
{
    partial class frmBasePesquisa
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
            this.pnlDadosPesquisa = new System.Windows.Forms.Panel();
            this.dgvPesquisa = new System.Windows.Forms.DataGridView();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlDadosPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).BeginInit();
            this.pnlFiltro.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDadosPesquisa
            // 
            this.pnlDadosPesquisa.Controls.Add(this.dgvPesquisa);
            this.pnlDadosPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDadosPesquisa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDadosPesquisa.Location = new System.Drawing.Point(115, 73);
            this.pnlDadosPesquisa.Name = "pnlDadosPesquisa";
            this.pnlDadosPesquisa.Size = new System.Drawing.Size(574, 225);
            this.pnlDadosPesquisa.TabIndex = 3;
            // 
            // dgvPesquisa
            // 
            this.dgvPesquisa.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPesquisa.Location = new System.Drawing.Point(0, 0);
            this.dgvPesquisa.Name = "dgvPesquisa";
            this.dgvPesquisa.ReadOnly = true;
            this.dgvPesquisa.RowHeadersVisible = false;
            this.dgvPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisa.Size = new System.Drawing.Size(574, 225);
            this.dgvPesquisa.TabIndex = 0;
            this.dgvPesquisa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisa_CellDoubleClick);
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.btnPesquisar);
            this.pnlFiltro.Controls.Add(this.label1);
            this.pnlFiltro.Controls.Add(this.txtFiltro);
            this.pnlFiltro.Controls.Add(this.cbFiltro);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFiltro.Location = new System.Drawing.Point(115, 0);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(574, 73);
            this.pnlFiltro.TabIndex = 0;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPesquisar.Image = global::optmed.Properties.Resources.Pesquisar;
            this.btnPesquisar.Location = new System.Drawing.Point(542, 27);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(26, 26);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pesquisar por";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(160, 29);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(378, 23);
            this.txtFiltro.TabIndex = 1;
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(6, 28);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(148, 24);
            this.cbFiltro.TabIndex = 0;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnOK);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(115, 298);
            this.pnlBotoes.TabIndex = 1;
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
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOK.Image = global::optmed.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOK.Location = new System.Drawing.Point(3, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 33);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "    &OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmBasePesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(689, 298);
            this.Controls.Add(this.pnlDadosPesquisa);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.pnlBotoes);
            this.KeyPreview = true;
            this.Name = "frmBasePesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa";
            this.Load += new System.EventHandler(this.frmBasePesquisa_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBasePesquisa_KeyPress);
            this.pnlDadosPesquisa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).EndInit();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlBotoes;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel pnlFiltro;
        protected System.Windows.Forms.DataGridView dgvPesquisa;
        protected System.Windows.Forms.Panel pnlDadosPesquisa;
        protected System.Windows.Forms.TextBox txtFiltro;
        protected System.Windows.Forms.ComboBox cbFiltro;
    }
}
