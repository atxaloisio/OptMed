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
    public partial class frmCadEditCliente_Vendedor : optmed.frmBaseCadEdit
    {
        private ClienteBLL clienteBLL;
        private VendedorBLL vendedorBLL;
        private Cliente_VendedorBLL Cliente_VendedorBLL;
        
        public frmCadEditCliente_Vendedor()
        {
            InitializeComponent();
            if (Cliente_VendedorBLL == null)
            {
                Cliente_VendedorBLL = new Cliente_VendedorBLL();
                Cliente_VendedorBLL.UsuarioLogado = Program.usuario_logado;
            }
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {

                Cliente_Vendedor Cliente_Vendedor = Cliente_VendedorBLL.Localizar(Id);

                if (Cliente_Vendedor != null)
                {
                    txtCodCliIntegracao.Text = Cliente_Vendedor.cliente.codigo_cliente_integracao;
                    txtClienteNome.Text = Cliente_Vendedor.cliente.nome_fantasia;
                    txtIdCliente.Text = Cliente_Vendedor.Id_cliente.ToString();
                    cbVendedor.SelectedValue = Cliente_Vendedor.Id_Vendedor;
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
                    Cliente_VendedorBLL.UsuarioLogado = Program.usuario_logado;

                    Cliente_Vendedor Cliente_Vendedor = LoadFromControls();

                    if (Id != null)
                    {
                        Cliente_VendedorBLL.AlterarCliente_Vendedor(Cliente_Vendedor);
                    }
                    else
                    {
                        Cliente_VendedorBLL.AdicionarCliente_Vendedor(Cliente_Vendedor);
                    }

                    if (Cliente_Vendedor.Id != 0)
                    {
                        Id = Cliente_Vendedor.Id;
                        txtId.Text = Cliente_Vendedor.Id.ToString();
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

        protected virtual Cliente_Vendedor LoadFromControls()
        {
            Cliente_Vendedor Cliente_Vendedor = new Cliente_Vendedor();

            if (Id != null)
            {
                Cliente_Vendedor = Cliente_VendedorBLL.Localizar(Id);
            }

            Cliente_Vendedor.Id_cliente = Convert.ToInt64(txtIdCliente.Text);
            Cliente_Vendedor.Id_Vendedor= Convert.ToInt32(cbVendedor.SelectedValue);            

            return Cliente_Vendedor;
        }

        protected override void SetupControls()
        {
            SetupCondPagamento();
        }

        private void SetupCondPagamento()
        {
            vendedorBLL = new VendedorBLL();
            cbVendedor.DataSource = vendedorBLL.getVendedor();
            cbVendedor.ValueMember = "Id";
            cbVendedor.DisplayMember = "nome";
            cbVendedor.SelectedIndex = -1;
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
                        if (cliente.cliente_vendedor.Count >0)
                        {
                            Id = cliente.cliente_vendedor.FirstOrDefault().Id;
                            txtId.Text = Convert.ToString(Id);
                            cbVendedor.SelectedValue = cliente.cliente_vendedor.FirstOrDefault().Id_Vendedor;
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
                if (cliente.cliente_vendedor.Count > 0)
                {
                    Id = cliente.cliente_vendedor.FirstOrDefault().Id;
                    txtId.Text = Convert.ToString(Id);
                    cbVendedor.SelectedValue = cliente.cliente_vendedor.FirstOrDefault().Id_Vendedor;
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
    }
}
