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
    public partial class frmListRotas : optmed.frmBaseList
    {
        RotaBLL rotaBLL;

        #region Constante de Colunas da Grid
        private const int col_Id = 0;
        private const int col_transportadora = 1;
        private const int col_uf = 2;
        private const int col_cidade = 3;


        #endregion
        public frmListRotas()
        {            
            InitializeComponent();            
        }

        private void frmListRotas_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditRota();
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
            gridFiltros.Columns.Add("TRANSPORTADORA", "Transportadora");

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



            gridFiltros.Columns[col_Id].Width = 70;
            gridFiltros.Columns[col_Id].ValueType = typeof(int);
            gridFiltros.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[col_Id].Visible = true;

            gridFiltros.Columns[col_transportadora].Width = 300;
            gridFiltros.Columns[col_transportadora].ValueType = typeof(string);
            gridFiltros.Columns[col_transportadora].SortMode = DataGridViewColumnSortMode.Programmatic;

            


            gridFiltros.Columns[col_uf].Width = 50;
            //gridFiltros.Columns[col_uf].ValueType = typeof(string);
            gridFiltros.Columns[col_uf].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_cidade].Width = 200;
            gridFiltros.Columns[col_cidade].ValueType = typeof(string);
            gridFiltros.Columns[col_cidade].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gridFiltros_EditingControlShowing);

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();

        }

        private void gridFiltros_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            switch (dgvFiltro.CurrentCell.ColumnIndex)
            {                
                case col_uf:
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
            
            Expression<Func<Rota, bool>> predicate = p => true;

            if (!string.IsNullOrEmpty(value))
            {
                predicate = predicate.And(p => p.cidade.cUF == value & p.cliente.cliente_tag.Any(c => c.tag == "Transportadora"));
            }

            rotaBLL = new RotaBLL();
            List<Rota> RotaList = rotaBLL.getRota(predicate.Expand(), t => t.id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            
            dgvDados.DataSource = rotaBLL.ToList_RotaView(RotaList);
        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[col_Id].Width = 70;
            gridDados.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_Id].Visible = true;
            gridDados.Columns[col_transportadora].Width = 300;
            gridDados.Columns[col_transportadora].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_uf].Width = 50;
            gridDados.Columns[col_uf].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_cidade].Width = 200;
            gridDados.Columns[col_cidade].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            rotaBLL = new RotaBLL();
            base.carregaConsulta();
            dgvDados.DataSource = null;
            List<Rota> RotaList = rotaBLL.getRota(p => p.id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            
            dgvDados.DataSource = rotaBLL.ToList_RotaView(RotaList);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);

            rotaBLL = new RotaBLL();

            List<Rota> RotaList;

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

                case col_transportadora:
                    {
                        RotaList = rotaBLL.getRota(x => x.cliente.cliente_tag.Any(c => c.tag == "Transportadora"), p => p.cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;

                case col_uf:
                    {
                        RotaList = rotaBLL.getRota(x => x.cliente.cliente_tag.Any(c => c.tag == "Transportadora"), p => p.cidade.cUF, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;

                case col_cidade:
                    {
                        RotaList = rotaBLL.getRota(x => x.cliente.cliente_tag.Any(c => c.tag == "Transportadora"), p => p.cidade.cNome, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        RotaList = rotaBLL.getRota(x => x.cliente.cliente_tag.Any(c => c.tag == "Transportadora"), p => p.id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);                        
                    }
                    break;
            }
           
            dgvDados.DataSource = rotaBLL.ToList_RotaView(RotaList);

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

            if (e.ColumnIndex == col_transportadora && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == col_uf && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == col_cidade && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            rotaBLL = new RotaBLL();

            int id = 0;
            string transportadora = string.Empty;
            string uf = string.Empty;
            string cidade = string.Empty;

            if (dgvFiltro[col_Id, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_Id, e.RowIndex].Value.ToString()))
                {
                    id = Convert.ToInt32(dgvFiltro[col_Id, e.RowIndex].Value);
                }
            }
            
            if (dgvFiltro[col_transportadora, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_transportadora, e.RowIndex].Value))
                {
                    transportadora = dgvFiltro[col_transportadora, e.RowIndex].Value.ToString();
                }
            }
            
            if (dgvFiltro[col_uf, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_uf, e.RowIndex].Value))
                {
                    uf = dgvFiltro[col_uf, e.RowIndex].Value.ToString();
                }
            }
            
            if (dgvFiltro[col_cidade, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_cidade, e.RowIndex].Value))
                {
                    cidade = dgvFiltro[col_cidade, e.RowIndex].Value.ToString();
                }
            }
            

            Expression<Func<Rota, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.id == id;
            }

            if (!string.IsNullOrEmpty(transportadora))
            {
                predicate = predicate.And(p => p.cliente.razao_social.Contains(transportadora) & p.cliente.cliente_tag.Any(c => c.tag == "Transportadora"));
            }

            if (!string.IsNullOrEmpty(uf))
            {
                predicate = predicate.And(p => p.cidade.cUF.Contains(uf));
            }

            if (!string.IsNullOrEmpty(cidade))
            {
                predicate = predicate.And(p => p.cidade.cNome.ToLower().Contains(cidade.ToLower()));
            }

            List<Rota> RotaList = rotaBLL.getRota(predicate.Expand(), t => t.id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            
            dgvDados.DataSource = rotaBLL.ToList_RotaView(RotaList);

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);

            rotaBLL = new RotaBLL();

            if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
            {
                Rota rota = rotaBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                if (MessageBox.Show("Deseja realmente excluir o registro : " + rota.cliente.nome_fantasia + " - " + rota.cidade.cNome, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rotaBLL.ExcluirRota(rota);
                }
            }
        }
        
        #endregion
    }
}
