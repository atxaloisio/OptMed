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
    public partial class frmPesquisaCNAE : optmed.frmBasePesquisa
    {
        private CNAEBLL CNAEBLL;
        public string CNAE { get; set; }
        public frmPesquisaCNAE()
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
            CNAEBLL = new CNAEBLL();
            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                dgvPesquisa.Columns.Clear();
                dgvPesquisa.DataSource = CNAEBLL.getCNAE();
            }
            else
            {
                dgvPesquisa.Columns.Clear();
                switch (Convert.ToString(cbFiltro.SelectedValue))
                {
                    case "codigo":
                        {
                            dgvPesquisa.DataSource = CNAEBLL.getCNAE(p => p.codigo == txtFiltro.Text);
                        }
                        break;
                    case "descricao":
                        {
                            dgvPesquisa.DataSource = CNAEBLL.getCNAE(p => p.descricao.ToLower().Contains(txtFiltro.Text.ToLower()));
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
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "descricao", descricao = "Descrição" });
            
            cbFiltro.DataSource = lstFiltroPesquisa;
            cbFiltro.ValueMember = "chave";
            cbFiltro.DisplayMember = "descricao";

            dgvPesquisa.Columns.Add("codigo", "Código");
            dgvPesquisa.Columns.Add("descricao", "Descrição");            
                      
        }

        protected override void SetupColunasGrid()
        {
            List<CNAE> lstCNAE = new List<CNAE>();
            lstCNAE.Add(new CNAE());
            dgvPesquisa.DataSource = lstCNAE;
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
                if (col.Name == "codigo")
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
            }
        }

        private void frmPesquisaCNAE_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFiltro.Text))
            {
                if (txtFiltro.Text.Where(c => char.IsNumber(c)).Count() > 0)
                {
                    cbFiltro.SelectedValue = "codigo";
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
