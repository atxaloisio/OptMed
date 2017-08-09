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
    public partial class frmProcAgrupaPedido : optmed.frmBase
    {
        #region Constante de Colunas da Grid
        private const int COL_ID = 0;
        private const int COL_IDPEDIDO_OMIE = 1;
        private const int COL_AGRUPA = 2;
        private const int COL_PEDIDO_OMIE = 3;
        private const int COL_PEDIDO = 4;
        private const int COL_CLIENTE = 5;
        private const int COL_CONDPAG = 6;
        private const int COL_DTEMISSAO = 7;
        private const int COL_DTFECHAMENTO = 8;
        private const int COL_STATUS = 9;

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

        private PedidoBLL pedidoBLL;
        private Pedido_OticaBLL pedido_OticaBLL;
        public frmProcAgrupaPedido()
        {
            InitializeComponent();
            carregaDados();
            //this.WindowState = FormWindowState.Maximized;
        }

        private void frmProcAgrupaPedido_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        protected virtual void InstanciarFormulario()
        {

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

        protected virtual void btnIncluir_Click(object sender, EventArgs e)
        {
            if (ValidaAcessoFuncao(Operacao.Salvar))
            {
                AgruparPedidos();
            }

        }

        protected virtual void btnExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidaAcessoFuncao(Operacao.Excluir))
                {
                    if (dgvDados.CurrentRow != null)
                    {
                        excluirRegistro(dgvDados.CurrentRow.Index);
                        carregaConsulta();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected virtual void excluirRegistro(int RowSelected)
        {
            if (dgvDados[COL_IDPEDIDO_OMIE, dgvDados.CurrentRow.Index].Value != null)
            {
                if (Convert.ToInt32(dgvDados[COL_IDPEDIDO_OMIE, dgvDados.CurrentRow.Index].Value) > 0)
                {

                    pedido_OticaBLL = new Pedido_OticaBLL();
                    int IdPedidoOmie = Convert.ToInt32(dgvDados[COL_IDPEDIDO_OMIE, dgvDados.CurrentRow.Index].Value);
                    List<Pedido_Otica> pedido_oticaList = pedido_OticaBLL.getPedido_Otica(p => p.Id_pedido == IdPedidoOmie);

                    string pedidos = string.Empty;
                    foreach (Pedido_Otica item in pedido_oticaList)
                    {
                        if (string.IsNullOrEmpty(pedidos))
                        {
                            pedidos = item.codigo.ToString();
                        }
                        else
                        {
                            pedidos += ", " + item.codigo.ToString();
                        }
                    }

                    if (MessageBox.Show("Deseja realmente excluir o agrupamento referente ao(s) pedido(s): " + pedidos, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (Pedido_Otica item in pedido_oticaList)
                        {
                            item.Id_pedido = null;
                            item.codigo_pedido = null;
                            item.status = (int)StatusPedido.IMPRESSO;
                            item.agrupado = "N";
                            pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;
                            pedido_OticaBLL.AlterarPedido_Otica(item);
                        }

                        pedidoBLL = new PedidoBLL();
                        Pedido pedido = pedidoBLL.Localizar(IdPedidoOmie);
                        pedidoBLL.ExcluirPedido(pedido);
                    }
                }
            }

        }



        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void frmProcAgrupaPedido_Load(object sender, EventArgs e)
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
            //editarRegistro();
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
            int? status = null;

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

            if (dgvFiltro[COL_STATUS, 0].Value != null)
            {
                status = (int)((DataGridViewComboBoxCell)dgvFiltro[COL_STATUS, 0]).Value;
            }

            if (status == null || status == StatusPedidoLimpo)
            {
                status = (int)StatusPedido.ENTREGUE;
            }

            switch (e.ColumnIndex)
            {

                case COL_PEDIDO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.codigo.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
                    }
                    break;

                case COL_PEDIDO_OMIE:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.codigo_pedido.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
                    }
                    break;

                case COL_CLIENTE:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
                    }
                    break;

                case COL_CONDPAG:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.parcela.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
                    }
                    break;

                case COL_DTEMISSAO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.data_emissao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
                    }
                    break;

                case COL_DTFECHAMENTO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.data_emissao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
                    }
                    break;

                case COL_STATUS:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.status.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == status, p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
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
                    dgvFiltro.CurrentCell = dgvFiltro[COL_AGRUPA, iRow];
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
            else
            {
                status = (int)StatusPedido.ENTREGUE;
                predicate = predicate.And(p => p.status == status);
            }

            pedido_OticaBLL = new Pedido_OticaBLL();
            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
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
            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);

        }

        protected virtual void formataColunagridDados(DataGridView gridDados)
        {
            gridDados.Columns[COL_ID].Width = 150;
            gridDados.Columns[COL_ID].ValueType = typeof(int);
            gridDados.Columns[COL_ID].Visible = false;
            gridDados.Columns[COL_ID].ReadOnly = true;

            gridDados.Columns[COL_IDPEDIDO_OMIE].Width = 150;
            gridDados.Columns[COL_IDPEDIDO_OMIE].ValueType = typeof(int);
            gridDados.Columns[COL_IDPEDIDO_OMIE].Visible = false;
            gridDados.Columns[COL_IDPEDIDO_OMIE].ReadOnly = true;

            gridDados.Columns[COL_AGRUPA].Width = 80;
            gridDados.Columns[COL_AGRUPA].ValueType = typeof(bool);
            gridDados.Columns[COL_AGRUPA].Visible = true;
            gridDados.Columns[COL_AGRUPA].ReadOnly = false;

            gridDados.Columns[COL_PEDIDO_OMIE].Width = 150;
            gridDados.Columns[COL_PEDIDO_OMIE].ReadOnly = true;
            gridDados.Columns[COL_PEDIDO_OMIE].ValueType = typeof(string);
            gridDados.Columns[COL_PEDIDO_OMIE].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_PEDIDO_OMIE].DefaultCellStyle = new DataGridViewCellStyle(gridDados.Columns[COL_PEDIDO].DefaultCellStyle);
            gridDados.Columns[COL_PEDIDO_OMIE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            gridFiltros.Columns.Add("IDOMIE", "Id");
            gridFiltros.Columns.Add("AGRUPA", "");

            //DataGridViewCheckBoxColumn colAgrupa = new DataGridViewCheckBoxColumn();
            //colAgrupa.DataPropertyName = "Agrupa";
            //colAgrupa.HeaderText = "";
            //colAgrupa.Name = "AGRUPA";
            //colAgrupa.ValueType = typeof(string);
            //colAgrupa.ReadOnly = false;
            //colAgrupa.SortMode = DataGridViewColumnSortMode.NotSortable;
            //gridFiltros.Columns.Add(colAgrupa);

            gridFiltros.Columns.Add("PEDIDO_OMIE", "Pedido Omie");
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

            gridFiltros.Columns[COL_IDPEDIDO_OMIE].Width = 150;
            gridFiltros.Columns[COL_IDPEDIDO_OMIE].ValueType = typeof(int);
            gridFiltros.Columns[COL_IDPEDIDO_OMIE].Visible = false;

            gridFiltros.Columns[COL_AGRUPA].Width = 80;
            gridFiltros.Columns[COL_AGRUPA].Visible = true;
            gridFiltros.Columns[COL_AGRUPA].Frozen = true;
            gridFiltros.Columns[COL_AGRUPA].ReadOnly = true;
            gridFiltros.Columns[COL_AGRUPA].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_PEDIDO_OMIE].Width = 150;
            gridFiltros.Columns[COL_PEDIDO_OMIE].ValueType = typeof(string);
            gridFiltros.Columns[COL_PEDIDO_OMIE].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_PEDIDO_OMIE].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle);
            gridFiltros.Columns[COL_PEDIDO_OMIE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFiltros.Columns[COL_PEDIDO_OMIE].Frozen = true;

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
            int stEntregue = (int)StatusPedido.ENTREGUE;

            List<Pedido_Otica> Pedido_OticaList = pedido_OticaBLL.getPedido_Otica(c => c.status == stEntregue, false, deslocamento, tamanhoPagina, out totalReg, p => p.Id_cliente.ToString(), p => p.codigo.ToString());

            //List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.nome.Contains("x"), T => T.Id.ToString(), false, deslocamento, tamanhopagina, out totalreg);
            dgvDados.DataSource = pedido_OticaBLL.ToList_Pedido_OticaAgrupaView(Pedido_OticaList);
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

        private void AgruparPedidos()
        {
            //Carregar os pedido_otica para uma lista.
            pedido_OticaBLL = new Pedido_OticaBLL();
            pedidoBLL = new PedidoBLL();

            List<Pedido_Otica> Pedido_OticaList = new List<Pedido_Otica>();

            foreach (DataGridViewRow item in dgvDados.Rows)
            {
                if ((bool)item.Cells[COL_AGRUPA].Value)
                {
                    Pedido_Otica pedido_otica = pedido_OticaBLL.Localizar(Convert.ToInt32(item.Cells[COL_ID].Value));
                    if (pedido_otica != null)
                    {
                        Pedido_OticaList.Add(pedido_otica);
                    }
                }
            }

            CriarPedido(Pedido_OticaList);

        }

        private void CriarPedido(List<Pedido_Otica> pedido_OticaList)
        {
            if (ValidaPedido_Otica(pedido_OticaList))
            {
                //Validação passou vamos criar o pedido.

                Pedido pedido = new Pedido();

                Cliente cli = pedido_OticaList.FirstOrDefault().cliente;

                pedido.codigo_cliente = Convert.ToInt32(cli.codigo_cliente_omie);
                pedido.codigo_cliente_integracao = cli.codigo_cliente_integracao;
                pedido.codigo_empresa = Convert.ToInt32(ConfigurationManager.AppSettings["codEmpresa"]);
                pedido.codigo_parcela = pedido_OticaList.FirstOrDefault().parcela.codigo;
                pedido.codigo_pedido_integracao = Sequence.GetNextVal("sq_pedido_sequence").ToString();
                pedido.data_previsao = DateTime.Now.ToShortDateString();
                pedido.etapa = "10";
                pedido.Id_cliente = cli.Id;
                pedido.importado_api = "S";
                pedido.numero_pedido = "";

                int qtdItens = 0;
                string strPedidos = string.Empty;
                foreach (Pedido_Otica item in pedido_OticaList)
                {
                    if (!string.IsNullOrEmpty(strPedidos))
                    {
                        strPedidos += ", " + item.codigo.ToString();
                    }
                    else
                    {
                        strPedidos += item.codigo.ToString();
                    }

                    qtdItens += item.itempedido_otica.Count();

                    foreach (ItemPedido_Otica itemPedido_Otica in item.itempedido_otica)
                    {

                        Produto_ImpostoBLL produto_ImpostoBLL = new Produto_ImpostoBLL();

                        ItemPedido itempedido = new ItemPedido();

                        itempedido.codigo_item_integracao = itemPedido_Otica.Id.ToString();

                        Produto_Imposto produto_Imposto = produto_ImpostoBLL.getProduto_Imposto(p => p.nCodProd == itemPedido_Otica.produto.codigo_produto & p.cUfDestino == cli.estado).First();

                        //Produto
                        ItemPedido_Produto itemPedido_Produto = new ItemPedido_Produto();
                        itemPedido_Produto.cfop = produto_Imposto.cCFOP;
                        itemPedido_Produto.codigo = itemPedido_Otica.produto.codigo;
                        itemPedido_Produto.codigo_produto = itemPedido_Otica.produto.codigo_produto;
                        itemPedido_Produto.codigo_produto_integracao = itemPedido_Otica.produto.codigo_produto_integracao;
                        itemPedido_Produto.descricao = itemPedido_Otica.produto.descricao;
                        itemPedido_Produto.Id_produto = itemPedido_Otica.Id_produto;
                        itemPedido_Produto.ncm = itemPedido_Otica.produto.ncm;
                        itemPedido_Produto.percentual_desconto = itemPedido_Otica.percentual_desconto;
                        itemPedido_Produto.quantidade = itemPedido_Otica.quantidade;
                        itemPedido_Produto.unidade = itemPedido_Otica.unidade;
                        itemPedido_Produto.valor_desconto = itemPedido_Otica.valor_desconto;
                        itemPedido_Produto.valor_mercadoria = itemPedido_Otica.valor_total;
                        itemPedido_Produto.valor_unitario = itemPedido_Otica.valor_unitario;
                        itemPedido_Produto.valor_total = itemPedido_Otica.valor_total;

                        itempedido.itempedido_produto.Add(itemPedido_Produto);

                        ItemPedido_Imposto itemPedido_Imposto = new ItemPedido_Imposto();
                        //COFINS
                        itemPedido_Imposto.cod_sit_trib_cofins = produto_Imposto.cCSTCOFINS;
                        itemPedido_Imposto.tipo_calculo_cofins = produto_Imposto.cTpCalcCOFINS;
                        itemPedido_Imposto.base_cofins = 0;
                        itemPedido_Imposto.aliq_cofins = produto_Imposto.nAliqCOFINS;
                        itemPedido_Imposto.qtde_unid_trib_cofins = 0;
                        itemPedido_Imposto.valor_unid_trib_cofins = produto_Imposto.nValUnTribCOFINS;
                        itemPedido_Imposto.valor_cofins = 0;
                        itemPedido_Imposto.cod_sit_trib_cofins_st = produto_Imposto.cCSTCOFINS;
                        itemPedido_Imposto.tipo_calculo_cofins_st = produto_Imposto.cTpCalcCOFINS;
                        itemPedido_Imposto.base_cofins_st = 0;
                        itemPedido_Imposto.aliq_cofins_st = produto_Imposto.nAliqCOFINS;
                        itemPedido_Imposto.qtde_unid_trib_cofins_st = 0;
                        itemPedido_Imposto.valor_unid_trib_cofins_st = produto_Imposto.nValUnTribCOFINS;
                        itemPedido_Imposto.margem_cofins_st = 0;
                        itemPedido_Imposto.valor_cofins_st = 0;

                        //csll
                        itemPedido_Imposto.aliq_csll = 0;
                        itemPedido_Imposto.valor_csll = 0;

                        //icms    
                        itemPedido_Imposto.cod_sit_trib_icms = produto_Imposto.cCSTICMS;
                        itemPedido_Imposto.origem_icms = produto_Imposto.cOrigemICMS;
                        itemPedido_Imposto.modalidade_icms = produto_Imposto.cModBCICMS;
                        itemPedido_Imposto.perc_red_base_icms = produto_Imposto.nRedBCICMS;
                        itemPedido_Imposto.base_icms = 0;
                        itemPedido_Imposto.aliq_icms = produto_Imposto.nAliqICMS;
                        itemPedido_Imposto.valor_icms = 0;

                        //icms_sn
                        itemPedido_Imposto.cod_sit_trib_icms_sn = "";
                        itemPedido_Imposto.origem_icms_sn = produto_Imposto.cOrigemICMS;
                        itemPedido_Imposto.aliq_icms_sn = produto_Imposto.nAliqICMS;
                        itemPedido_Imposto.valor_credito_icms_sn = 0;
                        itemPedido_Imposto.base_icms_sn = 0;
                        itemPedido_Imposto.valor_icms_sn = 0;

                        //icms_st
                        itemPedido_Imposto.cod_sit_trib_icms_st = produto_Imposto.cCSTICMS;
                        itemPedido_Imposto.modalidade_icms_st = produto_Imposto.cModBCICMSST;
                        itemPedido_Imposto.perc_red_base_icms_st = produto_Imposto.nRedBCICMSST;
                        itemPedido_Imposto.base_icms_st = 0;
                        itemPedido_Imposto.aliq_icms_st = produto_Imposto.nAliqICMSST;
                        itemPedido_Imposto.margem_icms_st = produto_Imposto.nMargValAdICMSST;
                        itemPedido_Imposto.valor_icms_st = 0;
                        itemPedido_Imposto.aliq_icms_opprop = 0;

                        //inss
                        itemPedido_Imposto.aliq_inss = 0;
                        itemPedido_Imposto.valor_inss = 0;

                        //ipi
                        itemPedido_Imposto.cod_sit_trib_ipi = produto_Imposto.cCSTIPI;
                        itemPedido_Imposto.tipo_calculo_ipi = produto_Imposto.cTpCalcIPI;
                        itemPedido_Imposto.enquadramento_ipi = produto_Imposto.cEnqIPI;
                        itemPedido_Imposto.base_ipi = 0;
                        itemPedido_Imposto.aliq_ipi = produto_Imposto.nAliqIPI;
                        itemPedido_Imposto.qtde_unid_trib_ipi = 0;
                        itemPedido_Imposto.valor_unid_trib_ipi = produto_Imposto.nValUnTribIPI;
                        itemPedido_Imposto.valor_ipi = 0;

                        //irrf
                        itemPedido_Imposto.aliq_irrf = 0;
                        itemPedido_Imposto.valor_irrf = 0;

                        //iss
                        itemPedido_Imposto.base_iss = 0;
                        itemPedido_Imposto.aliq_iss = 0;
                        itemPedido_Imposto.valor_iss = 0;
                        itemPedido_Imposto.retem_iss = " ";

                        //pis
                        itemPedido_Imposto.cod_sit_trib_pis = produto_Imposto.cCSTPIS;
                        itemPedido_Imposto.tipo_calculo_pis = produto_Imposto.cTpCalcPIS;
                        itemPedido_Imposto.base_pis = 0;
                        itemPedido_Imposto.aliq_pis = produto_Imposto.nAliqPIS;
                        itemPedido_Imposto.qtde_unid_trib_pis = 0;
                        itemPedido_Imposto.valor_unid_trib_pis = produto_Imposto.nValUnTribPIS;
                        itemPedido_Imposto.valor_pis = 0;

                        //pis_st
                        itemPedido_Imposto.cod_sit_trib_pis_st = produto_Imposto.cCSTPIS;
                        itemPedido_Imposto.tipo_calculo_pis_st = produto_Imposto.cTpCalcPIS;
                        itemPedido_Imposto.base_pis_st = 0;
                        itemPedido_Imposto.aliq_pis_st = produto_Imposto.nAliqPIS;
                        itemPedido_Imposto.qtde_unid_trib_pis_st = 0;
                        itemPedido_Imposto.valor_unid_trib_pis_st = produto_Imposto.nValUnTribPIS;
                        itemPedido_Imposto.margem_pis_st = 0;
                        itemPedido_Imposto.valor_pis_st = 0;

                        itempedido.itempedido_imposto.Add(itemPedido_Imposto);

                        pedido.itempedidoes.Add(itempedido);
                    }


                }

                decimal? totalValor = 0;
                foreach (ItemPedido itemPedido in pedido.itempedidoes)
                {
                    totalValor += itemPedido.itempedido_produto.Sum(p => p.valor_total);
                }

                CategoriaBLL categoriaBLL = new CategoriaBLL();
                string idCategoria = Parametro.GetParametro("IdCategoria");
                Categoria Categoria = new Categoria();
                if (idCategoria != "-1")
                {
                    Categoria = categoriaBLL.Localizar(Convert.ToInt64(idCategoria));
                }
                Conta_CorrenteBLL conta_CorrenteBLL = new Conta_CorrenteBLL();
                string idContaCorrente = Parametro.GetParametro("IdContaCorrente");
                Conta_Corrente Conta_Corrente = new Conta_Corrente();
                if (idContaCorrente != "-1")
                {
                    Conta_Corrente = conta_CorrenteBLL.Localizar(Convert.ToInt64(idContaCorrente));
                }

                Pedido_InfoAdic Pedido_InfoAdic = new Pedido_InfoAdic();
                if (Categoria != null)
                {
                    Pedido_InfoAdic.codigo_categoria = Categoria.codigo;
                }

                if (Conta_Corrente != null)
                {
                    Pedido_InfoAdic.Id_conta_corrente = Conta_Corrente.Id;
                    Pedido_InfoAdic.codigo_conta_corrente = Conta_Corrente.nCodCC;
                }

                if (pedido_OticaList.FirstOrDefault().vendedor != null)
                {
                    Pedido_InfoAdic.codVend = Convert.ToInt32(pedido_OticaList.FirstOrDefault().vendedor.codigo);
                }

                pedido.pedido_infoadic.Add(Pedido_InfoAdic);

                //criar uma rotina que gera a lista de parcelas conforme a condição de pagamento selecionada.
                //Aqui temos um impasse usar como data do primeiro boleto a data de emissão do primeiro pedido ou
                //usar a data de agrupamento. Vamos usar por enquanto a data do primeiro agrupamento.
                pedido.pedido_parcelas = pedidoBLL.GerarParcelas(pedido_OticaList.FirstOrDefault().condicao_pagamento, totalValor, DateTime.Now);

                //pedido.pedido_parcelas.Add(new Pedido_Parcelas()
                //{
                //    numero_parcela = 1,
                //    percentual = 100,
                //    quantidade_dias = 0,
                //    valor = Convert.ToDecimal(totalValor)
                //});

                if (!string.IsNullOrEmpty(strPedidos))
                {
                    pedido.pedido_observacoes.Add(new Pedido_Observacoes()
                    {
                        observacao = "Pedido composto pelos Pedidos Otica : " + strPedidos
                    });
                }

                bool IntegraOmie = Convert.ToBoolean(Parametro.GetParametro("intOmie"));


                pedido.quantidade_itens = pedido.itempedidoes.Count();


                this.Cursor = Cursors.WaitCursor;
                PedidoVendaProxy proxy = new PedidoVendaProxy();

                try
                {
                    if (IntegraOmie)
                    {
                        proxy.IncluirPedidoVenda(ref pedido);
                    }
                    pedidoBLL.AdicionarPedido(pedido);

                    //Atualizando os pedidos otica
                    pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;
                    foreach (Pedido_Otica item in pedido_OticaList)
                    {
                        item.Id_pedido = pedido.id;
                        item.codigo_pedido = pedido.numero_pedido;
                        item.agrupado = (pedido_OticaList.Count > 0) ? "S" : "N";
                        item.status = (int)StatusPedido.AGRUPADO;
                        pedido_OticaBLL.AlterarPedido_Otica(item);
                    }
                    MessageBox.Show("Processo concluido com sucesso! Pedido Omie criado : " + pedido.numero_pedido, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregaConsulta();
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    string mensagem = TrataException.getAllMessage(ex);
                    MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    proxy.Dispose();
                    pedidoBLL.Dispose();
                    pedido_OticaBLL.Dispose();
                }
            }
        }

        private bool ValidaPedido_Otica(List<Pedido_Otica> pedido_OticaList)
        {
            bool Retorno = true;
            long? IdCliente = null;
            long? IdCondicaoPag = null;
            string msgValidacao = string.Empty;

            Produto_ImpostoBLL produto_ImpostoBLL = new Produto_ImpostoBLL();

            if (pedido_OticaList.Count() < 1)
            {
                msgValidacao = "Nenhum pedido selecionados para agrupamento";
                Retorno = false;
            }


            foreach (Pedido_Otica item in pedido_OticaList)
            {
                if (IdCliente == null)
                {
                    IdCliente = item.cliente.Id;
                    Retorno = true;
                }
                else
                {
                    if (IdCliente != item.cliente.Id)
                    {
                        msgValidacao = "Pedidos selecionados são de clientes diferentes";
                        Retorno = false;
                        break;
                    }
                }

                if (Retorno)
                {
                    if (IdCondicaoPag == null)
                    {
                        IdCondicaoPag = item.condicao_pagamento;
                        Retorno = true;
                    }
                    else
                    {
                        if (IdCondicaoPag != item.condicao_pagamento)
                        {
                            msgValidacao = "Pedidos selecionados com condições de pagamento diferentes";
                            Retorno = false;
                            break;
                        }
                    }
                }

                if (Retorno)
                {
                    if (!string.IsNullOrEmpty(item.codigo_pedido))
                    {
                        msgValidacao = "Pedido " + item.codigo + " Já foi agrupado.";
                        Retorno = false;
                        break;
                    }
                }

                if (Retorno)
                {
                    foreach (ItemPedido_Otica ItemPedido in item.itempedido_otica)
                    {
                        if (produto_ImpostoBLL.getProduto_Imposto(p => p.nCodProd == ItemPedido.produto.codigo_produto & p.cUfDestino == item.cliente.estado).Count <= 0)
                        {
                            msgValidacao = "O produto " + ItemPedido.produto.codigo + " - " + ItemPedido.produto.descricao + "\n" + "Não está parametrizado nos impostos aprendidos do Omie";
                            Retorno = false;
                            break;
                        }
                    }
                }

            }

            if (!Retorno)
            {
                MessageBox.Show(msgValidacao, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Retorno;
        }

        private void btnDesagrupar_Click(object sender, EventArgs e)
        {
            DesagruparPedidos();
        }

        private void DesagruparPedidos()
        {
            throw new NotImplementedException();
        }

        private void selecionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Row = dgvDados.CurrentCell.RowIndex;

            dgvDados[COL_AGRUPA, Row].Value = true;
        }

        private void selecionarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDados.Rows)
            {
                item.Cells[COL_AGRUPA].Value = true;
            }
        }

        private void desmarcarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Row = dgvDados.CurrentCell.RowIndex;

            dgvDados[COL_AGRUPA, Row].Value = false;
        }

        private void descarcarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDados.Rows)
            {
                item.Cells[COL_AGRUPA].Value = false;
            }
        }
    }
}
