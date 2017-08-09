namespace optmed
{
    partial class frmProcAgrupaPedido
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
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlBorda = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblTotalPaginas = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblNumeroPagina = new System.Windows.Forms.Label();
            this.btnPrimeiro = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAgrupar = new System.Windows.Forms.Button();
            this.pnlDados = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.ctxMenuGridDados = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selecionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecionarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desmarcarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descarcarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFiltro = new System.Windows.Forms.DataGridView();
            this.pnlBotoes.SuspendLayout();
            this.pnlDados.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.ctxMenuGridDados.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlBotoes.Controls.Add(this.btnImprimir);
            this.pnlBotoes.Controls.Add(this.pnlBorda);
            this.pnlBotoes.Controls.Add(this.lblTotalRegistros);
            this.pnlBotoes.Controls.Add(this.lblRegistros);
            this.pnlBotoes.Controls.Add(this.lblTotalPaginas);
            this.pnlBotoes.Controls.Add(this.lblDe);
            this.pnlBotoes.Controls.Add(this.lblNumeroPagina);
            this.pnlBotoes.Controls.Add(this.btnPrimeiro);
            this.pnlBotoes.Controls.Add(this.btnAnterior);
            this.pnlBotoes.Controls.Add(this.btnProximo);
            this.pnlBotoes.Controls.Add(this.btnUltimo);
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnAgrupar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBotoes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBotoes.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(116, 405);
            this.pnlBotoes.TabIndex = 10;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImprimir.Image = global::optmed.Properties.Resources.Imprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(4, 71);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(109, 33);
            this.btnImprimir.TabIndex = 22;
            this.btnImprimir.Text = "Imprimi&r";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pnlBorda
            // 
            this.pnlBorda.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlBorda.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlBorda.Location = new System.Drawing.Point(6, 310);
            this.pnlBorda.Name = "pnlBorda";
            this.pnlBorda.Size = new System.Drawing.Size(104, 4);
            this.pnlBorda.TabIndex = 21;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(72, 286);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(40, 16);
            this.lblTotalRegistros.TabIndex = 20;
            this.lblTotalRegistros.Text = "0";
            this.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(9, 288);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(56, 15);
            this.lblRegistros.TabIndex = 19;
            this.lblRegistros.Text = "Registros:";
            // 
            // lblTotalPaginas
            // 
            this.lblTotalPaginas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalPaginas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaginas.Location = new System.Drawing.Point(70, 322);
            this.lblTotalPaginas.Name = "lblTotalPaginas";
            this.lblTotalPaginas.Size = new System.Drawing.Size(40, 16);
            this.lblTotalPaginas.TabIndex = 18;
            this.lblTotalPaginas.Text = "0";
            this.lblTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDe
            // 
            this.lblDe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(51, 322);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(22, 16);
            this.lblDe.TabIndex = 17;
            this.lblDe.Text = "de";
            this.lblDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumeroPagina
            // 
            this.lblNumeroPagina.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblNumeroPagina.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroPagina.Location = new System.Drawing.Point(9, 322);
            this.lblNumeroPagina.Name = "lblNumeroPagina";
            this.lblNumeroPagina.Size = new System.Drawing.Size(39, 16);
            this.lblNumeroPagina.TabIndex = 16;
            this.lblNumeroPagina.Text = "0";
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrimeiro.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPrimeiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimeiro.Image = global::optmed.Properties.Resources.primeiro;
            this.btnPrimeiro.Location = new System.Drawing.Point(6, 341);
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(26, 23);
            this.btnPrimeiro.TabIndex = 15;
            this.btnPrimeiro.UseVisualStyleBackColor = false;
            this.btnPrimeiro.Click += new System.EventHandler(this.btnPrimeiro_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnterior.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::optmed.Properties.Resources.anterior;
            this.btnAnterior.Location = new System.Drawing.Point(34, 341);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(24, 23);
            this.btnAnterior.TabIndex = 14;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnProximo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximo.Image = global::optmed.Properties.Resources.proximo;
            this.btnProximo.Location = new System.Drawing.Point(60, 341);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(24, 23);
            this.btnProximo.TabIndex = 13;
            this.btnProximo.UseVisualStyleBackColor = false;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUltimo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.Image = global::optmed.Properties.Resources.ultimo;
            this.btnUltimo.Location = new System.Drawing.Point(86, 341);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(26, 23);
            this.btnUltimo.TabIndex = 12;
            this.btnUltimo.UseVisualStyleBackColor = false;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFechar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFechar.Image = global::optmed.Properties.Resources.fechar;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(4, 370);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(109, 33);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExcluir.Image = global::optmed.Properties.Resources.excluir;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(4, 37);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(109, 33);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "E&xcluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgrupar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgrupar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgrupar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgrupar.Image = global::optmed.Properties.Resources.novo;
            this.btnAgrupar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAgrupar.Location = new System.Drawing.Point(4, 3);
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Size = new System.Drawing.Size(109, 33);
            this.btnAgrupar.TabIndex = 8;
            this.btnAgrupar.Text = "&Incluir";
            this.btnAgrupar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgrupar.UseVisualStyleBackColor = false;
            this.btnAgrupar.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.panel2);
            this.pnlDados.Controls.Add(this.panel1);
            this.pnlDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDados.Location = new System.Drawing.Point(116, 0);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(615, 405);
            this.pnlDados.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDados);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 335);
            this.panel2.TabIndex = 1;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.ContextMenuStrip = this.ctxMenuGridDados;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.Size = new System.Drawing.Size(615, 335);
            this.dgvDados.TabIndex = 0;
            // 
            // ctxMenuGridDados
            // 
            this.ctxMenuGridDados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecionarToolStripMenuItem,
            this.selecionarTodosToolStripMenuItem,
            this.desmarcarToolStripMenuItem,
            this.descarcarTodosToolStripMenuItem});
            this.ctxMenuGridDados.Name = "ctxMenuGridDados";
            this.ctxMenuGridDados.Size = new System.Drawing.Size(164, 92);
            // 
            // selecionarToolStripMenuItem
            // 
            this.selecionarToolStripMenuItem.Name = "selecionarToolStripMenuItem";
            this.selecionarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.selecionarToolStripMenuItem.Text = "Selecionar";
            this.selecionarToolStripMenuItem.Click += new System.EventHandler(this.selecionarToolStripMenuItem_Click);
            // 
            // selecionarTodosToolStripMenuItem
            // 
            this.selecionarTodosToolStripMenuItem.Name = "selecionarTodosToolStripMenuItem";
            this.selecionarTodosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.selecionarTodosToolStripMenuItem.Text = "Selecionar Todos";
            this.selecionarTodosToolStripMenuItem.Click += new System.EventHandler(this.selecionarTodosToolStripMenuItem_Click);
            // 
            // desmarcarToolStripMenuItem
            // 
            this.desmarcarToolStripMenuItem.Name = "desmarcarToolStripMenuItem";
            this.desmarcarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.desmarcarToolStripMenuItem.Text = "Desmarcar";
            this.desmarcarToolStripMenuItem.Click += new System.EventHandler(this.desmarcarToolStripMenuItem_Click);
            // 
            // descarcarTodosToolStripMenuItem
            // 
            this.descarcarTodosToolStripMenuItem.Name = "descarcarTodosToolStripMenuItem";
            this.descarcarTodosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.descarcarTodosToolStripMenuItem.Text = "Descarcar Todos";
            this.descarcarTodosToolStripMenuItem.Click += new System.EventHandler(this.descarcarTodosToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvFiltro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 70);
            this.panel1.TabIndex = 0;
            // 
            // dgvFiltro
            // 
            this.dgvFiltro.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiltro.Location = new System.Drawing.Point(0, 0);
            this.dgvFiltro.Name = "dgvFiltro";
            this.dgvFiltro.Size = new System.Drawing.Size(615, 70);
            this.dgvFiltro.TabIndex = 0;
            // 
            // frmProcAgrupaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(731, 405);
            this.Controls.Add(this.pnlDados);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmProcAgrupaPedido";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agrupamento de pedidos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmProcAgrupaPedido_Activated);
            this.Load += new System.EventHandler(this.frmProcAgrupaPedido_Load);
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.pnlDados.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ctxMenuGridDados.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel pnlBotoes;
        public System.Windows.Forms.Panel pnlDados;
        public System.Windows.Forms.Button btnExcluir;
        public System.Windows.Forms.Button btnAgrupar;
        public System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.DataGridView dgvDados;
        protected System.Windows.Forms.DataGridView dgvFiltro;
        private System.Windows.Forms.Label lblDe;
        protected System.Windows.Forms.Label lblTotalPaginas;
        protected System.Windows.Forms.Label lblNumeroPagina;
        protected System.Windows.Forms.Button btnPrimeiro;
        protected System.Windows.Forms.Button btnAnterior;
        protected System.Windows.Forms.Button btnProximo;
        protected System.Windows.Forms.Button btnUltimo;
        protected System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Panel pnlBorda;
        public System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ContextMenuStrip ctxMenuGridDados;
        private System.Windows.Forms.ToolStripMenuItem selecionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecionarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desmarcarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descarcarTodosToolStripMenuItem;
    }
}
