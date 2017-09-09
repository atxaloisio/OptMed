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
    public partial class frmListPedidos_Otica : optmed.frmBaseList
    {
        Pedido_OticaBLL Pedido_OticaBLL;

        #region Constante de Colunas da Grid
        private const int COL_ID            = 0;
        private const int COL_PEDIDO        = 1;
        private const int COL_OS            = 2;
        private const int COL_DTEMISSAO     = 3;
        private const int COL_CLIENTE       = 4;
        private const int COL_CONDPAG       = 5;
        private const int COL_VENDEDOR      = 6;
        private const int COL_LABORATORIO   = 7;       
        private const int COL_TOTAL         = 8;
        private const int COL_STATUS        = 9;
        private const int COL_CANCELADO     = 10;
        private const int COL_USUARIO       = 11;

        #endregion
        public frmListPedidos_Otica()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmPedidoOtica_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditPedido_Otica();
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
            gridFiltros.Columns.Add("PEDIDO", "Pedido");
            gridFiltros.Columns.Add("NRPEDCLIENTE", "OS");

            DataGridViewMaskedTextColumn colDtEmissao = new DataGridViewMaskedTextColumn("99/99/9999");
            colDtEmissao.DataPropertyName = "DTEMISSAO";
            colDtEmissao.HeaderText = "Dt. Emissão";
            colDtEmissao.Name = "DTEMISSAO";
            colDtEmissao.ValueType = typeof(DateTime);
            colDtEmissao.SortMode = DataGridViewColumnSortMode.Programmatic;
            colDtEmissao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDtEmissao.DefaultCellStyle.Format = "d";
            gridFiltros.Columns.Add(colDtEmissao);

            gridFiltros.Columns.Add("CLIENTE", "Cliente");
            gridFiltros.Columns.Add("CONDPAGTO", "Cond. Pagamento");
            gridFiltros.Columns.Add("VENDEDOR", "Vendedor");
            gridFiltros.Columns.Add("laboratorio", "Laboratório");            
            
            gridFiltros.Columns.Add("Total", "Total");

            StatusPedido sp = new StatusPedido();
            DataGridViewComboBoxColumn colStatus = new DataGridViewComboBoxColumn();
            IList<itemEnumList> lstStatusPedido = Enumerados.getListEnum(sp);            
            lstStatusPedido.Insert(0, new itemEnumList { chave = 7, descricao = string.Empty });
            
            colStatus.DataSource = lstStatusPedido;
            colStatus.ValueMember = "chave";
            colStatus.DisplayMember = "descricao";
            colStatus.DataPropertyName = "STATUS";
            colStatus.HeaderText = "Status";
            colStatus.Name = "STATUS";
            colStatus.SortMode = DataGridViewColumnSortMode.Programmatic;            
            gridFiltros.Columns.Add(colStatus);
            
            DataGridViewCheckBoxColumn Cancelado = new DataGridViewCheckBoxColumn();
            Cancelado.HeaderText = "Cancelado";
            Cancelado.Name = "CANCELADO";
            Cancelado.TrueValue = true;
            Cancelado.FalseValue = false;
            Cancelado.ThreeState = true;
            gridFiltros.Columns.Add(Cancelado);

            gridFiltros.Columns.Add("USUARIO", "Usuário");

            //
            gridFiltros.Columns[COL_ID].Width = 120;
            gridFiltros.Columns[COL_ID].ValueType = typeof(int);
            gridFiltros.Columns[COL_ID].Visible = false;

            gridFiltros.Columns[COL_PEDIDO].Width = 80;
            gridFiltros.Columns[COL_PEDIDO].ValueType = typeof(int);
            gridFiltros.Columns[COL_PEDIDO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_PEDIDO].DefaultCellStyle);
            gridFiltros.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridFiltros.Columns[COL_OS].Width = 80;
            gridFiltros.Columns[COL_OS].ValueType = typeof(string);
            gridFiltros.Columns[COL_OS].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_DTEMISSAO].Width = 130;
            gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle = new DataGridViewCellStyle(gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle);
            gridFiltros.Columns[COL_DTEMISSAO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridFiltros.Columns[COL_CLIENTE].Width = 380;
            gridFiltros.Columns[COL_CLIENTE].ValueType = typeof(string);
            gridFiltros.Columns[COL_CLIENTE].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_CONDPAG].Width = 200;
            gridFiltros.Columns[COL_CONDPAG].ValueType = typeof(string);
            gridFiltros.Columns[COL_CONDPAG].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_VENDEDOR].Width = 250;
            gridFiltros.Columns[COL_VENDEDOR].ValueType = typeof(string);
            gridFiltros.Columns[COL_VENDEDOR].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[COL_LABORATORIO].Width = 250;
            gridFiltros.Columns[COL_LABORATORIO].ValueType = typeof(string);
            gridFiltros.Columns[COL_LABORATORIO].SortMode = DataGridViewColumnSortMode.Programmatic;
            
            gridFiltros.Columns[COL_TOTAL].Width = 130;
            gridFiltros.Columns[COL_TOTAL].ValueType = typeof(decimal);
            gridFiltros.Columns[COL_TOTAL].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[COL_TOTAL].DefaultCellStyle.Format = "N2";

            gridFiltros.Columns[COL_STATUS].Width = 200;

            gridFiltros.Columns[COL_CANCELADO].Width = 100;
            gridFiltros.Columns[COL_CANCELADO].ValueType = typeof(bool);
            gridFiltros.Columns[COL_CANCELADO].SortMode = DataGridViewColumnSortMode.Programmatic;
            
            gridFiltros.Columns[COL_USUARIO].Width = 200;
            gridFiltros.Columns[COL_USUARIO].ValueType = typeof(string);
            gridFiltros.Columns[COL_USUARIO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gridFiltros_EditingControlShowing);

            //Adiciona uma linha ao grid.
            gridFiltros.DefaultCellStyle.SelectionBackColor = Color.Green;
            gridFiltros.Rows.Add();
            
        }

        private void gridFiltros_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Col_Pedido_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Col_DtEmissaoFechamento_KeyPress);

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
            
            Expression<Func<Pedido_Otica, bool>> predicate = p => true;

            if (value != 7)
            {
                predicate = predicate.And(p => p.status == value);
            }
          
            List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
        }
        
        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.DefaultCellStyle.SelectionBackColor = Color.Green;

            gridDados.Columns[COL_ID].Width = 120;
            gridDados.Columns[COL_ID].ValueType = typeof(int);
            gridDados.Columns[COL_ID].Visible = false;

            gridDados.Columns[COL_PEDIDO].Width = 80;
            gridDados.Columns[COL_PEDIDO].ValueType = typeof(int);
            gridDados.Columns[COL_PEDIDO].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_PEDIDO].DefaultCellStyle = new DataGridViewCellStyle(gridDados.Columns[COL_PEDIDO].DefaultCellStyle);
            gridDados.Columns[COL_PEDIDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridDados.Columns[COL_OS].Width = 80;
            gridDados.Columns[COL_OS].ValueType = typeof(string);
            gridDados.Columns[COL_OS].SortMode = DataGridViewColumnSortMode.Programmatic;
            
            gridDados.Columns[COL_CLIENTE].Width = 380;
            gridDados.Columns[COL_CLIENTE].ValueType = typeof(string);
            gridDados.Columns[COL_CLIENTE].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_CONDPAG].Width = 200;
            gridDados.Columns[COL_CONDPAG].ValueType = typeof(string);
            gridDados.Columns[COL_CONDPAG].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_VENDEDOR].Width = 250;
            gridDados.Columns[COL_VENDEDOR].ValueType = typeof(string);
            gridDados.Columns[COL_VENDEDOR].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_LABORATORIO].Width = 250;
            gridDados.Columns[COL_LABORATORIO].ValueType = typeof(string);
            gridDados.Columns[COL_LABORATORIO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_DTEMISSAO].Width = 130;

            gridDados.Columns[COL_TOTAL].Width = 130;
            gridDados.Columns[COL_TOTAL].ValueType = typeof(decimal);
            gridDados.Columns[COL_TOTAL].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[COL_TOTAL].DefaultCellStyle.Format = "N2";

            gridDados.Columns[COL_STATUS].Width = 200;
            gridDados.Columns[COL_STATUS].ValueType = typeof(string);
            gridDados.Columns[COL_STATUS].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_CANCELADO].Width = 100;
            gridDados.Columns[COL_CANCELADO].ValueType = typeof(Boolean);
            gridDados.Columns[COL_CANCELADO].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridDados.Columns[COL_USUARIO].Width = 200;
            gridDados.Columns[COL_USUARIO].ValueType = typeof(string);
            gridDados.Columns[COL_USUARIO].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            base.carregaConsulta();
            Pedido_OticaBLL = new Pedido_OticaBLL();
            List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);            
            dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);
            Pedido_OticaBLL = new Pedido_OticaBLL();

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
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.codigo.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                case COL_OS:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.pedido_otica_infoadic.FirstOrDefault().ordem_servico, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;
                
                case COL_CLIENTE:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.cliente.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                case COL_CONDPAG:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.parcela.descricao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                case COL_VENDEDOR:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.vendedor.nome, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                case COL_LABORATORIO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.pedido_otica_infoadic.FirstOrDefault().laboratorio, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                case COL_DTEMISSAO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.data_emissao.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;
                
                case COL_STATUS:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.status.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                case COL_CANCELADO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p=>p.cancelado == "S", direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg,c=>c.Id.ToString());
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                case COL_USUARIO:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.usuario_inclusao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                        dgvDados.DataSource = Pedido_OticaList;
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
            
            if (e.ColumnIndex == COL_STATUS && !string.IsNullOrEmpty((string)e.FormattedValue))
            {
                //Executa filtro.                
            }
        }

        protected override void executeCellEndEditChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellEndEditChild(sender, e);

            executeFilter(sender, e);
           
            

        }

        private void executeFilter(object sender, DataGridViewCellEventArgs e)
        {
            int codigo = 0;
            string os = string.Empty;            
            string cliente = string.Empty;
            string condPag = string.Empty;
            string vendedor = string.Empty;
            string laboratorio = string.Empty;
            DateTime? DtEmiss = null;
            decimal? total = null;
            int? status = null;
            string cancelado = string.Empty;
            string usuario = string.Empty;

            if (dgvFiltro[COL_PEDIDO, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty(dgvFiltro[COL_PEDIDO, e.RowIndex].Value.ToString()))
                {
                    codigo = Convert.ToInt32(dgvFiltro[COL_PEDIDO, e.RowIndex].Value);
                }
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_OS, e.RowIndex].Value))
            {
                os = dgvFiltro[COL_OS, e.RowIndex].Value.ToString();
            }            

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_CLIENTE, e.RowIndex].Value))
            {
                cliente = dgvFiltro[COL_CLIENTE, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_CONDPAG, e.RowIndex].Value))
            {
                condPag = dgvFiltro[COL_CONDPAG, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_VENDEDOR, e.RowIndex].Value))
            {
                vendedor = dgvFiltro[COL_VENDEDOR, e.RowIndex].Value.ToString();
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_LABORATORIO, e.RowIndex].Value))
            {
                laboratorio = dgvFiltro[COL_LABORATORIO, e.RowIndex].Value.ToString();
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

            if (dgvFiltro[COL_TOTAL, e.RowIndex].Value!= null)
            {
                total = Convert.ToDecimal(dgvFiltro[COL_TOTAL, e.RowIndex].Value);
            }

            if (dgvFiltro[COL_STATUS, e.RowIndex].Value != null)
            {
                status = (int)((DataGridViewComboBoxCell)dgvFiltro[COL_STATUS, e.RowIndex]).Value;
            }

            if (e.ColumnIndex == COL_CANCELADO)
            {
                DataGridViewCheckBoxCell cell = dgvFiltro.CurrentCell as DataGridViewCheckBoxCell;
                if (cell != null)
                {
                    CheckState value = (CheckState)cell.EditedFormattedValue;
                    switch (value)
                    {
                        case CheckState.Checked:
                            cancelado = "S";
                            break;
                        case CheckState.Unchecked:
                            cancelado = "N";
                            break;
                        default:
                            cancelado = string.Empty;
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty((string)dgvFiltro[COL_USUARIO, e.RowIndex].Value))
            {
                usuario = dgvFiltro[COL_USUARIO, e.RowIndex].Value.ToString();
            }

            //var predicate = PredicateBuilder.True<Pedido_Otica>();


            Expression<Func<Pedido_Otica, bool>> predicate = p => true;


            if (codigo > 0)
            {
                predicate = predicate = p => p.codigo == codigo;
            }

            if (!string.IsNullOrEmpty(os))
            {
                predicate = predicate.And(p => p.pedido_otica_infoadic.Any(c => c.ordem_servico == os));
            }
            
            if (!string.IsNullOrEmpty(cliente))
            {
                predicate = predicate.And(p => p.cliente.nome_fantasia.ToLower().Contains(cliente.ToLower()));
            }

            if (!string.IsNullOrEmpty(condPag))
            {
                predicate = predicate.And(p => p.parcela.descricao.Contains(condPag));
            }

            if (!string.IsNullOrEmpty(vendedor))
            {
                predicate = predicate.And(p => p.vendedor.nome.ToLower().Contains(vendedor.ToLower()));
            }

            if (!string.IsNullOrEmpty(laboratorio))
            {
                predicate = predicate.And(p => p.pedido_otica_infoadic.Any(c => c.laboratorio.ToLower().Contains(laboratorio.ToLower())));
            }

            if ((DtEmiss != null) & (ValidateUtils.isDate(DtEmiss.ToString())))
            {
                predicate = predicate.And(p => DbFunctions.TruncateTime(p.data_emissao) == DbFunctions.TruncateTime(DtEmiss));
            }

            if ((total != null))
            {
                predicate = predicate.And(p => p.itempedido_otica.Any(c => c.valor_total == total));
            }

            if ((status != null) && (status != 7))
            {
                predicate = predicate.And(p => p.status == status);
            }

            if (!string.IsNullOrEmpty(cancelado))
            {
                predicate = predicate.And(p => p.cancelado == cancelado);
            }

            if (!string.IsNullOrEmpty(usuario))
            {
                predicate = predicate.And(p => p.transportadora.usuario_inclusao.ToLower().Contains(usuario.ToLower()));
            }

            List<Pedido_Otica> Pedido_OticaList = Pedido_OticaBLL.getPedido_Otica(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);
            dgvDados.DataSource = Pedido_OticaBLL.ToList_Pedido_OticaView(Pedido_OticaList);
        }

        protected override void executeCellLeaveChild(object sender, DataGridViewCellEventArgs e)
        {
            base.executeCellLeaveChild(sender, e);
            executeFilter(sender, e);
        }
        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);
            Pedido_OticaBLL = new Pedido_OticaBLL();
            try
            {
                if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
                {
                    Pedido_Otica Pedido_Otica = Pedido_OticaBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                    if (MessageBox.Show("Deseja realmente excluir o registro : " + Pedido_Otica.Id.ToString() + " - " + Pedido_Otica.cliente.nome_fantasia, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Pedido_OticaBLL.ExcluirPedido_Otica(Pedido_Otica);
                    }

                }
            }
            finally
            {
                Pedido_OticaBLL.Dispose();
            }

        }

        public override void ConfigurarForm(Form pFormParent)
        {
            base.ConfigurarForm(pFormParent);
            base.btnImprimir.Visible = true;
            base.btnImprimir.Enabled = true;
        }

        protected override void imprimirRegistro(object sender, EventArgs e)
        {
            frmRelReciboVenda relatorio = new frmRelReciboVenda();

            relatorio.rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relReciboVenda.rdlc";
            if (dgvDados.CurrentRow != null)
            {
                if (dgvDados[0, dgvDados.CurrentRow.Index].Value != null)
                {
                    if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
                    {
                        long? idPed = Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value);
                        Pedido_OticaBLL pedido_OticaBLL = new Pedido_OticaBLL();
                        Pedido_Otica pedido_otica = pedido_OticaBLL.Localizar(idPed);
                        if (pedido_otica.status == (int)StatusPedido.GRAVADO)
                        {
                            pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;
                            pedido_OticaBLL.AtualizarStatusPedido(idPed, StatusPedido.IMPRESSO);
                        }
                        relatorio.ExibeDialogo(this, idPed);
                    }

                }
            }
            //relatorio.ShowDialog();            
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarPedido_Otica();
        }

        private void CancelarPedido_Otica()
        {
            frmUtilCancelarPedido CancelarPedido = new frmUtilCancelarPedido();
            try
            {
                if (ValidaAcessoFuncao(Operacao.Cancelar, CancelarPedido.Tag))
                {
                    if (dgvDados.CurrentRow != null)
                    {
                        if (dgvDados[0, dgvDados.CurrentRow.Index].Value != null)
                        {
                            if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
                            {
                                Id = Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value);

                                DataGridViewCheckBoxCell cell = dgvDados[COL_CANCELADO, dgvDados.CurrentRow.Index] as DataGridViewCheckBoxCell;
                                if (cell != null)
                                {
                                    if (Convert.ToBoolean(cell.Value))
                                    {
                                        Pedido_OticaBLL = new Pedido_OticaBLL();
                                        Pedido_Otica Pedido_Otica = Pedido_OticaBLL.getPedido_Otica(p => p.Id == Id).FirstOrDefault();
                                        if (MessageBox.Show("Pedido : " + Pedido_Otica.Id.ToString() + " - " + Pedido_Otica.cliente.nome_fantasia + " \n Já se encotra cancelado. Desfazer o cancelamento?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            Pedido_Otica.cancelado = "N";
                                            Pedido_Otica.data_cancelamento = null;
                                            Pedido_Otica.motivo_cancelamento = string.Empty;
                                            Pedido_OticaBLL.UsuarioLogado = Program.usuario_logado;
                                            Pedido_OticaBLL.AlterarPedido_Otica(Pedido_Otica);
                                            MessageBox.Show(Text + " salvo com sucesso.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        CancelarPedido.ExibeDialogo(this, Id);
                                    }
                                }

                                //CancelarPedido.atualizagrid = true;

                            }

                        }
                    }


                    //if (CancelarPedido.atualizagrid)
                    //{
                    //    carregaConsulta();
                    //    AtualizaContadores();
                    //}
                }
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CancelarPedido.Dispose();
            }
        }
    }
}
