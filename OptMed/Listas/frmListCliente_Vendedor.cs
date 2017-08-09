using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
using Model;
using BLL;
using JThomas.Controls;
using Utils;
using LinqKit;

namespace optmed
{
    public partial class frmListCliente_Vendedor : optmed.frmBaseList
    {
        Cliente_VendedorBLL Cliente_VendedorBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID = 0;
        private const int COL_CLIENTE = 1;
        private const int COL_VENDEDOR = 2;


        #endregion
        public frmListCliente_Vendedor()
        {
            InitializeComponent();
        }

        private void frmListCliente_Vendedor_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditCliente_Vendedor();
        }

        protected override void formataColunagridFiltros(DataGridView gridFiltros)
        {
            base.formataColunagridFiltros(gridFiltros);
            //altera o nome das colunas                        
            gridFiltros.Columns.Add("ID", "Código");
            gridFiltros.Columns.Add("CLIENTE", "Cliente");
            gridFiltros.Columns.Add("Vendedor", "Vendedor");

            gridFiltros.Columns[COL_ID].Width = 70;
            gridFiltros.Columns[COL_ID].ValueType = typeof(int);
            gridFiltros.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_ID].Visible = true;

            gridFiltros.Columns[COL_CLIENTE].Width = 400;
            gridFiltros.Columns[COL_CLIENTE].ValueType = typeof(string);
            gridFiltros.Columns[COL_CLIENTE].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_VENDEDOR].Width = 400;
            gridFiltros.Columns[COL_VENDEDOR].ValueType = typeof(string);
            gridFiltros.Columns[COL_VENDEDOR].SortMode = DataGridViewColumnSortMode.Programmatic;

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();

        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[COL_ID].Width = 70;
            gridDados.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_ID].Visible = true;
            gridDados.Columns[COL_CLIENTE].Width = 400;
            gridDados.Columns[COL_CLIENTE].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_VENDEDOR].Width = 400;
            gridDados.Columns[COL_VENDEDOR].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            Cliente_VendedorBLL = new Cliente_VendedorBLL();
            base.carregaConsulta();
            dgvDados.DataSource = null;
            dgvDados.DataSource = Cliente_VendedorBLL.ToList_Cliente_VendedorView(Cliente_VendedorBLL.getCliente_Vendedor(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg));
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);

            Cliente_VendedorBLL = new Cliente_VendedorBLL();

            DataGridViewColumn col = dgvFiltro.Columns[e.ColumnIndex];
            DataGridViewColumn colAnt = dgvFiltro.Columns[colOrdem];

            ListSortDirection direction;

            switch (col.HeaderCell.SortGlyphDirection)
            {
                case SortOrder.None:
                    direction = ListSortDirection.Ascending;
                    break;
                case SortOrder.Ascending:
                    direction = ListSortDirection.Ascending;
                    break;
                case SortOrder.Descending:
                    direction = ListSortDirection.Descending;
                    break;
                default:
                    direction = ListSortDirection.Ascending;
                    break;
            }


            if (colOrdem == e.ColumnIndex)
            {
                if (direction == ListSortDirection.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                    col.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
                colAnt.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            switch (e.ColumnIndex)
            {

                case COL_CLIENTE:
                    {
                        List<Cliente_Vendedor> Cliente_VendedorList = Cliente_VendedorBLL.getCliente_Vendedor(p => p.cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);

                        dgvDados.DataSource = Cliente_VendedorBLL.ToList_Cliente_VendedorView(Cliente_VendedorList);
                    }
                    break;

                case COL_VENDEDOR:
                    {
                        List<Cliente_Vendedor> Cliente_VendedorList = Cliente_VendedorBLL.getCliente_Vendedor(p => p.vendedor.nome, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Cliente_VendedorBLL.ToList_Cliente_VendedorView(Cliente_VendedorList);
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        List<Cliente_Vendedor> Cliente_VendedorList = Cliente_VendedorBLL.getCliente_Vendedor(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Cliente_VendedorBLL.ToList_Cliente_VendedorView(Cliente_VendedorList);
                    }
                    break;
            }

            colOrdem = e.ColumnIndex;

            col.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ?
        SortOrder.Ascending : SortOrder.Descending;

        }

        protected override void executeCellValidatingChild(object sender, DataGridViewCellValidatingEventArgs e)
        {
            base.executeCellValidatingChild(sender, e);

            if (e.ColumnIndex == COL_ID && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //
            }

            if (e.ColumnIndex == COL_CLIENTE && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == COL_VENDEDOR && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            Cliente_VendedorBLL = new Cliente_VendedorBLL();

            int id = 0;
            string cliente = string.Empty;
            string Vendedor = string.Empty;




            if (dgvFiltro[COL_ID, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_ID, e.RowIndex].Value.ToString()))
                {
                    id = Convert.ToInt32(dgvFiltro[COL_ID, e.RowIndex].Value);
                }
            }

            if (dgvFiltro[COL_CLIENTE, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_CLIENTE, e.RowIndex].Value))
                {
                    cliente = dgvFiltro[COL_CLIENTE, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[COL_VENDEDOR, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_VENDEDOR, e.RowIndex].Value))
                {
                    Vendedor = dgvFiltro[COL_VENDEDOR, e.RowIndex].Value.ToString();
                }
            }


            Expression<Func<Cliente_Vendedor, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(cliente))
            {
                predicate = predicate.And(p => p.cliente.razao_social.ToLower().Contains(cliente.ToLower()));
            }

            if (!string.IsNullOrEmpty(Vendedor))
            {
                predicate = predicate.And(p => p.vendedor.nome.ToLower().Contains(Vendedor.ToLower()));
            }

            List<Cliente_Vendedor> Cliente_VendedorList = Cliente_VendedorBLL.getCliente_Vendedor(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = Cliente_VendedorBLL.ToList_Cliente_VendedorView(Cliente_VendedorList);

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);

            Cliente_VendedorBLL = new Cliente_VendedorBLL();

            if (Convert.ToInt32(dgvDados[COL_ID, dgvDados.CurrentRow.Index].Value) > 0)
            {
                Cliente_Vendedor Cliente_Vendedor = Cliente_VendedorBLL.Localizar(Convert.ToInt32(dgvDados[COL_ID, dgvDados.CurrentRow.Index].Value));
                if (MessageBox.Show("Deseja realmente excluir o registro : " + Cliente_Vendedor.cliente.nome_fantasia + " - " + Cliente_Vendedor.vendedor.nome, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cliente_VendedorBLL.ExcluirCliente_Vendedor(Cliente_Vendedor);
                }
            }
        }

        #endregion
    }
}
