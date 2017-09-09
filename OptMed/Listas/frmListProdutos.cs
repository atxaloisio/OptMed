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
using Sync;

namespace optmed
{
    public partial class frmListProdutos : optmed.frmBaseList
    {
        ProdutoBLL ProdutoBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID = 0;
        private const int COL_CODIGO = 1;
        private const int COL_DESCRICAO = 2;
        private const int COL_UNIDADE = 3;
        private const int COL_NCM = 4;
        private const int COL_VALOR_UNITARIO = 5;
        private const int COL_FAMILIA = 6;

        #endregion

        public frmListProdutos()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmProdutos_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditProduto();
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
            gridFiltros.Columns.Add("ID", "Id");
            gridFiltros.Columns.Add("CODIGO", "Código");
            gridFiltros.Columns.Add("DESCRICAO", "Descrição");
            gridFiltros.Columns.Add("UNIDADE", "Unidade");
            gridFiltros.Columns.Add("NCM", "NCM");
            gridFiltros.Columns.Add("VALORUNITARIO", "Valor Unitario");
            gridFiltros.Columns.Add("FAMILIA", "Familia");
            //
            gridFiltros.Columns[COL_ID].Width = 50;
            gridFiltros.Columns[COL_ID].ValueType = typeof(int);
            gridFiltros.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_ID].Visible = false;

            gridFiltros.Columns[COL_CODIGO].Width = 100;
            gridFiltros.Columns[COL_CODIGO].ValueType = typeof(string);
            gridFiltros.Columns[COL_CODIGO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_DESCRICAO].Width = 450;
            gridFiltros.Columns[COL_DESCRICAO].ValueType = typeof(string);
            gridFiltros.Columns[COL_DESCRICAO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_UNIDADE].Width = 80;
            gridFiltros.Columns[COL_UNIDADE].ValueType = typeof(string);
            gridFiltros.Columns[COL_UNIDADE].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_NCM].Width = 100;
            gridFiltros.Columns[COL_NCM].ValueType = typeof(string);
            gridFiltros.Columns[COL_NCM].SortMode = DataGridViewColumnSortMode.Programmatic;
            
            gridFiltros.Columns[COL_VALOR_UNITARIO].Width = 100;
            gridFiltros.Columns[COL_VALOR_UNITARIO].ValueType = typeof(decimal);
            gridFiltros.Columns[COL_VALOR_UNITARIO].DefaultCellStyle.Format = "N2";
            gridFiltros.Columns[COL_VALOR_UNITARIO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_FAMILIA].Width = 300;
            gridFiltros.Columns[COL_FAMILIA].ValueType = typeof(string);
            gridFiltros.Columns[COL_FAMILIA].SortMode = DataGridViewColumnSortMode.Programmatic;
            
            gridFiltros.Rows.Add();            
        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[COL_ID].Width = 50;
            gridDados.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_ID].Visible = false;

            gridDados.Columns[COL_CODIGO].Width = 100;
            gridDados.Columns[COL_CODIGO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_DESCRICAO].Width = 450;
            gridDados.Columns[COL_DESCRICAO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_UNIDADE].Width = 80;
            gridDados.Columns[COL_UNIDADE].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_NCM].Width = 100;
            gridDados.Columns[COL_NCM].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_VALOR_UNITARIO].Width = 100;
            gridDados.Columns[COL_VALOR_UNITARIO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_VALOR_UNITARIO].DefaultCellStyle.Format = "N2";

            gridDados.Columns[COL_FAMILIA].Width = 300;
            gridDados.Columns[COL_FAMILIA].SortMode = DataGridViewColumnSortMode.Programmatic;


        }

        protected override void carregaConsulta()
        {
            base.carregaConsulta();
            ProdutoBLL = new ProdutoBLL();
            List<Produto> ProdutoList = ProdutoBLL.getProduto(p => p.id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            //List<Produto> ProdutoList = ProdutoBLL.getProduto(p => p.nome.Contains("x"), T => T.Id.ToString(), false, deslocamento, tamanhopagina, out totalreg);
            dgvDados.DataSource = ProdutoBLL.ToList_ProdutoView(ProdutoList);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);
            ProdutoBLL = new ProdutoBLL();

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

                case COL_CODIGO:
                    {
                        List<Produto> ProdutoList = ProdutoBLL.getProduto(p => p.codigo, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = ProdutoList;
                    }
                    break;

                case COL_DESCRICAO:
                    {
                        List<Produto> ProdutoList = ProdutoBLL.getProduto(p => p.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = ProdutoList;
                    }
                    break;

                case COL_NCM:
                    {
                        List<Produto> ProdutoList = ProdutoBLL.getProduto(p => p.ncm, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = ProdutoList;
                    }
                    break;

                case COL_FAMILIA:
                    {
                        List<Produto> ProdutoList = ProdutoBLL.getProduto(p => p.descricao_familia, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = ProdutoList;
                    }
                    break;
                //O default será executado quando o index for 0
                default:
                    {
                        List<Produto> ProdutoList = ProdutoBLL.getProduto(p => p.id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = ProdutoList;
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

            
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            int id = 0;
            string codigo = string.Empty;
            string descricao = string.Empty;
            string unidade = string.Empty;
            string ncm = string.Empty;
            string familia = string.Empty;

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_ID, e.RowIndex].Value))
            {
                id = Convert.ToInt32(dgvFiltro[0, e.RowIndex].Value);
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_CODIGO, e.RowIndex].Value))
            {
                codigo = dgvFiltro[COL_CODIGO, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_DESCRICAO, e.RowIndex].Value))
            {
                descricao = dgvFiltro[COL_DESCRICAO, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_UNIDADE, e.RowIndex].Value))
            {
                unidade = dgvFiltro[COL_UNIDADE, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_FAMILIA, e.RowIndex].Value))
            {
                familia = dgvFiltro[COL_FAMILIA, e.RowIndex].Value.ToString();
            }

            //var predicate = PredicateBuilder.True<Produto>();


            Expression<Func<Produto, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.id == id;
            }

            if (!string.IsNullOrEmpty(codigo))
            {
                predicate = predicate.And(p => p.codigo.ToLower().Contains(codigo.ToLower()));
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                predicate = predicate.And(p => p.descricao.ToLower().Contains(descricao.ToLower()));
            }

            if (!string.IsNullOrEmpty(unidade))
            {
                predicate = predicate.And(p => p.unidade.ToLower().Contains(unidade.ToLower()));
            }

            if (!string.IsNullOrEmpty(familia))
            {
                predicate = predicate.And(p => p.descricao_familia.ToLower().Contains(familia.ToLower()));
            }

            List<Produto> ProdutoList = ProdutoBLL.getProduto(predicate.Expand(), false, deslocamento, tamanhoPagina, out totalReg, t => t.id.ToString());
            dgvDados.DataSource = ProdutoList;

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);
            ProdutoBLL = new ProdutoBLL();
            try
            {
                if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
                {
                    Produto Produto = ProdutoBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                    if (MessageBox.Show("Deseja realmente excluir o registro : " + Produto.id.ToString() + " - " + Produto.descricao, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ProdutoBLL.ExcluirProduto(Produto);
                        bool intOmie = Convert.ToBoolean(Parametro.GetParametro("intOmie"));
                        bool updateProdutoOmie = Convert.ToBoolean(Parametro.GetParametro("updateProdutoOmie"));
                        ProdutoProxy proxy = new ProdutoProxy();
                        if (intOmie & updateProdutoOmie)
                        {
                            if (Produto.codigo_produto > 0)
                            {
                                proxy.ExcluirProduto(Produto);
                            }
                        }
                    }

                }
            }
            finally
            {
                ProdutoBLL.Dispose();
            }

        }
        #endregion
    }
}
