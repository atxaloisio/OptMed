using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace optmed
{
    public partial class frmPesquisaProdutos : optmed.frmBasePesquisa
    {
        private ProdutoBLL produtoBLL;
        public frmPesquisaProdutos()
        {
            InitializeComponent();
        }

        protected override void setRetorno()
        {
            base.setRetorno();
        }

        public virtual DialogResult ExibeDialogo(string valorProcura)
        {
            txtFiltro.Text = valorProcura;
            return ShowDialog();
        }

        protected override void ExecutaPesquisa()
        {
            produtoBLL = new ProdutoBLL();
            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                dgvPesquisa.Columns.Clear();
                dgvPesquisa.DataSource = produtoBLL.getProduto();
            }
            else
            {
                dgvPesquisa.Columns.Clear();
                switch (Convert.ToString(cbFiltro.SelectedValue))
                {
                    case "id":
                        {
                            dgvPesquisa.DataSource = produtoBLL.getProduto(p => p.codigo_produto_integracao.ToLower() == txtFiltro.Text.ToLower());
                        }
                        break;
                    case "descricao":
                        {
                            dgvPesquisa.DataSource = produtoBLL.getProduto(p => p.descricao.ToLower().Contains(txtFiltro.Text.ToLower()));
                        }
                        break;
                }
            }


        }

        protected override void SetupControls()
        {
            base.SetupControls();

            List<FiltroPesquisa> lstFiltroPesquisa = new List<FiltroPesquisa>();

            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "id", descricao = "Código" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "descricao", descricao = "Nome" });
            
            cbFiltro.DataSource = lstFiltroPesquisa;
            cbFiltro.ValueMember = "chave";
            cbFiltro.DisplayMember = "descricao";

            dgvPesquisa.Columns.Add("codigo_produto_integracao", "Código");
            dgvPesquisa.Columns.Add("descricao", "Descrição");
            dgvPesquisa.Columns.Add("unidade", "Unidade");
                      
        }

        protected override void SetupColunasGrid()
        {
            List<Produto> lstProduto = new List<Produto>();
            lstProduto.Add(new Produto());
            dgvPesquisa.DataSource = lstProduto;
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltro.SelectedValue.ToString() == "id")
            {
                if (!char.IsDigit(e.KeyChar))

                {
                    e.Handled = true;
                }
            }

        }

        private void cbFiltro_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            dgvPesquisa.DataSource = null;
            SetupColunasGrid();
            FormataGridPesquisa();
        }

        protected override void FormataGridPesquisa()
        {
            base.FormataGridPesquisa();

            foreach (DataGridViewColumn col in dgvPesquisa.Columns)
            {
                col.Visible = false;
                if (col.Name == "codigo_produto_integracao")
                {
                    col.Visible = true;
                    col.HeaderText = "Código";
                    col.Width = 100;
                }

                if (col.Name == "descricao")
                {
                    col.Visible = true;
                    col.HeaderText = "Descrição";
                    col.Width = 300;
                }

                if (col.Name == "unidade")
                {
                    col.Visible = true;
                    col.HeaderText = "Unidade";
                    col.Width = 100;
                }                
            }
        }

        private void frmPesquisaProdutos_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFiltro.Text))
            {
                if (txtFiltro.Text.Where(c => char.IsNumber(c)).Count() > 0)
                {
                    cbFiltro.SelectedValue = "id";
                }                
                else
                {
                    cbFiltro.SelectedValue = "descricao";
                }

                ExecutaPesquisa();
                FormataGridPesquisa();
            }
        }
    }
}
