using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Configuration;
using BLL;
using Model;
using Sync;
using Utils;

namespace optmed
{
    public partial class frmParametroSistema : optmed.frmBase
    {
        #region Constante de Colunas da Grid de Filiais
        private const int COL_ID = 0;
        private const int COL_IDEMPRESA = 1;
        private const int COL_CODIGO = 2;
        private const int COL_CODINT = 3;
        private const int COL_CNPJ = 4;
        private const int COL_RAZAOSOCIAL = 5;
        private const int COL_NOMEFANTASIA = 6;
        #endregion

        CategoriaBLL categoriaBLL;
        Conta_CorrenteBLL conta_CorrenteBLL;
        public frmParametroSistema()
        {
            InitializeComponent();
        }

        private void btnCaminhoArquivos_Click(object sender, EventArgs e)
        {
            if (dlgCaminhoArquivos.ShowDialog() == DialogResult.OK)
            {
                txtCaminhoArquivos.Text = dlgCaminhoArquivos.SelectedPath;
            }
        }

        protected virtual void SetupControls()
        {
            SetupCategoria();
            SetupContaCorrente();
            SetupUF();
            SetupRegimeTributario();
        }

        private void SetupRegimeTributario()
        {
            Regime_Tributario tp = new Regime_Tributario();

            cbRegimeTributario.DataSource = Enumerados.getListEnum(tp);
            cbRegimeTributario.ValueMember = "chave";
            cbRegimeTributario.DisplayMember = "descricao";
            cbRegimeTributario.SelectedIndex = -1;
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

        private void cbUF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetupCidade(cbUF.SelectedValue.ToString());
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
                e.Cancel = ((ComboBox)sender).FindStringExact(((ComboBox)sender).Text) < 0;
                if (e.Cancel)
                {
                    MessageBox.Show("Valor digitado não encontrado na lista", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected virtual void SetupContaCorrente()
        {
            conta_CorrenteBLL = new Conta_CorrenteBLL();
            cbContaCorrente.DataSource = conta_CorrenteBLL.getConta_Corrente();
            cbContaCorrente.ValueMember = "Id";
            cbContaCorrente.DisplayMember = "descricao";
            cbContaCorrente.SelectedIndex = -1;
        }

        protected virtual void SetupCategoria()
        {
            categoriaBLL = new CategoriaBLL();
            cbCategoria.DataSource = categoriaBLL.getCategoria(c => c.conta_receita == "S" & c.descricao != "&lt;Disponível&gt;");
            cbCategoria.ValueMember = "Id";
            cbCategoria.DisplayMember = "descricao";
            cbCategoria.SelectedIndex = -1;
        }

        private void frmParametroSistema_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SetupControls();
            LoadToControls();
            this.Cursor = Cursors.Default;
        }

        private void LoadToControls()
        {
            LoadParametros();
            LoadEmpresa();
        }

        private void LoadParametros()
        {
            string genlab = Parametro.GetParametro("intGenLab");
            if (!string.IsNullOrEmpty(genlab))
            {
                rbIntGenLab.Checked = Convert.ToBoolean(genlab);
            }

            string tooling = Parametro.GetParametro("intTooling");
            if (!string.IsNullOrEmpty(tooling))
            {
                rbIntTooling.Checked = Convert.ToBoolean(tooling);
            }

            string NrRegPagListagem = Parametro.GetParametro("NrRegPag");
            if (!string.IsNullOrEmpty(NrRegPagListagem))
            {
                txtNrRegPag.Text = NrRegPagListagem;
            }

            string strPathFileLab = Parametro.GetParametro("strPathFileLab");
            if (!string.IsNullOrEmpty(strPathFileLab))
            {
                txtCaminhoArquivos.Text = strPathFileLab;
            }

            string layoutLaboratorio = Parametro.GetParametro("layoutLaboratorio");
            if (!string.IsNullOrEmpty(layoutLaboratorio))
            {
                rbLaboratorio.Checked = Convert.ToBoolean(layoutLaboratorio);
            }

            string layoutOtica = Parametro.GetParametro("layoutOtica");
            if (!string.IsNullOrEmpty(layoutOtica))
            {
                rbOtica.Checked = Convert.ToBoolean(layoutOtica);
            }

            string IdCategoria = Parametro.GetParametro("IdCategoria");
            if (!string.IsNullOrEmpty(IdCategoria) && StringExtensions.IsNumeric(IdCategoria))
            {
                cbCategoria.SelectedValue = Convert.ToInt64(IdCategoria);
            }

            string IdContaCorrente = Parametro.GetParametro("IdContaCorrente");
            if (!string.IsNullOrEmpty(IdContaCorrente) && StringExtensions.IsNumeric(IdContaCorrente))
            {
                cbContaCorrente.SelectedValue = Convert.ToInt64(IdContaCorrente);
            }

            string codEmpresa = Parametro.GetParametro("codEmpresa");
            if (!string.IsNullOrEmpty(codEmpresa) && StringExtensions.IsNumeric(codEmpresa))
            {
                txtCodigoEmpresa.Text = codEmpresa;
                txtCodigo.Text = codEmpresa;
            }

            string intOmie = Parametro.GetParametro("intOmie");
            if (!string.IsNullOrEmpty(intOmie))
            {
                chkIntegrarOmie.Checked = Convert.ToBoolean(intOmie);
            }

            string app_key = Parametro.GetParametro("app_key");
            if (!string.IsNullOrEmpty(app_key))
            {
                txtAppKey.Text = app_key;
            }

            string app_secret = Parametro.GetParametro("app_secret");
            if (!string.IsNullOrEmpty(app_secret))
            {
                txtAppSecret.Text = app_secret;
            }

            string updateClienteOmie = Parametro.GetParametro("updateClienteOmie");
            if (!string.IsNullOrEmpty(updateClienteOmie))
            {
                chkAtualizaCliente.Checked = Convert.ToBoolean(updateClienteOmie);
            }

            string updateFornecedorOmie = Parametro.GetParametro("updateFornecedorOmie");
            if (!string.IsNullOrEmpty(updateFornecedorOmie))
            {
                chkAtualizaFornecedor.Checked = Convert.ToBoolean(updateFornecedorOmie);
            }

            string updateTransportadoraOmie = Parametro.GetParametro("updateTransportadoraOmie");
            if (!string.IsNullOrEmpty(updateTransportadoraOmie))
            {
                chkAtualizaTransportadora.Checked = Convert.ToBoolean(updateTransportadoraOmie);
            }

            string updateProdutoOmie = Parametro.GetParametro("updateProdutoOmie");
            if (!string.IsNullOrEmpty(updateProdutoOmie))
            {
                chkAtualizaProduto.Checked = Convert.ToBoolean(updateProdutoOmie);
            }

            string updateVendedorOmie = Parametro.GetParametro("updateVendedorOmie");
            if (!string.IsNullOrEmpty(updateVendedorOmie))
            {
                chkAtualizaVendedor.Checked = Convert.ToBoolean(updateVendedorOmie);
            }

            long ultCodCliente = Sequence.GetCurrentVal("sq_cliente_sequence");
            txtCodCliente.Text = ultCodCliente.ToString();

            long ultCodProduto = Sequence.GetCurrentVal("sq_produto_sequence");
            txtCodProduto.Text = ultCodProduto.ToString();

            long ultCodPedido = Sequence.GetCurrentVal("sq_pedido_sequence");
            txtCodPedido.Text = ultCodPedido.ToString();
        }

        private void LoadEmpresa()
        {
            if (!string.IsNullOrEmpty(txtCodigoEmpresa.Text))
            {
                long? codigo = Convert.ToInt64(txtCodigoEmpresa.Text);
                EmpresaBLL empresaBLL = new EmpresaBLL();
                List<Empresa> empresaList = empresaBLL.getEmpresa(p => p.codigo_empresa == codigo);
                if (empresaList.Count() > 0)
                {
                    Empresa empresa = empresaList.FirstOrDefault();

                    LoadEmpresaToControls(empresa);
                    if (chkIntegrarOmie.Checked)
                    {
                        foreach (Control item in tpEmpresa.Controls)
                        {
                            item.Enabled = false;
                            if (item is TextBox)
                            {
                                ((TextBox)item).ReadOnly = true;
                            }
                        }

                        tcCliente.Enabled = true;
                        foreach (Control item in tpEndereco.Controls)
                        {
                            item.Enabled = false;
                            if (item is TextBox)
                            {
                                ((TextBox)item).ReadOnly = true;
                            }
                        }

                        foreach (Control item in tpTelefoneEmail.Controls)
                        {
                            item.Enabled = false;
                            if (item is TextBox)
                            {
                                ((TextBox)item).ReadOnly = true;
                            }
                        }

                        foreach (Control item in tpInscrCnae.Controls)
                        {
                            item.Enabled = false;
                            if (item is TextBox)
                            {
                                ((TextBox)item).ReadOnly = true;
                            }
                        }
                    }

                    imgLogoEmp.Image = ImagemFromDB.GetImagem(empresa.Id, "empresa_logo", "id_empresa");

                    imgLogoEmp.Enabled = true;
                    btnAbrirLogo.Enabled = true;
                }


            }
            else if (!chkIntegrarOmie.Checked)
            {
                EmpresaBLL empresaBLL = new EmpresaBLL();
                List<Empresa> empresaList = empresaBLL.getEmpresa();
                if (empresaList.Count() > 0)
                {
                    Empresa empresa = empresaList.FirstOrDefault();

                    LoadEmpresaToControls(empresa);
                }
            }

        }

        private void LoadEmpresaToControls(Empresa empresa)
        {
            txtId.Text = empresa.Id.ToString();

            if (empresa.codigo_empresa != null)
            {
                txtCodigo.Text = empresa.codigo_empresa.ToString();
            }

            txtCodInt.Text = empresa.codigo_empresa_integracao;
            txtRazaoSocial.Text = empresa.razao_social;
            txtCNPJ.Text = empresa.cnpj;
            txtNomeFantasia.Text = empresa.nome_fantasia;
            txtDDD.Text = empresa.telefone1_ddd;
            txtTelefone.Text = empresa.telefone1_numero;
            txtEndereco.Text = empresa.endereco;
            txtNumero.Text = empresa.endereco_numero;
            txtBairro.Text = empresa.bairro;
            txtComplemento.Text = empresa.complemento;
            cbUF.Text = empresa.estado;
            cbCidade.Text = empresa.cidade;
            txtCEP.Text = empresa.cep;
            txtDDD2.Text = empresa.telefone2_ddd;
            txtTelefone2.Text = empresa.telefone2_numero;
            txtDDDFax.Text = empresa.fax_ddd;
            txtFax.Text = empresa.fax_numero;
            txtEmail.Text = empresa.email;
            txtWebSite.Text = empresa.website;
            txtInscricaoEstadual.Text = empresa.inscricao_estadual;
            txtInscricaoMunicipal.Text = empresa.inscricao_municipal;
            txtInscricaoSuframa.Text = empresa.inscricao_suframa;
            txtCodCnae.Text = empresa.cnae;
            if (!string.IsNullOrEmpty(empresa.cnae))
            {
                CNAEBLL CNAEBLL = new CNAEBLL();
                txtDescricaoCnae.Text = CNAEBLL.getCNAE(p => p.codigo == empresa.cnae).FirstOrDefault().descricao;
            }

            if (empresa.regime_tributario != null)
            {
                cbRegimeTributario.SelectedValue = empresa.regime_tributario;
            }

            if (empresa.data_adesao_sn != null)
            {
                txtDtSimplNac.Text = empresa.data_adesao_sn.Value.ToShortDateString();
            }

            //if (empresa.filials.Count <= 0)
            //{
            //    adicionaColunasGridFilial();
            //}
            LoadListFilialToGrid(empresa.filials);


        }

        private void adicionaColunasGridFilial()
        {
            //altera o nome das colunas                        
            dgvFilial.Columns.Add("ID", "ID");
            dgvFilial.Columns.Add("ID_EMPRESA", "ID_EMPRESA");
            dgvFilial.Columns.Add("CODIGO", "CODIGO");
            dgvFilial.Columns.Add("COD_INT", "COD_INT");
            dgvFilial.Columns.Add("CNPJ", "CNPJ");
            dgvFilial.Columns.Add("RAZAO_SOCIAL", "Razão Social");
            dgvFilial.Columns.Add("NOME_FANTASIA", "Nome Fantasia");
        }

        private void LoadListFilialToGrid(ICollection<Filial> filials)
        {
            FilialBLL filialBLL = new FilialBLL();
            dgvFilial.DataSource = filialBLL.ToList_FilialView(filials);
            formataGridFilial();
        }

        private void formataGridFilial()
        {
            dgvFilial.AutoGenerateColumns = true;
            dgvFilial.ColumnHeadersVisible = true;
            dgvFilial.RowHeadersVisible = false;
            dgvFilial.ReadOnly = true;
            dgvFilial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvFilial.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //altera a cor das linhas alternadas no grid
            dgvFilial.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvFilial.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            formataColunadgvFilial();
            //seleciona a linha inteira
            dgvFilial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //não permite seleção de multiplas linhas
            dgvFilial.MultiSelect = false;
            // exibe nulos formatados
            dgvFilial.DefaultCellStyle.NullValue = " - ";
            //permite que o texto maior que célula não seja truncado
            dgvFilial.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvFilial.DefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Regular);

            dgvFilial.CellDoubleClick -= new DataGridViewCellEventHandler(dgvDados_CellDoubleClick);
            dgvFilial.CellDoubleClick += new DataGridViewCellEventHandler(dgvDados_CellDoubleClick);
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarFilial();
        }

        private void EditarFilial()
        {
            if (dgvFilial.CurrentRow != null)
            {
                if (dgvFilial[0, dgvFilial.CurrentRow.Index].Value != null)
                {
                    if (Convert.ToInt32(dgvFilial[COL_ID, dgvFilial.CurrentRow.Index].Value) > 0)
                    {
                        frmCadEditFilial frmFilial = new frmCadEditFilial();
                        frmFilial.Id_Empresa = Convert.ToInt64(txtId.Text);
                        frmFilial.Cursor = Cursors.WaitCursor;
                        frmFilial.atualizagrid = new AtualizaGrid(atualizaGrid);
                        frmFilial.ExibeDialogo(this, Convert.ToInt32(dgvFilial[COL_ID, dgvFilial.CurrentRow.Index].Value));
                        frmFilial.Dispose();
                    }

                }
            }
        }

        public virtual void atualizaGrid()
        {
            FilialBLL filialBLL = new FilialBLL();
            long idEmp = Convert.ToInt64(txtId.Text);
            dgvFilial.DataSource = filialBLL.ToList_FilialView(filialBLL.getFilial(t => t.Id_empresa == idEmp, true));
        }

        private void formataColunadgvFilial()
        {
            dgvFilial.Columns[COL_ID].Width = 70;
            dgvFilial.Columns[COL_ID].ValueType = typeof(int);
            dgvFilial.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvFilial.Columns[COL_ID].Visible = false;
            dgvFilial.Columns[COL_ID].HeaderText = "ID";

            dgvFilial.Columns[COL_IDEMPRESA].Width = 200;
            dgvFilial.Columns[COL_IDEMPRESA].ValueType = typeof(int);
            dgvFilial.Columns[COL_IDEMPRESA].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvFilial.Columns[COL_IDEMPRESA].Visible = false;
            dgvFilial.Columns[COL_IDEMPRESA].HeaderText = "";

            dgvFilial.Columns[COL_CODIGO].Width = 70;
            dgvFilial.Columns[COL_CODIGO].ValueType = typeof(string);
            dgvFilial.Columns[COL_CODIGO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvFilial.Columns[COL_CODIGO].HeaderText = "Código";

            dgvFilial.Columns[COL_CODINT].Width = 75;
            dgvFilial.Columns[COL_CODINT].ValueType = typeof(string);
            dgvFilial.Columns[COL_CODINT].Visible = false;
            dgvFilial.Columns[COL_CODINT].HeaderText = "";

            dgvFilial.Columns[COL_CNPJ].Width = 120;
            dgvFilial.Columns[COL_CNPJ].ValueType = typeof(string);
            dgvFilial.Columns[COL_CNPJ].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvFilial.Columns[COL_CNPJ].HeaderText = "CNPJ";

            dgvFilial.Columns[COL_RAZAOSOCIAL].Width = 260;
            dgvFilial.Columns[COL_RAZAOSOCIAL].ValueType = typeof(string);
            dgvFilial.Columns[COL_RAZAOSOCIAL].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvFilial.Columns[COL_RAZAOSOCIAL].HeaderText = "Razão Social";

            dgvFilial.Columns[COL_NOMEFANTASIA].Width = 260;
            dgvFilial.Columns[COL_NOMEFANTASIA].ValueType = typeof(string);
            dgvFilial.Columns[COL_NOMEFANTASIA].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvFilial.Columns[COL_NOMEFANTASIA].HeaderText = "Nome Fantasia";






            //Adiciona uma linha ao grid.
            //dgvFilial.Rows.Add();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            try
            {
                SalvarParametros();

                if (!chkIntegrarOmie.Checked)
                {
                    SalvarEmpresa();
                }
                else
                {
                    EmpresaBLL empresaBLL = new EmpresaBLL();
                    Empresa empresa = empresaBLL.getEmpresa().FirstOrDefault();
                    if (empresa != null)
                    {
                        if (empresa.Id > 0)
                        {
                            if (imgLogoEmp.Image != null)
                            {
                                ImagemFromDB.setImagem(empresa.Id, "empresa_logo", "id_empresa", imgLogoEmp.Image);
                            }
                        }
                    }
                }
                MessageBox.Show(Text + " salvo com sucesso.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void SalvarParametros()
        {
            string genlab = Parametro.GetParametro("intGenLab");
            if (!string.IsNullOrEmpty(genlab))
            {
                Parametro.SetParametro("intGenLab", Convert.ToString(rbIntGenLab.Checked));
            }
            else
            {
                Parametro.DelParametro("intGenLab");
                Parametro.AddParametro("intGenLab", Convert.ToString(rbIntGenLab.Checked));
            }


            string tooling = Parametro.GetParametro("intTooling");
            if (!string.IsNullOrEmpty(tooling))
            {
                Parametro.SetParametro("intTooling", Convert.ToString(rbIntTooling.Checked));
            }
            else
            {
                Parametro.DelParametro("intTooling");
                Parametro.AddParametro("intTooling", Convert.ToString(rbIntTooling.Checked));
            }

            string NrRegPagListagem = Parametro.GetParametro("NrRegPag");
            if (!string.IsNullOrEmpty(NrRegPagListagem))
            {
                Parametro.SetParametro("NrRegPag", txtNrRegPag.Text);
            }
            else
            {
                Parametro.DelParametro("NrRegPag");
                Parametro.AddParametro("NrRegPag", txtNrRegPag.Text);
            }

            string strPathFileLab = Parametro.GetParametro("strPathFileLab");
            if (!string.IsNullOrEmpty(strPathFileLab))
            {
                Parametro.SetParametro("strPathFileLab", txtCaminhoArquivos.Text);
            }
            else
            {
                Parametro.DelParametro("strPathFileLab");
                Parametro.AddParametro("strPathFileLab", txtCaminhoArquivos.Text);
            }

            string layoutLaboratorio = Parametro.GetParametro("layoutLaboratorio");
            if (!string.IsNullOrEmpty(layoutLaboratorio))
            {
                Parametro.SetParametro("layoutLaboratorio", Convert.ToString(rbLaboratorio.Checked));
            }
            else
            {
                Parametro.DelParametro("layoutLaboratorio");
                Parametro.AddParametro("layoutLaboratorio", Convert.ToString(rbLaboratorio.Checked));
            }


            string layoutOtica = Parametro.GetParametro("layoutOtica");
            if (!string.IsNullOrEmpty(tooling))
            {
                Parametro.SetParametro("layoutOtica", Convert.ToString(rbOtica.Checked));
            }
            else
            {
                Parametro.DelParametro("layoutOtica");
                Parametro.AddParametro("layoutOtica", Convert.ToString(rbOtica.Checked));
            }

            if (cbCategoria.SelectedValue != null)
            {
                string IdCategoria = Parametro.GetParametro("IdCategoria");
                if (!string.IsNullOrEmpty(IdCategoria) && StringExtensions.IsNumeric(IdCategoria))
                {
                    Parametro.SetParametro("IdCategoria", cbCategoria.SelectedValue.ToString());
                }
                else
                {
                    if (cbCategoria.SelectedValue != null)
                    {
                        Parametro.DelParametro("IdCategoria");
                        Parametro.AddParametro("IdCategoria", cbCategoria.SelectedValue.ToString());
                    }

                }
            }

            if (cbContaCorrente.SelectedValue != null)
            {
                string IdContaCorrente = Parametro.GetParametro("IdContaCorrente");
                if (!string.IsNullOrEmpty(IdContaCorrente) && StringExtensions.IsNumeric(IdContaCorrente))
                {

                    Parametro.SetParametro("IdContaCorrente", cbContaCorrente.SelectedValue.ToString());
                }
                else
                {
                    if (cbContaCorrente.SelectedValue != null)
                    {
                        Parametro.DelParametro("IdContaCorrente");
                        Parametro.AddParametro("IdContaCorrente", cbContaCorrente.SelectedValue.ToString());
                    }
                }
            }

            string codEmpresa = Parametro.GetParametro("codEmpresa");
            if (!string.IsNullOrEmpty(codEmpresa) && StringExtensions.IsNumeric(codEmpresa))
            {
                Parametro.SetParametro("codEmpresa", txtCodigoEmpresa.Text);
            }
            else
            {
                Parametro.DelParametro("codEmpresa");
                Parametro.AddParametro("codEmpresa", txtCodigoEmpresa.Text);
            }

            string intOmie = Parametro.GetParametro("intOmie");
            if (!string.IsNullOrEmpty(intOmie))
            {
                Parametro.SetParametro("intOmie", Convert.ToString(chkIntegrarOmie.Checked));
            }
            else
            {
                Parametro.DelParametro("intOmie");
                Parametro.AddParametro("intOmie", Convert.ToString(chkIntegrarOmie.Checked));
            }

            string app_key = Parametro.GetParametro("app_key");
            if (!string.IsNullOrEmpty(app_key))
            {
                Parametro.SetParametro("app_key", txtAppKey.Text);
            }
            else
            {
                Parametro.DelParametro("app_key");
                Parametro.AddParametro("app_key", txtAppKey.Text);
            }

            string app_secret = Parametro.GetParametro("app_secret");
            if (!string.IsNullOrEmpty(app_secret))
            {
                Parametro.SetParametro("app_secret", txtAppSecret.Text);
            }
            else
            {
                Parametro.DelParametro("app_secret");
                Parametro.AddParametro("app_secret", txtAppSecret.Text);
            }

            string updateClienteOmie = Parametro.GetParametro("updateClienteOmie");
            if (!string.IsNullOrEmpty(updateClienteOmie))
            {
                Parametro.SetParametro("updateClienteOmie", Convert.ToString(chkAtualizaCliente.Checked));
            }
            else
            {
                Parametro.DelParametro("updateClienteOmie");
                Parametro.AddParametro("updateClienteOmie", Convert.ToString(chkAtualizaCliente.Checked));
            }

            string updateFornecedorOmie = Parametro.GetParametro("updateFornecedorOmie");
            if (!string.IsNullOrEmpty(updateFornecedorOmie))
            {
                Parametro.SetParametro("updateFornecedorOmie", Convert.ToString(chkAtualizaFornecedor.Checked));
            }
            else
            {
                Parametro.DelParametro("updateFornecedorOmie");
                Parametro.AddParametro("updateFornecedorOmie", Convert.ToString(chkAtualizaFornecedor.Checked));
            }

            string updateTransportadoraOmie = Parametro.GetParametro("updateTransportadoraOmie");
            if (!string.IsNullOrEmpty(updateTransportadoraOmie))
            {
                Parametro.SetParametro("updateTransportadoraOmie", Convert.ToString(chkAtualizaTransportadora.Checked));
            }
            else
            {
                Parametro.DelParametro("updateTransportadoraOmie");
                Parametro.AddParametro("updateTransportadoraOmie", Convert.ToString(chkAtualizaTransportadora.Checked));
            }

            string updateProdutoOmie = Parametro.GetParametro("updateProdutoOmie");
            if (!string.IsNullOrEmpty(updateProdutoOmie))
            {
                Parametro.SetParametro("updateProdutoOmie", Convert.ToString(chkAtualizaProduto.Checked));
            }
            else
            {
                Parametro.DelParametro("updateProdutoOmie");
                Parametro.AddParametro("updateProdutoOmie", Convert.ToString(chkAtualizaProduto.Checked));
            }

            string updateVendedorOmie = Parametro.GetParametro("updateVendedorOmie");
            if (!string.IsNullOrEmpty(updateVendedorOmie))
            {
                Parametro.SetParametro("updateVendedorOmie", Convert.ToString(chkAtualizaVendedor.Checked));
            }
            else
            {
                Parametro.DelParametro("updateVendedorOmie");
                Parametro.AddParametro("updateVendedorOmie", Convert.ToString(chkAtualizaVendedor.Checked));
            }

            if (!string.IsNullOrEmpty(txtCodCliente.Text) && StringExtensions.IsNumeric(txtCodCliente.Text))
            {
                Sequence.SetCurrentVal("sq_cliente_sequence", Convert.ToInt64(txtCodCliente.Text));
            }

            if (!string.IsNullOrEmpty(txtCodProduto.Text) && StringExtensions.IsNumeric(txtCodProduto.Text))
            {
                Sequence.SetCurrentVal("sq_produto_sequence", Convert.ToInt64(txtCodProduto.Text));
            }

            if (!string.IsNullOrEmpty(txtCodPedido.Text) && StringExtensions.IsNumeric(txtCodPedido.Text))
            {
                Sequence.SetCurrentVal("sq_pedido_sequence", Convert.ToInt64(txtCodPedido.Text));
            }
        }

        private void SalvarEmpresa()
        {
            EmpresaBLL empresaBLL = new EmpresaBLL();
            Empresa empresa = empresaBLL.getEmpresa().FirstOrDefault();
            if (empresa != null)
            {
                empresa = LoadEmpresaFromControls(empresa);
                empresaBLL.AlterarEmpresa(empresa);
            }
            else
            {
                empresa = new Empresa();
                empresa = LoadEmpresaFromControls(empresa);
                empresaBLL.AdicionarEmpresa(empresa);
            }

            if (empresa.Id > 0)
            {
                if (imgLogoEmp.Image != null)
                {
                    ImagemFromDB.setImagem(empresa.Id, "empresa_logo", "id_empresa", imgLogoEmp.Image);
                }
            }
        }

        private Empresa LoadEmpresaFromControls(Empresa empresa)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                empresa.Id = Convert.ToInt64(txtId.Text);
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                empresa.codigo_empresa = Convert.ToInt64(txtCodigo.Text);
            }

            empresa.cnpj = txtCNPJ.Text;
            empresa.codigo_empresa_integracao = txtCodInt.Text;
            empresa.razao_social = txtRazaoSocial.Text;
            empresa.nome_fantasia = txtNomeFantasia.Text;
            empresa.telefone1_ddd = txtDDD.Text;
            empresa.telefone1_numero = txtTelefone.Text;
            empresa.endereco = txtEndereco.Text;
            empresa.endereco_numero = txtNumero.Text;
            empresa.bairro = txtBairro.Text;
            empresa.complemento = txtComplemento.Text;
            if (cbUF.SelectedValue != null)
            {
                empresa.estado = cbUF.SelectedValue.ToString();
            }
            if (cbCidade.SelectedValue != null)
            {
                empresa.cidade = cbCidade.SelectedValue.ToString();
            }
            empresa.cep = txtCEP.Text;
            empresa.telefone2_ddd = txtDDD2.Text;
            empresa.telefone2_numero = txtTelefone2.Text;
            empresa.fax_ddd = txtDDDFax.Text;
            empresa.fax_numero = txtFax.Text;
            empresa.email = txtEmail.Text;
            empresa.website = txtWebSite.Text;
            empresa.inscricao_estadual = txtInscricaoEstadual.Text;
            empresa.inscricao_municipal = txtInscricaoMunicipal.Text;
            empresa.inscricao_suframa = txtInscricaoSuframa.Text;
            empresa.cnae = txtCodCnae.Text;

            if (cbRegimeTributario.SelectedValue != null)
            {
                empresa.regime_tributario = Convert.ToSByte(cbRegimeTributario.SelectedValue);
            }

            if (!string.IsNullOrEmpty(txtDtSimplNac.Text))
            {
                empresa.data_adesao_sn = Convert.ToDateTime(txtDtSimplNac.Text);
            }

            return empresa;
        }

        private void onlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsNumber(e.KeyChar)) & (e.KeyChar != 8) & (e.KeyChar != 22))
            {
                e.Handled = true;
            }
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            if (chkClientes.Checked ||
                chkProdutos.Checked ||
                chkUnidades.Checked ||
                chkImpostos.Checked ||
                chkFamiliaProdutos.Checked ||
                chkCategoria.Checked ||
                chkContaCorrente.Checked ||
                chkCidade.Checked ||
                chkFormaPagto.Checked ||
                chkVendedores.Checked ||
                chkEmpresa.Checked)
            {
                if (MessageBox.Show("Deseja iniciar a sincronização de dados?" +
                    " \n Esta operação pode levar alguns minutos dependento da quantidade de dados sinconizada. ",
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SincronizarBase();
                }
            }


        }

        private void SincronizarBase()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (chkClientes.Checked)
                {
                    ClienteProxy cp = new ClienteProxy();
                    try
                    {
                        cp.ProgressBar = pbSincronizar;
                        cp.Mensagem = lblMensagem;
                        cp.QtdRegistros = lblQtdRegistros;
                        cp.SyncCadastroCliente();
                        LimpaAbaSincronizar();
                        chkClientes.Checked = false;
                    }
                    finally
                    {
                        cp.Dispose();
                    }

                }

                if (chkProdutos.Checked)
                {

                    ProdutoProxy pp = new ProdutoProxy();
                    try
                    {
                        pp.ProgressBar = pbSincronizar;
                        pp.Mensagem = lblMensagem;
                        pp.QtdRegistros = lblQtdRegistros;
                        pp.SyncCadastroProduto();
                        LimpaAbaSincronizar();
                        chkProdutos.Checked = false;
                    }
                    finally
                    {
                        pp.Dispose();
                    }

                }

                if (chkUnidades.Checked)
                {

                    UnidadesProxy up = new UnidadesProxy();
                    try
                    {
                        up.ProgressBar = pbSincronizar;
                        up.Mensagem = lblMensagem;
                        up.QtdRegistros = lblQtdRegistros;
                        up.SyncUnidades();
                        LimpaAbaSincronizar();
                        chkUnidades.Checked = false;
                    }
                    finally
                    {
                        up.Dispose();
                    }

                }

                if (chkFamiliaProdutos.Checked)
                {

                    FamiliaProdutoProxy fp = new FamiliaProdutoProxy();
                    try
                    {
                        fp.ProgressBar = pbSincronizar;
                        fp.Mensagem = lblMensagem;
                        fp.QtdRegistros = lblQtdRegistros;
                        fp.SyncFamilia_Produto();
                        LimpaAbaSincronizar();
                        chkFamiliaProdutos.Checked = false;
                    }
                    finally
                    {
                        fp.Dispose();
                    }

                }

                if (chkImpostos.Checked)
                {
                    ProdutosImpostosProxy pi = new ProdutosImpostosProxy();
                    try
                    {
                        pi.ProgressBar = pbSincronizar;
                        pi.Mensagem = lblMensagem;
                        pi.QtdRegistros = lblQtdRegistros;
                        pi.SyncProdutosImpostos();
                        LimpaAbaSincronizar();
                        chkImpostos.Checked = false;
                    }
                    finally
                    {
                        pi.Dispose();
                    }

                }

                if (chkFormaPagto.Checked)
                {
                    ParcelaProxy par = new ParcelaProxy();
                    try
                    {
                        par.ProgressBar = pbSincronizar;
                        par.Mensagem = lblMensagem;
                        par.QtdRegistros = lblQtdRegistros;
                        par.SyncParcela();
                        LimpaAbaSincronizar();
                        chkFormaPagto.Checked = false;
                    }
                    finally
                    {
                        par.Dispose();
                    }

                }

                if (chkCategoria.Checked)
                {
                    CategoriaProxy categ = new CategoriaProxy();
                    try
                    {

                        categ.ProgressBar = pbSincronizar;
                        categ.Mensagem = lblMensagem;
                        categ.QtdRegistros = lblQtdRegistros;
                        categ.SyncCategoria();
                        LimpaAbaSincronizar();
                        chkCategoria.Checked = false;
                    }
                    finally
                    {
                        categ.Dispose();
                    }

                }

                if (chkContaCorrente.Checked)
                {
                    ContaCorrenteProxy cc = new ContaCorrenteProxy();
                    try
                    {
                        cc.ProgressBar = pbSincronizar;
                        cc.Mensagem = lblMensagem;
                        cc.QtdRegistros = lblQtdRegistros;
                        cc.SyncContaCorrente();
                        LimpaAbaSincronizar();
                        chkContaCorrente.Checked = false;
                    }
                    finally
                    {
                        cc.Dispose();
                    }

                }

                if (chkCidade.Checked)
                {
                    CidadesProxy cid = new CidadesProxy();
                    try
                    {
                        cid.ProgressBar = pbSincronizar;
                        cid.Mensagem = lblMensagem;
                        cid.QtdRegistros = lblQtdRegistros;
                        cid.SyncCidades();
                        LimpaAbaSincronizar();
                        chkCidade.Checked = false;
                    }
                    finally
                    {
                        cid.Dispose();
                    }

                }

                if (chkVendedores.Checked)
                {
                    VendedorProxy Vend = new VendedorProxy();
                    try
                    {
                        Vend.ProgressBar = pbSincronizar;
                        Vend.Mensagem = lblMensagem;
                        Vend.QtdRegistros = lblQtdRegistros;
                        Vend.SyncVendedor();
                        LimpaAbaSincronizar();
                        chkVendedores.Checked = false;
                    }
                    finally
                    {
                        Vend.Dispose();
                    }

                }

                if (chkEmpresa.Checked)
                {
                    EmpresaProxy emp = new EmpresaProxy();
                    try
                    {
                        emp.ProgressBar = pbSincronizar;
                        emp.Mensagem = lblMensagem;
                        emp.QtdRegistros = lblQtdRegistros;
                        emp.SyncEmpresa();
                        LimpaAbaSincronizar();
                        chkEmpresa.Checked = false;
                        LoadEmpresa();
                    }
                    finally
                    {
                        emp.Dispose();
                    }

                }

                MessageBox.Show("Sincronização concluida!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LimpaAbaSincronizar()
        {
            pbSincronizar.Value = 0;
            lblMensagem.Text = string.Empty;
            lblQtdRegistros.Text = string.Empty;
        }

        private void btnZerarCadProd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;


                if (chkProdutos.Checked)
                {

                    ProdutoProxy pp = new ProdutoProxy();
                    try
                    {

                        ProdutoBLL produtoBLL = new ProdutoBLL();

                        List<Produto> produtoList = produtoBLL.getProduto();

                        int reg = 0;
                        int qtdregs = 0;
                        qtdregs = produtoList.Count();
                        qtdregs++;
                        pbSincronizar.Maximum = qtdregs;

                        foreach (Produto item in produtoList)
                        {
                            reg++;
                            pbSincronizar.Value = reg;
                            lblQtdRegistros.Text = reg.ToString() + " de " + qtdregs.ToString();
                            lblMensagem.Text = "Limpando base de produtos omie.";
                            pp.ExcluirProduto(item);
                            pbSincronizar.Refresh();
                            Application.DoEvents();
                        }


                        //pp.ProgressBar = pbSincronizar;
                        //pp.Mensagem = lblMensagem;
                        //pp.QtdRegistros = lblQtdRegistros;
                        //pp.SyncCadastroProduto();
                        //LimpaAbaSincronizar();
                        //chkProdutos.Checked = false;
                    }
                    finally
                    {
                        pp.Dispose();
                    }

                }



                MessageBox.Show("Sincronização concluida!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
            }
        }

        private void txtCodigoEmpresa_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoEmpresa.Text))
            {
                if (!StringExtensions.IsNumeric(txtCodigoEmpresa.Text))
                {
                    MessageBox.Show("Valor inválido.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }

        }

        private void btnZerarCadFamiliaProd_Click(object sender, EventArgs e)
        {
            Familia_ProdutoBLL familia_ProdutoBLL = new Familia_ProdutoBLL();
            FamiliaProdutoProxy fp = new FamiliaProdutoProxy();
            try
            {
                List<Familia_Produto> Familia_ProdutoList = familia_ProdutoBLL.getFamilia_Produto();

                int reg = 0;
                int qtdregs = 0;
                qtdregs = Familia_ProdutoList.Count() + 1;
                pbSincronizar.Maximum = qtdregs;

                foreach (Familia_Produto item in Familia_ProdutoList)
                {
                    reg++;
                    pbSincronizar.Value = reg;
                    lblQtdRegistros.Text = reg.ToString() + " de " + qtdregs.ToString();
                    lblMensagem.Text = "Limpando base familia de produtos omie.";
                    lblMensagem.Text = fp.ExcluirFamilia_Produto(item);
                    pbSincronizar.Refresh();
                    Application.DoEvents();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                familia_ProdutoBLL.Dispose();
                fp.Dispose();
            }
        }

        private void btnAbrirLogo_Click(object sender, EventArgs e)
        {
            if (dlgCaminhoImagem.ShowDialog() == DialogResult.OK)
            {
                imgLogoEmp.Image = Image.FromFile(@dlgCaminhoImagem.FileName);
            }
        }

        private void frmParametroSistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tcParametros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcParametros.SelectedTab == tpGeral)
            {
                gbTipoArqIntegracao.Focus();
            }
            else if (tcParametros.SelectedTab == tpPedidoVenda)
            {
                cbCategoria.Focus();
            }
            else if (tcParametros.SelectedTab == tpIntegracao)
            {
                chkIntegrarOmie.Focus();
            }
            else if (tcParametros.SelectedTab == tpSincroniar)
            {
                chkClientes.Focus();
            }
            else if (tcParametros.SelectedTab == tpEmpresa)
            {
                txtCNPJ.Focus();
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

        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            string strCPF, strCNPJ = string.Empty;
            bool exibeMsg = false;


            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

                if (((TextBox)sender).Text.Where(c => char.IsNumber(c)).Count() == 11)
                {
                    strCPF = Convert.ToInt64(((TextBox)sender).Text).ToString(@"000\.000\.000\-00");
                    if (!ValidaCPF.IsCpf(strCPF))
                    {
                        exibeMsg = true;
                    }
                    else
                    {
                        ((TextBox)sender).Text = strCPF;
                    }
                }
                else if (((TextBox)sender).Text.Where(c => char.IsNumber(c)).Count() == 15)
                {
                    strCNPJ = Convert.ToInt64(((TextBox)sender).Text).ToString(@"00\.000\.000\/0000\-00");
                    if (!ValidaCNPJ.IsCnpj(strCNPJ))
                    {
                        exibeMsg = true;
                    }
                    else
                    {
                        ((TextBox)sender).Text = strCNPJ;
                    }
                }
                else
                {
                    exibeMsg = true;
                }

                if (exibeMsg)
                {
                    MessageBox.Show("CNPJ / CPF inválido.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCadEditFilial frmFilial = new frmCadEditFilial();
            try
            {
                frmFilial.Id_Empresa = Convert.ToInt64(txtId.Text);
                frmFilial.atualizagrid = new AtualizaGrid(atualizaGrid);
                frmFilial.Id_Empresa = Convert.ToInt64(txtId.Text);
                frmFilial.ExibeDialogo();
                frmFilial.Dispose();
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditarFilial();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaAcessoFuncao(Operacao.Excluir))
                {
                    if (dgvFilial.CurrentRow != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        excluirRegistro(dgvFilial.CurrentRow.Index);
                        this.atualizaGrid();
                        this.Cursor = Cursors.Default;
                    }

                }

            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excluirRegistro(int index)
        {
            FilialBLL filialBLL = new FilialBLL();
            try
            {
                if (Convert.ToInt32(dgvFilial[COL_ID, index].Value) > 0)
                {
                    Filial filial = filialBLL.Localizar(Convert.ToInt32(dgvFilial[COL_ID, index].Value));
                    if (MessageBox.Show("Deseja realmente excluir a filial : " + filial.Id.ToString() + " - " + filial.nome_fantasia, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        filialBLL.ExcluirFilial(filial);
                    }

                }
            }
            finally
            {
                filialBLL.Dispose();
            }
        }
    }
}
