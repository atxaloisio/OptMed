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
    public partial class frmListPerfis : optmed.frmBaseList
    {
        PerfilBLL PerfilBLL;

        #region Constante de Colunas da Grid
        private const int col_Id = 0;        
        private const int col_nome = 1;
        private const int col_descricao = 2;
        private const int col_inclusao = 3;
        private const int col_usuario_inclusao = 4;
        private const int col_alteracao = 5;
        private const int col_usuario_alteracao = 6;

        #endregion

        public frmListPerfis()
        {
            InitializeComponent();            
        }

        private void frmPerfis_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditPerfil();
        }

        protected override void formataColunagridFiltros(DataGridView gridFiltros)
        {
            base.formataColunagridFiltros(gridFiltros);
            //altera o nome das colunas                        
            gridFiltros.Columns.Add("ID", "Código");
            gridFiltros.Columns.Add("NOME", "Nome");
            gridFiltros.Columns.Add("DESCRICAO", "Descrição");

            DataGridViewMaskedTextColumn col = new DataGridViewMaskedTextColumn("99/99/9999");
            col.DataPropertyName = "INCLUSAO";
            col.HeaderText = "Dt. Inclusão";
            col.Name = "INCLUSAO";
            col.ValueType = typeof(DateTime);
            col.SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns.Add(col);
            gridFiltros.Columns.Add("USRINCLUSAO", "Usuário Inclusão");

            DataGridViewMaskedTextColumn col2 = new DataGridViewMaskedTextColumn("99/99/9999");
            col2.DataPropertyName = "ALTERACAO";
            col2.HeaderText = "Dt. Alteração";
            col2.Name = "ALTERACAO";
            col2.ValueType = typeof(DateTime);
            col2.SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns.Add(col2);
            gridFiltros.Columns.Add("USRALTERACAO", "Usuário Alteração");
           
            gridFiltros.Columns[col_Id].Width = 70;
            gridFiltros.Columns[col_Id].ValueType = typeof(int);
            gridFiltros.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_nome].Width = 200;
            gridFiltros.Columns[col_nome].ValueType = typeof(string);
            gridFiltros.Columns[col_nome].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_descricao].Width = 200;
            gridFiltros.Columns[col_descricao].ValueType = typeof(string);
            gridFiltros.Columns[col_descricao].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_inclusao].Width = 200;

            gridFiltros.Columns[col_usuario_inclusao].Width = 200;
            gridFiltros.Columns[col_usuario_inclusao].ValueType = typeof(string);
            gridFiltros.Columns[col_usuario_inclusao].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_alteracao].Width = 200;

            gridFiltros.Columns[col_usuario_alteracao].Width = 200;
            gridFiltros.Columns[col_usuario_alteracao].ValueType = typeof(string);
            gridFiltros.Columns[col_usuario_alteracao].SortMode = DataGridViewColumnSortMode.Programmatic;



            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();
                       
        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[col_Id].Width = 70;
            gridDados.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_nome].Width = 200;
            gridDados.Columns[col_nome].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_descricao].Width = 200;
            gridDados.Columns[col_descricao].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_inclusao].Width = 200;
            gridDados.Columns[col_inclusao].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_usuario_inclusao].Width = 200;
            gridDados.Columns[col_usuario_inclusao].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_alteracao].Width = 200;
            gridDados.Columns[col_alteracao].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_usuario_alteracao].Width = 200;
            gridDados.Columns[col_usuario_alteracao].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            base.carregaConsulta();
            PerfilBLL = new PerfilBLL();                        
            dgvDados.DataSource = PerfilBLL.getPerfil(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);
            PerfilBLL = new PerfilBLL();

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

                case 1:
                    {
                        List<Perfil> PerfilList = PerfilBLL.getPerfil(p => p.nome, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = PerfilList;
                    }
                    break;

                case 2:
                    {
                        List<Perfil> PerfilList = PerfilBLL.getPerfil(p => p.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = PerfilList;
                    }
                    break;

                case 3:
                    {
                        List<Perfil> PerfilList = PerfilBLL.getPerfil(p => p.inclusao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = PerfilList;
                    }
                    break;
                case 4:
                    {
                        List<Perfil> PerfilList = PerfilBLL.getPerfil(p => p.usuario_inclusao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = PerfilList;
                    }
                    break;
                case 5:
                    {
                        List<Perfil> PerfilList = PerfilBLL.getPerfil(p => p.alteracao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = PerfilList;
                    }
                    break;

                case 6:
                    {
                        List<Perfil> PerfilList = PerfilBLL.getPerfil(p => p.usuario_alteracao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = PerfilList;
                    }
                    break;
                //O default será executado quando o index for 0
                default:
                    {
                        List<Perfil> PerfilList = PerfilBLL.getPerfil(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = PerfilList;
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

            if (e.ColumnIndex == col_nome && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == col_descricao && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (((e.ColumnIndex == col_inclusao)||(e.ColumnIndex == col_alteracao)) && !string.IsNullOrEmpty((string)e.FormattedValue))
            {

                if ((string.IsNullOrEmpty((string)e.FormattedValue)) || ((string)e.FormattedValue == "__/__/____"))
                {
                    dgvFiltro[e.ColumnIndex, e.RowIndex].Value = "";
                    return;

                }

                if (!ValidateUtils.isDate((string)e.FormattedValue))
                {
                    e.Cancel = true;
                    dgvFiltro[e.ColumnIndex, e.RowIndex].Value = "";
                    MessageBox.Show("Data inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Executa filtro.
                }
            }            
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            int id = 0;
            string nome = string.Empty, usuario_inclusao = string.Empty, usuario_alteracao = string.Empty, descricao = string.Empty;            
            DateTime? inclusao = null,alteracao  = null;

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_Id, e.RowIndex].Value.ToString()))
            {
                id = Convert.ToInt32(dgvFiltro[col_Id, e.RowIndex].Value);
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_nome, e.RowIndex].Value))
            {
                nome = dgvFiltro[col_nome, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_descricao, e.RowIndex].Value))
            {
                descricao = dgvFiltro[col_descricao, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_inclusao, e.RowIndex].Value))
            {
                inclusao = Convert.ToDateTime(dgvFiltro[col_inclusao, e.RowIndex].Value);
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_alteracao, e.RowIndex].Value))
            {
                alteracao = Convert.ToDateTime(dgvFiltro[col_alteracao, e.RowIndex].Value);
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_usuario_inclusao, e.RowIndex].Value))
            {
                usuario_inclusao = dgvFiltro[col_usuario_inclusao, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[col_usuario_alteracao, e.RowIndex].Value))
            {
                usuario_alteracao = dgvFiltro[col_usuario_alteracao, e.RowIndex].Value.ToString();
            }

        
            Expression<Func<Perfil, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(nome))
            {
                predicate = predicate.And(p => p.nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                predicate = predicate.And(p => p.descricao.Contains(descricao));
            }

            if (!string.IsNullOrEmpty(usuario_inclusao))
            {
                predicate = predicate.And(p => p.usuario_inclusao.Contains(usuario_inclusao));
            }

            if (!string.IsNullOrEmpty(usuario_alteracao))
            {
                predicate = predicate.And(p => p.usuario_alteracao.Contains(usuario_alteracao));
            }

            if ((inclusao != null) & (ValidateUtils.isDate(inclusao.ToString())))
            {
                predicate = predicate.And(p => DbFunctions.TruncateTime(p.inclusao) == DbFunctions.TruncateTime(inclusao));
            }

            if ((alteracao != null) & (ValidateUtils.isDate(alteracao.ToString())))
            {
                predicate = predicate.And(p => DbFunctions.TruncateTime(p.alteracao) == DbFunctions.TruncateTime(alteracao));
            }

            List<Perfil> PerfilList = PerfilBLL.getPerfil(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = PerfilList;

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);
            PerfilBLL = new PerfilBLL();
            try
            {
                if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
                {
                    Perfil Perfil = PerfilBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                    if (MessageBox.Show("Deseja realmente excluir o registro : " + Perfil.Id.ToString() + " - " + Perfil.nome, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PerfilBLL.ExcluirPerfil(Perfil);
                    }

                }
            }
            finally
            {
                PerfilBLL.Dispose();
            }

        }
        #endregion
        
        private void frmPerfis_BindingContextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
