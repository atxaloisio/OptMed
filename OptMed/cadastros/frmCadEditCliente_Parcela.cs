using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using System.Linq;

namespace optmed
{
    public partial class frmCadEditCliente_Parcela : optmed.frmBaseCadEdit
    {
        private ClienteBLL clienteBLL;
        private Cliente_ParcelaBLL cliente_ParcelaBLL;
        private ParcelaBLL parcelaBLL;

        public frmCadEditCliente_Parcela()
        {
            InitializeComponent();
            if (cliente_ParcelaBLL == null)
            {
                cliente_ParcelaBLL = new Cliente_ParcelaBLL();
                cliente_ParcelaBLL.UsuarioLogado = Program.usuario_logado;
            }
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {

                Cliente_Parcela cliente_Parcela = cliente_ParcelaBLL.Localizar(Id);

                if (cliente_Parcela != null)
                {
                    txtCodCliIntegracao.Text = cliente_Parcela.cliente.codigo_cliente_integracao;
                    txtClienteNome.Text = cliente_Parcela.cliente.nome_fantasia;
                    txtIdCliente.Text = cliente_Parcela.Id_cliente.ToString();
                    cbCondPagamento.SelectedValue = cliente_Parcela.Id_parcela;
                }
            }
        }

        protected override bool salvar(object sender, EventArgs e)
        {
            bool Retorno = epValidaDados.Validar(true);

            if (Retorno)
            {
                try
                {
                    cliente_ParcelaBLL.UsuarioLogado = Program.usuario_logado;

                    Cliente_Parcela cliente_Parcela = LoadFromControls();

                    if (Id != null)
                    {
                        cliente_ParcelaBLL.AlterarCliente_Parcela(cliente_Parcela);
                    }
                    else
                    {
                        cliente_ParcelaBLL.AdicionarCliente_Parcela(cliente_Parcela);
                    }

                    if (cliente_Parcela.Id != 0)
                    {
                        Id = cliente_Parcela.Id;
                        txtId.Text = cliente_Parcela.Id.ToString();
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

        protected virtual Cliente_Parcela LoadFromControls()
        {
            Cliente_Parcela cliente_Parcela = new Cliente_Parcela();

            if (Id != null)
            {
                cliente_Parcela = cliente_ParcelaBLL.Localizar(Id);
            }

            cliente_Parcela.Id_cliente = Convert.ToInt64(txtIdCliente.Text);
            cliente_Parcela.Id_parcela = Convert.ToInt32(cbCondPagamento.SelectedValue);
            cliente_Parcela.descricao = cbCondPagamento.Text;

            return cliente_Parcela;
        }

        protected override void SetupControls()
        {
            SetupCondPagamento();
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
                        if (cliente.cliente_parcela.Count >0)
                        {
                            Id = cliente.cliente_parcela.FirstOrDefault().Id;
                            txtId.Text = Convert.ToString(Id);
                            cbCondPagamento.SelectedValue = cliente.cliente_parcela.FirstOrDefault().Id_parcela;
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
                if (cliente.cliente_parcela.Count > 0)
                {
                    cbCondPagamento.SelectedValue = cliente.cliente_parcela.First().Id_parcela;
                    Id = cliente.cliente_parcela.FirstOrDefault().Id;
                    txtId.Text = Convert.ToString(Id);
                    cbCondPagamento.SelectedValue = cliente.cliente_parcela.FirstOrDefault().Id_parcela;
                }
            }
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

        protected override void Limpar(Control control)
        {
            base.Limpar(control);

            txtCodCliIntegracao.Focus();
        }

        private void frmCadEditCliente_Parcela_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
