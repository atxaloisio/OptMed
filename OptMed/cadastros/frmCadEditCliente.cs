using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Model;
using BLL;
using System.Linq;
using Sync;
using Utils;

namespace optmed
{
    public partial class frmCadEditCliente : optmed.frmBaseCadEdit
    {
        private ClienteBLL ClienteBLL;
        private CidadeBLL cidadeBLL;
        
        public frmCadEditCliente()
        {
            InitializeComponent();
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {
                ClienteBLL = new ClienteBLL();

                Cliente Cliente = ClienteBLL.Localizar(Id);

                if (Cliente != null)
                {
                    //Principal
                    txtId.Text = Cliente.Id.ToString();
                    txtCodigo.Text = Cliente.codigo_cliente_omie.ToString();
                    txtCodInt.Text = Cliente.codigo_cliente_integracao;
                    txtRazaoSocial.Text = Cliente.razao_social;
                    txtNomeFantasia.Text = Cliente.nome_fantasia;
                    txtCNPJCPF.Text = Cliente.cnpj_cpf;
                    txtContato.Text = Cliente.contato;

                    if (Cliente.nascimento != null)
                    {
                        txtDtNascimento.Text = Cliente.nascimento.Value.ToShortDateString();
                    }
                    
                    txtDDD.Text = Cliente.telefone1_ddd;
                    txtTelefone.Text = Cliente.telefone1_numero;
                    chkBloqueado.Checked = Cliente.bloqueado == "S";

                    //Endereço
                    txtEndereco.Text = Cliente.endereco;
                    txtNumero.Text = Cliente.endereco_numero;
                    txtBairro.Text = Cliente.bairro;
                    cbUF.Text = Cliente.estado;
                    cbCidade.Text = Cliente.cidade;
                    txtComplemento.Text = Cliente.complemento;
                    txtCEP.TextMaskFormat = MaskFormat.IncludeLiterals;
                    txtCEP.Text = Cliente.cep;
                    txtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    txtObsEndereco.Text = Cliente.obsEndereco;

                    //Telefone Email
                    txtDDD2.Text = Cliente.telefone2_ddd;
                    txtTelefone2.Text = Cliente.telefone2_numero;
                    txtDDDFax.Text = Cliente.fax_ddd;
                    txtFax.Text = Cliente.fax_numero;
                    txtEmail.Text = Cliente.email;
                    txtWebSite.Text = Cliente.homepage;
                    txtObsTelefonesEmail.Text = Cliente.obsTelefonesEmail;

                    txtInscricaoEstadual.Text = Cliente.inscricao_estadual;
                    txtInscricaoMunicipal.Text = Cliente.inscricao_municipal;
                    txtInscricaoSuframa.Text = Cliente.inscricao_suframa;
                    txtCodCnae.Text = Cliente.cnae;

                    txtObservacoes.Text = Cliente.observacao;
                    chkoptantesimples.Checked = Cliente.optante_simples_nacional == "S";

                    imgFotoCliente.Image = ImagemFromDB.GetImagem(Cliente.Id, "cliente_imagem", "id_cliente");
                    imgFotoCliente.Refresh();
                }
            }
        }

        protected override bool salvar(object sender, EventArgs e)
        {
            bool layoutOtica = Convert.ToBoolean(Parametro.GetParametro("layoutOtica"));

            if (layoutOtica)
            {
                epValidaDados.SetObrigatorio(txtCNPJCPF, false);
            }

            bool Retorno = epValidaDados.Validar(true);

            if (Retorno)
            {
                Retorno = ValidaDadosEspecifico();
            }

            if (Retorno)
            {
                try
                {
                    ClienteBLL = new ClienteBLL();
                    ClienteBLL.UsuarioLogado = Program.usuario_logado;

                    ClienteProxy proxy = new ClienteProxy();

                    proxy.usuario = Program.usuario_logado;

                    bool intOmie = Convert.ToBoolean(Parametro.GetParametro("intOmie"));
                    bool updateClienteOmie = Convert.ToBoolean(Parametro.GetParametro("updateClienteOmie"));

                    Cliente Cliente = LoadFromControls();
                    Cliente.sincronizar = "S";

                    if (Id != null)
                    {
                        ClienteBLL.AlterarCliente(Cliente);                        
                    }
                    else
                    {
                        Cliente.codigo_cliente_integracao = Sequence.GetNextVal("sq_cliente_sequence").ToString();
                        TagBLL tagBLL = new TagBLL();
                        Tag tg = tagBLL.getTag("Cliente").FirstOrDefault();
                        Cliente.cliente_tag.Add(new Cliente_Tag { Id_tag = tg.Id, tag = tg.tag1 });
                                                                        
                        ClienteBLL.AdicionarCliente(Cliente);                                             
                    }

                    if ((intOmie) & (updateClienteOmie))
                    {
                        if (Cliente.codigo_cliente_omie <= 0)
                        {
                            proxy.IncluirClientes(Cliente);
                        }
                        else
                        {
                            proxy.AlterarClientes(Cliente);
                        }                        
                    }

                    if (Cliente.Id != 0)
                    {
                        Id = Cliente.Id;
                        txtId.Text = Cliente.Id.ToString();
                    }

                    SalvarImagem(Cliente.Id);

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

        private void SalvarImagem(long Id)
        {
            if (imgFotoCliente.Image != null)
            {                
                ImagemFromDB.setImagem(Id, "cliente_imagem", "id_cliente", imgFotoCliente.Image);
            }
        }

        private bool ValidaDadosEspecifico()
        {
            bool retorno = true;
            List<Cliente> cliList = null;

            bool layoutLaboratorio = Convert.ToBoolean(Parametro.GetParametro("layoutLaboratorio"));

            if (layoutLaboratorio)
            {
                ClienteBLL = new ClienteBLL();
                cliList = ClienteBLL.getCliente(p => p.cnpj_cpf.Contains(txtCNPJCPF.Text), true);
                if (cliList.Count() > 0)
                {
                    if (Id != cliList.FirstOrDefault().Id)
                    {
                        epValidaDados.SetError(txtCNPJCPF, "CNPJ / CPF Já está cadastrado.");
                        MessageBox.Show("CNPJ / CPF Já está cadastrado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        retorno = false;
                    }
                }
            }

            if (Id == null)
            {
                cliList = ClienteBLL.getCliente(p => p.razao_social == txtRazaoSocial.Text & p.cliente_tag.Any(c => c.tag == "Cliente"), true);
                if (cliList.Count() > 0)
                {
                    epValidaDados.SetError(txtRazaoSocial, "Razão social / Nome Completo  informada já está cadastrada.");
                    MessageBox.Show("Razão social / Nome Completo informada já está cadastrada.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    retorno = false;
                }

                if (retorno)
                {
                    cliList = ClienteBLL.getCliente(p => p.nome_fantasia == txtNomeFantasia.Text & p.cliente_tag.Any(c => c.tag == "Cliente"), true);
                    if (cliList.Count() > 0)
                    {
                        epValidaDados.SetError(txtNomeFantasia, "Nome Fantasia / Nome Abreviado informado já está cadastrado.");
                        MessageBox.Show("Nome Fantasia / Nome Abreviado informado já está cadastrado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        retorno = false;
                    }
                }
            }
            

            
            return retorno;
        }

        protected virtual Cliente LoadFromControls()
        {
            Cliente Cliente = new Cliente();

            if (Id != null)
            {
                Cliente = ClienteBLL.getCliente(Id).FirstOrDefault();

                Cliente.Id = Convert.ToInt64(txtId.Text);
                Cliente.codigo_cliente_omie = Convert.ToInt64(txtCodigo.Text);
                Cliente.codigo_cliente_integracao = txtCodInt.Text;
            }

            //Principal            
            Cliente.razao_social = txtRazaoSocial.Text;
            Cliente.nome_fantasia = txtNomeFantasia.Text;
            Cliente.cnpj_cpf = txtCNPJCPF.Text;
            Cliente.contato = txtContato.Text;

            if (!string.IsNullOrEmpty(txtDtNascimento.Text))
            {
                txtDtNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                Cliente.nascimento = Convert.ToDateTime(txtDtNascimento.Text);
                txtDtNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            }

            Cliente.telefone1_ddd = txtDDD.Text;
            Cliente.telefone1_numero = txtTelefone.Text;
            Cliente.bloqueado = chkBloqueado.Checked ? "S" : "N";

            //Endereço
            Cliente.endereco = txtEndereco.Text;
            Cliente.endereco_numero = txtNumero.Text;
            Cliente.bairro = txtBairro.Text;
            Cliente.estado = cbUF.Text;
            Cliente.cidade = cbCidade.Text;
            Cliente.complemento = txtComplemento.Text;
            Cliente.cep = txtCEP.Text;
            Cliente.obsEndereco = txtObsEndereco.Text;

            //Telefone Email
            Cliente.telefone2_ddd = txtDDD2.Text;
            Cliente.telefone2_numero = txtTelefone2.Text;
            Cliente.fax_ddd = txtDDDFax.Text;
            Cliente.fax_numero = txtFax.Text;
            Cliente.email = txtEmail.Text;
            Cliente.homepage = txtWebSite.Text;
            Cliente.obsTelefonesEmail = txtObsTelefonesEmail.Text;

            Cliente.inscricao_estadual = txtInscricaoEstadual.Text;
            Cliente.inscricao_municipal = txtInscricaoMunicipal.Text;
            Cliente.inscricao_suframa = txtInscricaoSuframa.Text;
            Cliente.cnae = txtCodCnae.Text;

            Cliente.observacao = txtObservacoes.Text;
            Cliente.optante_simples_nacional = chkoptantesimples.Checked ? "S" : "N";

            return Cliente;
        }

        protected override void SetupControls()
        {
            SetupUF();
        }

        private void SetupUF()
        {
            cidadeBLL = new CidadeBLL();
            List<string> CidadeList = cidadeBLL.getCidade().OrderBy(p => p.cUF).Select(c => c.cUF).Distinct().ToList();

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (string item in CidadeList)
            {
                acc.Add(item);
            }

            cbUF.DataSource = CidadeList;
            cbUF.AutoCompleteCustomSource = acc;
            cbUF.SelectedIndex = -1;
        }

        private void cbUF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetupCidade(cbUF.SelectedValue.ToString());
        }

        private void SetupCidade(string UF)
        {
            cidadeBLL = new CidadeBLL();
            List<Cidade> CidadeList = cidadeBLL.getCidade(p => p.cUF == UF).OrderBy(p => p.cNome).ToList();
            cbCidade.DataSource = CidadeList;

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            foreach (Cidade item in CidadeList)
            {
                acc.Add(item.cCod);
            }


            cbCidade.AutoCompleteCustomSource = acc;
            cbCidade.ValueMember = "Id";
            cbCidade.DisplayMember = "cCod";
            cbCidade.SelectedIndex = -1;
        }

        private void cbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbUF.Text))
            {
                SetupCidade(cbUF.Text);
            }
        }

        private void cbUF_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((ComboBox)sender).Text))
            {               
                e.Cancel = ((ComboBox)sender).FindString(((ComboBox)sender).Text) < 0;
                if (e.Cancel)
                {
                    MessageBox.Show("Valor digitado não encontrado na lista", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void Limpar(Control control)
        {
            base.Limpar(control);
            imgFotoCliente.Image = null;

            txtRazaoSocial.Focus();
        }

        private void cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void txtCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = true;
                tcCliente.SelectedTab = tpTelefoneEmail;
                tpTelefoneEmail.Show();
                txtDDD2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtWebSite_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = true;
                tcCliente.SelectedTab = tpInscrCnae;
                tpInscrCnae.Show();
                txtInscricaoEstadual.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            string strCPF, strCNPJ = string.Empty;
            bool exibeMsg = false;
            
            if (!string.IsNullOrEmpty(txtCNPJCPF.Text))
            {
                txtCNPJCPF.Text = txtCNPJCPF.Text.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

                if (txtCNPJCPF.Text.Where(c => char.IsNumber(c)).Count() == 11)
                {
                    strCPF = Convert.ToInt64(txtCNPJCPF.Text).ToString(@"000\.000\.000\-00");
                    if (!ValidaCPF.IsCpf(strCPF))
                    {
                        exibeMsg = true;
                    }
                    else
                    {
                        txtCNPJCPF.Text = strCPF;
                    }
                }
                else if (txtCNPJCPF.Text.Where(c => char.IsNumber(c)).Count() >= 14)
                {
                    strCNPJ = Convert.ToInt64(txtCNPJCPF.Text).ToString(@"00\.000\.000\/0000\-00");
                    if (!ValidaCNPJ.IsCnpj(strCNPJ))
                    {
                        exibeMsg = true;
                    }
                    else
                    {
                        txtCNPJCPF.Text = strCNPJ;
                    }
                }
                else
                {
                    exibeMsg = true;
                }

                if (exibeMsg)
                {
                    epValidaDados.SetError(txtCNPJCPF, "CNPJ / CPF inválido.");
                    MessageBox.Show("CNPJ / CPF inválido.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    ClienteBLL = new ClienteBLL();
                    List<Cliente> cliList = ClienteBLL.getCliente(p => p.cnpj_cpf.Contains(txtCNPJCPF.Text));
                    if (cliList.Count() > 0)
                    {
                        if (cliList.FirstOrDefault().Id != Id)
                        {
                            epValidaDados.SetError(txtCNPJCPF, "CNPJ / CPF Já está cadastrado.");
                            MessageBox.Show("CNPJ / CPF Já está cadastrado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void txtCNPJCPF_Validated(object sender, EventArgs e)
        {
            epValidaDados.SetError((TextBox) sender, string.Empty);
        }

        private void txtCNPJCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) & (e.KeyChar != 8) & (e.KeyChar != 13) & (e.KeyChar != 22))
            {
                e.Handled = true;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsNumber(e.KeyChar)) & (e.KeyChar != 8) & (e.KeyChar != 22))
            {
                e.Handled = true;
            }
        }

        private void txtCEP_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCEP.Text))
            {
                txtCEP.TextMaskFormat = MaskFormat.IncludeLiterals;

                //Validar por expressão regular
                Regex re = new Regex(@"^\d{5}-\d{3}$");
                if (!re.IsMatch(txtCEP.Text))
                {
                    epValidaDados.SetError(txtCEP, "Formato do CEP inválido.");
                    MessageBox.Show("Formato do CEP inválido.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                txtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            }
        }

        private void txtCEP_Validated(object sender, EventArgs e)
        {
            epValidaDados.SetError(txtCEP, string.Empty);
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            ExecutaPesquisaCNAE();
        }

        private void ExecutaPesquisaCNAE()
        {
            frmPesquisaCNAE pesquisa = new frmPesquisaCNAE();
            if (pesquisa.ExibeDialogo(txtCodCnae.Text) == DialogResult.OK)
            {
                if (pesquisa.Id != null)
                {
                    CNAEBLL CNAEBLL = new CNAEBLL();
                    CNAE CNAE = CNAEBLL.Localizar(pesquisa.Id);
                    if (CNAE != null)
                    {
                        txtCodCnae.Text = CNAE.codigo;
                        txtDescricaoCnae.Text = CNAE.descricao;
                        chkoptantesimples.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("CNAE não localizado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodCnae.Text = String.Empty;
                }
            }
            else
            {
                txtCodCnae.Focus();
            }
        }

        private void txtCodCnae_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodCnae.Text))
            {
                if (txtCodCnae.Text.Where(c => char.IsNumber(c)).Count() > 0)
                {
                    CNAEBLL CNAEBLL = new CNAEBLL();
                    List<CNAE> CNAEList = CNAEBLL.getCNAE(p => p.codigo == txtCodCnae.Text);
                    if (CNAEList.Count() > 0)
                    {
                        txtCodCnae.Text = CNAEList.FirstOrDefault().codigo;
                        txtDescricaoCnae.Text = CNAEList.FirstOrDefault().descricao;
                    }
                    else
                    {
                        ExecutaPesquisaCNAE();
                    }
                    
                }
                else
                {
                    ExecutaPesquisaCNAE();
                }
            }
        }

        private void txt_Validated(object sender, EventArgs e)
        {
            epValidaDados.SetError((TextBox)sender, string.Empty);
        }

        private void txtTelefone_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((MaskedTextBox)sender).Text))
            {
                string telefone = (((MaskedTextBox)sender).Text.Replace("-", string.Empty));
                int valor = Convert.ToInt32(telefone.Trim());

                switch (((MaskedTextBox)sender).Text.Length)
                {
                    case 8:
                        {
                            ((MaskedTextBox)sender).Text = string.Format("{0:####-####}", valor);
                        }
                        break;
                    case 9:
                        {
                            ((MaskedTextBox)sender).Text = string.Format("{0:#####-####}", valor);
                        }
                        break;
                    default:
                        break;
                }
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

        private void btnCapturaCamera_Click(object sender, EventArgs e)
        {
            CapturaCamera();
        }

        private void CapturaCamera()
        {
            frmUtilCamera camera = new frmUtilCamera();
            if (camera.ExibeDialogo() == DialogResult.OK)
            {
                imgFotoCliente.Image = (Bitmap)camera.imgCaptura.Clone();
            }
            camera.Dispose(); 
        }

        private void btnAbrirImagem_Click(object sender, EventArgs e)
        {
            AbrirImagem();
        }

        private void AbrirImagem()
        {
            if (dlgCaminhoImagem.ShowDialog() == DialogResult.OK)
            {
                imgFotoCliente.Image = Image.FromFile(@dlgCaminhoImagem.FileName);
            }
        }

        private void txtDtNascimento_Validating(object sender, CancelEventArgs e)
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

        private void txtObservacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtObservacoes.AppendText("\r\n");
                txtObservacoes.ScrollToCaret();
                e.SuppressKeyPress = true;
            }
        }
    }
}
