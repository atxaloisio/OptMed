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
    public partial class frmPesquisaVendedor : optmed.frmBasePesquisa
    {
        private VendedorBLL VendedorBLL;
        public string Vendedor { get; set; }
        public frmPesquisaVendedor()
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
            VendedorBLL = new VendedorBLL();
            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                dgvPesquisa.Columns.Clear();
                dgvPesquisa.DataSource = VendedorBLL.ToList_VendedorView(VendedorBLL.getVendedor());
            }
            else
            {
                dgvPesquisa.Columns.Clear();
                switch (Convert.ToString(cbFiltro.SelectedValue))
                {
                    case "codigo":
                        {
                            dgvPesquisa.DataSource = VendedorBLL.ToList_VendedorView(VendedorBLL.getVendedor(p => p.codInt.ToString() == txtFiltro.Text));
                        }
                        break;
                    case "descricao":
                        {
                            dgvPesquisa.DataSource = VendedorBLL.ToList_VendedorView(VendedorBLL.getVendedor(p => p.nome.ToLower().Contains(txtFiltro.Text.ToLower())));
                        }
                        break;
                }
            }


        }

        protected override void SetupControls()
        {
            base.SetupControls();

            List<FiltroPesquisa> lstFiltroPesquisa = new List<FiltroPesquisa>();

            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "codigo", descricao = "Código" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "nome", descricao = "Nome" });
            
            cbFiltro.DataSource = lstFiltroPesquisa;
            cbFiltro.ValueMember = "chave";
            cbFiltro.DisplayMember = "descricao";

            //dgvPesquisa.Columns.Add("codigo", "Código");
            //dgvPesquisa.Columns.Add("descricao", "Descrição");            
                      
        }

        protected override void SetupColunasGrid()
        {
            VendedorBLL VendedorBLL = new VendedorBLL();
            List<Vendedor> lstVendedor = VendedorBLL.getVendedor();
            dgvPesquisa.DataSource = VendedorBLL.ToList_VendedorView(lstVendedor);
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (cbFiltro.SelectedValue.ToString() == "codigo")
            //{
            //    if (!char.IsDigit(e.KeyChar))

            //    {
            //        e.Handled = true;
            //    }
            //}

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
                if (col.Name == "Id")
                {
                    col.Visible = true;
                    col.HeaderText = "Código";                    
                    col.Width = 100;
                }

                if (col.Name == "nome")
                {
                    col.Visible = true;
                    col.HeaderText = "Nome";
                    col.Width = 300;
                }                               
            }
        }

        private void frmPesquisaVendedor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFiltro.Text))
            {
                if (txtFiltro.Text.Where(c => char.IsNumber(c)).Count() > 0)
                {
                    cbFiltro.SelectedValue = "codigo";
                }                
                else
                {
                    cbFiltro.SelectedValue = "nome";
                }

                ExecutaPesquisa();
                FormataGridPesquisa();
            }
        }
    }
}
