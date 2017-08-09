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
    public partial class frmCadEditCliente_Transportadora : optmed.frmBaseCadEdit
    {
        private ClienteBLL clienteBLL;
        private Cliente_TransportadoraBLL Cliente_TransportadoraBLL;
        
        public frmCadEditCliente_Transportadora()
        {
            InitializeComponent();
            if (Cliente_TransportadoraBLL == null)
            {
                Cliente_TransportadoraBLL = new Cliente_TransportadoraBLL();
                Cliente_TransportadoraBLL.UsuarioLogado = Program.usuario_logado;
            }
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {

                Cliente_Transportadora Cliente_Transportadora = Cliente_TransportadoraBLL.Localizar(Id);

                if (Cliente_Transportadora != null)
                {
                    txtCodCliIntegracao.Text = Cliente_Transportadora.Cliente.codigo_cliente_integracao;
                    txtClienteNome.Text = Cliente_Transportadora.Cliente.nome_fantasia;
                    txtIdCliente.Text = Cliente_Transportadora.Id_cliente.ToString();
                    cbTransportadora.SelectedValue = Cliente_Transportadora.Id_transportadora;
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
                    Cliente_TransportadoraBLL.UsuarioLogado = Program.usuario_logado;

                    Cliente_Transportadora Cliente_Transportadora = LoadFromControls();

                    if (Id != null)
                    {
                        Cliente_TransportadoraBLL.AlterarCliente_Transportadora(Cliente_Transportadora);
                    }
                    else
                    {
                        Cliente_TransportadoraBLL.AdicionarCliente_Transportadora(Cliente_Transportadora);
                    }

                    if (Cliente_Transportadora.Id != 0)
                    {
                        Id = Cliente_Transportadora.Id;
                        txtId.Text = Cliente_Transportadora.Id.ToString();
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

        protected virtual Cliente_Transportadora LoadFromControls()
        {
            Cliente_Transportadora Cliente_Transportadora = new Cliente_Transportadora();

            if (Id != null)
            {
                Cliente_Transportadora = Cliente_TransportadoraBLL.Localizar(Id);
            }

            Cliente_Transportadora.Id_cliente = Convert.ToInt64(txtIdCliente.Text);
            Cliente_Transportadora.Id_transportadora= Convert.ToInt32(cbTransportadora.SelectedValue);            

            return Cliente_Transportadora;
        }

        protected override void SetupControls()
        {
            SetupCondPagamento();
        }

        private void SetupCondPagamento()
        {
            clienteBLL = new ClienteBLL();
            cbTransportadora.DataSource = clienteBLL.getCliente(x => x.cliente_tag.Any(e => e.tag == "Transportadora"));
            cbTransportadora.ValueMember = "Id";
            cbTransportadora.DisplayMember = "nome_fantasia";
            cbTransportadora.SelectedIndex = -1;
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
                        if (cliente.cliente_transportadora.Count >0)
                        {
                            Id = cliente.cliente_transportadora.FirstOrDefault().Id;
                            txtId.Text = Convert.ToString(Id);
                            cbTransportadora.SelectedValue = cliente.cliente_transportadora.FirstOrDefault().Id_transportadora;
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
                if (cliente.cliente_transportadora.Count > 0)
                {
                    Id = cliente.cliente_transportadora.FirstOrDefault().Id;
                    txtId.Text = Convert.ToString(Id);
                    cbTransportadora.SelectedValue = cliente.cliente_transportadora.FirstOrDefault().Id_transportadora;
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
