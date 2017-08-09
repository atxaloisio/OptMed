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
    public partial class frmUtilCancelarPedido : optmed.frmBaseCadEdit
    {
        private ClienteBLL clienteBLL;       
        private ParcelaBLL parcelaBLL;
        private Motivo_EntregaBLL motivo_EntregaBLL;
        private Pedido_OticaBLL pedido_OticaBLL;
        private VendedorBLL vendedorBLL;        
        private CaixaBLL caixaBLL;
                
        public frmUtilCancelarPedido()
        {
            InitializeComponent();
        }

        protected override void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                atualizagrid = true;
                if (ValidaAcessoFuncao(Operacao.Cancelar))
                {
                    if (salvar(sender, e))
                    {                        
                        MessageBox.Show(Text + " Pedido cancelado com sucesso.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }


            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            }
        }

        private bool ValidaDadosEspecifico()
        {            
            bool retorno = true;

            pedido_OticaBLL = new Pedido_OticaBLL();
            try
            {
                Pedido_Otica pedido_Otica = pedido_OticaBLL.Localizar(Id);

                if (pedido_Otica.status > (int)StatusPedido.AENTREGAR)
                {
                    string mensagem = string.Empty;
                    if (pedido_Otica.status == (int)StatusPedido.SAIUPENTREGA)
                    {
                        mensagem = "Pedido: " + pedido_Otica.codigo + " Não pode ser cancelado pois encontra-se em rota de entrega.";
                    }

                    if (pedido_Otica.status == (int)StatusPedido.ENTREGUE)
                    {
                        mensagem = "Pedido: " + pedido_Otica.codigo + " Não pode ser cancelado pois consta como entregue.";
                    }

                    if (pedido_Otica.status == (int)StatusPedido.AGRUPADO)
                    {
                        mensagem = "Pedido: " + pedido_Otica.codigo + " Não pode ser cancelado pois consta como agrupado.";
                    }

                    if (pedido_Otica.status == (int)StatusPedido.FATURADO)
                    {
                        mensagem = "Pedido: " + pedido_Otica.codigo + " Não pode ser cancelado pois consta como faturado.";
                    }

                    if (string.IsNullOrEmpty(txtMotivoCancelamento.Text))
                    {
                        mensagem = "Pedido: " + pedido_Otica.codigo + " Motivo de cancelamento obrigatório";
                    }
                    else if (txtMotivoCancelamento.Text.Length < 20)
                    {
                        mensagem = "Pedido: " + pedido_Otica.codigo + " Motivo de cancelamento com descrição insuficiente. \n Minimo 20 Caracteres";
                    }

                    if (!string.IsNullOrEmpty(mensagem))
                    {
                        MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        retorno = false;
                    }
                }
            }
            finally
            {
                pedido_OticaBLL.Dispose();
            }
            



            return retorno;
        }

        protected override bool salvar(object sender, EventArgs e)
        {
            bool Retorno = epValidaDados.Validar(true);

            Retorno = ValidaDadosEspecifico();
                        
            if (Retorno)
            {
                try
                {
                    pedido_OticaBLL = new Pedido_OticaBLL();
                    pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;

                    Pedido_Otica pedido_Otica = pedido_OticaBLL.Localizar(Id);
                    pedido_Otica.cancelado = "S";
                    pedido_Otica.data_cancelamento = DateTime.Now;
                    pedido_Otica.motivo_cancelamento = txtMotivoCancelamento.Text;


                    if (MessageBox.Show("Deseja realmente cancelar o pedido otica: " + pedido_Otica.codigo + " - " + 
                        pedido_Otica.cliente.nome_fantasia, Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pedido_OticaBLL.AlterarPedido_Otica(pedido_Otica);
                        Retorno = true;
                    }
                    else
                    {
                        Retorno = false;
                    }                                                                                   
                }
                catch (Exception ex)
                {
                    Retorno = false;
                    throw ex;
                }
            }
            return Retorno;
        }

        protected override void SetupControls()
        {
            SetupCondPagamento();
            SetupCaixa();
            SetupTransportadora();
            SetupVendedor();
            SetupMotivoEntrega();            
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

        private void txtMotivoCancelamento_Validating(object sender, CancelEventArgs e)
        {
           
        }
    }
}
