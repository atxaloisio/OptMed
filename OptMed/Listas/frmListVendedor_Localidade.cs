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
    public partial class frmListVendedor_Localidade : optmed.frmBaseList
    {
        Vendedor_LocalidadeBLL Vendedor_LocalidadeBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID = 0;
        private const int COL_NOME = 1;
        private const int COL_UF = 2;
        private const int COL_CIDADE = 3;


        #endregion
        public frmListVendedor_Localidade()
        {            
            InitializeComponent();            
        }

        private void frmListVendedor_Localidade_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditVendedor_Localidade();
        }

        protected override void formataColunagridFiltros(DataGridView gridFiltros)
        {
            base.formataColunagridFiltros(gridFiltros);
            //altera o nome das colunas                        
            gridFiltros.Columns.Add("ID", "Código");
            gridFiltros.Columns.Add("NOME", "Vendedor");

            CidadeBLL cidadeBLL = new CidadeBLL();
            DataGridViewComboBoxColumn colUF = new DataGridViewComboBoxColumn();

            List<string> CidadeList = cidadeBLL.getCidade().OrderBy(p => p.cUF).Select(c => c.cUF).Distinct().ToList();
            CidadeList.Insert(0, string.Empty);
            colUF.DataSource = CidadeList;
            colUF.DataPropertyName = "cUF";
            colUF.HeaderText = "UF";
            colUF.Name = "UF";
            colUF.SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns.Add(colUF);

            gridFiltros.Columns.Add("Cidade", "Cidade");



            gridFiltros.Columns[COL_ID].Width = 70;
            gridFiltros.Columns[COL_ID].ValueType = typeof(int);
            gridFiltros.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_ID].Visible = true;

            gridFiltros.Columns[COL_NOME].Width = 300;
            gridFiltros.Columns[COL_NOME].ValueType = typeof(string);
            gridFiltros.Columns[COL_NOME].SortMode = DataGridViewColumnSortMode.Programmatic;

            


            gridFiltros.Columns[COL_UF].Width = 50;
            //gridFiltros.Columns[col_uf].ValueType = typeof(string);
            gridFiltros.Columns[COL_UF].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_CIDADE].Width = 200;
            gridFiltros.Columns[COL_CIDADE].ValueType = typeof(string);
            gridFiltros.Columns[COL_CIDADE].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gridFiltros_EditingControlShowing);

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();

        }

        private void gridFiltros_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            switch (dgvFiltro.CurrentCell.ColumnIndex)
            {                
                case COL_UF:
                    {
                        if (e.Control is ComboBox)
                        {
                            ComboBox cb = e.Control as ComboBox;
                            if (cb != null)
                            {
                                cb.SelectionChangeCommitted -= new EventHandler(ComboBox_SelectionChangeCommitted);
                                cb.SelectionChangeCommitted += new EventHandler(ComboBox_SelectionChangeCommitted);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            string value = string.Empty;

            value = cb.SelectedValue.ToString();
            
            Expression<Func<Vendedor_Localidade, bool>> predicate = p => true;

            if (!string.IsNullOrEmpty(value))
            {
                predicate = predicate.And(p => p.cidade.cUF == value);
            }

            Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();
            List<Vendedor_Localidade> Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            
            dgvDados.DataSource = Vendedor_LocalidadeBLL.ToList_Vendedor_LocalidadeView(Vendedor_LocalidadeList);
        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[COL_ID].Width = 70;
            gridDados.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_ID].Visible = true;
            gridDados.Columns[COL_NOME].Width = 300;
            gridDados.Columns[COL_NOME].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_UF].Width = 50;
            gridDados.Columns[COL_UF].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_CIDADE].Width = 200;
            gridDados.Columns[COL_CIDADE].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();
            base.carregaConsulta();
            dgvDados.DataSource = null;
            List<Vendedor_Localidade> Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            
            dgvDados.DataSource = Vendedor_LocalidadeBLL.ToList_Vendedor_LocalidadeView(Vendedor_LocalidadeList);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);

            Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();

            List<Vendedor_Localidade> Vendedor_LocalidadeList;

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

                case COL_NOME:
                    {
                        Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(p => p.vendedor.nome, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;

                case COL_UF:
                    {
                        Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(p => p.cidade.cUF, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;

                case COL_CIDADE:
                    {
                        Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(p => p.cidade.cNome, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;
            }
           
            dgvDados.DataSource = Vendedor_LocalidadeBLL.ToList_Vendedor_LocalidadeView(Vendedor_LocalidadeList);

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

            if (e.ColumnIndex == COL_NOME && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == COL_UF && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == COL_CIDADE && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();

            int id = 0;
            string nome = string.Empty;
            string uf = string.Empty;
            string cidade = string.Empty;

            if (dgvFiltro[COL_ID, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_ID, e.RowIndex].Value.ToString()))
                {
                    id = Convert.ToInt32(dgvFiltro[COL_ID, e.RowIndex].Value);
                }
            }
            
            if (dgvFiltro[COL_NOME, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_NOME, e.RowIndex].Value))
                {
                    nome = dgvFiltro[COL_NOME, e.RowIndex].Value.ToString();
                }
            }
            
            if (dgvFiltro[COL_UF, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_UF, e.RowIndex].Value))
                {
                    uf = dgvFiltro[COL_UF, e.RowIndex].Value.ToString();
                }
            }
            
            if (dgvFiltro[COL_CIDADE, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_CIDADE, e.RowIndex].Value))
                {
                    cidade = dgvFiltro[COL_CIDADE, e.RowIndex].Value.ToString();
                }
            }
            

            Expression<Func<Vendedor_Localidade, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(nome))
            {
                predicate = predicate.And(p => p.vendedor.nome.ToLower().Contains(nome.ToLower()));
            }

            if (!string.IsNullOrEmpty(uf))
            {
                predicate = predicate.And(p => p.cidade.cUF.Contains(uf));
            }

            if (!string.IsNullOrEmpty(cidade))
            {
                predicate = predicate.And(p => p.cidade.cNome.ToLower().Contains(cidade.ToLower()));
            }

            List<Vendedor_Localidade> Vendedor_LocalidadeList = Vendedor_LocalidadeBLL.getVendedor_Localidade(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            
            dgvDados.DataSource = Vendedor_LocalidadeBLL.ToList_Vendedor_LocalidadeView(Vendedor_LocalidadeList);

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);

            Vendedor_LocalidadeBLL = new Vendedor_LocalidadeBLL();

            if (Convert.ToInt32(dgvDados[COL_ID, dgvDados.CurrentRow.Index].Value) > 0)
            {
                Vendedor_Localidade Vendedor_Localidade = Vendedor_LocalidadeBLL.Localizar(Convert.ToInt32(dgvDados[COL_ID, dgvDados.CurrentRow.Index].Value));
                if (MessageBox.Show("Deseja realmente excluir o registro : " + Vendedor_Localidade.vendedor.nome + " - " + Vendedor_Localidade.cidade.cNome, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Vendedor_LocalidadeBLL.ExcluirVendedor_Localidade(Vendedor_Localidade);
                }
            }
        }
        
        #endregion
    }
}
