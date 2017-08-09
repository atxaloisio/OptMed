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
    public partial class frmPesquisaPedido_Otica : optmed.frmBasePesquisa
    {
        private Pedido_OticaBLL Pedido_OticaBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID = 0;
        private const int COL_PEDIDO = 1;
        private const int COL_NRPEDCLIENTE = 2;
        private const int COL_NRCAIXA = 3;
        private const int COL_CLIENTE = 4;
        private const int COL_CONDPAG = 5;
        private const int COL_VENDEDOR = 6;
        private const int COL_TRANSP = 7;
        private const int COL_DTEMISSAO = 8;
        private const int COL_DTFECHAMENTO = 9;
        private const int COL_STATUS = 10;
        private const int COL_USUARIO = 11;
        #endregion

        public frmPesquisaPedido_Otica()
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
            Pedido_OticaBLL = new Pedido_OticaBLL();
            
            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                dgvPesquisa.Columns.Clear();
                List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica();
                dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
            }
            else
            {
                dgvPesquisa.Columns.Clear();
                
                switch (Convert.ToString(cbFiltro.SelectedValue))
                {                    
                    case "PEDIDO":
                        {                            
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.codigo.ToString() == txtFiltro.Text);                             
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);                            
                        }
                        break;
                    case "NRPEDCLIENTE":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.numero_pedido_cliente == txtFiltro.Text);                            
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;
                    case "NRCAIXA":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.caixa.numero == txtFiltro.Text);
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;

                    case "CODCLIENTE":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.cliente.razao_social.ToLower().Contains(txtFiltro.Text));
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;

                    case "CONDPAG":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.parcela.descricao.ToLower().Contains(txtFiltro.Text));
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;

                    case "VENDEDOR":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.vendedor.nome.ToLower().Contains(txtFiltro.Text));
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;

                    case "TRANSPORTADORA":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.transportadora.razao_social.ToLower().Contains(txtFiltro.Text));
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;

                    case "DTEMISSAO":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.data_emissao.Value.ToShortDateString() == txtFiltro.Text);
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;

                    case "DTFECHAMENTO":
                        {
                            List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.data_fechamento.Value.ToShortDateString() == txtFiltro.Text);
                            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                        }
                        break;

                    case "STATUS":
                        {
                            StatusPedido sp = new StatusPedido();                            
                            IList<itemEnumList> lstStatusPedido = Enumerados.getListEnum(sp);
                            lstStatusPedido.Select(p => p.descricao.ToLower().Contains(txtFiltro.Text.ToLower()));
                            foreach (itemEnumList item in lstStatusPedido)
                            {
                                List<Pedido_Otica> lstPedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.status == item.chave);
                                dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
                            }

                        }
                        break;
                }
            }
            
            
        }

        protected override void SetupControls()
        {
            base.SetupControls();
            List<FiltroPesquisa> lstFiltroPesquisa = new List<FiltroPesquisa>();

            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "PEDIDO", descricao = "Pedido" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "NRPEDCLIENTE", descricao = "Nr. Pedido Cliente" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "NRCAIXA", descricao = "Número da Caixa" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "CODCLIENTE", descricao = "Codigo do Cliente" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "CONDPAG", descricao = "Condicao de Pagamento" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "VENDEDOR", descricao = "Vendedor" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "TRANSPORTADORA", descricao = "Transportadora" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "DTEMISSAO", descricao = "Data de Emissão" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "DTFECHAMENTO", descricao = "Data de Fechamento" });
            lstFiltroPesquisa.Add(new FiltroPesquisa() { chave = "STATUS", descricao = "Status" });

            cbFiltro.DataSource = lstFiltroPesquisa;
            cbFiltro.ValueMember = "chave";
            cbFiltro.DisplayMember = "descricao";
                                                
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltro.SelectedValue.ToString() == "PEDIDO")
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
                if (col.Name == "codigo")
                {
                    col.Visible = true;
                    col.HeaderText = "Pedido";
                    col.Width = 80;
                }

                if (col.Name == "numero_pedido_cliente")
                {
                    col.Visible = true;
                    col.HeaderText = "Nr. Ped Cliente ";
                    col.Width = 140;
                }

                if (col.Name == "numero_caixa")
                {
                    col.Visible = true;
                    col.HeaderText = "Caixa";
                    col.Width = 70;
                }

                if (col.Name == "cliente")
                {
                    col.Visible = true;
                    col.HeaderText = "Cliente";
                    col.Width = 380;                    
                }

                if (col.Name == "codicao_pagamento")
                {
                    col.Visible = true;
                    col.HeaderText = "Cond. Pagamento";
                    col.Width = 200;
                }

                if (col.Name == "vendedor")
                {
                    col.Visible = true;
                    col.HeaderText = "Vendedor";
                    col.Width = 250;
                }

                if (col.Name == "transportadora")
                {
                    col.Visible = true;
                    col.HeaderText = "Transportadora";
                    col.Width = 250;
                }

                if (col.Name == "DtEmissao")
                {
                    col.Visible = true;
                    col.HeaderText = "Dt. Emissao";
                    col.Width = 140;
                }

                if (col.Name == "DtFechamento")
                {
                    col.Visible = true;
                    col.HeaderText = "Dt. Fechamento";
                    col.Width = 140;
                }

                if (col.Name == "Status")
                {
                    col.Visible = true;
                    col.HeaderText = "Status";
                    col.Width = 200;
                }
            }
        }

        protected override void SetupColunasGrid()
        {
            Pedido_OticaBLL = new Pedido_OticaBLL();
            List<Pedido_Otica> lstPedido_Otica = new List<Pedido_Otica>();
            lstPedido_Otica.Add(new Pedido_Otica());
            dgvPesquisa.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(lstPedido_Otica);
        }

        private void frmPesquisaPedido_Otica_Load(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(txtFiltro.Text))
            {
                //if (txtFiltro.Text.Where(c => char.IsNumber(c)).Count() >= 11)
                //{
                //    cbFiltro.SelectedValue = "cnpj_cpf";
                //}
                //else if ((txtFiltro.Text.Where(c => char.IsNumber(c)).Count() > 0)&& (txtFiltro.Text.Where(c => char.IsNumber(c)).Count() < 11))
                //{
                //    cbFiltro.SelectedValue = "Id";
                //}
                //else
                //{
                //    cbFiltro.SelectedValue = "nome_fantasia";
                //}
                
                ExecutaPesquisa();                
            }
            FormataGridPesquisa();
        }
    }
}
