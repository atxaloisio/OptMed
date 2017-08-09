namespace optmed
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuSistema = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransportadoras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVendedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadPedidoVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadRelClienteFormaPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadRelLocalidadeTransportadora = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadRelClienteTransportadora = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadRelVendedorLocalidade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadRelClienteVendedor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadTipoArmacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadTipoLente = new System.Windows.Forms.ToolStripMenuItem();
            this.processosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgrupamentoPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatusPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuParcelasPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotasDeEntregaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelPedidoVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trocarSenhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trocarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosDeSistemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controleAcessoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerfilUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPermissoesAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.janelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJanFecharTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTopicosAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSistema.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuSistema
            // 
            this.menuSistema.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSistema.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.processosToolStripMenuItem,
            this.relatoriosToolStripMenuItem,
            this.utilitáriosToolStripMenuItem,
            this.janelasToolStripMenuItem,
            this.mnuAjuda,
            this.sairToolStripMenuItem});
            this.menuSistema.Location = new System.Drawing.Point(0, 0);
            this.menuSistema.MdiWindowListItem = this.janelasToolStripMenuItem;
            this.menuSistema.Name = "menuSistema";
            this.menuSistema.Size = new System.Drawing.Size(723, 24);
            this.menuSistema.TabIndex = 1;
            this.menuSistema.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadCaixa,
            this.mnuCadClientes,
            this.mnuFornecedores,
            this.mnuTransportadoras,
            this.mnuProdutos,
            this.mnuVendedores,
            this.mnuCadPedidoVendas,
            this.produtoToolStripMenuItem,
            this.mnuCadTipoArmacao,
            this.mnuCadTipoLente});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.arquivoToolStripMenuItem.Tag = "1000";
            this.arquivoToolStripMenuItem.Text = "&Cadastros";
            // 
            // mnuCadCaixa
            // 
            this.mnuCadCaixa.Name = "mnuCadCaixa";
            this.mnuCadCaixa.Size = new System.Drawing.Size(172, 22);
            this.mnuCadCaixa.Tag = "1006";
            this.mnuCadCaixa.Text = "Caixa";
            this.mnuCadCaixa.Click += new System.EventHandler(this.mnuCadCaixa_Click);
            // 
            // mnuCadClientes
            // 
            this.mnuCadClientes.Name = "mnuCadClientes";
            this.mnuCadClientes.Size = new System.Drawing.Size(172, 22);
            this.mnuCadClientes.Tag = "1001";
            this.mnuCadClientes.Text = "&Clientes";
            this.mnuCadClientes.Visible = false;
            this.mnuCadClientes.Click += new System.EventHandler(this.mnuCadClientes_Click);
            // 
            // mnuFornecedores
            // 
            this.mnuFornecedores.Name = "mnuFornecedores";
            this.mnuFornecedores.Size = new System.Drawing.Size(172, 22);
            this.mnuFornecedores.Tag = "1010";
            this.mnuFornecedores.Text = "Fornecedores";
            this.mnuFornecedores.Click += new System.EventHandler(this.mnuFornecedores_Click);
            // 
            // mnuTransportadoras
            // 
            this.mnuTransportadoras.Name = "mnuTransportadoras";
            this.mnuTransportadoras.Size = new System.Drawing.Size(172, 22);
            this.mnuTransportadoras.Tag = "1011";
            this.mnuTransportadoras.Text = "Transportadoras";
            this.mnuTransportadoras.Click += new System.EventHandler(this.mnuTransportadoras_Click);
            // 
            // mnuProdutos
            // 
            this.mnuProdutos.Name = "mnuProdutos";
            this.mnuProdutos.Size = new System.Drawing.Size(172, 22);
            this.mnuProdutos.Tag = "1002";
            this.mnuProdutos.Text = "&Produtos";
            this.mnuProdutos.Visible = false;
            this.mnuProdutos.Click += new System.EventHandler(this.mnuProdutos_Click);
            // 
            // mnuVendedores
            // 
            this.mnuVendedores.Name = "mnuVendedores";
            this.mnuVendedores.Size = new System.Drawing.Size(172, 22);
            this.mnuVendedores.Tag = "1005";
            this.mnuVendedores.Text = "&Vendedores";
            this.mnuVendedores.Click += new System.EventHandler(this.mnuVendedores_Click);
            // 
            // mnuCadPedidoVendas
            // 
            this.mnuCadPedidoVendas.Name = "mnuCadPedidoVendas";
            this.mnuCadPedidoVendas.Size = new System.Drawing.Size(172, 22);
            this.mnuCadPedidoVendas.Tag = "1003";
            this.mnuCadPedidoVendas.Text = "Pedidos de &Vendas";
            this.mnuCadPedidoVendas.Click += new System.EventHandler(this.mnuCadPedidoVendas_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadRelClienteFormaPagamento,
            this.mnuCadRelLocalidadeTransportadora,
            this.mnuCadRelClienteTransportadora,
            this.mnuCadRelVendedorLocalidade,
            this.mnuCadRelClienteVendedor});
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.produtoToolStripMenuItem.Tag = "1004";
            this.produtoToolStripMenuItem.Text = "R&elacionamentos";
            // 
            // mnuCadRelClienteFormaPagamento
            // 
            this.mnuCadRelClienteFormaPagamento.Name = "mnuCadRelClienteFormaPagamento";
            this.mnuCadRelClienteFormaPagamento.Size = new System.Drawing.Size(236, 22);
            this.mnuCadRelClienteFormaPagamento.Tag = "10042";
            this.mnuCadRelClienteFormaPagamento.Text = "Cliente x &Forma de Pagamento";
            this.mnuCadRelClienteFormaPagamento.Click += new System.EventHandler(this.mnuCadRelClienteFormaPagamento_Click);
            // 
            // mnuCadRelLocalidadeTransportadora
            // 
            this.mnuCadRelLocalidadeTransportadora.Name = "mnuCadRelLocalidadeTransportadora";
            this.mnuCadRelLocalidadeTransportadora.Size = new System.Drawing.Size(236, 22);
            this.mnuCadRelLocalidadeTransportadora.Tag = "10043";
            this.mnuCadRelLocalidadeTransportadora.Text = "Transportadora x &Localidades";
            this.mnuCadRelLocalidadeTransportadora.Click += new System.EventHandler(this.mnuCadRelLocalidadeTransportadora_Click);
            // 
            // mnuCadRelClienteTransportadora
            // 
            this.mnuCadRelClienteTransportadora.Name = "mnuCadRelClienteTransportadora";
            this.mnuCadRelClienteTransportadora.Size = new System.Drawing.Size(236, 22);
            this.mnuCadRelClienteTransportadora.Tag = "10044";
            this.mnuCadRelClienteTransportadora.Text = "Cliente x &Transportadora";
            this.mnuCadRelClienteTransportadora.Click += new System.EventHandler(this.mnuCadRelClienteTransportadora_Click);
            // 
            // mnuCadRelVendedorLocalidade
            // 
            this.mnuCadRelVendedorLocalidade.Name = "mnuCadRelVendedorLocalidade";
            this.mnuCadRelVendedorLocalidade.Size = new System.Drawing.Size(236, 22);
            this.mnuCadRelVendedorLocalidade.Tag = "10045";
            this.mnuCadRelVendedorLocalidade.Text = "&Vendedor x Localidade";
            this.mnuCadRelVendedorLocalidade.Click += new System.EventHandler(this.mnuCadRelVendedorLocalidade_Click);
            // 
            // mnuCadRelClienteVendedor
            // 
            this.mnuCadRelClienteVendedor.Name = "mnuCadRelClienteVendedor";
            this.mnuCadRelClienteVendedor.Size = new System.Drawing.Size(236, 22);
            this.mnuCadRelClienteVendedor.Tag = "10046";
            this.mnuCadRelClienteVendedor.Text = "Cli&ente x Vendedor";
            this.mnuCadRelClienteVendedor.Click += new System.EventHandler(this.mnuCadRelClienteVendedor_Click);
            // 
            // mnuCadTipoArmacao
            // 
            this.mnuCadTipoArmacao.Name = "mnuCadTipoArmacao";
            this.mnuCadTipoArmacao.Size = new System.Drawing.Size(172, 22);
            this.mnuCadTipoArmacao.Tag = "1008";
            this.mnuCadTipoArmacao.Text = "Tipo de Armação";
            this.mnuCadTipoArmacao.Click += new System.EventHandler(this.mnuCadTipoArmacao_Click);
            // 
            // mnuCadTipoLente
            // 
            this.mnuCadTipoLente.Name = "mnuCadTipoLente";
            this.mnuCadTipoLente.Size = new System.Drawing.Size(172, 22);
            this.mnuCadTipoLente.Tag = "1009";
            this.mnuCadTipoLente.Text = "Tipo de Lente";
            this.mnuCadTipoLente.Click += new System.EventHandler(this.mnuCadTipoLente_Click);
            // 
            // processosToolStripMenuItem
            // 
            this.processosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgrupamentoPedido,
            this.mnuStatusPedido,
            this.mnuParcelasPedido});
            this.processosToolStripMenuItem.Name = "processosToolStripMenuItem";
            this.processosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.processosToolStripMenuItem.Tag = "2000";
            this.processosToolStripMenuItem.Text = "&Processos";
            // 
            // mnuAgrupamentoPedido
            // 
            this.mnuAgrupamentoPedido.Name = "mnuAgrupamentoPedido";
            this.mnuAgrupamentoPedido.Size = new System.Drawing.Size(230, 22);
            this.mnuAgrupamentoPedido.Tag = "2001";
            this.mnuAgrupamentoPedido.Text = "Agrupamento de Pedidos";
            this.mnuAgrupamentoPedido.Click += new System.EventHandler(this.mnuAgrupamentoPedido_Click);
            // 
            // mnuStatusPedido
            // 
            this.mnuStatusPedido.Name = "mnuStatusPedido";
            this.mnuStatusPedido.Size = new System.Drawing.Size(230, 22);
            this.mnuStatusPedido.Tag = "2002";
            this.mnuStatusPedido.Text = "Status do Pedido de Vendas";
            this.mnuStatusPedido.Click += new System.EventHandler(this.mnuStatusPedido_Click);
            // 
            // mnuParcelasPedido
            // 
            this.mnuParcelasPedido.Name = "mnuParcelasPedido";
            this.mnuParcelasPedido.Size = new System.Drawing.Size(230, 22);
            this.mnuParcelasPedido.Tag = "2003";
            this.mnuParcelasPedido.Text = "Parcelas do Pedido de Vendas";
            this.mnuParcelasPedido.Click += new System.EventHandler(this.mnuParcelasPedido_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotasDeEntregaToolStripMenuItem,
            this.mnuRelPedidoVendas});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatoriosToolStripMenuItem.Tag = "3000";
            this.relatoriosToolStripMenuItem.Text = "&Relatorios";
            // 
            // rotasDeEntregaToolStripMenuItem
            // 
            this.rotasDeEntregaToolStripMenuItem.Name = "rotasDeEntregaToolStripMenuItem";
            this.rotasDeEntregaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.rotasDeEntregaToolStripMenuItem.Tag = "3001";
            this.rotasDeEntregaToolStripMenuItem.Text = "Rotas de Entrega";
            this.rotasDeEntregaToolStripMenuItem.Click += new System.EventHandler(this.rotasDeEntregaToolStripMenuItem_Click);
            // 
            // mnuRelPedidoVendas
            // 
            this.mnuRelPedidoVendas.Name = "mnuRelPedidoVendas";
            this.mnuRelPedidoVendas.Size = new System.Drawing.Size(167, 22);
            this.mnuRelPedidoVendas.Text = "Pedido de Vendas";
            this.mnuRelPedidoVendas.Click += new System.EventHandler(this.mnuRelPedidoVendas_Click);
            // 
            // utilitáriosToolStripMenuItem
            // 
            this.utilitáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trocarSenhaToolStripMenuItem,
            this.trocarUsuárioToolStripMenuItem,
            this.parametrosDeSistemasToolStripMenuItem,
            this.controleAcessoToolStripMenuItem});
            this.utilitáriosToolStripMenuItem.Name = "utilitáriosToolStripMenuItem";
            this.utilitáriosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.utilitáriosToolStripMenuItem.Tag = "4000";
            this.utilitáriosToolStripMenuItem.Text = "&Utilitários";
            // 
            // trocarSenhaToolStripMenuItem
            // 
            this.trocarSenhaToolStripMenuItem.Name = "trocarSenhaToolStripMenuItem";
            this.trocarSenhaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.trocarSenhaToolStripMenuItem.Tag = "";
            this.trocarSenhaToolStripMenuItem.Text = "Trocar senha";
            this.trocarSenhaToolStripMenuItem.Click += new System.EventHandler(this.trocarSenhaToolStripMenuItem_Click);
            // 
            // trocarUsuárioToolStripMenuItem
            // 
            this.trocarUsuárioToolStripMenuItem.Name = "trocarUsuárioToolStripMenuItem";
            this.trocarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.trocarUsuárioToolStripMenuItem.Tag = "";
            this.trocarUsuárioToolStripMenuItem.Text = "Trocar usuário";
            this.trocarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.trocarUsuarioToolStripMenuItem_Click);
            // 
            // parametrosDeSistemasToolStripMenuItem
            // 
            this.parametrosDeSistemasToolStripMenuItem.Name = "parametrosDeSistemasToolStripMenuItem";
            this.parametrosDeSistemasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.parametrosDeSistemasToolStripMenuItem.Tag = "4001";
            this.parametrosDeSistemasToolStripMenuItem.Text = "Parâmetro de Sistema";
            this.parametrosDeSistemasToolStripMenuItem.Click += new System.EventHandler(this.parametrosDeSistemasToolStripMenuItem_Click);
            // 
            // controleAcessoToolStripMenuItem
            // 
            this.controleAcessoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadUsuario,
            this.mnuPerfilUsuarios,
            this.mnuPermissoesAcesso});
            this.controleAcessoToolStripMenuItem.Name = "controleAcessoToolStripMenuItem";
            this.controleAcessoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.controleAcessoToolStripMenuItem.Tag = "4002";
            this.controleAcessoToolStripMenuItem.Text = "&Controle de Acesso";
            // 
            // mnuCadUsuario
            // 
            this.mnuCadUsuario.Name = "mnuCadUsuario";
            this.mnuCadUsuario.Size = new System.Drawing.Size(189, 22);
            this.mnuCadUsuario.Tag = "40021";
            this.mnuCadUsuario.Text = "Usuários";
            this.mnuCadUsuario.Click += new System.EventHandler(this.mnuCadUsuario_Click);
            // 
            // mnuPerfilUsuarios
            // 
            this.mnuPerfilUsuarios.Name = "mnuPerfilUsuarios";
            this.mnuPerfilUsuarios.Size = new System.Drawing.Size(189, 22);
            this.mnuPerfilUsuarios.Tag = "40022";
            this.mnuPerfilUsuarios.Text = "Perfis de Usuários";
            this.mnuPerfilUsuarios.Click += new System.EventHandler(this.mnuPerfilUsuarios_Click);
            // 
            // mnuPermissoesAcesso
            // 
            this.mnuPermissoesAcesso.Name = "mnuPermissoesAcesso";
            this.mnuPermissoesAcesso.Size = new System.Drawing.Size(189, 22);
            this.mnuPermissoesAcesso.Tag = "40023";
            this.mnuPermissoesAcesso.Text = "Permissões de Acesso";
            this.mnuPermissoesAcesso.Click += new System.EventHandler(this.mnuPermissoesAcesso_Click);
            // 
            // janelasToolStripMenuItem
            // 
            this.janelasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJanFecharTodos});
            this.janelasToolStripMenuItem.Name = "janelasToolStripMenuItem";
            this.janelasToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.janelasToolStripMenuItem.Tag = "5000";
            this.janelasToolStripMenuItem.Text = "&Janelas";
            // 
            // mnuJanFecharTodos
            // 
            this.mnuJanFecharTodos.Name = "mnuJanFecharTodos";
            this.mnuJanFecharTodos.Size = new System.Drawing.Size(144, 22);
            this.mnuJanFecharTodos.Text = "Fechar Todos";
            this.mnuJanFecharTodos.Click += new System.EventHandler(this.mnuJanFecharTodos_Click);
            // 
            // mnuAjuda
            // 
            this.mnuAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTopicosAjuda,
            this.mnuRegistro,
            this.toolStripMenuItem2,
            this.mnuSobre});
            this.mnuAjuda.Name = "mnuAjuda";
            this.mnuAjuda.Size = new System.Drawing.Size(50, 20);
            this.mnuAjuda.Tag = "6000";
            this.mnuAjuda.Text = "&Ajuda";
            // 
            // mnuTopicosAjuda
            // 
            this.mnuTopicosAjuda.Name = "mnuTopicosAjuda";
            this.mnuTopicosAjuda.Size = new System.Drawing.Size(176, 22);
            this.mnuTopicosAjuda.Text = "Tópicos da Ajuda ";
            this.mnuTopicosAjuda.Visible = false;
            this.mnuTopicosAjuda.Click += new System.EventHandler(this.mnuTopicosAjuda_Click);
            // 
            // mnuRegistro
            // 
            this.mnuRegistro.Name = "mnuRegistro";
            this.mnuRegistro.Size = new System.Drawing.Size(176, 22);
            this.mnuRegistro.Text = "Registro de Licença";
            this.mnuRegistro.Click += new System.EventHandler(this.mnuRegistro_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuSobre
            // 
            this.mnuSobre.Name = "mnuSobre";
            this.mnuSobre.Size = new System.Drawing.Size(176, 22);
            this.mnuSobre.Text = "Sobre";
            this.mnuSobre.Click += new System.EventHandler(this.mnuSobre_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(723, 413);
            this.Controls.Add(this.menuSistema);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuSistema;
            this.Name = "frmPrincipal";
            this.Text = "Optima";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuSistema.ResumeLayout(false);
            this.menuSistema.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuSistema;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCadPedidoVendas;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCadRelClienteFormaPagamento;
        private System.Windows.Forms.ToolStripMenuItem mnuCadRelLocalidadeTransportadora;
        private System.Windows.Forms.ToolStripMenuItem mnuCadRelClienteTransportadora;
        private System.Windows.Forms.ToolStripMenuItem processosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAgrupamentoPedido;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotasDeEntregaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosDeSistemasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCadClientes;
        private System.Windows.Forms.ToolStripMenuItem janelasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAjuda;
        private System.Windows.Forms.ToolStripMenuItem mnuJanFecharTodos;
        private System.Windows.Forms.ToolStripMenuItem mnuProdutos;
        private System.Windows.Forms.ToolStripMenuItem controleAcessoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCadUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnuPerfilUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuPermissoesAcesso;
        private System.Windows.Forms.ToolStripMenuItem trocarSenhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trocarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuStatusPedido;
        private System.Windows.Forms.ToolStripMenuItem mnuVendedores;
        private System.Windows.Forms.ToolStripMenuItem mnuCadRelVendedorLocalidade;
        private System.Windows.Forms.ToolStripMenuItem mnuCadRelClienteVendedor;
        private System.Windows.Forms.ToolStripMenuItem mnuCadCaixa;
        private System.Windows.Forms.ToolStripMenuItem mnuParcelasPedido;
        private System.Windows.Forms.ToolStripMenuItem mnuCadTipoArmacao;
        private System.Windows.Forms.ToolStripMenuItem mnuCadTipoLente;
        private System.Windows.Forms.ToolStripMenuItem mnuRelPedidoVendas;
        private System.Windows.Forms.ToolStripMenuItem mnuFornecedores;
        private System.Windows.Forms.ToolStripMenuItem mnuTransportadoras;
        private System.Windows.Forms.ToolStripMenuItem mnuTopicosAjuda;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuSobre;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistro;
    }
}