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
using Utils;

namespace optmed
{
    public partial class frmCadEditFilial : optmed.frmBaseCadEdit
    {
        FilialBLL FilialBLL;
        public virtual long Id_Empresa { get; set; }
        public frmCadEditFilial()
        {
            InitializeComponent();
            isDialogo = true;
        }

        protected override void LoadToControls()
        {
            base.LoadToControls();

            if (Id != null)
            {
                FilialBLL = new FilialBLL();
                Filial Filial = FilialBLL.Localizar(Id);

                if (Filial != null)
                {                    
                    txtId.Text = Filial.Id.ToString();

                    if (Filial.codigo_filial != null)
                    {
                        txtCodigo.Text = Filial.codigo_filial.ToString();
                    }

                    txtCodInt.Text = Filial.codigo_filial_integracao;
                    txtRazaoSocial.Text = Filial.razao_social;
                    txtCNPJ.Text = Filial.cnpj;
                    txtNomeFantasia.Text = Filial.nome_fantasia;
                    txtDDD.Text = Filial.telefone1_ddd;
                    txtTelefone.Text = Filial.telefone1_numero;
                    txtEndereco.Text = Filial.endereco;
                    txtNumero.Text = Filial.endereco_numero;
                    txtBairro.Text = Filial.bairro;
                    txtComplemento.Text = Filial.complemento;
                    cbUF.Text = Filial.estado;
                    cbCidade.Text = Filial.cidade;
                    txtCEP.Text = Filial.cep;
                    txtDDD2.Text = Filial.telefone2_ddd;
                    txtTelefone2.Text = Filial.telefone2_numero;
                    txtDDDFax.Text = Filial.fax_ddd;
                    txtFax.Text = Filial.fax_numero;
                    txtEmail.Text = Filial.email;
                    txtWebSite.Text = Filial.website;
                    txtInscricaoEstadual.Text = Filial.inscricao_estadual;
                    txtInscricaoMunicipal.Text = Filial.inscricao_municipal;
                    txtInscricaoSuframa.Text = Filial.inscricao_suframa;
                    txtCodCnae.Text = Filial.cnae;
                    if (!string.IsNullOrEmpty(Filial.cnae))
                    {
                        CNAEBLL CNAEBLL = new CNAEBLL();
                        txtDescricaoCnae.Text = CNAEBLL.getCNAE(p => p.codigo == Filial.cnae).FirstOrDefault().descricao;
                    }

                    if (Filial.regime_tributario != null)
                    {
                        cbRegimeTributario.SelectedValue = Filial.regime_tributario;
                    }

                    if (Filial.data_adesao_sn != null)
                    {
                        txtDtSimplNac.Text = Filial.data_adesao_sn.Value.ToShortDateString();
                    }

                    imgLogoEmp.Image = ImagemFromDB.GetImagem(Filial.Id, "filial_logo", "id_filial");

                    imgLogoEmp.Enabled = true;
                    btnAbrirLogo.Enabled = true;
                }
            }

        }

        protected override void SetupControls()
        {
            SetupUF();
        }

        protected override bool salvar(object sender, EventArgs e)
        {
            if (epValidaDados.Validar())
            {
                Filial Filial = new Filial();
                FilialBLL = new FilialBLL();

                FilialBLL.UsuarioLogado = Program.usuario_logado;

                Filial = LoadFromControls();

                if (Id != null)
                {                    
                    FilialBLL.AlterarFilial(Filial);
                }
                else
                {                    
                    FilialBLL.AdicionarFilial(Filial);
                }

                if (Filial.Id != 0)
                {
                    Id = Filial.Id;
                    txtId.Text = Filial.Id.ToString();

                    if (Filial.Id > 0)
                    {
                        if (imgLogoEmp.Image != null)
                        {
                            ImagemFromDB.setImagem(Filial.Id, "filial_logo", "id_filial", imgLogoEmp.Image);
                        }
                    }

                }
                txtNumero.Focus();
                return true;                
            }
            else
            {
                return false;
            }
        }

        protected virtual Filial LoadFromControls()
        {
            Filial filial = new Filial();

            if (Id != null)
            {
                filial.Id = Convert.ToInt64(txtId.Text);
            }

            filial.Id_empresa = Id_Empresa;
            
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                filial.codigo_filial = Convert.ToInt64(txtCodigo.Text);
            }

            filial.cnpj = txtCNPJ.Text;
            filial.codigo_filial_integracao = txtCodInt.Text;
            filial.razao_social = txtRazaoSocial.Text;
            filial.nome_fantasia = txtNomeFantasia.Text;
            filial.telefone1_ddd = txtDDD.Text;
            filial.telefone1_numero = txtTelefone.Text;
            filial.endereco = txtEndereco.Text;
            filial.endereco_numero = txtNumero.Text;
            filial.bairro = txtBairro.Text;
            filial.complemento = txtComplemento.Text;
            if (cbUF.SelectedValue != null)
            {
                filial.estado = cbUF.SelectedValue.ToString();
            }
            if (cbCidade.SelectedValue != null)
            {
                filial.cidade = cbCidade.SelectedValue.ToString();
            }
            filial.cep = txtCEP.Text;
            filial.telefone2_ddd = txtDDD2.Text;
            filial.telefone2_numero = txtTelefone2.Text;
            filial.fax_ddd = txtDDDFax.Text;
            filial.fax_numero = txtFax.Text;
            filial.email = txtEmail.Text;
            filial.website = txtWebSite.Text;
            filial.inscricao_estadual = txtInscricaoEstadual.Text;
            filial.inscricao_municipal = txtInscricaoMunicipal.Text;
            filial.inscricao_suframa = txtInscricaoSuframa.Text;
            filial.cnae = txtCodCnae.Text;

            if (cbRegimeTributario.SelectedValue != null)
            {
                filial.regime_tributario = Convert.ToSByte(cbRegimeTributario.SelectedValue);
            }

            if (!string.IsNullOrEmpty(txtDtSimplNac.Text))
            {
                filial.data_adesao_sn = Convert.ToDateTime(txtDtSimplNac.Text);
            }

            return filial;            
        }

        protected override void Limpar(Control control)

        {
            base.Limpar(control);
            txtNumero.Focus();
        }

        private void Ctrls_Validated(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                epValidaDados.SetError((TextBox)sender, string.Empty);
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

        private void frmCadEditFilial_Activated(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void frmCadEditFilial_Load(object sender, EventArgs e)
        {
            
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

        private void cbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbUF.Text))
            {
                SetupCidade(cbUF.Text);
            }
        }

        private void SetupCidade(string UF)
        {
            CidadeBLL cidadeBLL = new CidadeBLL();
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

        private void cbUF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetupCidade(cbUF.SelectedValue.ToString());
        }

        private void cbUF_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((ComboBox)sender).Text))
            {
                e.Cancel = ((ComboBox)sender).FindStringExact(((ComboBox)sender).Text) < 0;
                if (e.Cancel)
                {
                    MessageBox.Show("Valor digitado não encontrado na lista", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTelefone2_Validating(object sender, CancelEventArgs e)
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

        private void txtFax_Validating(object sender, CancelEventArgs e)
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

        private void btnAbrirLogo_Click(object sender, EventArgs e)
        {
            if (dlgCaminhoImagem.ShowDialog() == DialogResult.OK)
            {
                imgLogoEmp.Image = Image.FromFile(@dlgCaminhoImagem.FileName);
            }
        }

        private void SetupUF()
        {
            CidadeBLL cidadeBLL = new CidadeBLL();
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
        
    }
}
