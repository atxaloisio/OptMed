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
    public partial class frmListCliente_Transportadora : optmed.frmBaseList
    {
        Cliente_TransportadoraBLL Cliente_TransportadoraBLL;

        #region Constante de Colunas da Grid
        private const int col_Id = 0;
        private const int col_cliente = 1;
        private const int col_transportadora = 2;


        #endregion
        public frmListCliente_Transportadora()
        {
            InitializeComponent();
        }

        private void frmListCliente_Transportadora_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditCliente_Transportadora();
        }

        protected override void formataColunagridFiltros(DataGridView gridFiltros)
        {
            base.formataColunagridFiltros(gridFiltros);
            //altera o nome das colunas                        
            gridFiltros.Columns.Add("ID", "Código");
            gridFiltros.Columns.Add("CLIENTE", "Cliente");
            gridFiltros.Columns.Add("TRANSPORTADORA", "Transportadora");



            gridFiltros.Columns[col_Id].Width = 70;
            gridFiltros.Columns[col_Id].ValueType = typeof(int);
            gridFiltros.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[col_Id].Visible = true;

            gridFiltros.Columns[col_cliente].Width = 400;
            gridFiltros.Columns[col_cliente].ValueType = typeof(string);
            gridFiltros.Columns[col_cliente].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_transportadora].Width = 400;
            gridFiltros.Columns[col_transportadora].ValueType = typeof(string);
            gridFiltros.Columns[col_transportadora].SortMode = DataGridViewColumnSortMode.Programmatic;

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();

        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[col_Id].Width = 70;
            gridDados.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_Id].Visible = true;
            gridDados.Columns[col_cliente].Width = 400;
            gridDados.Columns[col_cliente].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_transportadora].Width = 400;
            gridDados.Columns[col_transportadora].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            Cliente_TransportadoraBLL = new Cliente_TransportadoraBLL();
            base.carregaConsulta();
            dgvDados.DataSource = null;
            dgvDados.DataSource = Cliente_TransportadoraBLL.ToList_Cliente_TransportadoraView(Cliente_TransportadoraBLL.getCliente_Transportadora(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg));
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);

            Cliente_TransportadoraBLL = new Cliente_TransportadoraBLL();

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

                case col_cliente:
                    {
                        List<Cliente_Transportadora> Cliente_TransportadoraList = Cliente_TransportadoraBLL.getCliente_Transportadora(p => p.Cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);

                        dgvDados.DataSource = Cliente_TransportadoraBLL.ToList_Cliente_TransportadoraView(Cliente_TransportadoraList);
                    }
                    break;

                case col_transportadora:
                    {
                        List<Cliente_Transportadora> Cliente_TransportadoraList = Cliente_TransportadoraBLL.getCliente_Transportadora(p => p.Cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Cliente_TransportadoraBLL.ToList_Cliente_TransportadoraView(Cliente_TransportadoraList);
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        List<Cliente_Transportadora> Cliente_TransportadoraList = Cliente_TransportadoraBLL.getCliente_Transportadora(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Cliente_TransportadoraBLL.ToList_Cliente_TransportadoraView(Cliente_TransportadoraList);
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

            if (e.ColumnIndex == col_Id && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //
            }

            if (e.ColumnIndex == col_cliente && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == col_transportadora && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            Cliente_TransportadoraBLL = new Cliente_TransportadoraBLL();

            int id = 0;
            string cliente = string.Empty;
            string transportadora = string.Empty;




            if (dgvFiltro[col_Id, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_Id, e.RowIndex].Value.ToString()))
                {
                    id = Convert.ToInt32(dgvFiltro[col_Id, e.RowIndex].Value);
                }
            }

            if (dgvFiltro[col_cliente, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_cliente, e.RowIndex].Value))
                {
                    cliente = dgvFiltro[col_cliente, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_transportadora, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_transportadora, e.RowIndex].Value))
                {
                    transportadora = dgvFiltro[col_transportadora, e.RowIndex].Value.ToString();
                }
            }


            Expression<Func<Cliente_Transportadora, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(cliente))
            {
                predicate = predicate.And(p => p.Cliente.razao_social.ToLower().Contains(cliente.ToLower()));
            }

            if (!string.IsNullOrEmpty(transportadora))
            {
                predicate = predicate.And(p => p.Transportadora.nome_fantasia.ToLower().Contains(transportadora.ToLower()));
            }

            List<Cliente_Transportadora> Cliente_TransportadoraList = Cliente_TransportadoraBLL.getCliente_Transportadora(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = Cliente_TransportadoraBLL.ToList_Cliente_TransportadoraView(Cliente_TransportadoraList);

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);

            Cliente_TransportadoraBLL = new Cliente_TransportadoraBLL();

            if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
            {
                Cliente_Transportadora Cliente_Transportadora = Cliente_TransportadoraBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                if (MessageBox.Show("Deseja realmente excluir o registro : " + Cliente_Transportadora.Cliente.nome_fantasia + " - " + Cliente_Transportadora.Transportadora.nome_fantasia, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cliente_TransportadoraBLL.ExcluirCliente_Transportadora(Cliente_Transportadora);
                }
            }
        }

        #endregion
    }
}
