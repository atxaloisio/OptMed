using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Utils;
using BLL;
using Model;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using JThomas.Controls;
using LinqKit;
using Sync;
using System.Globalization;

namespace optmed
{
    public partial class frmProcAtualizaStatusPedido : optmed.frmBase
    {
        #region Constante de Colunas da Grid
        private const int COL_ID = 0;
        private const int COL_PEDIDO = 1;
        private const int COL_CLIENTE = 2;
        private const int COL_CONDPAG = 3;
        private const int COL_DTEMISSAO = 4;
        private const int COL_DTFECHAMENTO = 5;
        private const int COL_STATUS = 6;
        #endregion                               
        protected virtual int colOrdem { get; set; }
        private Pedido_OticaBLL pedido_OticaBLL;
        public frmProcAtualizaStatusPedido()
        {
            InitializeComponent();
            carregaDados();
        }

        private void frmProcAtualizaStatusPedido_Activated(object sender, EventArgs e)
        {

        }

        protected virtual void frmProcAtualizaStatusPedido_Load(object sender, EventArgs e)
        {

        }

        protected virtual void formataGridFiltro()
        {
            var gridFiltros = dgvFiltro;
            gridFiltros.AutoGenerateColumns = false;
            gridFiltros.AllowUserToAddRows = false;
            gridFiltros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridFiltros.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gridFiltros.RowHeadersVisible = false;
            formataColunagridFiltros(gridFiltros);
            //altera a cor das linhas alternadas no grid
            gridFiltros.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            gridFiltros.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine;

            //seleciona uma celula
            gridFiltros.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //não permite seleção de multiplas linhas
            gridFiltros.MultiSelect = false;
            // exibe nulos formatados
            //gridFiltros.DefaultCellStyle.NullValue = " - ";
            //permite que o texto maior que célula não seja truncado
            gridFiltros.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridFiltros.DefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Regular);
            gridFiltros.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);

            gridFiltros.DataError += new DataGridViewDataErrorEventHandler(dgvFiltro_DataError);

            gridFiltros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvFiltro_EditingControlShowing);

            gridFiltros.CellValidating += new DataGridViewCellValidatingEventHandler(dgvFiltro_CellValidating);
            gridFiltros.KeyDown += new KeyEventHandler(dgvFiltro_KeyDown);
            gridFiltros.CellEndEdit += new DataGridViewCellEventHandler(dgvFiltro_CellEndEdit);

            gridFiltros.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dgvFiltro_ColumnHeaderMouseClick);
            gridFiltros.CellLeave += new DataGridViewCellEventHandler(gridFiltros_CellLeave);
        }

        private void gridFiltros_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                executeCellLeaveChild(sender, e);
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected virtual void executeCellLeaveChild(object sender, DataGridViewCellEventArgs e)
        {
            executeFilter(sender, e);
        }

        private void dgvFiltro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ordenaCelula(sender, e);
        }

        protected virtual void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{

            //}
            //pedido_OticaBLL = new Pedido_OticaBLL();

            //DataGridViewColumn col = dgvFiltro.Columns[e.ColumnIndex];
            //DataGridViewColumn colAnt = dgvFiltro.Columns[colOrdem];
            //int? status = null;

            //ListSortDirection direction;

            //switch (col.HeaderCell.SortGlyphDirection)
            //{
            //    case SortOrder.None:
            //        direction = ListSortDirection.Ascending;
            //        break;
            //    case SortOrder.Ascending:
            //        direction = ListSortDirection.Ascending;
            //        break;
            //    case SortOrder.Descending:
            //        direction = ListSortDirection.Descending;
            //        break;
            //    default:
            //        direction = ListSortDirection.Ascending;
            //        break;
            //}


            //if (colOrdem == e.ColumnIndex)
            //{
            //    if (direction == ListSortDirection.Ascending)
            //    {
            //        direction = ListSortDirection.Descending;
            //    }
            //    else
            //    {
            //        direction = ListSortDirection.Ascending;
            //        col.HeaderCell.SortGlyphDirection = SortOrder.None;
            //    }
            //}
            //else
            //{
            //    direction = ListSortDirection.Ascending;
            //    colAnt.HeaderCell.SortGlyphDirection = SortOrder.None;
            //}

            //if (dgvFiltro[COL_STATUS, 0].Value != null)
            //{
            //    status = (int)((DataGridViewComboBoxCell)dgvFiltro[COL_STATUS, 0]).Value;
            //}

            //if (status == null || status == 7)
            //{
            //    status = (int)StatusPedido.IMPRESSO;
            //}

            //switch (e.ColumnIndex)
            //{

            //    case COL_PEDIDO:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.codigo.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;

            //    case COL_PEDIDO_OMIE:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.codigo_pedido.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;

            //    case COL_CLIENTE:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;

            //    case COL_CONDPAG:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.parcela.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;

            //    case COL_DTEMISSAO:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.data_emissao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;

            //    case COL_DTFECHAMENTO:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.data_emissao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;

            //    case COL_STATUS:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.status.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;

            //    //O default será executado quando o index for 0
            //    default:
            //        {
            //            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
            //            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
            //        }
            //        break;
            //}

            //colOrdem = e.ColumnIndex;

            //col.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }

        private void dgvFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvFiltro.CurrentCell.ColumnIndex;
                int iRow = dgvFiltro.CurrentCell.RowIndex;
                if (iColumn == dgvFiltro.Columns.Count - 1)
                    dgvFiltro.CurrentCell = dgvFiltro[COL_PEDIDO, iRow];
                else
                {
                    try
                    {
                        dgvFiltro.CurrentCell = dgvFiltro[iColumn + 1, iRow];
                    }
                    catch (Exception)
                    {
                        dgvFiltro.CurrentCell = dgvFiltro[iColumn, iRow];
                    }
                }
            }

            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.Back))
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvFiltro.CurrentCell.ColumnIndex;
                int iRow = dgvFiltro.CurrentCell.RowIndex;

                dgvFiltro[iColumn, iRow].Value = "";

                DataGridViewCellEventArgs eventArgs = new DataGridViewCellEventArgs(iColumn, iRow);

                dgvFiltro_CellEndEdit(dgvFiltro, eventArgs);

                dgvFiltro.CurrentCell = dgvFiltro[iColumn, iRow];
            }
        }

        private void dgvFiltro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                executeCellEndEditChild(sender, e);
                dgvFiltro.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected virtual void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            Expression<Func<Pedido_Otica, bool>> predicate = executeFilter(sender, e);
            carregaConsulta(predicate);
        }

        private Expression<Func<Pedido_Otica, bool>> executeFilter(object sender, DataGridViewCellEventArgs e)
        {
            int codigo = 0;
            string cliente = string.Empty;
            string condPag = string.Empty;
            DateTime? DtEmiss = null;
            DateTime? DtFecha = null;
            int? status = null;

            if (dgvFiltro[COL_PEDIDO, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty(dgvFiltro[COL_PEDIDO, e.RowIndex].Value.ToString()))
                {
                    codigo = Convert.ToInt32(dgvFiltro[COL_PEDIDO, e.RowIndex].Value);
                }
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_CLIENTE, e.RowIndex].Value))
            {
                cliente = dgvFiltro[COL_CLIENTE, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_CONDPAG, e.RowIndex].Value))
            {
                condPag = dgvFiltro[COL_CONDPAG, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_DTEMISSAO, e.RowIndex].Value))
            {
                if (dgvFiltro[COL_DTEMISSAO, e.RowIndex].Value.ToString() != "__/__/____")
                {
                    if (ValidateUtils.isDate((string)dgvFiltro[COL_DTEMISSAO, e.RowIndex].Value.ToString()))
                    {
                        DtEmiss = Convert.ToDateTime(dgvFiltro[COL_DTEMISSAO, e.RowIndex].Value);
                    }
                }
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_DTFECHAMENTO, e.RowIndex].Value))
            {
                if (dgvFiltro[COL_DTFECHAMENTO, e.RowIndex].Value.ToString() != "__/__/____")
                {
                    if (ValidateUtils.isDate((string)dgvFiltro[COL_DTFECHAMENTO, e.RowIndex].Value.ToString()))
                    {
                        DtFecha = Convert.ToDateTime(dgvFiltro[COL_DTFECHAMENTO, e.RowIndex].Value);
                    }
                }

            }

            if (dgvFiltro[COL_STATUS, e.RowIndex].Value != null)
            {
                status = (int)((DataGridViewComboBoxCell)dgvFiltro[COL_STATUS, e.RowIndex]).Value;
            }

            //var predicate = PredicateBuilder.True<Pedido_Otica>();


            Expression<Func<Pedido_Otica, bool>> predicate = p => true;


            if (codigo > 0)
            {
                predicate = predicate = p => p.codigo == codigo;
            }

            if (!string.IsNullOrEmpty(cliente))
            {
                predicate = predicate.And(p => p.cliente.nome_fantasia.ToLower().Contains(cliente.ToLower()));
            }

            if (!string.IsNullOrEmpty(condPag))
            {
                predicate = predicate.And(p => p.parcela.descricao.Contains(condPag));
            }

            if ((DtEmiss != null) & (ValidateUtils.isDate(DtEmiss.ToString())))
            {
                predicate = predicate.And(p => DbFunctions.TruncateTime(p.data_emissao) == DbFunctions.TruncateTime(DtEmiss));
            }

            if ((DtFecha != null) & (ValidateUtils.isDate(DtFecha.ToString())))
            {
                predicate = predicate.And(p => DbFunctions.TruncateTime(p.data_fechamento) == DbFunctions.TruncateTime(DtFecha));
            }

            if ((status != null) && (status != 9))
            {
                predicate = predicate.And(p => p.status == status);
            }

            return predicate;

        }

        private void dgvFiltro_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                executeCellValidatingChild(sender, e);
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void executeCellValidatingChild(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == COL_ID && !string.IsNullOrEmpty((string)e.FormattedValue))
            //{
            //    //
            //}

            //if (e.ColumnIndex == COL_PEDIDO && !string.IsNullOrEmpty((string)e.FormattedValue))
            //{
            //    //Executa filtro.                
            //}

            //if (e.ColumnIndex == COL_CLIENTE && !string.IsNullOrEmpty((string)e.FormattedValue))
            //{
            //    //Executa filtro.                
            //}

            //if (e.ColumnIndex == COL_CONDPAG && !string.IsNullOrEmpty((string)e.FormattedValue))
            //{
            //    //Executa filtro.                
            //}

            //if (e.ColumnIndex == COL_DTEMISSAO && !string.IsNullOrEmpty((string)e.FormattedValue))
            //{

            //    if ((string.IsNullOrEmpty((string)e.FormattedValue)) || ((string)e.FormattedValue == "__/__/____"))
            //    {
            //        dgvFiltro[e.ColumnIndex, e.RowIndex].Value = "";
            //        return;

            //    }

            //    if (!ValidateUtils.isDate((string)e.FormattedValue))
            //    {
            //        e.Cancel = true;
            //        dgvFiltro[e.ColumnIndex, e.RowIndex].Value = "";
            //        MessageBox.Show("Data inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    else
            //    {
            //        //Executa filtro.
            //    }
            //}

            //if (e.ColumnIndex == COL_DTFECHAMENTO && !string.IsNullOrEmpty((string)e.FormattedValue))
            //{

            //    if ((string.IsNullOrEmpty((string)e.FormattedValue)) || ((string)e.FormattedValue == "__/__/____"))
            //    {
            //        dgvFiltro[e.ColumnIndex, e.RowIndex].Value = "";
            //        return;

            //    }

            //    if (!ValidateUtils.isDate((string)e.FormattedValue))
            //    {
            //        e.Cancel = true;
            //        dgvFiltro[e.ColumnIndex, e.RowIndex].Value = "";
            //        MessageBox.Show("Data inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    else
            //    {
            //        //Executa filtro.
            //    }
            //}

            //if (e.ColumnIndex == COL_STATUS && !string.IsNullOrEmpty((string)e.FormattedValue))
            //{
            //    //Executa filtro.                
            //}
        }

        protected virtual void dgvFiltro_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show(e.Exception.Message);
            }

            //&& e.Context == DataGridViewDataErrorContexts.Parsing)
        }

        private void dgvFiltro_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                executeEditingControlShowingChild(sender, e);
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected virtual void executeEditingControlShowingChild(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (dgvFiltro.CurrentCell.ColumnIndex)
            {
                case COL_PEDIDO:
                    {
                        TextBox tb = e.Control as TextBox;
                        if (tb != null)
                        {
                            tb.KeyPress -= new KeyPressEventHandler(Col_Pedido_KeyPress);
                            tb.KeyPress += new KeyPressEventHandler(Col_Pedido_KeyPress);
                        }
                    }
                    break;
                case COL_DTEMISSAO:
                case COL_DTFECHAMENTO:
                    {
                        TextBox tb = e.Control as TextBox;
                        if (tb != null)
                        {
                            tb.KeyPress -= new KeyPressEventHandler(Col_DtEmissaoFechamento_KeyPress);
                            tb.Validating -= new CancelEventHandler(Col_DtEmissaoFechamento_Validating);
                            tb.KeyPress += new KeyPressEventHandler(Col_DtEmissaoFechamento_KeyPress);
                            tb.Validating += new CancelEventHandler(Col_DtEmissaoFechamento_Validating);
                        }
                    }
                    break;
                case COL_CONDPAG:                    
                case COL_STATUS:
                    {
                        if (e.Control is ComboBox)
                        {
                            ComboBox cb = e.Control as ComboBox;
                            if (cb != null)
                            {
                                cb.SelectionChangeCommitted -= new EventHandler(ComboBox_SelectionChangeCommitted);
                                cb.SelectionChangeCommitted -= new EventHandler(cbCondPag_SelectionChangeCommitted);
                                if (cb.SelectedItem is itemEnumList)
                                {
                                    
                                    cb.SelectionChangeCommitted += new EventHandler(ComboBox_SelectionChangeCommitted);
                                }
                                else if (cb.SelectedItem is Parcela)
                                {                                    
                                    cb.SelectionChangeCommitted += new EventHandler(cbCondPag_SelectionChangeCommitted);
                                }                                
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void cbCondPag_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            string value = string.Empty;

            value = cb.SelectedValue.ToString();

            dgvFiltro[COL_CONDPAG, 0].Value = value;

            int iRow = dgvFiltro.CurrentCell.RowIndex;

            DataGridViewCellEventArgs eventArgs = new DataGridViewCellEventArgs(COL_CONDPAG, iRow);

            dgvFiltro_CellEndEdit(dgvFiltro, eventArgs);

        }

        private void Col_DtEmissaoFechamento_Validating(object sender, CancelEventArgs e)
        {
            var controle = ((DataGridViewTextBoxEditingControl)sender);
            // ValidateUtils é uma classe estática utilizada para validação
            if (!string.IsNullOrEmpty(controle.Text) && !ValidateUtils.isDate(controle.Text))
            {
                controle.Clear();
                e.Cancel = true;
                MessageBox.Show("Data inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Col_DtEmissaoFechamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !e.KeyChar.Equals('/') && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Col_Pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals(8))
            {
                e.Handled = true;
            }
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            int? value = null;

            if (cb.SelectedValue is itemEnumList)
            {
                value = Convert.ToInt32(((itemEnumList)cb.SelectedValue).chave);
            }
            else
            {
                value = Convert.ToInt32(cb.SelectedValue);
            }

            dgvFiltro[COL_STATUS, 0].Value = value;

            int iColumn = dgvFiltro.CurrentCell.ColumnIndex;
            int iRow = dgvFiltro.CurrentCell.RowIndex;

            DataGridViewCellEventArgs eventArgs = new DataGridViewCellEventArgs(iColumn, iRow);

            if (value == 9)
            {
                dgvFiltro_CellEndEdit(dgvFiltro, eventArgs);
            }
            else
            {
                limpaLlbsCount();
                switch (value)
                {
                    case (int)StatusPedido.GRAVADO:
                    case (int)StatusPedido.IMPRESSO:
                        {
                            var predicate = executeFilter(dgvFiltro, eventArgs);
                            LimpaCartoes(pnlAGProducao);
                            LimpaCartoes(pnlEmProducao);
                            LimpaCartoes(pnlAEntregar);
                            LimpaCartoes(pnlSaiuPEntrega);
                            LimpaCartoes(pnlEntregue);
                            carregaGravadasImpressas(predicate);
                        }
                        break;
                    case (int)StatusPedido.AGPRODUCAO:
                        {
                            var predicate = executeFilter(dgvFiltro, eventArgs);
                            LimpaCartoes(pnlGravadaImpressa);
                            LimpaCartoes(pnlEmProducao);
                            LimpaCartoes(pnlAEntregar);
                            LimpaCartoes(pnlSaiuPEntrega);
                            LimpaCartoes(pnlEntregue);
                            carregaAgProducao(predicate);
                        }
                        break;
                    case (int)StatusPedido.PRODUCAO:
                        {
                            var predicate = executeFilter(dgvFiltro, eventArgs);
                            LimpaCartoes(pnlGravadaImpressa);
                            LimpaCartoes(pnlAGProducao);
                            LimpaCartoes(pnlAEntregar);
                            LimpaCartoes(pnlSaiuPEntrega);
                            LimpaCartoes(pnlEntregue);
                            carregaEmProducao(predicate);
                        }
                        break;
                    case (int)StatusPedido.AENTREGAR:
                        {
                            var predicate = executeFilter(dgvFiltro, eventArgs);
                            LimpaCartoes(pnlGravadaImpressa);
                            LimpaCartoes(pnlEmProducao);
                            LimpaCartoes(pnlAGProducao);
                            LimpaCartoes(pnlSaiuPEntrega);
                            LimpaCartoes(pnlEntregue);
                            carregaAEntregar(predicate);
                        }
                        break;
                    case (int)StatusPedido.SAIUPENTREGA:
                        {
                            var predicate = executeFilter(dgvFiltro, eventArgs);
                            LimpaCartoes(pnlGravadaImpressa);
                            LimpaCartoes(pnlAGProducao);
                            LimpaCartoes(pnlEmProducao);
                            LimpaCartoes(pnlAEntregar);                            
                            LimpaCartoes(pnlEntregue);
                            carregaSaiuPEntrega(predicate);
                        }
                        break;
                    case (int)StatusPedido.ENTREGUE:
                        {
                            var predicate = executeFilter(dgvFiltro, eventArgs);
                            LimpaCartoes(pnlGravadaImpressa);
                            LimpaCartoes(pnlAGProducao);
                            LimpaCartoes(pnlEmProducao);
                            LimpaCartoes(pnlAEntregar);
                            LimpaCartoes(pnlSaiuPEntrega);                            
                            carregaEntregues(predicate);
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        private void limpaLlbsCount()
        {
            lblCountGravadas.Text = "(0)";
            lblCountAgProducao.Text = "(0)";
            lblCountEmProducao.Text = "(0)";
            lblCountAEntregar.Text = "(0)";
            lblCountSaiuPEntrega.Text = "(0)";
            lblCountEntregue.Text = "(0)";
        }

        protected virtual void formataColunagridFiltros(DataGridView gridFiltros)
        {
            //altera o nome das colunas                        
            //altera o nome das colunas                 
            gridFiltros.Columns.Add("ID", "Id");

            gridFiltros.Columns.Add("PEDIDO", "Pedido");
            gridFiltros.Columns.Add("CLIENTE", "Cliente");

            DataGridViewComboBoxColumn colCondPagto = new DataGridViewComboBoxColumn();
            ParcelaBLL parcelaBLL = new ParcelaBLL();
            IList<Parcela> ParcelaList = parcelaBLL.getParcela();
            ParcelaList.Insert(0, new Parcela { Id = 7, descricao = string.Empty });
            colCondPagto.DataSource = ParcelaList;
            colCondPagto.ValueMember = "descricao";
            colCondPagto.DisplayMember = "descricao";
            colCondPagto.DataPropertyName = "CONDPAGTO";
            colCondPagto.HeaderText = "Cond. Pagamento";
            colCondPagto.Name = "CONDPAGTO";
            colCondPagto.SortMode = DataGridViewColumnSortMode.NotSortable;
            gridFiltros.Columns.Add(colCondPagto);

            //gridFiltros.Columns.Add("CONDPAGTO", "Cond. Pagamento");

            DataGridViewMaskedTextColumn colDtEmissao = new DataGridViewMaskedTextColumn("99/99/9999");
            colDtEmissao.DataPropertyName = "DTEMISSAO";
            colDtEmissao.HeaderText = "Emissão";
            colDtEmissao.Name = "DTEMISSAO";
            colDtEmissao.ValueType = typeof(DateTime);
            colDtEmissao.SortMode = DataGridViewColumnSortMode.NotSortable;
            colDtEmissao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDtEmissao.DefaultCellStyle.Format = "d";
            gridFiltros.Columns.Add(colDtEmissao);

            DataGridViewMaskedTextColumn colDtFechamento = new DataGridViewMaskedTextColumn("99/99/9999");
            colDtFechamento.DataPropertyName = "DTFECHAMENTO";
            colDtFechamento.HeaderText = "Fechamento";
            colDtFechamento.Name = "DTFECHAMENTO";
            colDtFechamento.ValueType = typeof(DateTime);
            colDtFechamento.SortMode = DataGridViewColumnSortMode.NotSortable;
            colDtFechamento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDtFechamento.DefaultCellStyle.Format = "d";
            gridFiltros.Columns.Add(colDtFechamento);

            StatusPedido sp = new StatusPedido();
            DataGridViewComboBoxColumn colStatus = new DataGridViewComboBoxColumn();
            int statusEntregue = (int)StatusPedido.ENTREGUE;
            IList<itemEnumList> lstStatusPedido = Enumerados.getListEnum(sp).Where(p =>p.chave <= statusEntregue).ToList();
            lstStatusPedido.Insert(0, new itemEnumList { chave = 9, descricao = string.Empty });
            colStatus.DataSource = lstStatusPedido;
            colStatus.ValueMember = "chave";
            colStatus.DisplayMember = "descricao";
            colStatus.DataPropertyName = "STATUS";
            colStatus.HeaderText = "Status";
            colStatus.Name = "STATUS";
            colStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
            gridFiltros.Columns.Add(colStatus);

            //
            gridFiltros.Columns[COL_ID].Width = 150;
            gridFiltros.Columns[COL_ID].ValueType = typeof(int);
            gridFiltros.Columns[COL_ID].Visible = false;

            gridFiltros.Columns[COL_PEDIDO].Width = 100;
            gridFiltros.Columns[COL_PEDIDO].ValueType = typeof(int);
            gridFiltros.Columns[COL_PEDIDO].SortMode = DataGridViewColumnSortMode.NotSortable;
            gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle);
            gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFiltros.Columns[COL_PEDIDO].Frozen = true;

            gridFiltros.Columns[COL_CLIENTE].Width = 300;
            gridFiltros.Columns[COL_CLIENTE].ValueType = typeof(string);
            gridFiltros.Columns[COL_CLIENTE].SortMode = DataGridViewColumnSortMode.NotSortable;
            gridFiltros.Columns[COL_CLIENTE].Frozen = true;

            gridFiltros.Columns[COL_CONDPAG].Width = 200;
            gridFiltros.Columns[COL_CONDPAG].Frozen = true;

            gridFiltros.Columns[COL_DTEMISSAO].Width = 140;
            gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle);
            gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFiltros.Columns[COL_DTEMISSAO].Frozen = true;

            gridFiltros.Columns[COL_DTFECHAMENTO].Width = 140;
            gridFiltros.Columns[COL_DTFECHAMENTO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_DTFECHAMENTO].DefaultCellStyle);
            gridFiltros.Columns[COL_DTFECHAMENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFiltros.Columns[COL_DTFECHAMENTO].Frozen = true;

            gridFiltros.Columns[COL_STATUS].Width = 190;
            gridFiltros.Columns[COL_STATUS].Frozen = true;

            //gridFiltros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gridFiltros_EditingControlShowing);

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();
        }

        protected virtual void carregaConsulta(Expression<Func<Pedido_Otica, bool>> predicate = null)
        {
            //Metodos de carga individual por panel x status
            carregaGravadasImpressas(predicate);
            carregaAgProducao(predicate);
            carregaEmProducao(predicate);
            carregaAEntregar(predicate);
            carregaSaiuPEntrega(predicate);
            carregaEntregues(predicate);
            colOrdem = 0;
        }

        private void carregaGravadasImpressas(Expression<Func<Pedido_Otica, bool>> predicate)
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            Expression<Func<Pedido_Otica, bool>> predGavImpress = p => true;

            if (predicate != null)
            {
                predGavImpress = predicate.Expand();
            }

            int stgravado = (int)StatusPedido.GRAVADO;
            int stImpresso = (int)StatusPedido.IMPRESSO;
            predGavImpress = predGavImpress.And(c => c.status == stgravado || c.status == stImpresso);
            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(predGavImpress.Expand());
            lblCountGravadas.Text = "(" + Pedido_OticaList.Count().ToString() + ")";
            LimpaCartoes(pnlGravadaImpressa);
            for (int index = Pedido_OticaList.Count() - 1; index > -1; index--)
            {
                Pedido_Otica pedido_otica = Pedido_OticaList[index];
                AdicionaCartao(pnlGravadaImpressa, pedido_otica);
            }
        }

        private void carregaAgProducao(Expression<Func<Pedido_Otica, bool>> predicate)
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            Expression<Func<Pedido_Otica, bool>> predAgProd = p => true;

            if (predicate != null)
            {
                predAgProd = predicate.Expand();
            }

            int stAgProducao = (int)StatusPedido.AGPRODUCAO;
            predAgProd = predAgProd.And(c => c.status == stAgProducao);
            List<Pedido_Otica> AgProducaoList = pedido_OticaBLL.getPedido_Otica(predAgProd.Expand());
            lblCountAgProducao.Text = "(" + AgProducaoList.Count().ToString() + ")";
            LimpaCartoes(pnlAGProducao);
            for (int index = AgProducaoList.Count() - 1; index > -1; index--)
            {
                Pedido_Otica pedido_otica = AgProducaoList[index];
                AdicionaCartao(pnlAGProducao, pedido_otica);
            }
        }

        private void carregaEmProducao(Expression<Func<Pedido_Otica, bool>> predicate)
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            Expression<Func<Pedido_Otica, bool>> predProd = p => true;

            if (predicate != null)
            {
                predProd = predicate.Expand();
            }

            int stProducao = (int)StatusPedido.PRODUCAO;
            predProd = predProd.And(c => c.status == stProducao);
            List<Pedido_Otica> ProducaoList = pedido_OticaBLL.getPedido_Otica(predProd.Expand());
            lblCountEmProducao.Text = "(" + ProducaoList.Count().ToString() + ")";
            LimpaCartoes(pnlEmProducao);
            for (int index = ProducaoList.Count() - 1; index > -1; index--)
            {
                Pedido_Otica pedido_otica = ProducaoList[index];
                AdicionaCartao(pnlEmProducao, pedido_otica);
            }
        }

        private void carregaAEntregar(Expression<Func<Pedido_Otica, bool>> predicate)
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            int stAEntregar = (int)StatusPedido.AENTREGAR;
            Expression<Func<Pedido_Otica, bool>> predAEnt = p => true;

            if (predicate != null)
            {
                predAEnt = predicate.Expand();
            }

            predAEnt = predAEnt.And(c => c.status == stAEntregar);
            List<Pedido_Otica> AEntregarList = pedido_OticaBLL.getPedido_Otica(predAEnt.Expand());
            lblCountAEntregar.Text = "(" + AEntregarList.Count().ToString() + ")";

            LimpaCartoes(pnlAEntregar);

            for (int index = AEntregarList.Count() - 1; index > -1; index--)
            {
                Pedido_Otica pedido_otica = AEntregarList[index];
                AdicionaCartao(pnlAEntregar, pedido_otica);
            }
        }

        private void carregaSaiuPEntrega(Expression<Func<Pedido_Otica, bool>> predicate)
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            int stSaiuPEntrega = (int)StatusPedido.SAIUPENTREGA;
            Expression<Func<Pedido_Otica, bool>> predSEnt = p => true;

            if (predicate != null)
            {
                predSEnt = predicate.Expand();
            }

            predSEnt = predSEnt.And(c => c.status == stSaiuPEntrega);
            List<Pedido_Otica> SaiuPEntregaList = pedido_OticaBLL.getPedido_Otica(predSEnt.Expand());
            lblCountSaiuPEntrega.Text = "(" + SaiuPEntregaList.Count().ToString() + ")";

            LimpaCartoes(pnlSaiuPEntrega);

            for (int index = SaiuPEntregaList.Count() - 1; index > -1; index--)
            {
                Pedido_Otica pedido_otica = SaiuPEntregaList[index];
                AdicionaCartao(pnlSaiuPEntrega, pedido_otica);
            }
        }

        private void carregaEntregues(Expression<Func<Pedido_Otica, bool>> predicate)
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            int stEntregue = (int)StatusPedido.ENTREGUE;
            Expression<Func<Pedido_Otica, bool>> predEnt = p => true;

            if (predicate != null)
            {
                predEnt = predicate.Expand();
            }

            predEnt = predEnt.And(c => c.status == stEntregue);
            List<Pedido_Otica> EntregueList = pedido_OticaBLL.getPedido_Otica(predEnt.Expand());
            lblCountEntregue.Text = "(" + EntregueList.Count().ToString() + ")";

            LimpaCartoes(pnlEntregue);

            for (int index = EntregueList.Count() - 1; index > -1; index--)
            {
                Pedido_Otica pedido_otica = EntregueList[index];
                AdicionaCartao(pnlEntregue, pedido_otica);
            }
        }



        private void LimpaCartoes(Panel pnl)
        {
            pnl.Controls.Clear();
        }

        protected virtual void carregaDados()
        {
            try
            {

                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                carregaConsulta();
                formataGridFiltro();
                Cursor = Cursors.Default;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pnlExecuteDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ((Panel)e.Data.GetData(typeof(Panel))).Parent = (Panel)sender;

                Panel pnlCartao = ((Panel)e.Data.GetData(typeof(Panel)));
                Panel pnlDestino = (Panel)sender;

                StatusPedido st = (StatusPedido)Convert.ToInt16(pnlDestino.Tag);
                long? IdPed = Convert.ToInt64(pnlCartao.Tag);

                pedido_OticaBLL = new Pedido_OticaBLL();
                pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;
                pedido_OticaBLL.AtualizarStatusPedido(IdPed, st);

                AtualzalblCounts();

                //MessageBox.Show("Pedido: " + pnlCartao.Tag.ToString() + " - Status: " + Enumerados.GetStringValue(st));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }



        }

        private void AtualzalblCounts()
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            try
            {
                int qtdGravadaImpressa = 0;
                int qtdAgproducao = 0;
                int qtdEmProducao = 0;
                int qtdAEntregar = 0;
                int qtdSaiupEntrega = 0;
                int qtdEntregue = 0;

                int st = (int)StatusPedido.IMPRESSO;
                int st2 = (int)StatusPedido.GRAVADO;
                qtdGravadaImpressa = pedido_OticaBLL.getTotalRegistro(c => c.status == st || c.status == st2);

                st = (int)StatusPedido.AGPRODUCAO;
                qtdAgproducao = pedido_OticaBLL.getTotalRegistro(c => c.status == st);

                st = (int)StatusPedido.PRODUCAO;
                qtdEmProducao = pedido_OticaBLL.getTotalRegistro(c => c.status == st);

                st = (int)StatusPedido.AENTREGAR;
                qtdAEntregar = pedido_OticaBLL.getTotalRegistro(c => c.status == st);

                st = (int)StatusPedido.SAIUPENTREGA;
                qtdSaiupEntrega = pedido_OticaBLL.getTotalRegistro(c => c.status == st);

                st = (int)StatusPedido.ENTREGUE;
                qtdEntregue = pedido_OticaBLL.getTotalRegistro(c => c.status == st);

                lblCountGravadas.Text = "(" + qtdGravadaImpressa.ToString() + ")";
                lblCountAgProducao.Text = "(" + qtdAgproducao.ToString() + ")";
                lblCountEmProducao.Text = "(" + qtdEmProducao.ToString() + ")";
                lblCountAEntregar.Text = "(" + qtdAEntregar.ToString() + ")";
                lblCountSaiuPEntrega.Text = "(" + qtdSaiupEntrega.ToString() + ")";
                lblCountEntregue.Text = "(" + qtdEntregue.ToString() + ")";
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void pnlExecuteDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlExecuteMouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void lblExecute_DragDrop(object sender, DragEventArgs e)
        {
            Label l = (Label)sender;
            ((Panel)((Label)e.Data.GetData(typeof(Label))).Parent).Parent = (Panel)sender;
            //MessageBox.Show(((Panel)sender).Tag);
        }

        private void lblExecute_MouseDown(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            pnlExecuteMouseDown(l.Parent, e);
        }

        private void AdicionaCartao(Panel Destino, Pedido_Otica pedido_Otica)
        {
            Panel p = new Panel();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Dock = DockStyle.Top;
            p.DragDrop += pnlExecuteDragDrop;
            p.MouseDown += pnlExecuteMouseDown;
            p.Width = 180;
            p.Height = 92;
            p.Tag = pedido_Otica.Id;
            p.BackColor = Color.Wheat;
            p.Cursor = Cursors.SizeAll;
            p.Padding = new Padding(0, 0, 0, 3);


            Label lblNome = new Label();
            lblNome.Text = pedido_Otica.cliente.nome_fantasia;
            lblNome.Top = 2;
            lblNome.Left = 3;
            lblNome.AutoSize = false;
            lblNome.DragDrop += lblExecute_DragDrop;
            lblNome.MouseDown += lblExecute_MouseDown;

            Label lblCondP = new Label();
            lblCondP.Text = pedido_Otica.parcela.descricao;
            lblCondP.Top = 37;
            lblCondP.Left = 3;
            lblCondP.AutoSize = false;
            lblCondP.DragDrop += lblExecute_DragDrop;
            lblCondP.MouseDown += lblExecute_MouseDown;

            Label lbldsPed = new Label();
            lbldsPed.Text = "Pedido";
            lbldsPed.Top = 77;
            lbldsPed.Left = 3;
            lbldsPed.AutoSize = true;
            lbldsPed.DragDrop += lblExecute_DragDrop;
            lbldsPed.MouseDown += lblExecute_MouseDown;

            Label lblNrPed = new Label();
            lblNrPed.Text = pedido_Otica.codigo.ToString();
            lblNrPed.Top = 77;
            lblNrPed.Left = 46;
            lblNrPed.AutoSize = true;
            lblNrPed.DragDrop += lblExecute_DragDrop;
            lblNrPed.MouseDown += lblExecute_MouseDown;

            decimal? d = pedido_Otica.itempedido_otica.Sum(c => c.valor_total);

            Label lblVlPed = new Label();
            lblVlPed.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", d);
            lblVlPed.Top = 77;
            lblVlPed.Left = 96;
            lblVlPed.AutoSize = true;
            lblVlPed.DragDrop += lblExecute_DragDrop;
            lblVlPed.MouseDown += lblExecute_MouseDown;

            p.Controls.Add(lblNome);
            p.Controls.Add(lblCondP);
            p.Controls.Add(lbldsPed);
            p.Controls.Add(lblNrPed);
            p.Controls.Add(lblVlPed);

            Destino.Controls.Add(p);
        }

        private void lblSaiuPEntrega_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRelRota relatorio = new frmRelRota();
            relatorio.rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relRota.rdlc";
            relatorio.ExibeDialogo(this);
            relatorio.Dispose();
        }

        private void lblGravadasImpressas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaPedido_Otica(StatusPedido.GRAVADO, StatusPedido.IMPRESSO);
        }

        private void lblAgProducao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaPedido_Otica(StatusPedido.AGPRODUCAO, StatusPedido.AGPRODUCAO);
        }

        private void lblEmProducao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaPedido_Otica(StatusPedido.PRODUCAO, StatusPedido.PRODUCAO);
        }

        private void lblAEntregar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaPedido_Otica(StatusPedido.AENTREGAR, StatusPedido.AENTREGAR);
        }

        private void ListaPedido_Otica(StatusPedido StatusDe, StatusPedido StatusAte)
        {
            frmRelListPedido_Otica relatorio = new frmRelListPedido_Otica();
            relatorio.rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relListPedido_Otica.rdlc";
            relatorio.statusDe = (int)StatusDe;
            relatorio.statusAte = (int)StatusAte;
            relatorio.ExibeDialogo(this);
            relatorio.Dispose();
        }

        private void lblEntregue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaPedido_Otica(StatusPedido.ENTREGUE, StatusPedido.ENTREGUE);
        }
    }
}
