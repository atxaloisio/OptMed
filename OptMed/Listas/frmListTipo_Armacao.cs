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
    public partial class frmListTipo_Armacao : optmed.frmBaseList
    {
        Tipo_ArmacaoBLL Tipo_ArmacaoBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID = 0;        
        private const int COL_DESCRICAO = 1;
        private const int COL_INATIVO = 2;
        

        #endregion

        public frmListTipo_Armacao()
        {
            InitializeComponent();            
        }

        private void frmTipo_Armacao_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditTipo_Armacao();
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
            gridFiltros.Columns.Add("ID", "Código");
            gridFiltros.Columns.Add("DESCRICAO", "Tipo Armacao");
            DataGridViewCheckBoxColumn inativo = new DataGridViewCheckBoxColumn();
            inativo.HeaderText = "Inativo";
            inativo.Name = "INATIVO";
            inativo.TrueValue = true;
            inativo.FalseValue = false;
            inativo.ThreeState = true;                    
            gridFiltros.Columns.Add(inativo);
                       
           
            gridFiltros.Columns[COL_ID].Width = 70;
            gridFiltros.Columns[COL_ID].ValueType = typeof(int);
            gridFiltros.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_DESCRICAO].Width = 200;
            gridFiltros.Columns[COL_DESCRICAO].ValueType = typeof(string);
            gridFiltros.Columns[COL_DESCRICAO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_INATIVO].Width = 200;
            gridFiltros.Columns[COL_INATIVO].ValueType = typeof(bool);
            gridFiltros.Columns[COL_INATIVO].SortMode = DataGridViewColumnSortMode.Programmatic;
            
            gridFiltros.CellContentClick += new DataGridViewCellEventHandler(gridFiltros_CellContentClick);

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();
                       
        }

        private void gridFiltros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == COL_INATIVO)
            {
                executeCellEndEditChild(sender, e);
            }
        }
               
        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[COL_ID].Width = 70;
            gridDados.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_ID].Visible = true;
            gridDados.Columns[COL_DESCRICAO].Width = 200;
            gridDados.Columns[COL_DESCRICAO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_INATIVO].Width = 200;
            gridDados.Columns[COL_INATIVO].SortMode = DataGridViewColumnSortMode.Programmatic;            
        }

        protected override void carregaConsulta()
        {
            base.carregaConsulta();
            Tipo_ArmacaoBLL = new Tipo_ArmacaoBLL();                        
            List<Tipo_Armacao> lstTipo_Armacao = Tipo_ArmacaoBLL.getTipo_Armacao(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = Tipo_ArmacaoBLL.ToList_Tipo_ArmacaoView(lstTipo_Armacao);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);
            Tipo_ArmacaoBLL = new Tipo_ArmacaoBLL();

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

                case COL_DESCRICAO:
                    {
                        List<Tipo_Armacao> Tipo_ArmacaoList = Tipo_ArmacaoBLL.getTipo_Armacao(p => p.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Tipo_ArmacaoBLL.ToList_Tipo_ArmacaoView(Tipo_ArmacaoList);
                    }
                    break;                
                //O default será executado quando o index for 0
                default:
                    {
                        List<Tipo_Armacao> Tipo_ArmacaoList = Tipo_ArmacaoBLL.getTipo_Armacao(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Tipo_ArmacaoBLL.ToList_Tipo_ArmacaoView(Tipo_ArmacaoList);
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
            string descricao = string.Empty;
            string inativo = string.Empty;
            

            if (dgvFiltro[COL_ID, e.RowIndex].Value != null)
            {
                id = Convert.ToInt32(dgvFiltro[COL_ID, e.RowIndex].Value);
            }

            if (dgvFiltro[COL_DESCRICAO, e.RowIndex].Value!= null)
            {
                descricao = dgvFiltro[COL_DESCRICAO, e.RowIndex].Value.ToString();
            }

            if (e.ColumnIndex == COL_INATIVO)
            {
                DataGridViewCheckBoxCell cell = dgvFiltro.CurrentCell as DataGridViewCheckBoxCell;                
                if (cell != null)
                {
                    CheckState value = (CheckState)cell.EditedFormattedValue;
                    switch (value)
                    {
                        case CheckState.Checked:
                            inativo = "S";
                            break;
                        case CheckState.Unchecked:
                            inativo = "N";
                            break;
                        default:
                            inativo = string.Empty;
                            break;
                    }
                }                
            }

            Expression<Func<Tipo_Armacao, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                predicate = predicate.And(p => p.descricao.Contains(descricao));
            }

            if (!string.IsNullOrEmpty(inativo))
            {
                predicate = predicate.And(p => p.inativo==inativo);
            }

            List<Tipo_Armacao> Tipo_ArmacaoList = Tipo_ArmacaoBLL.getTipo_Armacao(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = Tipo_ArmacaoBLL.ToList_Tipo_ArmacaoView(Tipo_ArmacaoList);

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);
            Tipo_ArmacaoBLL = new Tipo_ArmacaoBLL();
            try
            {
                if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
                {
                    Tipo_Armacao Tipo_Armacao = Tipo_ArmacaoBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                    if (MessageBox.Show("Deseja realmente excluir o registro : " + Tipo_Armacao.Id.ToString() + " - " + Tipo_Armacao.descricao, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Tipo_ArmacaoBLL.ExcluirTipo_Armacao(Tipo_Armacao);
                    }

                }
            }
            finally
            {
                Tipo_ArmacaoBLL.Dispose();
            }

        }
        #endregion
        
        private void frmTipo_Armacao_BindingContextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
