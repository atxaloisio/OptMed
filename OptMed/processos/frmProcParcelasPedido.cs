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

namespace optmed
{
    public partial class frmProcParcelasPedido : optmed.frmBase
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

        #region Constante limpo do Status Pedido
        private const int StatusPedidoLimpo = 9;
        #endregion

        protected frmBase frmInstancia;

        protected int deslocamento = 0;
        protected int pagina = 0;
        protected int tamanhoPagina = 20;
        protected decimal totalPaginas = 0;
        protected int totalReg = 0;
        protected virtual int colOrdem { get; set; }
        
        private Pedido_OticaBLL pedido_OticaBLL;
        public frmProcParcelasPedido()
        {
            InitializeComponent();
            carregaDados();
            //this.WindowState = FormWindowState.Maximized;
        }

        private void frmProcParcelasPedido_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        protected virtual void InstanciarFormulario()
        {
            frmInstancia = new frmProcParcelaPedidoView();
        }

        public virtual void ConfigurarForm(Form pFormParent)
        {
            //WindowState = FormWindowState.Maximized;
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            MdiParent = pFormParent;
        }
        
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void frmProcParcelasPedido_Load(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Maximized;

            var topBotoesNavegacao = (pnlBotoes.Height - (btnFechar.Height + btnProximo.Height + 4));
            var topLabelsNavegacao = (pnlBotoes.Height - (btnFechar.Height + btnProximo.Height + lblDe.Height + 4));
            var topLabelsTotalReg = (pnlBotoes.Height - (btnFechar.Height + btnProximo.Height + lblDe.Height + lblRegistros.Height + 25));
            var topPanelBorda = (pnlBotoes.Height - (btnFechar.Height + btnProximo.Height + lblDe.Height + pnlBorda.Height + 10));

            lblDe.Top = topLabelsNavegacao;
            lblNumeroPagina.Top = topLabelsNavegacao;
            lblTotalPaginas.Top = topLabelsNavegacao;

            lblRegistros.Top = topLabelsTotalReg;
            lblTotalRegistros.Top = topLabelsTotalReg;

            pnlBorda.Top = topPanelBorda;

            btnProximo.Top = topBotoesNavegacao;
            btnUltimo.Top = topBotoesNavegacao;
            btnAnterior.Top = topBotoesNavegacao;
            btnPrimeiro.Top = topBotoesNavegacao;

            btnFechar.Top = (pnlBotoes.Height - btnFechar.Height);
            Parent.Text = Parent.Text + " : " + Text;

            //carregaDados();

        }

        protected virtual void formataGridDados()
        {
            var gridDados = dgvDados;
            gridDados.AutoGenerateColumns = false;
            gridDados.ColumnHeadersVisible = false;
            gridDados.RowHeadersVisible = false;
            gridDados.ReadOnly = false;
            gridDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridDados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //altera a cor das linhas alternadas no grid
            gridDados.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            gridDados.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            formataColunagridDados(gridDados);
            //seleciona a linha inteira
            gridDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //não permite seleção de multiplas linhas
            gridDados.MultiSelect = false;
            // exibe nulos formatados
            gridDados.DefaultCellStyle.NullValue = " - ";
            //permite que o texto maior que célula não seja truncado
            gridDados.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridDados.DefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Regular);

            gridDados.CellDoubleClick += new DataGridViewCellEventHandler(dgvDados_CellDoubleClick);
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VisualizarRegistro();
        }

        private void VisualizarRegistro()
        {
            String TituloTela;
            if ((frmInstancia == null) || (frmInstancia.IsDisposed))
            {
                this.InstanciarFormulario();
            }
            TituloTela = frmInstancia.Text;
            frmInstancia.Text = "Editar : " + frmInstancia.Text;
            if (this.Tag != null)
            {
                frmInstancia.Tag = this.Tag;
            }
            //frmInstancia.Text = TituloTela;


            if (dgvDados.CurrentRow != null)
            {
                if (dgvDados[0, dgvDados.CurrentRow.Index].Value != null)
                {
                    if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
                    {
                        frmInstancia.Cursor = Cursors.WaitCursor;
                        frmInstancia.MinimizeBox = false;
                        frmInstancia.MaximizeBox = false;
                        frmInstancia.ControlBox = false;
                        frmInstancia.FormBorderStyle = FormBorderStyle.FixedSingle;
                        frmInstancia.MdiParent = this.MdiParent;
                        frmInstancia.atualizagrid = new AtualizaGrid(atualizaGrid);
                        frmInstancia.Id = Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value);
                        frmInstancia.Show();

                        //frmInstancia.atualizagrid = new AtualizaGrid(atualizaGrid);
                        //frmInstancia.Id = Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value);
                        //frmInstancia.Show();
                        //frmInstancia.ExibeDialogo(this, Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                    }

                }
            }


            //if (frmInstancia.atualizagrid != null)
            //{

            //}

            //if (frmInstancia.atualizagrid)
            //{
            //    // MessageBox.Show("atualiza.");
            //    dgvDados.DataSource = null;
            //    carregaConsulta();
            //    //AtualizaContadores();
            //}
            //frmInstancia.Dispose();
        }

        public virtual void atualizaGrid()
        {
            carregaConsulta();            
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
            if (e.RowIndex > -1)
            {

            }
            pedido_OticaBLL = new Pedido_OticaBLL();

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

                case COL_PEDIDO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(p => p.codigo.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
                    }
                    break;                

                case COL_CLIENTE:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(p => p.cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
                    }
                    break;

                case COL_CONDPAG:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(p => p.parcela.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
                    }
                    break;

                case COL_DTEMISSAO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(p => p.data_emissao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
                    }
                    break;

                case COL_DTFECHAMENTO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(p => p.data_emissao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
                    }
                    break;

                case COL_STATUS:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(p => p.status.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
                    }
                    break;
            }

            colOrdem = e.ColumnIndex;

            col.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
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
            executeFilter(sender, e);
        }

        private void executeFilter(object sender, DataGridViewCellEventArgs e)
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
                predicate = predicate.And(p => p.cliente.nome_fantasia.Contains(cliente));
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

            if ((status != null) && (status != StatusPedidoLimpo))
            {
                predicate = predicate.And(p => p.status == status);
            }

            pedido_OticaBLL = new Pedido_OticaBLL();
            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
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
            if (e.ColumnIndex == COL_ID && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //
            }

            if (e.ColumnIndex == COL_PEDIDO && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == COL_CLIENTE && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == COL_CONDPAG && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }

            if (e.ColumnIndex == COL_DTEMISSAO && !string.IsNullOrEmpty((string)e.FormattedValue))
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

            if (e.ColumnIndex == COL_DTFECHAMENTO && !string.IsNullOrEmpty((string)e.FormattedValue))
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

            if (e.ColumnIndex == COL_STATUS && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }
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
                case COL_STATUS:
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

            Expression<Func<Pedido_Otica, bool>> predicate = p => true;

            if (value != StatusPedidoLimpo)
            {
                predicate = predicate.And(p => p.status == value);
            }

            pedido_OticaBLL = new Pedido_OticaBLL();
            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);

        }

        protected virtual void formataColunagridDados(DataGridView gridDados)
        {
            gridDados.Columns[COL_ID].Width = 150;
            gridDados.Columns[COL_ID].ValueType = typeof(int);
            gridDados.Columns[COL_ID].Visible = false;
            gridDados.Columns[COL_ID].ReadOnly = true;
            
            gridDados.Columns[COL_PEDIDO].Width = 100;
            gridDados.Columns[COL_PEDIDO].ReadOnly = true;
            gridDados.Columns[COL_PEDIDO].ValueType = typeof(int);
            gridDados.Columns[COL_PEDIDO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_PEDIDO].DefaultCellStyle = new DataGridViewCellStyle(gridDados.Columns[COL_PEDIDO].DefaultCellStyle);
            gridDados.Columns[COL_PEDIDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridDados.Columns[COL_CLIENTE].Width = 300;
            gridDados.Columns[COL_CLIENTE].ReadOnly = true;
            gridDados.Columns[COL_CLIENTE].ValueType = typeof(string);
            gridDados.Columns[COL_CLIENTE].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_CONDPAG].Width = 200;
            gridDados.Columns[COL_CONDPAG].ReadOnly = true;
            gridDados.Columns[COL_CONDPAG].ValueType = typeof(string);
            gridDados.Columns[COL_CONDPAG].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_DTEMISSAO].Width = 140;
            gridDados.Columns[COL_DTEMISSAO].ReadOnly = true;
            gridDados.Columns[COL_DTFECHAMENTO].Width = 140;
            gridDados.Columns[COL_DTFECHAMENTO].ReadOnly = true;

            gridDados.Columns[COL_STATUS].Width = 110;
            gridDados.Columns[COL_STATUS].ValueType = typeof(string);
            gridDados.Columns[COL_STATUS].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_STATUS].ReadOnly = true;
        }

        protected virtual void formataColunagridFiltros(DataGridView gridFiltros)
        {
            //altera o nome das colunas                        
            //altera o nome das colunas                 
            gridFiltros.Columns.Add("ID", "Id");

            //DataGridViewCheckBoxColumn colAgrupa = new DataGridViewCheckBoxColumn();
            //colAgrupa.DataPropertyName = "Agrupa";
            //colAgrupa.HeaderText = "";
            //colAgrupa.Name = "AGRUPA";
            //colAgrupa.ValueType = typeof(string);
            //colAgrupa.ReadOnly = false;
            //colAgrupa.SortMode = DataGridViewColumnSortMode.NotSortable;
            //gridFiltros.Columns.Add(colAgrupa);

            gridFiltros.Columns.Add("PEDIDO", "Pedido");
            gridFiltros.Columns.Add("CLIENTE", "Cliente");
            gridFiltros.Columns.Add("CONDPAGTO", "Cond. Pagamento");

            DataGridViewMaskedTextColumn colDtEmissao = new DataGridViewMaskedTextColumn("99/99/9999");
            colDtEmissao.DataPropertyName = "DTEMISSAO";
            colDtEmissao.HeaderText = "Emissão";
            colDtEmissao.Name = "DTEMISSAO";
            colDtEmissao.ValueType = typeof(DateTime);
            colDtEmissao.SortMode = DataGridViewColumnSortMode.Programmatic;
            colDtEmissao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDtEmissao.DefaultCellStyle.Format = "d";
            gridFiltros.Columns.Add(colDtEmissao);

            DataGridViewMaskedTextColumn colDtFechamento = new DataGridViewMaskedTextColumn("99/99/9999");
            colDtFechamento.DataPropertyName = "DTFECHAMENTO";
            colDtFechamento.HeaderText = "Fechamento";
            colDtFechamento.Name = "DTFECHAMENTO";
            colDtFechamento.ValueType = typeof(DateTime);
            colDtFechamento.SortMode = DataGridViewColumnSortMode.Programmatic;
            colDtFechamento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDtFechamento.DefaultCellStyle.Format = "d";
            gridFiltros.Columns.Add(colDtFechamento);

            StatusPedido sp = new StatusPedido();
            DataGridViewComboBoxColumn colStatus = new DataGridViewComboBoxColumn();

            int statusEntregue = (int)StatusPedido.ENTREGUE;
            int statusAgrupado = (int)StatusPedido.AGRUPADO;
            int statusFaturado = (int)StatusPedido.FATURADO;


            IList<itemEnumList> lstStatusPedido = Enumerados.getListEnum(sp).Where(p => p.chave == statusEntregue || p.chave == statusAgrupado || p.chave == statusFaturado).ToList();


            lstStatusPedido.Insert(0, new itemEnumList { chave = StatusPedidoLimpo, descricao = string.Empty });




            colStatus.DataSource = lstStatusPedido;
            colStatus.ValueMember = "chave";
            colStatus.DisplayMember = "descricao";
            colStatus.DataPropertyName = "STATUS";
            colStatus.HeaderText = "Status";
            colStatus.Name = "STATUS";
            colStatus.SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns.Add(colStatus);

            //
            gridFiltros.Columns[COL_ID].Width = 150;
            gridFiltros.Columns[COL_ID].ValueType = typeof(int);
            gridFiltros.Columns[COL_ID].Visible = false;

            gridFiltros.Columns[COL_PEDIDO].Width = 100;
            gridFiltros.Columns[COL_PEDIDO].ValueType = typeof(int);
            gridFiltros.Columns[COL_PEDIDO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle);
            gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFiltros.Columns[COL_PEDIDO].Frozen = true;

            gridFiltros.Columns[COL_CLIENTE].Width = 300;
            gridFiltros.Columns[COL_CLIENTE].ValueType = typeof(string);
            gridFiltros.Columns[COL_CLIENTE].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_CLIENTE].Frozen = true;

            gridFiltros.Columns[COL_CONDPAG].Width = 200;
            gridFiltros.Columns[COL_CONDPAG].ValueType = typeof(string);
            gridFiltros.Columns[COL_CONDPAG].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_CONDPAG].Frozen = true;

            gridFiltros.Columns[COL_DTEMISSAO].Width = 140;
            gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle);
            gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFiltros.Columns[COL_DTEMISSAO].Frozen = true;

            gridFiltros.Columns[COL_DTFECHAMENTO].Width = 140;
            gridFiltros.Columns[COL_DTFECHAMENTO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_DTFECHAMENTO].DefaultCellStyle);
            gridFiltros.Columns[COL_DTFECHAMENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFiltros.Columns[COL_DTFECHAMENTO].Frozen = true;

            gridFiltros.Columns[COL_STATUS].Width = 110;
            gridFiltros.Columns[COL_STATUS].Frozen = true;

            //gridFiltros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gridFiltros_EditingControlShowing);

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();
        }

        protected virtual void carregaConsulta()
        {
            pedido_OticaBLL = new Pedido_OticaBLL();
            pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;
            int stEntregue = (int)StatusPedido.GRAVADO;

            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status >= stEntregue, false, deslocamento, tamanhoPagina, out totalReg, p => p.Id_cliente.ToString(), p => p.codigo.ToString());

            //List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.nome.Contains("x"), T => T.Id.ToString(), false, deslocamento, tamanhopagina, out totalreg);
            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaParcelaView(Pedido_OticaList);
            colOrdem = 0;
        }

        protected virtual void carregaDados()
        {
            try
            {

                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                carregaConsulta();
                pagina++;
                if (totalReg > 0)
                {
                    totalPaginas = Math.Ceiling(decimal.Divide(totalReg, tamanhoPagina));
                    lblNumeroPagina.Text = Convert.ToString(pagina);
                    lblTotalPaginas.Text = Convert.ToString(totalPaginas);
                    lblTotalRegistros.Text = Convert.ToString(totalReg);
                }
                configuraBotoesNaveg();
                formataGridDados();
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

        protected virtual void callNextPage()
        {
            try
            {
                deslocamento = deslocamento + tamanhoPagina;
                if (deslocamento > totalReg)
                {
                    deslocamento = 0;
                }
                carregaConsulta();
                pagina++;

                if (pagina > (totalPaginas))
                {
                    pagina = 1;
                }

                lblNumeroPagina.Text = Convert.ToString(pagina);
                configuraBotoesNaveg();
                formataGridDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected virtual void callPrevPage()
        {
            try
            {
                if ((deslocamento > 0) & (deslocamento >= tamanhoPagina))
                {
                    deslocamento = deslocamento - tamanhoPagina;
                }
                else
                {
                    deslocamento = 0;
                }

                carregaConsulta();
                pagina--;

                if (pagina < 1)
                {
                    pagina = 1;
                }
                lblNumeroPagina.Text = Convert.ToString(pagina);
                configuraBotoesNaveg();
                formataGridDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void callLastPage()
        {
            try
            {
                int ultimapagina = totalReg - tamanhoPagina;

                if (ultimapagina < tamanhoPagina)
                {
                    deslocamento = totalReg - ultimapagina;
                }
                else
                {
                    deslocamento = ultimapagina;
                }


                carregaConsulta();

                pagina = Convert.ToInt32(totalPaginas);
                lblNumeroPagina.Text = Convert.ToString(totalPaginas);
                configuraBotoesNaveg();
                formataGridDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void callFirstPage()
        {
            try
            {
                deslocamento = 0;
                carregaConsulta();

                if (totalReg > 0)
                {
                    totalPaginas = Math.Ceiling(decimal.Divide(totalReg, tamanhoPagina));
                    pagina = 1;
                    lblNumeroPagina.Text = Convert.ToString(pagina);
                    lblTotalPaginas.Text = Convert.ToString(totalPaginas);
                }
                configuraBotoesNaveg();
                formataGridDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            callNextPage();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            callLastPage();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            callPrevPage();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            callFirstPage();
        }

        private void configuraBotoesNaveg()
        {
            btnAnterior.Enabled = deslocamento > 0;
            btnPrimeiro.Enabled = deslocamento > 0;
            btnProximo.Enabled = pagina < totalPaginas;
            btnUltimo.Enabled = pagina < totalPaginas;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirRegistro(sender, e);
        }

        protected virtual void imprimirRegistro(object sender, EventArgs e)
        {

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarRegistro();
        }
    }
}
