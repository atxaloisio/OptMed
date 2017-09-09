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
    public partial class frmCadEditPedido_Laboratorio : optmed.frmBaseCadEdit
    {
        private ClienteBLL clienteBLL;
        private ProdutoBLL produtoBLL;
        private ParcelaBLL parcelaBLL;
        private Motivo_EntregaBLL motivo_EntregaBLL;
        private Pedido_OticaBLL pedido_OticaBLL;
        private VendedorBLL vendedorBLL;
        private Vendedor_LocalidadeBLL vendedor_LocalidadeBLL;
        private CaixaBLL caixaBLL;

        #region Constante de Colunas da Grid
        private const int col_Id = 0;
        private const int col_IdItem = 1;
        private const int col_IdPedido = 2;
        private const int col_Codigo = 3;
        private const int col_BtnPesquisa = 4;
        private const int col_Descricao = 5;
        private const int col_Unidade = 6;
        private const int col_Quantidade = 7;
        private const int col_VlrUnitario = 8;
        private const int col_PercDesconto = 9;
        private const int col_VlrDesconto = 10;
        private const int col_VlrTotal = 11;

        #endregion
        public frmCadEditPedido_Laboratorio()
        {
            InitializeComponent();
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {
                pedido_OticaBLL = new Pedido_OticaBLL();

                Pedido_Otica pedido_otica = pedido_OticaBLL.Localizar(Id);
                if (pedido_otica != null)
                {
                    txtId.Text = pedido_otica.Id.ToString();
                    txtIdCliente.Text = pedido_otica.Id_cliente.ToString();
                    txtCodigo.Text = pedido_otica.codigo.ToString();
                    txtCodCliIntegracao.Text = pedido_otica.cliente.codigo_cliente_integracao;
                    txtClienteNome.Text = pedido_otica.cliente.nome_fantasia;
                    txtDtEmissao.Text = pedido_otica.data_emissao.Value.ToShortDateString();

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

                    txtod_gp_esf.Text = pedido_otica.od_gp_esf;
                    txtod_gp_cil.Text = pedido_otica.od_gp_cil;
                    txtod_eixo.Text = (pedido_otica.od_eixo != null) ? pedido_otica.od_eixo.Value.ToString() : string.Empty;
                    txtod_adicao.Text = pedido_otica.od_adicao;
                    txtod_gl_esf.Text = pedido_otica.od_gl_esf;
                    txtod_gl_cil.Text = pedido_otica.od_gl_cil;
                    txtod_dnp_longe.Text = pedido_otica.od_dnp_longe;
                    txtod_dnp_perto.Text = pedido_otica.od_dnp_perto;
                    txtod_alt.Text = pedido_otica.od_alt;
                    txtod_dech.Text = pedido_otica.od_dech;
                    txtod_prisma_valor.Text = pedido_otica.od_prisma_valor;
                    txtod_prisma_eixo.Text = (pedido_otica.od_prisma_eixo != null) ? pedido_otica.od_prisma_eixo.Value.ToString() : string.Empty;

                    txtoe_gp_esf.Text = pedido_otica.oe_gp_esf;
                    txtoe_gp_cil.Text = pedido_otica.oe_gp_cil;
                    txtoe_eixo.Text = (pedido_otica.oe_eixo != null) ? pedido_otica.oe_eixo.Value.ToString() : string.Empty;
                    txtoe_adicao.Text = pedido_otica.oe_adicao;
                    txtoe_gl_esf.Text = pedido_otica.oe_gl_esf;
                    txtoe_gl_cil.Text = pedido_otica.oe_gl_cil;
                    txtoe_dnp_longe.Text = pedido_otica.oe_dnp_longe;
                    txtoe_dnp_perto.Text = pedido_otica.oe_dnp_perto;
                    txtoe_alt.Text = pedido_otica.oe_alt;
                    txtoe_dech.Text = pedido_otica.oe_dech;
                    txtoe_prisma_valor.Text = pedido_otica.oe_prisma_valor;
                    txtoe_prisma_eixo.Text = (pedido_otica.oe_prisma_eixo != null) ? pedido_otica.oe_prisma_eixo.Value.ToString() : string.Empty;
                    txtBaseCalculada.Text = pedido_otica.base_calculada;

                    if (pedido_otica.pedido_armacao.Count > 0)
                    {
                        Pedido_Armacao Armacao = pedido_otica.pedido_armacao.FirstOrDefault();

                        txtIdPedArmacao.Text = Armacao.Id.ToString();

                        if (Armacao.tipo != null)
                        {
                            Tipo_ArmacaoBLL tabll = new Tipo_ArmacaoBLL();
                            Tipo_Armacao ta = tabll.getTipo_Armacao(Convert.ToInt32(Armacao.tipo)).FirstOrDefault();
                            cbTipoArmacao.SelectedValue = ta;
                            cbTipoArmacao.Text = ta.descricao;
                        }

                        if (Armacao.shape != null)
                        {
                            cbShapeArmacao.SelectedValue = Armacao.shape;
                        }

                        txtDiaFinLente.Text = (Armacao.diametro_final_lente != null) ? Armacao.diametro_final_lente.Value.ToString() : string.Empty;
                        txtLarguaArmacao.Text = (Armacao.largura != null) ? Armacao.largura.Value.ToString() : string.Empty;
                        txtPonteArmacao.Text = (Armacao.ponte != null) ? Armacao.ponte.Value.ToString() : string.Empty;
                        txtAlturaArmacao.Text = (Armacao.altura != null) ? Armacao.altura.Value.ToString() : string.Empty;
                        txtMaiorDiagonal.Text = (Armacao.maior_diagonal != null) ? Armacao.maior_diagonal.Value.ToString() : string.Empty;
                        txtEixoMaiorDiagonal.Text = (Armacao.eixo_maior_diagonal != null) ? Armacao.eixo_maior_diagonal.Value.ToString() : string.Empty;
                    }

                    if (pedido_otica.pedido_lente.Count > 0)
                    {
                        Pedido_Lente Lente = pedido_otica.pedido_lente.FirstOrDefault();
                        txtIdPedLente.Text = Lente.Id.ToString();
                        if (Lente.tipo != null)
                        {
                            Tipo_LenteBLL tlbll = new Tipo_LenteBLL();
                            Tipo_Lente tl = tlbll.getTipo_Lente(Convert.ToInt32(Lente.tipo)).FirstOrDefault();
                            cbTipoLente.SelectedValue = tl;
                            cbTipoLente.Text = tl.descricao;
                        }
                        txtMaterialLente.Text = Lente.marca_material;
                        txtObs.Text = Lente.observacoes;
                    }

                    foreach (ItemPedido_Otica item in pedido_otica.itempedido_otica)
                    {
                        int rowIndex = dgvItemPedido.Rows.Add();
                        dgvItemPedido[col_Id, rowIndex].Value = item.Id_produto;
                        dgvItemPedido[col_IdItem, rowIndex].Value = item.Id;
                        dgvItemPedido[col_IdPedido, rowIndex].Value = item.Id_pedido_otica;
                        dgvItemPedido[col_Codigo, rowIndex].Value = item.produto.codigo_produto_integracao;
                        dgvItemPedido[col_Descricao, rowIndex].Value = item.produto.descricao;
                        dgvItemPedido[col_Unidade, rowIndex].Value = item.unidade;
                        dgvItemPedido[col_Quantidade, rowIndex].Value = item.quantidade;
                        dgvItemPedido[col_VlrUnitario, rowIndex].Value = item.valor_unitario;
                        dgvItemPedido[col_PercDesconto, rowIndex].Value = item.percentual_desconto;
                        dgvItemPedido[col_VlrDesconto, rowIndex].Value = item.valor_desconto;
                        dgvItemPedido[col_VlrTotal, rowIndex].Value = item.valor_total;
                    }

                    if (pedido_otica.itempedido_otica.Count() > 0)
                    {
                        decimal ValorTotal = pedido_otica.itempedido_otica.Sum(p => p.valor_total);
                        txtValorTotal.Text = ValorTotal.ToString("N2");
                    }

                    txtUsuarioInc.Text = pedido_otica.usuario_inclusao;
                    txtDtInc.Text = pedido_otica.inclusao.ToString();

                    if (pedido_otica.cancelado == "S")
                    {
                        lblPedidoCancelado.Visible = true;

                        foreach (Control item in pnlJanela.Controls)
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
        protected override bool salvar(object sender, EventArgs e)
        {
            bool Retorno = epValidaDados.Validar(true);

            if (Retorno)
            {
                Retorno = ValidaDadosEspecifico();
            }

            if (Retorno)
            {
                try
                {
                    pedido_OticaBLL = new Pedido_OticaBLL();
                    pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;

                    Pedido_Otica pedido_Otica = LoadFromControls();

                    if (Id != null)
                    {
                        pedido_OticaBLL.AlterarPedido_Otica(pedido_Otica);
                    }
                    else
                    {
                        pedido_Otica.status = (int)StatusPedido.GRAVADO;
                        pedido_OticaBLL.AdicionarPedido_Otica(pedido_Otica);

                    }

                    Id = pedido_Otica.Id;
                    txtCodigo.Text = pedido_Otica.codigo.ToString();
                    txtIdPedArmacao.Text = pedido_Otica.pedido_armacao.FirstOrDefault().Id.ToString();
                    txtIdPedLente.Text = pedido_Otica.pedido_lente.FirstOrDefault().Id.ToString();

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

        protected override void ImprimirRegistro(Int64? id)
        {
            if (MessageBox.Show(Text + " Deseja imprimir o recido do pedido?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmRelPedido_Otica relatorio = new frmRelPedido_Otica();
                relatorio.Id = id;
                relatorio.ImprimirDireto(new PageProps(8.27, 11.69, 0.19685, 0.19685, 0.19685, 0.19685));
                pedido_OticaBLL = new Pedido_OticaBLL();
                Pedido_Otica pedido_otica = pedido_OticaBLL.Localizar(id);

                if (pedido_otica.status == (int)StatusPedido.GRAVADO)
                {
                    //decimal? totalValor = 0;
                    //totalValor = pedido_otica.itempedido_otica.Sum(p => p.valor_total);

                    //Pedido_Otica_ParcelasBLL popBLL = new Pedido_Otica_ParcelasBLL();
                    //pedido_otica.pedido_otica_parcelas.Clear();
                    //pedido_otica.pedido_otica_parcelas = popBLL.GerarParcelas(pedido_otica.condicao_pagamento, totalValor, DateTime.Now);

                    pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;
                    pedido_OticaBLL.AtualizarStatusPedido(id, StatusPedido.IMPRESSO);
                }

            }
        }

        protected virtual Pedido_Otica LoadFromControls()
        {
            Pedido_Otica pedido_Otica = new Pedido_Otica();

            #region Dados do Pedido
            if (Id != null)
            {
                pedido_Otica.Id = Convert.ToInt64(Id);
                pedido_Otica.codigo = Convert.ToInt64(txtCodigo.Text);
            }
            pedido_Otica.agrupado = "N";
            pedido_Otica.Id_cliente = Convert.ToInt64(txtIdCliente.Text);
            pedido_Otica.codigo_cliente = txtCodCliIntegracao.Text;

            if (!string.IsNullOrEmpty(txtDtEmissao.Text))
            {
                txtDtEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                pedido_Otica.data_emissao = Convert.ToDateTime(txtDtEmissao.Text);
                txtDtEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            }


            if (!string.IsNullOrEmpty(txtDtFechamento.Text))
            {
                txtDtFechamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                pedido_Otica.data_fechamento = Convert.ToDateTime(txtDtFechamento.Text);
                txtDtFechamento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            }

            pedido_Otica.numero_pedido_cliente = txtNrPedCliente.Text;
            pedido_Otica.numero_caixa = cbCaixa.SelectedText;

            if (cbCaixa.SelectedIndex != -1)
            {
                pedido_Otica.Id_caixa = Convert.ToInt32(cbCaixa.SelectedValue);
            }

            if (cbMotivoEntrega.SelectedIndex != -1)
            {
                pedido_Otica.id_motivo_entrega = Convert.ToInt64(cbMotivoEntrega.SelectedValue);
            }

            if (cbTransportadora.SelectedIndex != -1)
            {
                pedido_Otica.Id_transportadora = Convert.ToInt64(cbTransportadora.SelectedValue);
            }
            
            if (cbCondPagamento.SelectedIndex != -1)
            {
                pedido_Otica.condicao_pagamento = Convert.ToInt64(cbCondPagamento.SelectedValue);
            }

            if (cbVendedor.SelectedIndex != -1)
            {
                pedido_Otica.Id_vendedor = Convert.ToInt64(cbVendedor.SelectedValue);
            }

            if (!string.IsNullOrEmpty(txtDtPrevEntrega.Text))
            {
                txtDtPrevEntrega.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                pedido_Otica.date_previsao_entrega = Convert.ToDateTime(txtDtPrevEntrega.Text);
                txtDtPrevEntrega.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            }

            if (!string.IsNullOrEmpty(txtHrPrevEntrega.Text))
            {
                CultureInfo Culture = CultureInfo.CurrentCulture;
                TimeSpan horaEnt;
                txtHrPrevEntrega.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                TimeSpan.TryParseExact(txtHrPrevEntrega.Text, "g", Culture, out horaEnt);
                pedido_Otica.hora_previsao_entrega = horaEnt.ToString();
            }


            #endregion

            #region Dados Receiturario
            //Olho Direito
            pedido_Otica.od_gl_esf = txtod_gl_esf.Text;
            pedido_Otica.od_gl_cil = txtod_gl_cil.Text;

            if (!string.IsNullOrEmpty(txtod_eixo.Text))
            {
                pedido_Otica.od_eixo = Convert.ToInt32(txtod_eixo.Text);
            }

            pedido_Otica.od_adicao = txtod_adicao.Text;

            pedido_Otica.od_gp_esf = txtod_gp_esf.Text;
            pedido_Otica.od_gp_cil = txtod_gp_cil.Text;
            pedido_Otica.od_dnp_longe = txtod_dnp_longe.Text;
            pedido_Otica.od_dnp_perto = txtod_dnp_perto.Text;
            pedido_Otica.od_alt = txtod_alt.Text;
            pedido_Otica.od_dech = txtod_dech.Text;
            pedido_Otica.od_prisma_valor = txtod_prisma_valor.Text;

            if (!string.IsNullOrEmpty(txtod_prisma_eixo.Text))
            {
                pedido_Otica.od_prisma_eixo = Convert.ToInt32(txtod_prisma_eixo.Text);
            }
            //Olho Esquerdo
            pedido_Otica.oe_gl_esf = txtoe_gl_esf.Text;
            pedido_Otica.oe_gl_cil = txtoe_gl_cil.Text;

            if (!string.IsNullOrEmpty(txtoe_eixo.Text))
            {
                pedido_Otica.oe_eixo = Convert.ToInt32(txtoe_eixo.Text);
            }

            pedido_Otica.oe_adicao = txtoe_adicao.Text;

            pedido_Otica.oe_gp_esf = txtoe_gp_esf.Text;
            pedido_Otica.oe_gp_cil = txtoe_gp_cil.Text;
            pedido_Otica.oe_dnp_longe = txtoe_dnp_longe.Text;
            pedido_Otica.oe_dnp_perto = txtoe_dnp_perto.Text;
            pedido_Otica.oe_alt = txtoe_alt.Text;
            pedido_Otica.oe_dech = txtoe_dech.Text;
            pedido_Otica.oe_prisma_valor = txtoe_prisma_valor.Text;

            if (!string.IsNullOrEmpty(txtoe_prisma_eixo.Text))
            {
                pedido_Otica.oe_prisma_eixo = Convert.ToInt32(txtoe_prisma_eixo.Text);
            }
            pedido_Otica.base_calculada = txtBaseCalculada.Text;
            pedido_Otica.status = (int)StatusPedido.GRAVADO;
            #endregion

            #region Dados Armação

            Pedido_Armacao pedido_Armacao = new Pedido_Armacao();

            if (Id != null)
            {
                pedido_Armacao.Id_pedido_otica = Convert.ToInt64(Id);
                pedido_Armacao.Id = Convert.ToInt64(txtIdPedArmacao.Text);

                Pedido_ArmacaoBLL pedido_ArmacaoBLL = new Pedido_ArmacaoBLL();
                pedido_Otica.pedido_armacao = pedido_ArmacaoBLL.getPedido_Armacao(Convert.ToInt32(pedido_Armacao.Id));
                pedido_Armacao = pedido_Otica.pedido_armacao.FirstOrDefault();

            }

            if (cbTipoArmacao.SelectedIndex != -1)
            {
                pedido_Armacao.tipo = Convert.ToInt32(cbTipoArmacao.SelectedValue);
            }

            if (cbShapeArmacao.SelectedIndex != -1)
            {
                pedido_Armacao.shape = Convert.ToInt32(cbShapeArmacao.SelectedValue);
            }

            if (!string.IsNullOrEmpty(txtDiaFinLente.Text))
            {
                pedido_Armacao.diametro_final_lente = Convert.ToDecimal(txtDiaFinLente.Text);
            }

            if (!string.IsNullOrEmpty(txtLarguaArmacao.Text))
            {
                pedido_Armacao.largura = Convert.ToInt32(txtLarguaArmacao.Text);
            }

            if (!string.IsNullOrEmpty(txtPonteArmacao.Text))
            {
                pedido_Armacao.ponte = Convert.ToInt32(txtPonteArmacao.Text);
            }

            if (!string.IsNullOrEmpty(txtAlturaArmacao.Text))
            {
                pedido_Armacao.altura = Convert.ToInt32(txtAlturaArmacao.Text);
            }

            if (!string.IsNullOrEmpty(txtMaiorDiagonal.Text))
            {
                pedido_Armacao.maior_diagonal = Convert.ToInt32(txtMaiorDiagonal.Text);
            }

            if (!string.IsNullOrEmpty(txtEixoMaiorDiagonal.Text))
            {
                pedido_Armacao.eixo_maior_diagonal = Convert.ToInt32(txtEixoMaiorDiagonal.Text);
            }

            pedido_Otica.pedido_armacao.Add(pedido_Armacao);
            #endregion

            #region Dados Lente
            Pedido_Lente pedido_Lente = new Pedido_Lente();

            if (Id != null)
            {
                pedido_Lente.Id_pedido_otica = Convert.ToInt64(Id);
                pedido_Lente.Id = Convert.ToInt64(txtIdPedLente.Text);

                Pedido_LenteBLL pedido_LenteBLL = new Pedido_LenteBLL();
                pedido_Otica.pedido_lente = pedido_LenteBLL.getPedido_Lente(Convert.ToInt32(pedido_Lente.Id));
                pedido_Lente = pedido_Otica.pedido_lente.FirstOrDefault();
            }

            if (cbTipoLente.SelectedIndex != -1)
            {
                pedido_Lente.tipo = Convert.ToInt32(cbTipoLente.SelectedValue);
            }
            pedido_Lente.marca_material = txtMaterialLente.Text;
            pedido_Lente.observacoes = txtObs.Text;

            pedido_Otica.pedido_lente.Add(pedido_Lente);
            #endregion

            #region Itens do Pedido

            //

            foreach (DataGridViewRow item in dgvItemPedido.Rows)
            {

                if (item.Cells[col_Id].Value != null)
                {
                    ItemPedido_Otica itemPedido_Otica = new ItemPedido_Otica()
                    {
                        Id_produto = Convert.ToInt64(item.Cells[col_Id].Value),
                        quantidade = Convert.ToInt32(item.Cells[col_Quantidade].Value),
                        unidade = ((DataGridViewComboBoxCell)item.Cells[col_Unidade]).Value.ToString(),
                        percentual_desconto = Convert.ToDecimal(item.Cells[col_PercDesconto].Value),
                        valor_desconto = Convert.ToDecimal(item.Cells[col_VlrDesconto].Value),
                        valor_unitario = Convert.ToDecimal(item.Cells[col_VlrUnitario].Value),
                        valor_total = Convert.ToDecimal(item.Cells[col_VlrTotal].Value),

                    };

                    if (item.Cells[col_IdItem].Value != null)
                    {
                        itemPedido_Otica.Id = Convert.ToInt64(item.Cells[col_IdItem].Value);
                    }

                    if (item.Cells[col_IdPedido].Value != null)
                    {
                        itemPedido_Otica.Id_pedido_otica = Convert.ToInt64(item.Cells[col_IdPedido].Value);
                    }
                    else if (Id != null)
                    {
                        itemPedido_Otica.Id_pedido_otica = Convert.ToInt64(Id);
                    }

                    pedido_Otica.itempedido_otica.Add(itemPedido_Otica);


                }
            }

            #endregion

            if (Id != null)
            {
                pedido_Otica.usuario_inclusao = txtUsuarioInc.Text;
                if (!string.IsNullOrEmpty(txtDtInc.Text))
                {
                    pedido_Otica.inclusao = Convert.ToDateTime(txtDtInc.Text);
                }
            }

            return pedido_Otica;
        }

        private bool ValidaDadosEspecifico()
        {
            //Verifica se a caixa selecionada não está alocada um um pedido não entregue.
            bool retorno = true;
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
                            retorno = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Caixa selecionada está em uso no pedido : " + CaixaList.FirstOrDefault().pedido_otica.Where(t => t.status < status).FirstOrDefault().codigo, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        retorno = false;
                    }

                }
            }
            return retorno;
        }

        protected override void SetupControls()
        {
            SetupCondPagamento();
            SetupCaixa();
            SetupTransportadora();
            SetupVendedor();
            SetupMotivoEntrega();
            SetupTipoArmacao();
            SetupShapeArmacao();
            SetupTipoLente();
            formataGridItens();
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

        private void SetupTipoLente()
        {
            Tipo_LenteBLL Tipo_LenteBLL = new Tipo_LenteBLL();

            List<Tipo_Lente> Tipo_LenteList = Tipo_LenteBLL.getTipo_Lente();

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (Tipo_Lente item in Tipo_LenteList)
            {
                acc.Add(item.descricao);
            }

            cbTipoLente.DataSource = Tipo_LenteList;
            cbTipoLente.ValueMember = "Id";
            cbTipoLente.DisplayMember = "descricao";
            cbTipoLente.SelectedIndex = -1;
        }

        private void SetupShapeArmacao()
        {
            ShapeArmacao tp = new ShapeArmacao();

            cbShapeArmacao.DataSource = Enumerados.getListEnum(tp);
            cbShapeArmacao.ValueMember = "chave";
            cbShapeArmacao.DisplayMember = "descricao";
            cbShapeArmacao.SelectedIndex = -1;
        }

        private void SetupTipoArmacao()
        {
            Tipo_ArmacaoBLL Tipo_ArmacaoBLL = new Tipo_ArmacaoBLL();

            List<Tipo_Armacao> Tipo_ArmacaoList = Tipo_ArmacaoBLL.getTipo_Armacao();

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (Tipo_Armacao item in Tipo_ArmacaoList)
            {
                acc.Add(item.descricao);
            }

            cbTipoArmacao.DataSource = Tipo_ArmacaoList;
            cbTipoArmacao.ValueMember = "Id";
            cbTipoArmacao.DisplayMember = "descricao";
            cbTipoArmacao.SelectedIndex = -1;

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

        private void formataGridItens()
        {
            dgvItemPedido.Columns[col_Quantidade].ValueType = typeof(decimal);
            dgvItemPedido.Columns[col_Quantidade].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvItemPedido.Columns[col_VlrUnitario].DefaultCellStyle.Format = "N2";
            dgvItemPedido.Columns[col_VlrUnitario].ValueType = typeof(decimal);
            dgvItemPedido.Columns[col_VlrUnitario].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvItemPedido.Columns[col_PercDesconto].DefaultCellStyle.Format = "N2";
            dgvItemPedido.Columns[col_PercDesconto].ValueType = typeof(decimal);
            dgvItemPedido.Columns[col_PercDesconto].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvItemPedido.Columns[col_VlrDesconto].DefaultCellStyle.Format = "N2";
            dgvItemPedido.Columns[col_VlrDesconto].ValueType = typeof(decimal);
            dgvItemPedido.Columns[col_VlrDesconto].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvItemPedido.Columns[col_VlrTotal].DefaultCellStyle.Format = "N2";
            dgvItemPedido.Columns[col_VlrTotal].ReadOnly = true;
            dgvItemPedido.Columns[col_VlrTotal].ValueType = typeof(decimal);
            dgvItemPedido.Columns[col_VlrTotal].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            setupCol_Unidade();
        }

        private void dgvItemPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (dgvItemPedido.CurrentCell != null)
                {
                    int iColumn = dgvItemPedido.CurrentCell.ColumnIndex;
                    int iRow = dgvItemPedido.CurrentCell.RowIndex;

                    if (iColumn == dgvItemPedido.Columns.Count - 1)
                        dgvItemPedido.CurrentCell = dgvItemPedido[col_Codigo, iRow];
                    else
                    {
                        try
                        {
                            dgvItemPedido.CurrentCell = dgvItemPedido[iColumn + 1, iRow];
                        }
                        catch (Exception)
                        {
                            dgvItemPedido.CurrentCell = dgvItemPedido[iColumn, iRow];
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                if (dgvItemPedido.CurrentCell != null)
                {
                    int iColumn = dgvItemPedido.CurrentCell.ColumnIndex;
                    int iRow = dgvItemPedido.CurrentCell.RowIndex;

                    dgvItemPedido[iColumn, iRow].Value = "";
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;

                if (MessageBox.Show("Deseja cancelar a inclusão do produto?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvItemPedido.Rows.Count > 0)
                    {
                        dgvItemPedido.Rows.RemoveAt(dgvItemPedido.CurrentRow.Index);
                        AtualizaTotal();
                    }
                }
            }

            if (e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;

                if (dgvItemPedido.CurrentCell != null)
                {
                    int iColumn = dgvItemPedido.CurrentCell.ColumnIndex;
                    int iRow = dgvItemPedido.CurrentCell.RowIndex;

                    DataGridViewCellCancelEventArgs x = new DataGridViewCellCancelEventArgs(iColumn, iRow);

                    dgvItemPedido_RowValidating(dgvItemPedido, x);

                    if (!x.Cancel)
                    {
                        AdicionaItem();
                    }
                }
                else
                {
                    AdicionaItem();
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AdicionaItem();
        }

        private void AdicionaItem()
        {
            bool AdicionaLinha = true;

            AdicionaLinha = epValidaDados.Validar();

            if (AdicionaLinha)
            {
                dgvItemPedido.Rows.Add();
                dgvItemPedido.Focus();
                if (dgvItemPedido.Rows.Count > 0)
                {
                    dgvItemPedido.CurrentCell = dgvItemPedido.Rows[dgvItemPedido.Rows.Count - 1].Cells[col_Codigo];
                }
                SendKeys.Send("{DOWN}");
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvItemPedido.Rows.Count > 0)
            {
                dgvItemPedido.Rows.RemoveAt(dgvItemPedido.CurrentRow.Index);
                AtualizaTotal();
            }

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

                        if (txtDtFechamento.Visible)
                        {
                            txtDtFechamento.Focus();
                        }                        
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
                txtCodCliIntegracao.Text = string.Empty;
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


                if (txtDtFechamento.Visible)
                {
                    txtDtFechamento.Focus();
                }                
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

        private void dgvItemPedido_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == col_BtnPesquisa)
            {
                setupCol_BtnPesquisa(sender, e);
                e.Handled = true;
            }
        }

        private void setupCol_BtnPesquisa(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            var w = Properties.Resources.Pesquisar.Width;
            var h = Properties.Resources.Pesquisar.Height;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            e.CellStyle.BackColor = SystemColors.HotTrack;
            e.CellStyle.ForeColor = SystemColors.HighlightText;
            e.CellStyle.SelectionBackColor = SystemColors.Highlight;
            e.CellStyle.SelectionForeColor = SystemColors.HighlightText;

            e.PaintBackground(new Rectangle(x, y, w, h), false);

            e.Graphics.DrawImage(Properties.Resources.Pesquisar, new Rectangle(x, y, w, h));
        }

        private void dgvItemPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == col_BtnPesquisa)
            {
                ExecutaPesquisaProduto(sender, e);
            }
            else
            {
                dgvItemPedido.Select();
            }
        }

        private void ExecutaPesquisaProduto(object sender, DataGridViewCellEventArgs e)
        {
            frmPesquisaProdutos pesquisa = new frmPesquisaProdutos();
            string chavePesquisa = (dgvItemPedido[col_Codigo, e.RowIndex].Value == null ? string.Empty : dgvItemPedido[col_Codigo, e.RowIndex].Value.ToString());
            if (pesquisa.ExibeDialogo(chavePesquisa) == DialogResult.OK)
            {
                if (pesquisa.Id != null)
                {
                    produtoBLL = new ProdutoBLL();
                    Produto produto = produtoBLL.Localizar(pesquisa.Id);
                    if (produto != null)
                    {
                        dgvItemPedido[col_Id, e.RowIndex].Value = produto.id;
                        dgvItemPedido[col_Codigo, e.RowIndex].Value = produto.codigo_produto_integracao;
                        dgvItemPedido[col_Descricao, e.RowIndex].Value = produto.descricao;

                        ((DataGridViewComboBoxCell)dgvItemPedido[col_Unidade, e.RowIndex]).Value = produto.unidade;
                        //dgvItemPedido[col_Unidade, e.RowIndex].Value = produto.unidade;

                        dgvItemPedido[col_Quantidade, e.RowIndex].Value = string.Empty;
                        dgvItemPedido[col_VlrUnitario, e.RowIndex].Value = produto.valor_unitario;
                        dgvItemPedido[col_PercDesconto, e.RowIndex].Value = 0;
                        dgvItemPedido[col_VlrDesconto, e.RowIndex].Value = Convert.ToDecimal(0.00);
                        dgvItemPedido[col_VlrTotal, e.RowIndex].Value = Convert.ToDecimal(0.00);

                        if (dgvItemPedido.Rows.Count > 0)
                        {
                            dgvItemPedido.CurrentCell = dgvItemPedido.Rows[e.RowIndex].Cells[col_Quantidade];
                        }
                    }
                }
            }
            else
            {
                txtCodCliIntegracao.Focus();
            }
        }



        private void dgvItemPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void setupCol_Unidade()
        {
            UnidadeBLL unidadeBLL = new UnidadeBLL();
            ((DataGridViewComboBoxColumn)dgvItemPedido.Columns[col_Unidade]).DataSource = unidadeBLL.getUnidade();
            ((DataGridViewComboBoxColumn)dgvItemPedido.Columns[col_Unidade]).DisplayMember = "codigo";
            ((DataGridViewComboBoxColumn)dgvItemPedido.Columns[col_Unidade]).ValueMember = "codigo";
        }

        private void dgvItemPedido_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            e.Control.KeyPress -= new KeyPressEventHandler(onlyNumber_KeyPress);

            switch (dgvItemPedido.CurrentCell.ColumnIndex)
            {
                case col_Quantidade:
                case col_PercDesconto:
                case col_VlrDesconto:
                case col_VlrUnitario:
                    {
                        TextBox tb = e.Control as TextBox;
                        if (tb != null)
                        {
                            tb.KeyPress += new KeyPressEventHandler(onlyNumber_KeyPress);
                        }

                    }
                    break;
            }
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

        private void Grau_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvItemPedido_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int coluna = dgvItemPedido.CurrentCell.ColumnIndex;
            int linha = dgvItemPedido.CurrentCell.RowIndex;

            if (e.ColumnIndex == col_Quantidade)
            {
                e.Cancel = !dgvItemPedido_ValidarQuantidade(e);
            }

            if (coluna == col_VlrUnitario)
            {
                e.Cancel = !dgvItemPedido_ValidarValorUnitario(e);
            }

            if (coluna == col_PercDesconto)
            {
                e.Cancel = !dgvItemPedido_ValidarPercDesconto(e);
            }

            if (coluna == col_VlrDesconto)
            {
                e.Cancel = !dgvItemPedido_ValidarValorDesconto(e);
            }

            if (e.Cancel)
            {
                dgvItemPedido.CurrentCell = dgvItemPedido[e.ColumnIndex, e.RowIndex];
            }
        }

        private bool dgvItemPedido_ValidarValorDesconto(DataGridViewCellValidatingEventArgs e)
        {
            bool retorno = true;

            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("Valor de desconto invalido.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (retorno)
            {
                if ((dgvItemPedido[col_Quantidade, e.RowIndex].Value != null) & (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value != null))
                {
                    decimal qtd = Convert.ToDecimal(dgvItemPedido[col_Quantidade, e.RowIndex].Value);
                    decimal vlrUn = Convert.ToDecimal(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value);

                    decimal vlrTotal = qtd * vlrUn;
                    decimal vlrDesc = Convert.ToDecimal(e.FormattedValue);

                    if (vlrDesc > vlrTotal)
                    {
                        MessageBox.Show("Valor de desconto não pode ser maior que valor total.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        retorno = false;
                    }
                }
            }

            return retorno;
        }

        private bool dgvItemPedido_ValidarPercDesconto(DataGridViewCellValidatingEventArgs e)
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("Percentual de desconto invalido.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }
            else if (Convert.ToDecimal(e.FormattedValue) > 100)
            {
                MessageBox.Show("Percentual de desconto deve ser menor que 100.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }
            else if (Convert.ToDecimal(e.FormattedValue) < 0)
            {
                MessageBox.Show("Percentual de desconto não pode ser menor que zero.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            return retorno;
        }

        private bool dgvItemPedido_ValidarQuantidade(DataGridViewCellValidatingEventArgs e)
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("Quantidade obrigatória.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            return retorno;
        }

        private bool dgvItemPedido_ValidarValorUnitario(DataGridViewCellValidatingEventArgs e)
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("Valor unitário obrigatório.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }
            else if (Convert.ToDecimal(e.FormattedValue) <= 0)
            {
                MessageBox.Show("Deve ser maior que zero.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            return retorno;
        }

        private void eixo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                if (Convert.ToInt32(((TextBox)sender).Text) > 180)
                {

                    MessageBox.Show("Eixo não pode ser superior a 180°", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ((TextBox)sender).Text = "0";
                    e.Cancel = true;
                }

                if (Convert.ToInt32(((TextBox)sender).Text) < 0)
                {

                    MessageBox.Show("Eixo não pode ser inferior a 0°", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ((TextBox)sender).Text = "0";
                    e.Cancel = true;
                }
            }
        }

        protected override void Incluir()
        {
            base.Incluir();
            if (dgvItemPedido.Rows.Count > 0)
            {
                dgvItemPedido.Rows.Clear();
            }

            SetupCaixa();

            txtCodCliIntegracao.Focus();
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

        private void dgvItemPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool nextCell = false;
            if (e.ColumnIndex == col_Quantidade)
            {
                if ((dgvItemPedido[col_Quantidade, e.RowIndex].Value != null) && (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value != null))
                {
                    if (!string.IsNullOrEmpty(dgvItemPedido[col_Quantidade, e.RowIndex].Value.ToString()))
                    {
                        decimal qtd = Convert.ToDecimal(dgvItemPedido[col_Quantidade, e.RowIndex].Value);
                        decimal vlrUn = Convert.ToDecimal(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value);
                        dgvItemPedido[col_VlrTotal, e.RowIndex].Value = qtd * vlrUn;
                        nextCell = true;
                    }
                }
            }
            if (e.ColumnIndex == col_PercDesconto)
            {
                if ((dgvItemPedido[col_Quantidade, e.RowIndex].Value != null) & (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value != null))
                {
                    decimal qtd = Convert.ToDecimal(dgvItemPedido[col_Quantidade, e.RowIndex].Value);
                    decimal vlrUn = Convert.ToDecimal(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value);
                    decimal percDesc = Convert.ToDecimal(dgvItemPedido[col_PercDesconto, e.RowIndex].Value);
                    decimal vlrTotal = qtd * vlrUn;
                    decimal vlrDesc = (percDesc / 100) * vlrTotal;

                    dgvItemPedido[col_VlrDesconto, e.RowIndex].Value = vlrDesc;
                    dgvItemPedido[col_VlrTotal, e.RowIndex].Value = (vlrTotal - vlrDesc);
                    nextCell = true;
                }
            }

            if (e.ColumnIndex == col_VlrUnitario)
            {
                if ((dgvItemPedido[col_Quantidade, e.RowIndex].Value != null) && (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value != null))
                {
                    decimal qtd = Convert.ToDecimal(dgvItemPedido[col_Quantidade, e.RowIndex].Value);
                    decimal vlrUn = Convert.ToDecimal(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value);
                    dgvItemPedido[col_VlrTotal, e.RowIndex].Value = qtd * vlrUn;
                    nextCell = true;
                }
            }

            if (e.ColumnIndex == col_VlrDesconto)
            {
                decimal qtd = Convert.ToDecimal(dgvItemPedido[col_Quantidade, e.RowIndex].Value);
                decimal vlrUn = Convert.ToDecimal(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value);
                decimal vlrDesc = Convert.ToDecimal(dgvItemPedido[col_VlrDesconto, e.RowIndex].Value);

                decimal vlrTotal = qtd * vlrUn;

                if (vlrTotal > 0)
                {
                    decimal percDesc = (vlrDesc / vlrTotal) * 100;
                    dgvItemPedido[col_PercDesconto, e.RowIndex].Value = percDesc;
                }

                dgvItemPedido[col_VlrTotal, e.RowIndex].Value = (vlrTotal - vlrDesc);
                nextCell = true;

            }

            if (nextCell)
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    if (e.ColumnIndex == dgvItemPedido.Columns.Count - 1)
                        dgvItemPedido.CurrentCell = dgvItemPedido[col_Codigo, e.RowIndex];
                    else
                        dgvItemPedido.CurrentCell = dgvItemPedido[e.ColumnIndex + 1, e.RowIndex];
                }));
            }
        }

        private void dgvItemPedido_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string msg = string.Empty;

            switch (e.ColumnIndex)
            {
                case col_Codigo:
                    {
                        if (dgvItemPedido[col_Codigo, e.RowIndex].Value == null)
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Codigo, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else
                        {
                            string codigo = dgvItemPedido[col_Codigo, e.RowIndex].Value.ToString();
                            produtoBLL = new ProdutoBLL();
                            List<Produto> produtoList = produtoBLL.getProduto(p => p.codigo.ToLower() == codigo.ToLower());
                            if (produtoList.Count() > 0)
                            {
                                Produto produto = produtoList.First();
                                if (produto != null)
                                {
                                    if (dgvItemPedido[col_Id, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_Id, e.RowIndex].Value = produto.id;
                                    }

                                    if (dgvItemPedido[col_Codigo, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_Codigo, e.RowIndex].Value = produto.codigo_produto_integracao;
                                    }

                                    if (dgvItemPedido[col_Descricao, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_Descricao, e.RowIndex].Value = produto.descricao;
                                    }

                                    if (((DataGridViewComboBoxCell)dgvItemPedido[col_Unidade, e.RowIndex]).Value == null)
                                    {
                                        ((DataGridViewComboBoxCell)dgvItemPedido[col_Unidade, e.RowIndex]).Value = produto.unidade;
                                    }

                                    if (dgvItemPedido[col_Quantidade, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_Quantidade, e.RowIndex].Value = string.Empty;
                                    }

                                    if (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_VlrUnitario, e.RowIndex].Value = produto.valor_unitario;
                                    }

                                    if (dgvItemPedido[col_PercDesconto, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_PercDesconto, e.RowIndex].Value = 0;
                                    }

                                    if (dgvItemPedido[col_VlrDesconto, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_VlrDesconto, e.RowIndex].Value = Convert.ToDecimal(0.00);
                                    }

                                    if (dgvItemPedido[col_VlrTotal, e.RowIndex].Value == null)
                                    {
                                        dgvItemPedido[col_VlrTotal, e.RowIndex].Value = Convert.ToDecimal(0.00);
                                    }

                                    if (dgvItemPedido.Rows.Count > 0)
                                    {
                                        if (e.RowIndex >0)
                                            dgvItemPedido.CurrentCell = dgvItemPedido.Rows[e.RowIndex].Cells[col_Quantidade];
                                    }
                                }
                            }
                        }
                    }
                    break;
                case col_Quantidade:
                    {
                        if (dgvItemPedido[col_Codigo, e.RowIndex].Value == null)
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Codigo, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (dgvItemPedido[col_Quantidade, e.RowIndex].Value == null)
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Quantidade, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                    }
                    break;
                case col_VlrUnitario:
                    {
                        if (dgvItemPedido[col_Codigo, e.RowIndex].Value == null)
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Codigo, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (dgvItemPedido[col_Quantidade, e.RowIndex].Value == null)
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Quantidade, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                        else if (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value == null)
                        {
                            msg = msg + "Valor unitário obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Valor unitário obrigatório";
                        }
                        else if (Convert.ToDecimal(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value) <= 0)
                        {
                            msg = msg + "Deve ser maior que zero.";
                        }
                    }
                    break;
                case col_PercDesconto:
                    {
                        if (dgvItemPedido[col_Codigo, e.RowIndex].Value == null)
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Codigo, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (dgvItemPedido[col_Quantidade, e.RowIndex].Value == null)
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Quantidade, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                        else if (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value == null)
                        {
                            msg = msg + "Valor unitário obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Valor unitário obrigatório";
                        }
                        else if (dgvItemPedido[col_PercDesconto, e.RowIndex].Value == null)
                        {
                            msg = msg + "Percentual de desconto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_PercDesconto, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Percentual de desconto obrigatório";
                        }
                        else if (Convert.ToDecimal(dgvItemPedido[col_PercDesconto, e.RowIndex].Value) > 100)
                        {
                            msg = msg + "Percentual de desconto deve ser menor que 100.";
                        }
                        else if (Convert.ToDecimal(dgvItemPedido[col_PercDesconto, e.RowIndex].Value) < 0)
                        {
                            msg = msg + "Percentual de desconto não pode ser menor que zero.";
                        }
                    }
                    break;
                case col_VlrDesconto:
                    {
                        if (dgvItemPedido[col_Codigo, e.RowIndex].Value == null)
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Codigo, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Produto obrigatório";
                        }
                        else if (dgvItemPedido[col_Quantidade, e.RowIndex].Value == null)
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_Quantidade, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Quantidade obrigatório";
                        }
                        else if (dgvItemPedido[col_VlrUnitario, e.RowIndex].Value == null)
                        {
                            msg = msg + "Valor unitário obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_VlrUnitario, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Valor unitário obrigatório";
                        }
                        else if (dgvItemPedido[col_PercDesconto, e.RowIndex].Value == null)
                        {
                            msg = msg + "Percentual de desconto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_PercDesconto, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Percentual de desconto obrigatório";
                        }
                        else if (Convert.ToDecimal(dgvItemPedido[col_PercDesconto, e.RowIndex].Value) > 100)
                        {
                            msg = msg + "Percentual de desconto deve ser menor que 100.";
                        }
                        else if (Convert.ToDecimal(dgvItemPedido[col_PercDesconto, e.RowIndex].Value) < 0)
                        {
                            msg = msg + "Percentual de desconto não pode ser menor que zero.";
                        }
                        else if (dgvItemPedido[col_VlrDesconto, e.RowIndex].Value == null)
                        {
                            msg = msg + "Valor de desconto obrigatório";
                        }
                        else if (string.IsNullOrEmpty(dgvItemPedido[col_VlrDesconto, e.RowIndex].Value.ToString()))
                        {
                            msg = msg + "Valor de desconto obrigatório";
                        }
                    }
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string caminho = @"c:\temp\";
            string nomearq = "123.dat";
            string linha = "0,1,\"OTICA MATEUS; 0059; 8152\",+0.50,-0.50,180,2.50,+0.50,-0.50,180,2.50,,,,,,,,,,,,,,,,,,,,";
            GravaArquivo.EscreverArquivo(caminho + nomearq, linha);
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
                e.Cancel = ((ComboBox)sender).FindString(((ComboBox)sender).Text) < 0;
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

        private void EsfCilAd_Validated(object sender, EventArgs e)
        {
            epValidaDados.SetError(((TextBox)sender), string.Empty);
            string txt = ((TextBox)sender).Text;
            if (!string.IsNullOrEmpty(txt))
            {
                if (Utils.StringExtensions.IsNumeric(txt.Substring(0, 1)))
                {
                    decimal dec = Convert.ToDecimal(txt.Replace(".", ","));
                    if (dec > 10)
                    {
                        dec = dec / 100;
                    }
                    ((TextBox)sender).Text = "+" + dec.ToString("N2").Replace(",", ".");
                }
                else if ((txt.Substring(0, 1) == "-") & (txt.Trim().Length > 1))
                {
                    decimal dec = Convert.ToDecimal(txt.Substring(1, txt.Length - 1).Replace(".", ","));
                    if (dec > 10)
                    {
                        dec = dec / 100;
                    }
                    ((TextBox)sender).Text = "-" + dec.ToString("N2").Replace(",", ".");
                }
                else if ((txt.Substring(0, 1) == "+") & (txt.Trim().Length > 1))
                {
                    decimal dec = Convert.ToDecimal(txt.Substring(1, txt.Length - 1).Replace(".", ","));
                    if (dec > 10)
                    {
                        dec = dec / 100;
                    }
                    ((TextBox)sender).Text = "+" + dec.ToString("N2").Replace(",", ".");
                }
            }
            CalcularBase();
        }

        private void CalcularBase()
        {
            pedido_OticaBLL = new Pedido_OticaBLL();

            string esf = string.Empty;
            string cil = string.Empty;

            //Vamos usar primeiro o olho direito para calculo da base.
            if ((!string.IsNullOrEmpty(txtod_gl_esf.Text)) && (!string.IsNullOrEmpty(txtod_gl_cil.Text)))
            {
                esf = txtod_gl_esf.Text;
                cil = txtod_gl_cil.Text;
            }
            else if ((!string.IsNullOrEmpty(txtoe_gl_esf.Text)) && (!string.IsNullOrEmpty(txtoe_gl_cil.Text)))
            {
                esf = txtoe_gl_esf.Text;
                cil = txtoe_gl_cil.Text;
            }

            if ((!string.IsNullOrEmpty(esf)) && (!string.IsNullOrEmpty(cil)))
            {
                txtBaseCalculada.Text = pedido_OticaBLL.CalcularBasePedido_Otica(esf, cil).ToString();
            }

        }

        private void txtod_adicao_Validated(object sender, EventArgs e)
        {

            EsfCilAd_Validated(sender, e);
            if (!string.IsNullOrEmpty(txtod_adicao.Text))
            {
                decimal Esferico = 0;
                decimal Cilindro = 0;
                decimal Adicao = 0;
                decimal GlEsf = 0;
                decimal GlCil = 0;

                if (!string.IsNullOrEmpty(txtod_gl_esf.Text))
                {
                    Esferico = Convert.ToDecimal(txtod_gl_esf.Text.Substring(1, txtod_gl_esf.Text.Length - 1).Replace(".", ","));
                    if (txtod_gl_esf.Text.Substring(0, 1) == "-")
                    {
                        Esferico = Esferico * -1;
                    }
                }

                if (!string.IsNullOrEmpty(txtod_gl_cil.Text))
                {
                    Cilindro = Convert.ToDecimal(txtod_gl_cil.Text.Substring(1, txtod_gl_cil.Text.Length - 1).Replace(".", ","));
                    if (txtod_gl_cil.Text.Substring(0, 1) == "-")
                    {
                        Cilindro = Cilindro * -1;
                    }
                }

                if (!string.IsNullOrEmpty(txtod_adicao.Text))
                {
                    Adicao = Convert.ToDecimal(txtod_adicao.Text.Substring(1, txtod_adicao.Text.Length - 1).Replace(".", ","));
                    if ((txtod_adicao.Text.Substring(0, 1) == "-") & (txtod_adicao.Text.Trim().Length > 1))
                    {
                        Adicao = Adicao * -1;
                    }
                }
                GlEsf = Esferico + Adicao;
                GlCil = Cilindro;
                if (GlEsf > 0)
                {
                    txtod_gp_esf.Text = "+" + GlEsf.ToString("N2").Replace(",", ".");
                }
                else
                {
                    txtod_gp_esf.Text = GlEsf.ToString("N2").Replace(",", ".");
                }

                if (GlCil > 0)
                {
                    txtod_gp_cil.Text = "+" + GlCil.ToString("N2").Replace(",", ".");
                }
                else
                {
                    txtod_gp_cil.Text = GlCil.ToString("N2").Replace(",", ".");
                }

            }

        }

        private void txtoe_adicao_Validated(object sender, EventArgs e)
        {
            EsfCilAd_Validated(sender, e);

            if (!string.IsNullOrEmpty(txtoe_adicao.Text))
            {
                decimal Esferico = 0;
                decimal Cilindro = 0;
                decimal Adicao = 0;
                decimal GlEsf = 0;
                decimal GlCil = 0;

                if (!string.IsNullOrEmpty(txtoe_gl_esf.Text))
                {
                    Esferico = Convert.ToDecimal(txtoe_gl_esf.Text.Substring(1, txtoe_gl_esf.Text.Length - 1).Replace(".", ","));
                    if (txtoe_gl_esf.Text.Substring(0, 1) == "-")
                    {
                        Esferico = Esferico * -1;
                    }
                }

                if (!string.IsNullOrEmpty(txtoe_gl_cil.Text))
                {
                    Cilindro = Convert.ToDecimal(txtoe_gl_cil.Text.Substring(1, txtoe_gl_cil.Text.Length - 1).Replace(".", ","));
                    if (txtoe_gl_cil.Text.Substring(0, 1) == "-")
                    {
                        Cilindro = Cilindro * -1;
                    }
                }

                if (!string.IsNullOrEmpty(txtoe_adicao.Text))
                {
                    Adicao = Convert.ToDecimal(txtoe_adicao.Text.Substring(1, txtoe_adicao.Text.Length - 1).Replace(".", ","));
                    if (txtoe_adicao.Text.Substring(0, 1) == "-")
                    {
                        Adicao = Adicao * -1;
                    }
                }
                GlEsf = Esferico + Adicao;
                GlCil = Cilindro;
                if (GlEsf > 0)
                {
                    txtoe_gp_esf.Text = "+" + GlEsf.ToString("N2").Replace(",", ".");
                }
                else
                {
                    txtoe_gp_esf.Text = GlEsf.ToString("N2").Replace(",", ".");
                }

                if (GlCil > 0)
                {
                    txtoe_gp_cil.Text = "+" + GlCil.ToString("N2").Replace(",", ".");
                }
                else
                {
                    txtoe_gp_cil.Text = GlCil.ToString("N2").Replace(",", ".");
                }
            }
        }

        private void EsfCilAd_Validating(object sender, CancelEventArgs e)
        {
            decimal ret = 0;
            bool exibemsg = false;
            if (((TextBox)sender).Text.Length == 1)
            {
                if ((((TextBox)sender).Text == "+") || (((TextBox)sender).Text == "-"))
                {
                    exibemsg = true;
                }
            }
            else if (((TextBox)sender).Text.Length > 1)
            {
                if (((((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - 1)) == "+") ||
                    ((((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - 1)) == "-"))
                {
                    if (!Utils.StringExtensions.IsNumeric(((TextBox)sender).Text.Substring(1, ((TextBox)sender).Text.Length - 1)))
                    {
                        exibemsg = true;
                    }
                }
                else if (!decimal.TryParse(((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length).Replace(".", ","), out ret))
                {
                    exibemsg = true;
                }
            }

            if (exibemsg)
            {
                epValidaDados.SetError(((TextBox)sender), "Valor informado inválido.");
                e.Cancel = true;
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox)
            {
                ((MaskedTextBox)sender).Select(0, 0);
            }
            else if (sender is TextBox)
            {
                ((TextBox)sender).Select(0, 0);
            }

        }

        protected override void Limpar(Control control)
        {
            base.Limpar(control);
            
            txtCodCliIntegracao.Focus();

        }

        private void txtDiagonal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) &&
                !e.KeyChar.Equals('.') &&
                !e.KeyChar.Equals(',') &&
                !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtod_gl_esf_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_gl_cil, e);
        }

        private void txtod_gl_cil_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_eixo, e);
        }

        private void navegaProximo(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                ((TextBox)sender).Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtod_eixo_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_adicao, e);
        }

        private void txtod_adicao_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_gp_esf, e);
        }

        private void txtod_gp_esf_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_gp_cil, e);
        }

        private void txtod_gp_cil_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_gl_esf, e);
        }

        private void txtoe_gl_esf_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_gl_cil, e);
        }

        private void txtoe_gl_cil_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_eixo, e);
        }

        private void txtoe_eixo_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_adicao, e);
        }

        private void txtoe_adicao_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_gp_esf, e);
        }

        private void txtoe_gp_esf_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_gp_cil, e);
        }

        private void txtod_dnp_longe_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_dnp_perto, e);
        }

        private void txtod_dnp_perto_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_alt, e);
        }

        private void txtod_alt_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_dech, e);
        }

        private void txtod_dech_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_prisma_valor, e);
        }

        private void txtod_prisma_valor_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtod_prisma_eixo, e);
        }

        private void txtoe_dnp_longe_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_dnp_perto, e);
        }

        private void txtod_prisma_eixo_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_dnp_longe, e);
        }

        private void txtoe_dnp_perto_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_alt, e);
        }

        private void txtoe_alt_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_dech, e);
        }

        private void txtoe_dech_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_prisma_valor, e);
        }

        private void txtoe_prisma_valor_KeyDown(object sender, KeyEventArgs e)
        {
            navegaProximo(txtoe_prisma_eixo, e);
        }

        private void dgvItemPedido_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            AtualizaTotal();
        }

        private void AtualizaTotal()
        {
            decimal Valor_Total = 0;
            for (int i = 0; i < dgvItemPedido.RowCount; i++)
            {
                if (dgvItemPedido[col_VlrTotal, i].Value != null)
                {
                    Valor_Total += Convert.ToDecimal(dgvItemPedido[col_VlrTotal, i].Value);
                }
            }

            txtValorTotal.Text = Valor_Total.ToString("N2");
        }

        private void frmCadEditPedido_Laboratorio_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
