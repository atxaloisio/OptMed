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
    public partial class frmPesquisaTransportadora : optmed.frmBasePesquisa
    {
        private ClienteBLL clienteBLL;
        public frmPesquisaTransportadora()
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
            clienteBLL = new ClienteBLL();
            //Cliente_TagBLL cliente_TagBLL = new Cliente_TagBLL();
            //Cliente_Tag cliente_Tag = cliente_TagBLL.getCliente_Tag(t => t.tag == "Cliente").First();

            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                dgvPesquisa.Columns.Clear();
                //List<Cliente> lstCliente = clienteBLL.getCliente(c => c.cliente_tag.Where(t => t.tag.Equals("Transportadora") & t.Id_cliente == c.Id).FirstOrDefault().Id_cliente == c.Id);
                List<Cliente> lstCliente = clienteBLL.getCliente(c => c.cliente_tag.Any(e => e.tag == "Transportadora"));
                
                dgvPesquisa.DataSource = lstCliente;
            }
            else
            {
                dgvPesquisa.Columns.Clear();
                
                switch (Convert.ToString(cbFiltro.SelectedValue))
                {                    
                    case "Id":
                        {
                            
                            List<Cliente> lstCliente = clienteBLL.getCliente(p => p.codigo_cliente_integracao == txtFiltro.Text & p.cliente_tag.Any(e => e.tag == "Transportadora"));
                            //if (lstCliente.Count <= 0)
                            //{
                            //    MessageBox.Show("Cliente código: "+ txtFiltro.Text + " não localizado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //} 
                            dgvPesquisa.DataSource = lstCliente;
                            
                        }
                        break;
                    case "nome_fantasia":
                        {
                            List<Cliente> lstCliente = clienteBLL.getCliente(p => p.nome_fantasia.ToLower().Contains(txtFiltro.Text.ToLower()) & p.cliente_tag.Any(e => e.tag == "Transportadora"));
                            //if (lstCliente.Count <= 0)
                            //{
                            //    MessageBox.Show("Cliente Nome: " + txtFiltro.Text + " não localizado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            dgvPesquisa.DataSource = lstCliente;
                        }
                        break;
                    case "cnpj_cpf":
                        {
                            string strCPF, strCNPJ = string.Empty;
                            strCPF = Convert.ToInt64(txtFiltro.Text).ToString(@"000\.000\.000\-00");
                            strCNPJ = Convert.ToInt64(txtFiltro.Text).ToString(@"00\.000\.000\/0000\-00");
                            List<Cliente> lstCliente = clienteBLL.getCliente(p => (p.cnpj_cpf == strCPF || p.cnpj_cpf == strCNPJ) & p.cliente_tag.Any(e => e.tag == "Transportadora"));
                            //if (lstCliente.Count <= 0)
                            //{
                            //    MessageBox.Show("Cliente CNPJ/CPF: " + txtFiltro.Text + " não localizado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            dgvPesquisa.DataSource = lstCliente;
                        }
                        break;
                }
            }
            
            
        }

        protected override void SetupControls()
        {
            base.SetupControls();
            List<FiltroPesquisa> lstFiltroPesquisa = new List<FiltroPesquisa>();

            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "Id", descricao = "Código" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "nome_fantasia", descricao = "Nome" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "cnpj_cpf", descricao = "CNPJ / CPF" });

            cbFiltro.DataSource = lstFiltroPesquisa;
            cbFiltro.ValueMember = "chave";
            cbFiltro.DisplayMember = "descricao";
                                                
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltro.SelectedValue.ToString() == "Id")
            {
                if ((!char.IsDigit(e.KeyChar)) & (e.KeyChar != 8) & ((e.KeyChar != 13)))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == 13)
                {
                    ExecutaPesquisa();
                    FormataGridPesquisa();
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
                if (col.Name == "codigo_cliente_integracao")
                {
                    col.Visible = true;
                    col.HeaderText = "Código";
                    col.Width = 100;
                }

                if (col.Name == "nome_fantasia")
                {
                    col.Visible = true;
                    col.HeaderText = "Nome Fantasia";
                    col.Width = 300;
                }

                if (col.Name == "razao_social")
                {
                    col.Visible = true;
                    col.HeaderText = "Razão Social";
                    col.Width = 300;
                }

                if (col.Name == "cnpj_cpf")
                {
                    col.Visible = true;
                    col.HeaderText = "CNPJ / CPF";
                    col.Width = 100;                    
                }
            }
        }

        protected override void SetupColunasGrid()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            lstCliente.Add(new Cliente());
            dgvPesquisa.DataSource = lstCliente;
        }

        private void frmPesquisaClientes_Load(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(txtFiltro.Text))
            {
                if (txtFiltro.Text.Where(c => char.IsNumber(c)).Count() >= 11)
                {
                    cbFiltro.SelectedValue = "cnpj_cpf";
                }
                else if ((txtFiltro.Text.Where(c => char.IsNumber(c)).Count() > 0)&& (txtFiltro.Text.Where(c => char.IsNumber(c)).Count() < 11))
                {
                    cbFiltro.SelectedValue = "Id";
                }
                else
                {
                    cbFiltro.SelectedValue = "nome_fantasia";
                }
                
                ExecutaPesquisa();                
            }
            FormataGridPesquisa();
        }
    }
}
