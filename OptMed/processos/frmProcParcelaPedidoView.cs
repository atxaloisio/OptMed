using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;
using System.Globalization;
using Utils;

namespace optmed
{
    public partial class frmProcParcelaPedidoView : optmed.frmBaseCadEdit
    {
        private ClienteBLL clienteBLL;        
        private ParcelaBLL parcelaBLL;
        private Motivo_EntregaBLL motivo_EntregaBLL;
        private Pedido_OticaBLL pedido_OticaBLL;
        private VendedorBLL vendedorBLL;
        private Vendedor_LocalidadeBLL vendedor_LocalidadeBLL;
        private CaixaBLL caixaBLL;
        private Pedido_Otica_ParcelasBLL ParcelasBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID = 0;
        private const int COL_IDPEDIDO = 1;
        private const int COL_NUMEROPARCELA = 2;
        private const int COL_DATAVENCIMENTO = 3;
        private const int COL_VALOR = 4;
        private const int COL_PERCENTUAL = 5;        
        private const int COL_PAGO = 6;        
        private const int COL_DATAPAGAMENTO = 7;
        private const int COL_FORMAPAGAMENTO = 8;
        private const int COL_USUARIOPAGAMENTO = 9;
        private const int COL_EDITADO = 10;
        private const int COL_NRDIAS = 11;

        #endregion
        public frmProcParcelaPedidoView()
        {
            InitializeComponent();
            LoadViews();
        }

        private void LoadViews()
        {
            bool ViewOtica = Convert.ToBoolean(Parametro.GetParametro("layoutOtica"));
            bool ViewLaboratorio = Convert.ToBoolean(Parametro.GetParametro("layoutLaboratorio"));

            //Setup dos controles especificos da Ótica.
            #region Visão Otica
            if (ViewOtica)
            {
                lblPrevEntrega.Left = 550;
                txtDtPrevEntrega.Left = 647;
                txtHrPrevEntrega.Left = 735;

                lblNomeMedico.Visible = true;                
                txtNomeMedico.Enabled = false;
                txtNomeMedico.Visible = true;
                txtNomeMedico.TabIndex = 9;
                txtNomeMedico.TabStop = true;
                
                lblCRM.Visible = true;
                txtCRM.Enabled = false;
                txtCRM.Visible = true;
                txtCRM.TabIndex = 10;
                txtCRM.TabStop = true;

                lblLaboratorio.Visible = true;
                txtLaboratorio.Enabled = false;
                txtLaboratorio.Visible = true;
                txtLaboratorio.TabIndex = 12;
                txtLaboratorio.TabStop = true;

            }
            else
            {
                lblNomeMedico.Visible = false;
                txtNomeMedico.Enabled = false;
                txtNomeMedico.Visible = false;
                txtNomeMedico.TabIndex = 57;
                txtNomeMedico.TabStop = false;

                lblCRM.Visible = false;
                txtCRM.Enabled = false;
                txtCRM.Visible = false;
                txtCRM.TabIndex = 60;
                txtCRM.TabStop = false;

                lblLaboratorio.Visible = false;
                txtLaboratorio.Enabled = false;
                txtLaboratorio.Visible = false;
                txtLaboratorio.TabIndex = 61;
                txtLaboratorio.TabStop = false;
            }
            #endregion

            //Setup dos controles especificos do laboratório.
            #region Visão Laboratorio
            if (ViewLaboratorio)
            {
                lblDtFechamento.Enabled = true;
                lblDtFechamento.Visible = true;
                txtDtFechamento.Enabled = false;
                txtDtFechamento.Visible = true;
                txtDtFechamento.TabIndex = 5;
                txtDtFechamento.TabStop = true;
                
                lblPrevEntrega.Left = 753;
                txtDtPrevEntrega.Left = 854;
                txtHrPrevEntrega.Left = 942;

                lblMotivoEntrega.Enabled = true;
                lblMotivoEntrega.Visible = true;
                cbMotivoEntrega.Enabled = false;
                cbMotivoEntrega.Visible = true;
                cbMotivoEntrega.TabStop = true;

                lblTransportadora.Enabled = true;
                lblTransportadora.Visible = true;
                cbTransportadora.Enabled = false;
                cbTransportadora.Visible = true;
                cbTransportadora.TabStop = true;

                lblNrPedCliente.Enabled = true;
                lblNrPedCliente.Visible = true;
                txtNrPedCliente.Enabled = false;
                txtNrPedCliente.Visible = true;
                txtNrPedCliente.TabStop = true;

                lblNrCaixa.Enabled = true;
                lblNrCaixa.Visible = true;
                cbCaixa.Enabled = false;
                cbCaixa.Visible = true;
                cbCaixa.TabStop = true;
            }
            else
            {
                lblDtFechamento.Enabled = false;
                lblDtFechamento.Visible = false;
                txtDtFechamento.Enabled = false;
                txtDtFechamento.Visible = false;
                txtDtFechamento.TabIndex = 5;
                txtDtFechamento.TabStop = false;

                lblMotivoEntrega.Enabled = false;
                lblMotivoEntrega.Visible = false;
                cbMotivoEntrega.Enabled = false;
                cbMotivoEntrega.Visible = false;
                cbMotivoEntrega.TabStop = false;

                lblTransportadora.Enabled = false;
                lblTransportadora.Visible = false;
                cbTransportadora.Enabled = false;
                cbTransportadora.Visible = false;
                cbTransportadora.TabStop = false;

                lblNrPedCliente.Enabled = false;
                lblNrPedCliente.Visible = false;
                txtNrPedCliente.Enabled = false;
                txtNrPedCliente.Visible = false;
                txtNrPedCliente.TabStop = false;

                lblNrCaixa.Enabled = false;
                lblNrCaixa.Visible = false;
                cbCaixa.Enabled = false;
                cbCaixa.Visible = false;
                cbCaixa.TabStop = false;
            }
            #endregion
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {
                pedido_OticaBLL = new Pedido_OticaBLL();

                bool ViewOtica = Convert.ToBoolean(Parametro.GetParametro("layoutOtica"));
                bool ViewLaboratorio = Convert.ToBoolean(Parametro.GetParametro("layoutLaboratorio"));

                Pedido_Otica pedido_otica = pedido_OticaBLL.Localizar(Id);
                if (pedido_otica != null)
                {
                    txtId.Text = pedido_otica.Id.ToString();
                    txtIdCliente.Text = pedido_otica.Id_cliente.ToString();
                    txtCodigo.Text = pedido_otica.codigo.ToString();
                    txtCodCliIntegracao.Text = pedido_otica.cliente.codigo_cliente_integracao;
                    txtClienteNome.Text = pedido_otica.cliente.nome_fantasia;
                    txtDtEmissao.Text = pedido_otica.data_emissao.Value.ToShortDateString();

                    if (ViewLaboratorio)
                    {
                        if (pedido_otica.data_fechamento != null)
                        {
                            txtDtFechamento.Text = pedido_otica.data_fechamento.Value.ToShortDateString();
                        }

                        if (pedido_otica.Id_transportadora != null)
                        {
                            cbTransportadora.SelectedValue = pedido_otica.Id_transportadora;
                        }

                        txtNrPedCliente.Text = pedido_otica.numero_pedido_cliente;

                        if (pedido_otica.Id_caixa != null)
                        {
                            cbCaixa.SelectedValue = pedido_otica.Id_caixa;
                        }

                        if (pedido_otica.motivo_entrega != null)
                        {
                            cbMotivoEntrega.SelectedValue = pedido_otica.motivo_entrega.Id;
                        }
                    }
                    
                    
                    if (pedido_otica.date_previsao_entrega != null)
                    {
                        txtDtPrevEntrega.Text = pedido_otica.date_previsao_entrega.Value.ToShortDateString();
                    }

                    if (pedido_otica.hora_previsao_entrega != null)
                    {
                        txtHrPrevEntrega.Text = pedido_otica.hora_previsao_entrega;
                    }

                    if (pedido_otica.condicao_pagamento != null)
                    {
                        cbCondPagamento.SelectedValue = pedido_otica.condicao_pagamento;
                    }
                                                          
                    if (pedido_otica.vendedor != null)
                    {
                        cbVendedor.SelectedValue = pedido_otica.Id_vendedor;
                    }

                    if (ViewOtica)
                    {
                        if (pedido_otica.pedido_otica_infoadic.Count > 0)
                        {
                            Pedido_Otica_InfoAdic infoadic = pedido_otica.pedido_otica_infoadic.FirstOrDefault();
                            txtIdPedInfoadic.Text = infoadic.Id.ToString();
                            txtNomeMedico.Text = infoadic.nome_medico;
                            if (infoadic.crm_medico != null)
                            {
                                txtCRM.Text = infoadic.crm_medico.ToString();
                            }
                            txtLaboratorio.Text = infoadic.laboratorio;
                        }                        
                    }

                    if (pedido_otica.pedido_otica_parcelas.Count() > 0)
                    {
                        ParcelasBLL = new Pedido_Otica_ParcelasBLL();
                        dgvParcelas.DataSource = ParcelasBLL.ToList_Pedido_OticaParcelaView(pedido_otica.pedido_otica_parcelas);
                        formataGridParcelas();
                        loadCamposParcela();
                    }

                    if (pedido_otica.cancelado == "S")
                    {
                        lblPedidoCancelado.Visible = true;

                        foreach (Control item in pnlPrincipal.Controls)
                        {
                            item.Enabled = false;
                            btnSalvar.Enabled = false;
                            btnIncluir.Enabled = false;
                        }

                        lblPedidoCancelado.Enabled = true;
                    }

                }
            }
        }

        private void loadCamposParcela()
        {
            int row = dgvParcelas.SelectedRows[0].Index;

            txtIdParcela.Text = dgvParcelas[COL_ID, row].Value.ToString();
            txtIdPedido.Text = dgvParcelas[COL_IDPEDIDO, row].Value.ToString();
            txtNrDias.Text = dgvParcelas[COL_NRDIAS, row].Value.ToString();
            lblParcela.Text = "Parcela " + dgvParcelas[COL_NUMEROPARCELA, row].Value.ToString() + " de " + (dgvParcelas.RowCount);
            txtDtVencimento.Text = dgvParcelas[COL_DATAVENCIMENTO, row].Value.ToString();
            txtValor.Text = dgvParcelas[COL_VALOR, row].Value.ToString();
            txtPercentual.Text = Convert.ToDecimal(dgvParcelas[COL_PERCENTUAL, row].Value.ToString()).ToString("N2");
            chkPago.Checked = Convert.ToBoolean(dgvParcelas[COL_PAGO, row].Value);

            txtDtPagamento.Text = string.Empty;
            if (dgvParcelas[COL_DATAPAGAMENTO, row].Value != null)
            {
                txtDtPagamento.Text = dgvParcelas[COL_DATAPAGAMENTO, row].Value.ToString();
            }

            cbFormaPagamento.SelectedIndex = -1;
            if (dgvParcelas[COL_FORMAPAGAMENTO, row].Value != null)
            {
                cbFormaPagamento.Text = dgvParcelas[COL_FORMAPAGAMENTO, row].Value.ToString();
            }
            
        }

        protected override void Incluir()
        {
            if (dgvParcelas.SelectedRows.Count > 0)
            {
                int row = dgvParcelas.SelectedRows[0].Index;
                long IdParcela = Convert.ToInt64(dgvParcelas[COL_ID, row].Value);
                bool pago = Convert.ToBoolean(dgvParcelas[COL_PAGO, row].Value);
                if (pago)
                {
                    ImprimirRegistro(IdParcela);
                }
                
            }
            
        }

        protected override void ImprimirRegistro(Int64? id)
        {
            frmRelReciboParcela relatorio = new frmRelReciboParcela();
            try
            {
                relatorio.rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relReciboParcela.rdlc";
                relatorio.ExibeDialogo(this, id);
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                relatorio.Dispose();
            }                        
        }

        protected override void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (ValidaAcessoFuncao(Operacao.Salvar))
                {
                    if (salvar(sender, e))
                    {
                        this.atualizagrid();                        
                        MessageBox.Show(Text + " salvo com sucesso.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool salvar(object sender, EventArgs e)
        {
            bool Retorno = true;
            
            if (Retorno)
            {
                try
                {
                    ParcelasBLL = new Pedido_Otica_ParcelasBLL();
                    ParcelasBLL.UsuarioLogado = Program.usuario_logado;

                    List<Pedido_Otica_Parcelas> ParcelasList = toPedido_Otica_Parcelas(LoadFromGridParcela());

                    foreach (Pedido_Otica_Parcelas item in ParcelasList)
                    {
                        ParcelasBLL.AlterarPedido_Otica_Parcelas(item);
                    }
                                     
                    Retorno = true;
                }
                catch (Exception ex)
                {
                    Retorno = false;
                    throw ex;
                }
            }
            return Retorno;
        }

        private List<Pedido_Otica_Parcelas> toPedido_Otica_Parcelas(List<ParcelaView> ParcelaViewList)
        {
            List<Pedido_Otica_Parcelas> ParcelasList = new List<Pedido_Otica_Parcelas>();
            foreach (ParcelaView item in ParcelaViewList)
            {
                Pedido_Otica_Parcelas p = new Pedido_Otica_Parcelas();
                p.Id = Convert.ToInt64(item.Id);
                p.Id_pedido_otica = Convert.ToInt64(item.Id_Pedido_Otica);
                p.numero_parcela = item.NrParcela;
                p.pago = item.Pago?"S":"N";
                p.quantidade_dias = item.NrDias;
                p.percentual = item.Percentual;
                p.valor = item.Valor;
                p.usuario_pagamento = item.Usuario;
                p.data_vencimento = item.DtVencimento;
                p.data_pagamento = item.DtPagamento;
                p.forma_pagamento = item.FormaPagamento;
                ParcelasList.Add(p);                           
            }
            return ParcelasList;
        }
                
        protected override void SetupControls()
        {
            SetupCondPagamento();
            SetupCaixa();
            SetupTransportadora();
            SetupVendedor();
            SetupMotivoEntrega();
            setupFormaPagamento();       
        }

        private void setupFormaPagamento()
        {
            TipoPagamento tp = new TipoPagamento();

            cbFormaPagamento.DataSource = Enumerados.getListEnum(tp);
            cbFormaPagamento.ValueMember = "chave";
            cbFormaPagamento.DisplayMember = "descricao";
            cbFormaPagamento.SelectedIndex = -1;
        }

        private void formataGridParcelas()
        {
            dgvParcelas.AutoGenerateColumns = false;
            dgvParcelas.ColumnHeadersVisible = true;
            dgvParcelas.RowHeadersVisible = false;
            dgvParcelas.ReadOnly = true;
            dgvParcelas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvParcelas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //altera a cor das linhas alternadas no grid
            dgvParcelas.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvParcelas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            formataColunadgvParcelas();
            //seleciona a linha inteira
            dgvParcelas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //não permite seleção de multiplas linhas
            dgvParcelas.MultiSelect = false;
            // exibe nulos formatados
            dgvParcelas.DefaultCellStyle.NullValue = " - ";
            //permite que o texto maior que célula não seja truncado
            dgvParcelas.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvParcelas.DefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Regular);            
        }

        private void formataColunadgvParcelas()
        {
            //altera o nome das colunas                        
            
                        
            dgvParcelas.Columns[COL_ID].Width = 70;
            dgvParcelas.Columns[COL_ID].ValueType = typeof(int);
            dgvParcelas.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_ID].Visible = false;
            dgvParcelas.Columns[COL_ID].HeaderText = "Codigo";

            dgvParcelas.Columns[COL_IDPEDIDO].Width = 100;
            dgvParcelas.Columns[COL_IDPEDIDO].ValueType = typeof(int);
            dgvParcelas.Columns[COL_IDPEDIDO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_IDPEDIDO].Visible = false;
            dgvParcelas.Columns[COL_IDPEDIDO].HeaderText = "Pedido";

            dgvParcelas.Columns[COL_NUMEROPARCELA].Width = 100;
            dgvParcelas.Columns[COL_NUMEROPARCELA].ValueType = typeof(int);
            dgvParcelas.Columns[COL_NUMEROPARCELA].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_NUMEROPARCELA].HeaderText = "Parcela";

            dgvParcelas.Columns[COL_DATAVENCIMENTO].Width = 150;
            dgvParcelas.Columns[COL_DATAVENCIMENTO].ValueType = typeof(string);
            dgvParcelas.Columns[COL_DATAVENCIMENTO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_DATAVENCIMENTO].HeaderText = "Dt. Vencimento";

            dgvParcelas.Columns[COL_VALOR].Width = 100;
            dgvParcelas.Columns[COL_VALOR].ValueType = typeof(decimal);
            dgvParcelas.Columns[COL_VALOR].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_VALOR].DefaultCellStyle.Format = "N2";
            dgvParcelas.Columns[COL_VALOR].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvParcelas.Columns[COL_VALOR].HeaderText = "Valor";

            dgvParcelas.Columns[COL_PERCENTUAL].Width = 100;
            dgvParcelas.Columns[COL_PERCENTUAL].ValueType = typeof(decimal);
            dgvParcelas.Columns[COL_PERCENTUAL].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_PERCENTUAL].DefaultCellStyle.Format = "N2";
            dgvParcelas.Columns[COL_PERCENTUAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvParcelas.Columns[COL_PERCENTUAL].HeaderText = "Percentual";

            dgvParcelas.Columns[COL_PAGO].Width = 60;
            dgvParcelas.Columns[COL_PAGO].ValueType = typeof(Boolean);
            dgvParcelas.Columns[COL_PAGO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_PAGO].HeaderText = "Pago";

            dgvParcelas.Columns[COL_DATAPAGAMENTO].Width = 150;
            dgvParcelas.Columns[COL_DATAPAGAMENTO].ValueType = typeof(DateTime);
            dgvParcelas.Columns[COL_DATAPAGAMENTO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_DATAPAGAMENTO].HeaderText = "Dt. Pagamento";

            dgvParcelas.Columns[COL_FORMAPAGAMENTO].Width = 200;
            dgvParcelas.Columns[COL_FORMAPAGAMENTO].ValueType = typeof(String);
            dgvParcelas.Columns[COL_FORMAPAGAMENTO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_FORMAPAGAMENTO].HeaderText = "Forma de Pagamento";
            dgvParcelas.Columns[COL_FORMAPAGAMENTO].Visible = true;

            dgvParcelas.Columns[COL_USUARIOPAGAMENTO].Width = 200;
            dgvParcelas.Columns[COL_USUARIOPAGAMENTO].ValueType = typeof(String);
            dgvParcelas.Columns[COL_USUARIOPAGAMENTO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_USUARIOPAGAMENTO].HeaderText = "Usuário";
            dgvParcelas.Columns[COL_USUARIOPAGAMENTO].Visible = true;

            dgvParcelas.Columns[COL_EDITADO].Width = 60;
            dgvParcelas.Columns[COL_EDITADO].ValueType = typeof(Boolean);
            dgvParcelas.Columns[COL_EDITADO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_EDITADO].HeaderText = "Editado";
            dgvParcelas.Columns[COL_EDITADO].Visible = false;

            dgvParcelas.Columns[COL_NRDIAS].Width = 100;
            dgvParcelas.Columns[COL_NRDIAS].ValueType = typeof(int);
            dgvParcelas.Columns[COL_NRDIAS].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcelas.Columns[COL_NRDIAS].Visible = false;


        }

        private void SetupCaixa()
        {
            caixaBLL = new CaixaBLL();
            
            List<Caixa> CaixaList = caixaBLL.getCaixa();

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (Caixa item in CaixaList)
            {
                acc.Add(item.numero);
            }

            cbCaixa.DataSource = CaixaList;
            cbCaixa.AutoCompleteCustomSource = acc;
            cbCaixa.ValueMember = "Id";
            cbCaixa.DisplayMember = "numero";
            cbCaixa.SelectedIndex = -1;
        }

        private void SetupVendedor()
        {
            vendedorBLL = new VendedorBLL();
            List<Vendedor> VendedorList = vendedorBLL.getVendedor();

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (Vendedor item in VendedorList)
            {
                acc.Add(item.nome);
            }

            cbVendedor.DataSource = VendedorList;
            cbVendedor.AutoCompleteCustomSource = acc;
            cbVendedor.ValueMember = "Id";
            cbVendedor.DisplayMember = "nome";
            cbVendedor.SelectedIndex = -1;
        }
        
        private void SetupMotivoEntrega()
        {
            motivo_EntregaBLL = new Motivo_EntregaBLL();
            cbMotivoEntrega.DataSource = motivo_EntregaBLL.getMotivo_Entrega();
            cbMotivoEntrega.ValueMember = "Id";
            cbMotivoEntrega.DisplayMember = "Descricao";
            cbMotivoEntrega.SelectedIndex = -1;
        }

        private void SetupTransportadora()
        {
            clienteBLL = new ClienteBLL();
            List<Cliente> ClienteList = clienteBLL.getCliente(x => x.cliente_tag.Any(e => e.tag == "Transportadora"));

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (Cliente item in ClienteList)
            {
                acc.Add(item.nome_fantasia);
            }
            cbTransportadora.DataSource = ClienteList;
            cbTransportadora.AutoCompleteCustomSource = acc;
            cbTransportadora.ValueMember = "Id";
            cbTransportadora.DisplayMember = "nome_fantasia";
            cbTransportadora.SelectedIndex = -1;
        }

        private void SetupCondPagamento()
        {
            parcelaBLL = new ParcelaBLL();
            cbCondPagamento.DataSource = parcelaBLL.getParcela();
            cbCondPagamento.ValueMember = "Id";
            cbCondPagamento.DisplayMember = "Descricao";
            cbCondPagamento.SelectedIndex = -1;
        }
                        
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaCliente();
        }

        private void ExecutaPesquisaCliente()
        {
            frmPesquisaClientes pesquisa = new frmPesquisaClientes();
            if (pesquisa.ExibeDialogo(txtCodCliIntegracao.Text) == DialogResult.OK)
            {
                if (pesquisa.Id != null)
                {
                    clienteBLL = new ClienteBLL();
                    Cliente cliente = clienteBLL.Localizar(pesquisa.Id);
                    if (cliente != null)
                    {
                        txtCodCliIntegracao.Text = cliente.codigo_cliente_integracao;
                        txtClienteNome.Text = cliente.nome_fantasia;
                        txtIdCliente.Text = cliente.Id.ToString();

                        Cliente_Parcela cliente_Parcela = cliente.cliente_parcela.FirstOrDefault();
                        if (cliente_Parcela != null)
                        {
                            cbCondPagamento.SelectedValue = cliente_Parcela.Id_parcela;
                        }
                        if (Id == null)
                        {
                            txtDtEmissao.Text = DateTime.Now.ToShortDateString();
                        }

                        if (cliente.cliente_transportadora.Count() > 0)
                        {
                            Cliente_Transportadora cliente_Transportadora = cliente.cliente_transportadora.First();
                            if (cliente_Transportadora != null)
                            {
                                cbTransportadora.SelectedValue = cliente_Transportadora.Id_transportadora;
                            }
                        }
                        else
                        {
                            //Vamos sugerir a transportadora pela localidade do cliente.
                            RotaBLL rotaBLL = new RotaBLL();
                            IList<Rota> RotaList = rotaBLL.getRota(p => p.cidade.cCod == cliente.cidade);
                            if (RotaList.Count > 0)
                            {
                                cbTransportadora.SelectedValue = RotaList.First().id_transportadora;
                            }
                        }

                        if (cliente.cliente_vendedor.Count() > 0)
                        {
                            Cliente_Vendedor cliente_Vendedor = cliente.cliente_vendedor.First();
                            if (cliente_Vendedor != null)
                            {
                                cbVendedor.SelectedValue = cliente_Vendedor.Id_Vendedor;
                            }
                        }
                        else
                        {
                            //Vamos sugerir a transportadora pela localidade do cliente.
                            vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();
                            IList<Vendedor_Localidade> vendlocList = vendedor_LocalidadeBLL.getVendedor_Localidade(p => p.cidade.cCod == cliente.cidade);

                            if (vendlocList.Count > 0)
                            {
                                cbVendedor.SelectedValue = vendlocList.First().Id_vendedor;
                            }
                        }


                        txtDtFechamento.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Cliente não localizado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodCliIntegracao.Text = String.Empty;
                }
            }
            else
            {
                txtCodCliIntegracao.Focus();
            }
        }

        private void LoadDadosCliente(long? id = null, string CodInteg = "")
        {
            clienteBLL = new ClienteBLL();
            Cliente cliente = new Cliente();

            if (id != null)
            {
                cliente = clienteBLL.Localizar(id);
            }
            else if (!string.IsNullOrEmpty(CodInteg))
            {
                if (CodInteg.Where(c => char.IsNumber(c)).Count() >= 11)
                {
                    string strCPF, strCNPJ = string.Empty;
                    strCPF = Convert.ToInt64(CodInteg).ToString(@"000\.000\.000\-00");
                    strCNPJ = Convert.ToInt64(CodInteg).ToString(@"00\.000\.000\/0000\-00");
                    cliente = clienteBLL.getCliente(p => p.cnpj_cpf == strCPF || p.cnpj_cpf == strCNPJ).FirstOrDefault();
                }
                else if ((CodInteg.Where(c => char.IsNumber(c)).Count() > 0) && (CodInteg.Where(c => char.IsNumber(c)).Count() < 11))
                {
                    cliente = clienteBLL.getCliente(p => p.codigo_cliente_integracao == CodInteg).FirstOrDefault();
                }
            }

            if (cliente != null)
            {
                txtIdCliente.Text = cliente.Id.ToString();
                txtCodCliIntegracao.Text = cliente.codigo_cliente_integracao;
                txtClienteNome.Text = cliente.nome_fantasia;
                if (cliente.cliente_parcela.Count() > 0)
                {
                    cbCondPagamento.SelectedValue = cliente.cliente_parcela.FirstOrDefault().Id_parcela;
                }

                if (Id == null)
                {
                    txtDtEmissao.Text = DateTime.Now.ToShortDateString();
                }

                if (cliente.cliente_transportadora.Count() > 0)
                {
                    Cliente_Transportadora cliente_Transportadora = cliente.cliente_transportadora.First();
                    if (cliente_Transportadora != null)
                    {
                        cbTransportadora.SelectedValue = cliente_Transportadora.Id_transportadora;
                    }
                    else
                    {
                        //Vamos sugerir a transportadora pela localidade do cliente.
                        RotaBLL rotaBLL = new RotaBLL();
                        Rota rota = rotaBLL.getRota(p => p.cidade.cNome == cliente.cidade).First();
                        if (rota != null)
                        {
                            cbTransportadora.SelectedValue = rota.id_transportadora;
                        }
                    }
                }


                txtDtFechamento.Focus();
            }


        }

        private void txtDtEmissao_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodCliIntegracao_TextChanged(object sender, EventArgs e)
        {
            txtClienteNome.Text = string.Empty;
            txtIdCliente.Text = string.Empty;
        }

        private void txtCodCliIntegracao_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodCliIntegracao.Text))
            {
                if (txtCodCliIntegracao.Text.Where(c => char.IsNumber(c)).Count() > 0)
                {
                    LoadDadosCliente(null, txtCodCliIntegracao.Text);
                    if (string.IsNullOrEmpty(txtClienteNome.Text))
                    {
                        ExecutaPesquisaCliente();
                    }
                }
                else
                {
                    ExecutaPesquisaCliente();
                }
            }
        }

        private void Ctrls_Validated(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                epValidaDados.SetError((TextBox)sender, string.Empty);
                if (((TextBox)sender).Name == "txtCodCliIntegracao")
                {
                    epValidaDados.SetError(txtClienteNome, string.Empty);
                    epValidaDados.SetError(txtDtEmissao, string.Empty);
                }
            }
            else if (sender is MaskedTextBox)
            {
                epValidaDados.SetError((MaskedTextBox)sender, string.Empty);
            }
            else if (sender is ComboBox)
            {
                epValidaDados.SetError((ComboBox)sender, string.Empty);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
                
        private void onlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsNumber(e.KeyChar)) & (e.KeyChar != 8) & (!e.KeyChar.Equals(',')))
            {
                e.Handled = true;
            }
        }

        private void EsfCil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) &&
                !e.KeyChar.Equals('.') &&
                !e.KeyChar.Equals('+') &&
                !e.KeyChar.Equals('-') &&
                !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
                                             
        private void Ctrls_Validating(object sender, CancelEventArgs e)
        {
            if (sender is MaskedTextBox)
            {
                if ((((MaskedTextBox)sender).Name == txtDtEmissao.Name)
                    || (((MaskedTextBox)sender).Name == txtDtFechamento.Name)
                    || (((MaskedTextBox)sender).Name == txtDtPrevEntrega.Name))
                {
                    if (!string.IsNullOrEmpty(((MaskedTextBox)sender).Text))
                    {
                        ((MaskedTextBox)sender).TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        if (!ValidateUtils.isDate(((MaskedTextBox)sender).Text))
                        {
                            MessageBox.Show("Data inválida.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ((MaskedTextBox)sender).Text = string.Empty;
                            e.Cancel = true;
                        }
                        ((MaskedTextBox)sender).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                }
            }
        }

        private void btnPesquisa_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodCliIntegracao.Text))
            {
                Ctrls_Validated(txtCodCliIntegracao, e);
            }
        }
                        
        private void cbCaixa_Validating(object sender, CancelEventArgs e)
        {
            cb_Validating(sender, e);
            if (!e.Cancel)
            {
                if (cbCaixa.SelectedValue != null)
                {
                    caixaBLL = new CaixaBLL();
                    int id_caixa = Convert.ToInt32(cbCaixa.SelectedValue);
                    int status = (int)StatusPedido.ENTREGUE;
                    List<Caixa> CaixaList = caixaBLL.getCaixa(p => p.Id == id_caixa & p.pedido_otica.Any(c => c.status < status));
                    if (CaixaList.Count > 0)
                    {
                        if (Id != null)
                        {
                            if (Id != CaixaList.FirstOrDefault().pedido_otica.Where(t => t.status < status).FirstOrDefault().Id)
                            {
                                MessageBox.Show("Caixa selecionada está em uso no pedido : " + CaixaList.FirstOrDefault().pedido_otica.Where(t => t.status < status).FirstOrDefault().codigo, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                epValidaDados.SetError(cbCaixa, "Caixa selecionada está em uso no pedido: " + CaixaList.FirstOrDefault().pedido_otica.Where(t => t.status < status).FirstOrDefault().codigo);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Caixa selecionada está em uso no pedido : " + CaixaList.FirstOrDefault().pedido_otica.Where(t => t.status < status).FirstOrDefault().codigo, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            epValidaDados.SetError(cbCaixa, "Caixa selecionada está em uso no pedido: " + CaixaList.FirstOrDefault().pedido_otica.Where(t => t.status < status).FirstOrDefault().codigo);
                            e.Cancel = true;
                        }
                        
                    }
                }
            }            
        }

        private void cbCaixa_Validated(object sender, EventArgs e)
        {
            epValidaDados.SetError(cbCaixa, string.Empty);
        }

        private void cb_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (!string.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                e.Cancel = ((ComboBox)sender).FindStringExact(((ComboBox)sender).Text) < 0;
                if (e.Cancel)
                {
                    MessageBox.Show("Valor digitado não encontrado na lista", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgvParcelas.SelectedRows.Count > 0)
            {
                int row = dgvParcelas.SelectedRows[0].Index;
                row++;
                if (row <= dgvParcelas.RowCount - 1)
                {
                    dgvParcelas.CurrentCell = dgvParcelas.Rows[row].Cells[COL_NUMEROPARCELA];
                    dgvParcelas.Rows[row].Selected = true;
                }
                else
                {
                    row = 0;
                    dgvParcelas.CurrentCell = dgvParcelas.Rows[row].Cells[COL_NUMEROPARCELA];
                    dgvParcelas.Rows[row].Selected = true;
                }
                loadCamposParcela();
            } 
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvParcelas.SelectedRows.Count > 0)
            {
                int row = dgvParcelas.SelectedRows[0].Index;
                row--;
                if (row >= 0)
                {
                    dgvParcelas.CurrentCell = dgvParcelas.Rows[row].Cells[COL_NUMEROPARCELA];
                    dgvParcelas.Rows[row].Selected = true;
                }
                else
                {
                    row = dgvParcelas.RowCount - 1;
                    dgvParcelas.CurrentCell = dgvParcelas.Rows[row].Cells[COL_NUMEROPARCELA];
                    dgvParcelas.Rows[row].Selected = true;
                }
                loadCamposParcela();
            }
        }

        private void txtValor_Validated(object sender, EventArgs e)
        {
            if (dgvParcelas.SelectedRows.Count > 0)
            {
                int row = dgvParcelas.SelectedRows[0].Index;
                List<ParcelaView> ParcelasList = LoadFromGridParcela();
                decimal? TotalParcelas = 0;
                decimal? Valor = 0;
                decimal? percentual = 0;
                decimal? ValorRestante = 0;
                decimal? ValorParcelaRestante = 0;
                decimal? PercentualRestante = 0;
                decimal? ValorAtual = Convert.ToDecimal(dgvParcelas[COL_VALOR, row].Value);
                Valor = Convert.ToDecimal(((TextBox)sender).Text);

                if ((ParcelasList.Count() > 0) && (ValorAtual != Valor))
                {
                    TotalParcelas = ParcelasList.Sum(p => p.Valor);
                    //calcular o percentual.
                    
                    if (TotalParcelas > 0)
                    {
                        percentual = ((Valor / TotalParcelas) * 100);
                        txtPercentual.Text = percentual.Value.ToString("N2");

                        decimal? ValorEditado = 0;
                        int LinhasEditadas = 0;

                        ValorEditado = ParcelasList.Where(p => p.Editado == true).Sum(p => p.Valor);
                        LinhasEditadas = ParcelasList.Where(p => p.Editado == true).Count();

                        LinhasEditadas += 1;

                        ValorRestante = TotalParcelas - (Valor + ValorEditado);
                        ValorParcelaRestante = (ValorRestante / (dgvParcelas.RowCount - LinhasEditadas));
                        PercentualRestante = ((ValorParcelaRestante / TotalParcelas) * 100);

                        for (int i = 0; i < ParcelasList.Count(); i++)
                        {                            
                            ParcelaView p = ParcelasList[i];

                            if (p.Editado)
                            {
                                continue;
                            }

                            if (i == row)
                            {
                                p.Valor = Valor;
                                p.Percentual = percentual;
                                p.Editado = true;
                            }
                            else
                            {
                                p.Valor = ValorParcelaRestante;
                                p.Percentual = PercentualRestante;
                                p.Editado = false;
                            }
                        }

                        dgvParcelas.DataSource = ParcelasList;
                        
                    }
                }
            }
                
        }

        private List<ParcelaView> LoadFromGridParcela()
        {
            List<ParcelaView> ParcelaList = new List<ParcelaView>();
            
            foreach (DataGridViewRow item in dgvParcelas.Rows)
            {
                ParcelaView p = new ParcelaView();

                p.Id = Convert.ToInt64(item.Cells[COL_ID].Value);
                p.Id_Pedido_Otica = Convert.ToInt64(item.Cells[COL_IDPEDIDO].Value);
                p.NrParcela = Convert.ToInt32(item.Cells[COL_NUMEROPARCELA].Value);
                p.Valor = Convert.ToDecimal(item.Cells[COL_VALOR].Value);
                p.Percentual = Convert.ToDecimal(item.Cells[COL_PERCENTUAL].Value);
                p.Pago = Convert.ToBoolean(item.Cells[COL_PAGO].Value);
                p.DtVencimento = item.Cells[COL_DATAVENCIMENTO].Value.ToString();
                p.Editado = Convert.ToBoolean(item.Cells[COL_EDITADO].Value);
                p.NrDias = Convert.ToInt32(item.Cells[COL_NRDIAS].Value);

                if (item.Cells[COL_DATAPAGAMENTO].Value != null)
                {
                    p.DtPagamento = Convert.ToDateTime(item.Cells[COL_DATAPAGAMENTO].Value);
                }
                
                if (item.Cells[COL_FORMAPAGAMENTO].Value != null)
                {
                    p.FormaPagamento = item.Cells[COL_FORMAPAGAMENTO].Value.ToString();
                }
                
                if (item.Cells[COL_USUARIOPAGAMENTO].Value != null)
                {
                    p.Usuario = item.Cells[COL_USUARIOPAGAMENTO].Value.ToString();
                }
                

                ParcelaList.Add(p);               
            }

            return ParcelaList; 
        }

        private void dgvParcelas_Click(object sender, EventArgs e)
        {
            loadCamposParcela();
        }

        private void chkPago_CheckStateChanged(object sender, EventArgs e)
        {
            if (dgvParcelas.SelectedRows.Count > 0)
            {
                int row = dgvParcelas.SelectedRows[0].Index;
                List<ParcelaView> ParcelasList = LoadFromGridParcela();
                for (int i = 0; i < ParcelasList.Count(); i++)
                {
                    ParcelaView p = ParcelasList[i];
                   
                    if (i == row)
                    {
                        p.Pago = ((CheckBox)sender).Checked;
                        p.Editado = true;
                    }
                    
                }

                dgvParcelas.DataSource = ParcelasList;

                if (((CheckBox)sender).Checked)
                {
                    txtDtPagamento.Focus();
                }
                else
                {
                    txtDtPagamento.Text = string.Empty;
                }

                dgvParcelas.CurrentCell = dgvParcelas.Rows[row].Cells[COL_NUMEROPARCELA];
                dgvParcelas.Rows[row].Selected = true;
            }
        }

        private void txtDtPagamento_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).Select(0, 0);
        }

        private void txtDtPagamento_Validated(object sender, EventArgs e)
        {
            if (dgvParcelas.SelectedRows.Count > 0)
            {
                int row = dgvParcelas.SelectedRows[0].Index;
                List<ParcelaView> ParcelasList = LoadFromGridParcela();
                for (int i = 0; i < ParcelasList.Count(); i++)
                {
                    ParcelaView p = ParcelasList[i];

                    if (i == row)
                    {
                        ((MaskedTextBox)sender).TextMaskFormat = MaskFormat.IncludeLiterals;
                        p.DtPagamento = Convert.ToDateTime(((MaskedTextBox)sender).Text);
                        ((MaskedTextBox)sender).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        p.Editado = true;
                    }

                }

                dgvParcelas.DataSource = ParcelasList;

                dgvParcelas.CurrentCell = dgvParcelas.Rows[row].Cells[COL_NUMEROPARCELA];
                dgvParcelas.Rows[row].Selected = true;

            }
        }

        private void txtDtPagamento_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((MaskedTextBox)sender).Text))
            {
                ((MaskedTextBox)sender).TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                if (!ValidateUtils.isDate(((MaskedTextBox)sender).Text))
                {
                    MessageBox.Show("Data inválida.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((MaskedTextBox)sender).Text = string.Empty;
                    e.Cancel = true;
                }
                        ((MaskedTextBox)sender).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            }
        }

        private void cbFormaPagamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvParcelas.SelectedRows.Count > 0)
            {
                int row = dgvParcelas.SelectedRows[0].Index;
                List<ParcelaView> ParcelasList = LoadFromGridParcela();
                for (int i = 0; i < ParcelasList.Count(); i++)
                {
                    ParcelaView p = ParcelasList[i];

                    if (i == row)
                    {
                        p.FormaPagamento = cbFormaPagamento.Text;
                        p.Usuario = Program.usuario_logado.nome;                        
                        p.Editado = true;
                    }

                }

                dgvParcelas.DataSource = ParcelasList;

                dgvParcelas.CurrentCell = dgvParcelas.Rows[row].Cells[COL_NUMEROPARCELA];
                dgvParcelas.Rows[row].Selected = true;

            }
        }
    }
}
