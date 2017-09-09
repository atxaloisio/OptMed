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
    public partial class frmRelFiltroPedido_Otica : optmed.frmBaseRelFiltro
    {
        public frmRelFiltroPedido_Otica()
        {
            InitializeComponent();
        }

        private void btnPesquisaPedidoDe_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaPedido(txtCodPedidoDe);
        }

        private void ExecutaPesquisaPedido(TextBox txtCod, TextBox txtDesc = null)
        {
            frmPesquisaPedido_Otica pesquisa = new frmPesquisaPedido_Otica();
            if (pesquisa.ExibeDialogo(txtCod.Text) == DialogResult.OK)
            {
                if (pesquisa.Id != null)
                {
                    txtCod.Text = pesquisa.Id.ToString();
                }
            }
        }

        private void btnPesquisaPedidoAte_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaPedido(txtCodPedidoAte);
            txtDtEmissaoDe.Focus();
        }

        private void btnPesquisaClienteDe_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaCliente(txtIdClienteDe, txtCodClienteDe, txtNomeClienteDe);
            if (!string.IsNullOrEmpty(txtIdClienteDe.Text))
            {
                txtIdClienteAte.Text = txtIdClienteDe.Text;
                txtCodClienteAte.Text = txtCodClienteDe.Text;
                txtNomeClienteAte.Text = txtNomeClienteDe.Text;
            }
            txtCodClienteAte.Focus();
        }

        private void ExecutaPesquisaCliente(TextBox txtId, TextBox txtCod, TextBox txtDesc = null)
        {
            frmPesquisaClientes pesquisa = new frmPesquisaClientes();
            if (pesquisa.ExibeDialogo(txtCod.Text) == DialogResult.OK)
            {
                if (pesquisa.Id != null)
                {
                    LoadDadosCliente(pesquisa.Id, string.Empty, txtId, txtCod, txtDesc);
                }
            }
        }

        private void ExecutaPesquisaTransportadora(TextBox txtId, TextBox txtCod, TextBox txtDesc = null)
        {
            frmPesquisaTransportadora pesquisa = new frmPesquisaTransportadora();
            if (pesquisa.ExibeDialogo(txtCod.Text) == DialogResult.OK)
            {
                if (pesquisa.Id != null)
                {
                    LoadDadosCliente(pesquisa.Id, string.Empty, txtId, txtCod, txtDesc);
                }
            }
        }

        private void btnPesquisaClienteAte_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaCliente(txtIdClienteAte, txtCodClienteAte, txtNomeClienteAte);
        }

        private void btnPesquisaTransportadoraDe_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaTransportadora(txtIdTransportadoraDe, txtCodTransportadoraDe, txtNomeTransportadoraDe);
        }

        private void btnPesquisaTransportadoraAte_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaTransportadora(txtIdTransportadoraAte, txtCodTransportadoraAte, txtNomeTransportadoraAte);
        }

        private void LoadDadosCliente(long? id, string codCliente = "", TextBox txtId = null, TextBox txtCod = null, TextBox txtDesc = null)
        {
            ClienteBLL clienteBLL = new ClienteBLL();

            List<Cliente> ClienteList = new List<Cliente>();

            if (id != null)
            {
                ClienteList = clienteBLL.getCliente(id, true);
            }
            else if (!string.IsNullOrEmpty(codCliente))
            {
                ClienteList = clienteBLL.getCliente(p => p.codigo_cliente_integracao == codCliente, true);
            }

            if (ClienteList.Count() > 0)
            {
                Cliente cliente = ClienteList.FirstOrDefault();
                if (txtCod != null)
                {
                    txtCod.Text = cliente.codigo_cliente_integracao;
                    txtDesc.Text = cliente.razao_social;
                    txtId.Text = cliente.Id.ToString();
                }
            }
        }

        private void ExecutaPesquisaVendedor(TextBox txtCod, TextBox txtDesc = null)
        {
            frmPesquisaVendedor pesquisa = new frmPesquisaVendedor();
            if (pesquisa.ExibeDialogo(txtCod.Text) == DialogResult.OK)
            {
                if (pesquisa.Id != null)
                {
                    VendedorBLL VendedorBLL = new VendedorBLL();
                    Vendedor Vendedor = VendedorBLL.Localizar(pesquisa.Id);
                    if (Vendedor != null)
                    {
                        txtCod.Text = Vendedor.Id.ToString();
                        txtDesc.Text = Vendedor.nome;
                    }
                }
            }
        }

        private void btnPesquisaVendedorDe_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaVendedor(txtCodVendedorDe, txtNomeVendedorDe);
        }

        private void btnPesquisaVendedorAte_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaVendedor(txtCodVendedorAte, txtNomeVendedorAte);
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

        public override void ConfigurarForm(Form pFormParent)
        {
            base.ConfigurarForm(pFormParent);
            SetupControls();

        }

        private void SetupControls()
        {
            SetupCaixa(cbCaixaDe);
            SetupCaixa(cbCaixaAte);
            SetupStatus(cbStatusDe);
            SetupStatus(cbStatusAte);
            SetupTransportadora();
            setupcbFilial();
        }

        private void setupcbFilial()
        {
            if (stUsuario.UsuarioLogado.Id_filial == null)
            {
                FilialBLL filialBLL = new FilialBLL();
                List<Filial> lstFilial = filialBLL.getFilial();
                cbFilial.DataSource = lstFilial;
                cbFilial.ValueMember = "Id";
                cbFilial.DisplayMember = "nome_fantasia";
                cbFilial.SelectedIndex = -1;
                if (lstFilial.Count <= 0)
                {
                    cbFilial.Enabled = false;
                    gbFilial.Visible = false;
                }
                else
                {
                    cbFilial.Enabled = true;
                    gbFilial.Visible = true;
                }
            }
            
        }

        private void SetupTransportadora()
        {
            bool vwLaboratorio = false;
            string layoutLaboratorio = Parametro.GetParametro("layoutLaboratorio");
            if (!string.IsNullOrEmpty(layoutLaboratorio))
            {
                vwLaboratorio = Convert.ToBoolean(layoutLaboratorio);
            }

            gbCaixa.Visible = vwLaboratorio;
            gbCaixa.Enabled = vwLaboratorio;
            gbTransportadora.Visible = vwLaboratorio;
            gbTransportadora.Enabled = vwLaboratorio;
        }

        private void SetupStatus(ComboBox cb)
        {
            StatusPedido sp = new StatusPedido();
            IList<itemEnumList> lstStatusPedido = Enumerados.getListEnum(sp);

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (itemEnumList item in lstStatusPedido)
            {
                acc.Add(item.descricao);
            }

            cb.DataSource = lstStatusPedido;
            cb.ValueMember = "chave";
            cb.DisplayMember = "descricao";
            cb.SelectedIndex = -1;


        }

        private void SetupCaixa(ComboBox cb)
        {
            CaixaBLL caixaBLL = new CaixaBLL();

            List<Caixa> CaixaList = caixaBLL.getCaixa();

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (Caixa item in CaixaList)
            {
                acc.Add(item.numero);
            }

            cb.DataSource = CaixaList;
            cb.AutoCompleteCustomSource = acc;
            cb.ValueMember = "Id";
            cb.DisplayMember = "numero";
            cb.SelectedIndex = -1;
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
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

        protected override void imprimirRegistro(object sender, EventArgs e)
        {
            base.imprimirRegistro(sender, e);

            frmRelListPedido_Otica frm = new frmRelListPedido_Otica();

            if (!string.IsNullOrEmpty(txtCodPedidoDe.Text))
            {
                frm.pedidoDe = Convert.ToInt64(txtCodPedidoDe.Text);
            }

            if (!string.IsNullOrEmpty(txtCodPedidoAte.Text))
            {
                frm.pedidoAte = Convert.ToInt64(txtCodPedidoAte.Text);
            }

            if (!string.IsNullOrEmpty(txtCodClienteDe.Text))
            {
                frm.clienteDe = Convert.ToInt64(txtIdClienteDe.Text);
            }

            if (!string.IsNullOrEmpty(txtCodClienteAte.Text))
            {
                frm.clienteAte = Convert.ToInt64(txtIdClienteAte.Text);
            }

            if (ValidateUtils.isDate(txtDtEmissaoDe.Text))
            {
                frm.data_emissaoDe = Convert.ToDateTime(txtDtEmissaoDe.Text);
            }

            if (ValidateUtils.isDate(txtDtEmissaoAte.Text))
            {
                frm.data_emissaoAte = Convert.ToDateTime(txtDtEmissaoAte.Text);
            }

            if (ValidateUtils.isDate(txtDtFechamentoDe.Text))
            {
                frm.data_fechamentoDe = Convert.ToDateTime(txtDtFechamentoDe.Text);
            }

            if (ValidateUtils.isDate(txtDtFechamentoAte.Text))
            {
                frm.data_fechamentoAte = Convert.ToDateTime(txtDtFechamentoAte.Text);
            }

            if (!string.IsNullOrEmpty(txtIdTransportadoraDe.Text))
            {
                frm.transportadoraDe = Convert.ToInt64(txtIdTransportadoraDe.Text);
            }

            if (!string.IsNullOrEmpty(txtIdTransportadoraAte.Text))
            {
                frm.transportadoraAte = Convert.ToInt64(txtIdTransportadoraAte.Text);
            }

            if (!string.IsNullOrEmpty(txtCodVendedorDe.Text))
            {
                frm.vendedorDe = Convert.ToInt64(txtNomeVendedorDe.Text);
            }

            if (!string.IsNullOrEmpty(txtCodVendedorAte.Text))
            {
                frm.vendedorAte = Convert.ToInt64(txtNomeVendedorAte.Text);
            }

            if (cbCaixaDe.SelectedValue != null)
            {
                frm.caixaDe = (int)cbCaixaDe.SelectedValue;
            }

            if (cbCaixaAte.SelectedValue != null)
            {
                frm.caixaAte = (int)cbCaixaAte.SelectedValue;
            }

            frm.nrpedclienteDe = null;
            if (!string.IsNullOrEmpty(txtNrPedClienteDe.Text))
            {
                frm.nrpedclienteDe = txtNrPedClienteDe.Text;
            }

            frm.nrpedclienteAte = null;
            if (!string.IsNullOrEmpty(txtNrPedClienteAte.Text))
            {
                frm.nrpedclienteAte = txtNrPedClienteAte.Text;
            }

            if (cbStatusDe.SelectedValue != null)
            {
                frm.statusDe = (int)cbStatusDe.SelectedValue;
            }

            if (cbStatusAte.SelectedValue != null)
            {
                frm.statusAte = (int)cbStatusAte.SelectedValue;
            }

            if (stUsuario.UsuarioLogado.Id_empresa != null)
            {
                frm.empresa = stUsuario.UsuarioLogado.Id_empresa;
            }

            if (stUsuario.UsuarioLogado.Id_filial != null)
            {
                frm.filial = stUsuario.UsuarioLogado.Id_filial;
            }
            else
            {
                if (gbFilial.Visible)
                {
                    if (cbFilial.SelectedValue != null)
                    {
                        frm.filial = Convert.ToInt64(cbFilial.SelectedValue);
                    }
                }
            }

            frm.ExibeDialogo();
        }

        private void txtCodClienteDe_TextChanged(object sender, EventArgs e)
        {
            txtNomeClienteDe.Text = string.Empty;
            txtIdClienteDe.Text = string.Empty;
        }

        private void txtCodClienteAte_TextChanged(object sender, EventArgs e)
        {
            txtNomeClienteAte.Text = string.Empty;
            txtIdClienteAte.Text = string.Empty;
        }

        private void txtCodTransportadoraDe_TextChanged(object sender, EventArgs e)
        {
            txtNomeTransportadoraDe.Text = string.Empty;
            txtIdTransportadoraDe.Text = string.Empty;
        }

        private void txtCodTransportadoraAte_TextChanged(object sender, EventArgs e)
        {
            txtNomeTransportadoraAte.Text = string.Empty;
            txtIdTransportadoraAte.Text = string.Empty;
        }

        private void txtCodPedidoDe_Validated(object sender, EventArgs e)
        {
            txtCodPedidoAte.Text = txtCodPedidoDe.Text;
        }

        private void txtCodClienteDe_Validated(object sender, EventArgs e)
        {
            txtCodClienteAte.Text = txtCodClienteDe.Text;
            txtNomeClienteAte.Text = txtNomeClienteDe.Text;
            txtIdClienteAte.Text = txtIdClienteDe.Text;
        }

        private void txtDtEmissaoDe_Validated(object sender, EventArgs e)
        {
            txtDtEmissaoAte.Text = txtDtEmissaoDe.Text;
        }

        private void txtDtFechamentoDe_Validated(object sender, EventArgs e)
        {
            txtDtFechamentoAte.Text = txtDtFechamentoDe.Text;
        }

        private void txtCodVendedorDe_Validated(object sender, EventArgs e)
        {
            txtCodVendedorAte.Text = txtCodVendedorDe.Text;
        }

        private void txtCodTransportadoraDe_Validated(object sender, EventArgs e)
        {
            txtCodTransportadoraAte.Text = txtCodTransportadoraDe.Text;
        }

        private void cbCaixaDe_Validated(object sender, EventArgs e)
        {
            if (cbCaixaDe.SelectedValue != null)
                cbCaixaAte.SelectedValue = cbCaixaDe.SelectedValue;
        }

        private void txtNrPedClienteDe_Validated(object sender, EventArgs e)
        {
            txtNrPedClienteAte.Text = txtNrPedClienteDe.Text;
        }

        private void cbStatusDe_Validated(object sender, EventArgs e)
        {
            if (cbStatusDe.SelectedValue != null)
                cbStatusAte.SelectedValue = cbStatusDe.SelectedValue;
        }

        private void frmRelFiltroPedido_Otica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void txtCodClienteDe_Validating(object sender, CancelEventArgs e)
        {
            Cliente_Validating(null, ((TextBox)sender).Text, txtIdClienteDe, txtCodClienteDe, txtNomeClienteDe);
        }

        private void Cliente_Validating(long? id, string codCliente = "", TextBox txtId = null, TextBox txtCod = null, TextBox txtDesc = null)
        {
            if (!string.IsNullOrEmpty(txtCod.Text))
            {
                if (txtCod.Text.Where(c => char.IsNumber(c)).Count() > 0)
                {
                    LoadDadosCliente(null, codCliente, txtId, txtCod, txtDesc);
                    if (string.IsNullOrEmpty(txtDesc.Text))
                    {
                        ExecutaPesquisaCliente(txtId, txtCod, txtDesc);
                    }
                }
                else
                {
                    ExecutaPesquisaCliente(txtId, txtCod, txtDesc);
                }

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Cliente Código: " + txtCod.Text + " inexistente. ", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCod.Focus();
                }
            }
        }

        private void txtCodClienteAte_Validating(object sender, CancelEventArgs e)
        {
            Cliente_Validating(null, ((TextBox)sender).Text, txtIdClienteAte, txtCodClienteAte, txtNomeClienteAte);
        }

        private void Transportadora_Validating(long? id, string codCliente = "", TextBox txtId = null, TextBox txtCod = null, TextBox txtDesc = null)
        {
            if (!string.IsNullOrEmpty(txtCod.Text))
            {
                if (txtCod.Text.Where(c => char.IsNumber(c)).Count() > 0)
                {
                    LoadDadosCliente(null, codCliente, txtId, txtCod, txtDesc);
                    if (string.IsNullOrEmpty(txtDesc.Text))
                    {
                        ExecutaPesquisaTransportadora(txtId, txtCod, txtDesc);
                    }
                }
                else
                {
                    ExecutaPesquisaTransportadora(txtId, txtCod, txtDesc);
                }

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Transportadora Código: " + txtCod.Text + " inexistente. ", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCod.Focus();
                }
            }
        }

        private void txtCodTransportadoraDe_Validating(object sender, CancelEventArgs e)
        {
            Transportadora_Validating(null, ((TextBox)sender).Text, txtIdTransportadoraDe, txtCodTransportadoraDe, txtNomeTransportadoraDe);
        }

        private void txtCodTransportadoraAte_Validating(object sender, CancelEventArgs e)
        {
            Transportadora_Validating(null, ((TextBox)sender).Text, txtIdTransportadoraAte, txtCodTransportadoraAte, txtNomeTransportadoraAte);
        }

        private void frmRelFiltroPedido_Otica_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
