namespace optmed
{
    partial class frmProcAtualizaStatusPedido
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
            this.pnlDados = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCountEntregue = new System.Windows.Forms.Label();
            this.lblEntregue = new System.Windows.Forms.LinkLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCountSaiuPEntrega = new System.Windows.Forms.Label();
            this.lblSaiuPEntrega = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCountAEntregar = new System.Windows.Forms.Label();
            this.lblAEntregar = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCountEmProducao = new System.Windows.Forms.Label();
            this.lblEmProducao = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCountAgProducao = new System.Windows.Forms.Label();
            this.lblAgProducao = new System.Windows.Forms.LinkLabel();
            this.pnlGravadasImpressas = new System.Windows.Forms.Panel();
            this.lblCountGravadas = new System.Windows.Forms.Label();
            this.lblGravadasImpressas = new System.Windows.Forms.LinkLabel();
            this.pnlEntregue = new System.Windows.Forms.Panel();
            this.pnlSaiuPEntrega = new System.Windows.Forms.Panel();
            this.pnlAEntregar = new System.Windows.Forms.Panel();
            this.pnlEmProducao = new System.Windows.Forms.Panel();
            this.pnlAGProducao = new System.Windows.Forms.Panel();
            this.pnlGravadaImpressa = new System.Windows.Forms.Panel();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.dgvFiltro = new System.Windows.Forms.DataGridView();
            this.pnlDados.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlGravadasImpressas.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.panel2);
            this.pnlDados.Controls.Add(this.pnlFiltro);
            this.pnlDados.Location = new System.Drawing.Point(0, 0);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(1078, 572);
            this.pnlDados.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.pnlGravadasImpressas);
            this.panel2.Controls.Add(this.pnlEntregue);
            this.panel2.Controls.Add(this.pnlSaiuPEntrega);
            this.panel2.Controls.Add(this.pnlAEntregar);
            this.panel2.Controls.Add(this.pnlEmProducao);
            this.panel2.Controls.Add(this.pnlAGProducao);
            this.panel2.Controls.Add(this.pnlGravadaImpressa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1078, 502);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblCountEntregue);
            this.panel6.Controls.Add(this.lblEntregue);
            this.panel6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(896, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(180, 45);
            this.panel6.TabIndex = 5;
            // 
            // lblCountEntregue
            // 
            this.lblCountEntregue.AutoSize = true;
            this.lblCountEntregue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCountEntregue.Location = new System.Drawing.Point(75, 22);
            this.lblCountEntregue.Name = "lblCountEntregue";
            this.lblCountEntregue.Size = new System.Drawing.Size(28, 16);
            this.lblCountEntregue.TabIndex = 2;
            this.lblCountEntregue.Text = "(0)";
            this.lblCountEntregue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEntregue
            // 
            this.lblEntregue.AutoSize = true;
            this.lblEntregue.LinkColor = System.Drawing.Color.White;
            this.lblEntregue.Location = new System.Drawing.Point(55, 4);
            this.lblEntregue.Name = "lblEntregue";
            this.lblEntregue.Size = new System.Drawing.Size(67, 16);
            this.lblEntregue.TabIndex = 1;
            this.lblEntregue.TabStop = true;
            this.lblEntregue.Text = "Entregue";
            this.lblEntregue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEntregue_LinkClicked);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblCountSaiuPEntrega);
            this.panel5.Controls.Add(this.lblSaiuPEntrega);
            this.panel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(717, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 45);
            this.panel5.TabIndex = 4;
            // 
            // lblCountSaiuPEntrega
            // 
            this.lblCountSaiuPEntrega.AutoSize = true;
            this.lblCountSaiuPEntrega.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCountSaiuPEntrega.Location = new System.Drawing.Point(75, 22);
            this.lblCountSaiuPEntrega.Name = "lblCountSaiuPEntrega";
            this.lblCountSaiuPEntrega.Size = new System.Drawing.Size(28, 16);
            this.lblCountSaiuPEntrega.TabIndex = 2;
            this.lblCountSaiuPEntrega.Text = "(0)";
            this.lblCountSaiuPEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaiuPEntrega
            // 
            this.lblSaiuPEntrega.AutoSize = true;
            this.lblSaiuPEntrega.LinkColor = System.Drawing.Color.White;
            this.lblSaiuPEntrega.Location = new System.Drawing.Point(27, 4);
            this.lblSaiuPEntrega.Name = "lblSaiuPEntrega";
            this.lblSaiuPEntrega.Size = new System.Drawing.Size(124, 16);
            this.lblSaiuPEntrega.TabIndex = 1;
            this.lblSaiuPEntrega.TabStop = true;
            this.lblSaiuPEntrega.Text = "Saiu para Entrega";
            this.lblSaiuPEntrega.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSaiuPEntrega_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblCountAEntregar);
            this.panel4.Controls.Add(this.lblAEntregar);
            this.panel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(538, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 45);
            this.panel4.TabIndex = 3;
            // 
            // lblCountAEntregar
            // 
            this.lblCountAEntregar.AutoSize = true;
            this.lblCountAEntregar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCountAEntregar.Location = new System.Drawing.Point(75, 22);
            this.lblCountAEntregar.Name = "lblCountAEntregar";
            this.lblCountAEntregar.Size = new System.Drawing.Size(28, 16);
            this.lblCountAEntregar.TabIndex = 2;
            this.lblCountAEntregar.Text = "(0)";
            this.lblCountAEntregar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAEntregar
            // 
            this.lblAEntregar.AutoSize = true;
            this.lblAEntregar.LinkColor = System.Drawing.Color.White;
            this.lblAEntregar.Location = new System.Drawing.Point(53, 4);
            this.lblAEntregar.Name = "lblAEntregar";
            this.lblAEntregar.Size = new System.Drawing.Size(79, 16);
            this.lblAEntregar.TabIndex = 1;
            this.lblAEntregar.TabStop = true;
            this.lblAEntregar.Text = "A Entregar";
            this.lblAEntregar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAEntregar_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblCountEmProducao);
            this.panel3.Controls.Add(this.lblEmProducao);
            this.panel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(359, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 45);
            this.panel3.TabIndex = 2;
            // 
            // lblCountEmProducao
            // 
            this.lblCountEmProducao.AutoSize = true;
            this.lblCountEmProducao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCountEmProducao.Location = new System.Drawing.Point(75, 22);
            this.lblCountEmProducao.Name = "lblCountEmProducao";
            this.lblCountEmProducao.Size = new System.Drawing.Size(28, 16);
            this.lblCountEmProducao.TabIndex = 2;
            this.lblCountEmProducao.Text = "(0)";
            this.lblCountEmProducao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmProducao
            // 
            this.lblEmProducao.AutoSize = true;
            this.lblEmProducao.LinkColor = System.Drawing.Color.White;
            this.lblEmProducao.Location = new System.Drawing.Point(47, 4);
            this.lblEmProducao.Name = "lblEmProducao";
            this.lblEmProducao.Size = new System.Drawing.Size(91, 16);
            this.lblEmProducao.TabIndex = 1;
            this.lblEmProducao.TabStop = true;
            this.lblEmProducao.Text = "Em Producao";
            this.lblEmProducao.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEmProducao_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCountAgProducao);
            this.panel1.Controls.Add(this.lblAgProducao);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(180, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 45);
            this.panel1.TabIndex = 1;
            // 
            // lblCountAgProducao
            // 
            this.lblCountAgProducao.AutoSize = true;
            this.lblCountAgProducao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCountAgProducao.Location = new System.Drawing.Point(75, 22);
            this.lblCountAgProducao.Name = "lblCountAgProducao";
            this.lblCountAgProducao.Size = new System.Drawing.Size(28, 16);
            this.lblCountAgProducao.TabIndex = 2;
            this.lblCountAgProducao.Text = "(0)";
            this.lblCountAgProducao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAgProducao
            // 
            this.lblAgProducao.AutoSize = true;
            this.lblAgProducao.LinkColor = System.Drawing.Color.White;
            this.lblAgProducao.Location = new System.Drawing.Point(13, 4);
            this.lblAgProducao.Name = "lblAgProducao";
            this.lblAgProducao.Size = new System.Drawing.Size(153, 16);
            this.lblAgProducao.TabIndex = 1;
            this.lblAgProducao.TabStop = true;
            this.lblAgProducao.Text = "Aguardando Produção";
            this.lblAgProducao.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAgProducao_LinkClicked);
            // 
            // pnlGravadasImpressas
            // 
            this.pnlGravadasImpressas.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlGravadasImpressas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGravadasImpressas.Controls.Add(this.lblCountGravadas);
            this.pnlGravadasImpressas.Controls.Add(this.lblGravadasImpressas);
            this.pnlGravadasImpressas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGravadasImpressas.Location = new System.Drawing.Point(1, 0);
            this.pnlGravadasImpressas.Name = "pnlGravadasImpressas";
            this.pnlGravadasImpressas.Size = new System.Drawing.Size(180, 45);
            this.pnlGravadasImpressas.TabIndex = 0;
            // 
            // lblCountGravadas
            // 
            this.lblCountGravadas.AutoSize = true;
            this.lblCountGravadas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCountGravadas.Location = new System.Drawing.Point(72, 22);
            this.lblCountGravadas.Name = "lblCountGravadas";
            this.lblCountGravadas.Size = new System.Drawing.Size(28, 16);
            this.lblCountGravadas.TabIndex = 1;
            this.lblCountGravadas.Text = "(0)";
            this.lblCountGravadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGravadasImpressas
            // 
            this.lblGravadasImpressas.AutoSize = true;
            this.lblGravadasImpressas.LinkColor = System.Drawing.Color.White;
            this.lblGravadasImpressas.Location = new System.Drawing.Point(18, 4);
            this.lblGravadasImpressas.Name = "lblGravadasImpressas";
            this.lblGravadasImpressas.Size = new System.Drawing.Size(148, 16);
            this.lblGravadasImpressas.TabIndex = 0;
            this.lblGravadasImpressas.TabStop = true;
            this.lblGravadasImpressas.Text = "Gravada && Impressas";
            this.lblGravadasImpressas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGravadasImpressas_LinkClicked);
            // 
            // pnlEntregue
            // 
            this.pnlEntregue.AllowDrop = true;
            this.pnlEntregue.AutoScroll = true;
            this.pnlEntregue.BackColor = System.Drawing.Color.Transparent;
            this.pnlEntregue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEntregue.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEntregue.Location = new System.Drawing.Point(896, 44);
            this.pnlEntregue.Name = "pnlEntregue";
            this.pnlEntregue.Size = new System.Drawing.Size(180, 457);
            this.pnlEntregue.TabIndex = 11;
            this.pnlEntregue.Tag = "6";
            this.pnlEntregue.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragDrop);
            this.pnlEntregue.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragOver);
            // 
            // pnlSaiuPEntrega
            // 
            this.pnlSaiuPEntrega.AllowDrop = true;
            this.pnlSaiuPEntrega.AutoScroll = true;
            this.pnlSaiuPEntrega.BackColor = System.Drawing.Color.Transparent;
            this.pnlSaiuPEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSaiuPEntrega.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSaiuPEntrega.Location = new System.Drawing.Point(717, 44);
            this.pnlSaiuPEntrega.Name = "pnlSaiuPEntrega";
            this.pnlSaiuPEntrega.Size = new System.Drawing.Size(180, 457);
            this.pnlSaiuPEntrega.TabIndex = 10;
            this.pnlSaiuPEntrega.Tag = "5";
            this.pnlSaiuPEntrega.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragDrop);
            this.pnlSaiuPEntrega.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragOver);
            // 
            // pnlAEntregar
            // 
            this.pnlAEntregar.AllowDrop = true;
            this.pnlAEntregar.AutoScroll = true;
            this.pnlAEntregar.BackColor = System.Drawing.Color.Transparent;
            this.pnlAEntregar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAEntregar.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAEntregar.Location = new System.Drawing.Point(538, 44);
            this.pnlAEntregar.Name = "pnlAEntregar";
            this.pnlAEntregar.Size = new System.Drawing.Size(180, 457);
            this.pnlAEntregar.TabIndex = 9;
            this.pnlAEntregar.Tag = "4";
            this.pnlAEntregar.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragDrop);
            this.pnlAEntregar.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragOver);
            // 
            // pnlEmProducao
            // 
            this.pnlEmProducao.AllowDrop = true;
            this.pnlEmProducao.AutoScroll = true;
            this.pnlEmProducao.BackColor = System.Drawing.Color.Transparent;
            this.pnlEmProducao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEmProducao.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEmProducao.Location = new System.Drawing.Point(359, 44);
            this.pnlEmProducao.Name = "pnlEmProducao";
            this.pnlEmProducao.Size = new System.Drawing.Size(180, 457);
            this.pnlEmProducao.TabIndex = 8;
            this.pnlEmProducao.Tag = "3";
            this.pnlEmProducao.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragDrop);
            this.pnlEmProducao.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragOver);
            // 
            // pnlAGProducao
            // 
            this.pnlAGProducao.AllowDrop = true;
            this.pnlAGProducao.AutoScroll = true;
            this.pnlAGProducao.BackColor = System.Drawing.Color.Transparent;
            this.pnlAGProducao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAGProducao.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAGProducao.Location = new System.Drawing.Point(180, 44);
            this.pnlAGProducao.Name = "pnlAGProducao";
            this.pnlAGProducao.Size = new System.Drawing.Size(180, 457);
            this.pnlAGProducao.TabIndex = 7;
            this.pnlAGProducao.Tag = "2";
            this.pnlAGProducao.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragDrop);
            this.pnlAGProducao.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragOver);
            // 
            // pnlGravadaImpressa
            // 
            this.pnlGravadaImpressa.AllowDrop = true;
            this.pnlGravadaImpressa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlGravadaImpressa.AutoScroll = true;
            this.pnlGravadaImpressa.AutoScrollMinSize = new System.Drawing.Size(5, 0);
            this.pnlGravadaImpressa.BackColor = System.Drawing.Color.Transparent;
            this.pnlGravadaImpressa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGravadaImpressa.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGravadaImpressa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlGravadaImpressa.Location = new System.Drawing.Point(1, 44);
            this.pnlGravadaImpressa.Name = "pnlGravadaImpressa";
            this.pnlGravadaImpressa.Size = new System.Drawing.Size(180, 457);
            this.pnlGravadaImpressa.TabIndex = 6;
            this.pnlGravadaImpressa.Tag = "1";
            this.pnlGravadaImpressa.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragDrop);
            this.pnlGravadaImpressa.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlExecuteDragOver);
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.dgvFiltro);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(1078, 70);
            this.pnlFiltro.TabIndex = 0;
            // 
            // dgvFiltro
            // 
            this.dgvFiltro.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiltro.Location = new System.Drawing.Point(0, 0);
            this.dgvFiltro.Name = "dgvFiltro";
            this.dgvFiltro.Size = new System.Drawing.Size(1078, 70);
            this.dgvFiltro.TabIndex = 0;
            // 
            // frmProcAtualizaStatusPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1078, 572);
            this.Controls.Add(this.pnlDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmProcAtualizaStatusPedido";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Status do Pedido";
            this.Activated += new System.EventHandler(this.frmProcAtualizaStatusPedido_Activated);
            this.Load += new System.EventHandler(this.frmProcAtualizaStatusPedido_Load);
            this.Resize += new System.EventHandler(this.frmProcAtualizaStatusPedido_Resize);
            this.pnlDados.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlGravadasImpressas.ResumeLayout(false);
            this.pnlGravadasImpressas.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFiltro;
        protected System.Windows.Forms.DataGridView dgvFiltro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCountEntregue;
        private System.Windows.Forms.LinkLabel lblEntregue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblCountSaiuPEntrega;
        private System.Windows.Forms.LinkLabel lblSaiuPEntrega;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblCountAEntregar;
        private System.Windows.Forms.LinkLabel lblAEntregar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCountEmProducao;
        private System.Windows.Forms.LinkLabel lblEmProducao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCountAgProducao;
        private System.Windows.Forms.LinkLabel lblAgProducao;
        private System.Windows.Forms.Panel pnlGravadasImpressas;
        private System.Windows.Forms.Label lblCountGravadas;
        private System.Windows.Forms.LinkLabel lblGravadasImpressas;
        private System.Windows.Forms.Panel pnlEntregue;
        private System.Windows.Forms.Panel pnlSaiuPEntrega;
        private System.Windows.Forms.Panel pnlAEntregar;
        private System.Windows.Forms.Panel pnlEmProducao;
        private System.Windows.Forms.Panel pnlAGProducao;
        private System.Windows.Forms.Panel pnlGravadaImpressa;
        public System.Windows.Forms.Panel pnlDados;
    }
}
