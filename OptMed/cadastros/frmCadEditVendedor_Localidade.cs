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
    public partial class frmCadEditVendedor_Localidade : optmed.frmBaseCadEdit
    {
        private Vendedor_LocalidadeBLL Vendedor_LocalidadeBLL;
        private CidadeBLL cidadeBLL;
        private VendedorBLL VendedorBLL;

        public frmCadEditVendedor_Localidade()
        {
            InitializeComponent();            
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {
                Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();

                Vendedor_Localidade Vendedor_Localidade = Vendedor_LocalidadeBLL.Localizar(Id);

                if (Vendedor_Localidade != null)
                {
                    txtId.Text = Vendedor_Localidade.Id.ToString();
                    cbVendedor.SelectedValue = Vendedor_Localidade.vendedor.Id;
                    cbUF.Text = Vendedor_Localidade.cidade.cUF;
                    SetupCidade(Vendedor_Localidade.cidade.cUF);
                    cbCidade.SelectedValue = Vendedor_Localidade.cidade.Id;
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
                    Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();
                    Vendedor_LocalidadeBLL.UsuarioLogado = Program.usuario_logado;

                    Vendedor_Localidade Vendedor_Localidade = LoadFromControls();

                    if (Id != null)
                    {
                        Vendedor_LocalidadeBLL.AlterarVendedor_Localidade(Vendedor_Localidade);
                    }
                    else
                    {
                        Vendedor_LocalidadeBLL.AdicionarVendedor_Localidade(Vendedor_Localidade);
                    }
                    
                    if (Vendedor_Localidade.Id != 0)
                    {
                        Id = Vendedor_Localidade.Id;
                        txtId.Text = Vendedor_Localidade.Id.ToString();
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

        protected virtual Vendedor_Localidade LoadFromControls()
        {
            Vendedor_Localidade Vendedor_Localidade = new Vendedor_Localidade();

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                Vendedor_Localidade.Id = Convert.ToInt64(txtId.Text);
            }

            Vendedor_Localidade.Id_vendedor = Convert.ToInt64(cbVendedor.SelectedValue);
            Vendedor_Localidade.Id_localidade = Convert.ToInt32(cbCidade.SelectedValue);

            Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();

            List<Vendedor_Localidade> Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(p => p.Id_vendedor == Vendedor_Localidade.Id_vendedor & p.Id_localidade == Vendedor_Localidade.Id_localidade);

            if (Vendedor_LocalidadeList.Count > 0)
            {
                Vendedor_Localidade = Vendedor_LocalidadeList.First();
                Vendedor_Localidade.Id_localidade = Convert.ToInt64(cbCidade.SelectedValue);
                Vendedor_Localidade.Id_vendedor = Convert.ToInt64(cbVendedor.SelectedValue);
                Id = Vendedor_Localidade.Id;
            }
            
            return Vendedor_Localidade;
        }

        protected override void SetupControls()
        {            
            SetupVendedor();
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

        private void SetupVendedor()
        {
            VendedorBLL = new VendedorBLL();
            List<Vendedor> VendedorList = VendedorBLL.getVendedor();

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



        protected override void Limpar(Control control)
        {
            base.Limpar(control);

            cbVendedor.Focus();
        }

        private void cbUF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetupCidade(cbUF.SelectedValue.ToString());
        }

        private void SetupCidade(string UF)
        {
            cidadeBLL = new CidadeBLL();
            List<Cidade> CidadeList = cidadeBLL.getCidade(p => p.cUF == UF ).OrderBy(p => p.cNome).ToList();
            cbCidade.DataSource = CidadeList;

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            foreach (Cidade item in CidadeList)
            {
                acc.Add(item.cNome);
            } 
            

            cbCidade.AutoCompleteCustomSource = acc;
            cbCidade.ValueMember = "Id";
            cbCidade.DisplayMember = "cNome";
            cbCidade.SelectedIndex = -1;
        }

        private void cbVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbUF.Text))
            {
                SetupCidade(cbUF.Text);
            }
        }
    }
}
