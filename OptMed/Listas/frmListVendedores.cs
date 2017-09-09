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
    public partial class frmListVendedores : optmed.frmBaseList
    {
        VendedorBLL VendedorBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID = 0;                
        private const int COL_NOME = 1;
        private const int COL_INATIVO = 2;


        #endregion
        public frmListVendedores()
        {            
            InitializeComponent();            
        }

        private void frmListVendedores_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditVendedor();
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
            gridFiltros.Columns.Add("NOME", "Nome");
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
            gridFiltros.Columns[COL_ID].Visible = true;
           
            gridFiltros.Columns[COL_NOME].Width = 300;
            gridFiltros.Columns[COL_NOME].ValueType = typeof(string);
            gridFiltros.Columns[COL_NOME].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_INATIVO].Width = 100;
            gridFiltros.Columns[COL_INATIVO].ValueType = typeof(bool);
            gridFiltros.Columns[COL_INATIVO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_INATIVO].ReadOnly = false;

            gridFiltros.CellContentClick += new DataGridViewCellEventHandler(gridFiltros_CellContentClick);
            //Adiciona uma linha ao grid..RE
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
            
            gridDados.Columns[COL_NOME].Width = 300;
            gridDados.Columns[COL_NOME].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_NOME].Visible = true;

            gridDados.Columns[COL_INATIVO].Width = 100;
            gridDados.Columns[COL_INATIVO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_INATIVO].Visible = true;
            gridDados.Columns[COL_INATIVO].ValueType = typeof(bool);
            
        }

        protected override void carregaConsulta()
        {
            VendedorBLL = new VendedorBLL();
            base.carregaConsulta();
            dgvDados.DataSource = null;
            List<Vendedor> VendedorList = VendedorBLL.getVendedor(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);

            dgvDados.DataSource = VendedorBLL.ToList_VendedorView(VendedorList);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);

            VendedorBLL = new VendedorBLL();

            List<Vendedor> VendedorList;

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
                        VendedorList = VendedorBLL.getVendedor(p => p.nome, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;                

                //O default será executado quando o index for 0
                default:
                    {
                        VendedorList = VendedorBLL.getVendedor(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;
            }
           
            dgvDados.DataSource = VendedorBLL.ToList_VendedorView(VendedorList);

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

            VendedorBLL = new VendedorBLL();

            int id = 0;            
            string inativo = string.Empty;
            string nome = string.Empty;

            if (dgvFiltro[COL_ID, e.RowIndex].Value != null)
            {
                id = Convert.ToInt32(dgvFiltro[COL_ID, e.RowIndex].Value);
            }


            if (dgvFiltro[COL_NOME, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[COL_NOME, e.RowIndex].Value))
                {
                    nome = dgvFiltro[COL_NOME, e.RowIndex].Value.ToString();
                }
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

            Expression<Func<Vendedor, bool>> predicate = p => true;

            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(nome))
            {
                predicate = predicate.And(p => p.nome.ToLower().Contains(nome.ToLower()));
            }

            if (!string.IsNullOrEmpty(inativo))
            {
                predicate = predicate.And(p => p.inativo == inativo);
            }

            List<Vendedor> VendedorList = VendedorBLL.getVendedor(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            
            dgvDados.DataSource = VendedorBLL.ToList_VendedorView(VendedorList);

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);

            VendedorBLL = new VendedorBLL();

            if (Convert.ToInt32(dgvDados[COL_ID, dgvDados.CurrentRow.Index].Value) > 0)
            {
                Vendedor Vendedor = VendedorBLL.Localizar(Convert.ToInt32(dgvDados[COL_ID, dgvDados.CurrentRow.Index].Value));
                if (MessageBox.Show("Deseja realmente excluir o registro : " + Vendedor.codInt + " - " + Vendedor.nome, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool intOmie = Convert.ToBoolean(Parametro.GetParametro("intOmie"));
                    bool updateVendedorOmie = Convert.ToBoolean(Parametro.GetParametro("updateVendedorOmie"));

                    string retorno = string.Empty;

                    retorno = "Vendedor excluído com sucesso.";
                    VendedorBLL.ExcluirVendedor(Vendedor);
                    if ((intOmie) & (updateVendedorOmie))
                    {                        
                        VendedorProxy proxy = new VendedorProxy();
                        retorno = proxy.ExcluirVendedor(Vendedor);
                        
                    }
                        
                    MessageBox.Show(retorno, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        #endregion
    }
}
