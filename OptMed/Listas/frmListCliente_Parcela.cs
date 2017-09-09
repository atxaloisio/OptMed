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
    public partial class frmListCliente_Parcela : optmed.frmBaseList
    {
        Cliente_ParcelaBLL cliente_ParcelaBLL;

        #region Constante de Colunas da Grid
        private const int col_Id = 0;
        private const int col_cliente = 1;
        private const int col_condPagto = 2;


        #endregion
        public frmListCliente_Parcela()
        {            
            InitializeComponent();            
        }

        private void frmListCliente_Parcela_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditCliente_Parcela();
        }

        protected override void setTamanhoPagina()
        {
            string NrRegPagListagem = Parametro.GetParametro("NrRegPag");
            if (!string.IsNullOrEmpty(NrRegPagListagem))
            {
                tamanhoPagina = Convert.ToInt32(NrRegPagListagem);
            }
        }

        protected override void formataColunagridFiltros(DataGridView gridFiltros)
        {
            base.formataColunagridFiltros(gridFiltros);
            //altera o nome das colunas                        
            gridFiltros.Columns.Add("ID", "id");
            gridFiltros.Columns.Add("CLIENTE", "Cliente");
            gridFiltros.Columns.Add("FORMAPAGTO", "Forma de Pagamento");



            gridFiltros.Columns[col_Id].Width = 70;
            gridFiltros.Columns[col_Id].ValueType = typeof(int);
            gridFiltros.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[col_Id].Visible = false;

            gridFiltros.Columns[col_cliente].Width = 300;
            gridFiltros.Columns[col_cliente].ValueType = typeof(string);
            gridFiltros.Columns[col_cliente].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_condPagto].Width = 300;
            gridFiltros.Columns[col_condPagto].ValueType = typeof(string);
            gridFiltros.Columns[col_condPagto].SortMode = DataGridViewColumnSortMode.Programmatic;

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();

        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[col_Id].Width = 70;
            gridDados.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_Id].Visible = false;
            gridDados.Columns[col_cliente].Width = 300;
            gridDados.Columns[col_cliente].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_condPagto].Width = 300;
            gridDados.Columns[col_condPagto].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            cliente_ParcelaBLL = new Cliente_ParcelaBLL();            
            base.carregaConsulta();
            dgvDados.DataSource = null;
            dgvDados.DataSource = cliente_ParcelaBLL.ToList_Cliente_ParcelaView(cliente_ParcelaBLL.getCliente_Parcela(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg));
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);

            cliente_ParcelaBLL = new Cliente_ParcelaBLL();

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
                        List<Cliente_Parcela> Cliente_ParcelaList = cliente_ParcelaBLL.getCliente_Parcela(p => p.cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);

                        dgvDados.DataSource = cliente_ParcelaBLL.ToList_Cliente_ParcelaView(Cliente_ParcelaList);
                    }
                    break;

                case col_condPagto:
                    {
                        List<Cliente_Parcela> Cliente_ParcelaList = cliente_ParcelaBLL.getCliente_Parcela(p => p.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = cliente_ParcelaBLL.ToList_Cliente_ParcelaView(Cliente_ParcelaList);
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        List<Cliente_Parcela> Cliente_ParcelaList = cliente_ParcelaBLL.getCliente_Parcela(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = cliente_ParcelaBLL.ToList_Cliente_ParcelaView(Cliente_ParcelaList);
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

            if (e.ColumnIndex == col_condPagto && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            cliente_ParcelaBLL = new Cliente_ParcelaBLL();

            int id = 0;
            string nome = string.Empty;
            string descricao = string.Empty;


            if (!string.IsNullOrEmpty((string)dgvFiltro[col_Id, e.RowIndex].Value.ToString()))
            {
                id = Convert.ToInt32(dgvFiltro[col_Id, e.RowIndex].Value);
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_cliente, e.RowIndex].Value))
            {
                nome = dgvFiltro[col_cliente, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_condPagto, e.RowIndex].Value))
            {
                descricao = dgvFiltro[col_condPagto, e.RowIndex].Value.ToString();
            }

            Expression<Func<Cliente_Parcela, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(nome))
            {
                predicate = predicate.And(p => p.cliente.razao_social.Contains(nome));
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                predicate = predicate.And(p => p.descricao.Contains(descricao));
            }

            List<Cliente_Parcela> Cliente_ParcelaList = cliente_ParcelaBLL.getCliente_Parcela(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = cliente_ParcelaBLL.ToList_Cliente_ParcelaView(Cliente_ParcelaList);





        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);

            cliente_ParcelaBLL = new Cliente_ParcelaBLL();

            if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
            {
                Cliente_Parcela Cliente_Parcela = cliente_ParcelaBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                if (MessageBox.Show("Deseja realmente excluir o registro : " + Cliente_Parcela.cliente.nome_fantasia + " - " + Cliente_Parcela.descricao, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cliente_ParcelaBLL.ExcluirCliente_Parcela(Cliente_Parcela);
                }
            }
        }
        
        #endregion
    }
}
