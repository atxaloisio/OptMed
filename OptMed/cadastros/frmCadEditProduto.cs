using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using System.Linq;
using Sync;
using Utils;

namespace optmed
{
    public partial class frmCadEditProduto : optmed.frmBaseCadEdit
    {
        private ProdutoBLL ProdutoBLL;

        #region Constante de Colunas da Grid de Movimentações do estoque
        private const int COL_ID = 0;
        private const int COL_IDPRODUTO = 1;
        private const int COL_DATA = 2;
        private const int COL_ORIGEM = 3;        
        private const int COL_QUANTIDADE = 4;
        private const int COL_VALOR = 5;
        private const int COL_SALDO = 6;
        private const int COL_CMCUNITARIO = 7;        
        private const int COL_CMCTOTAL = 8;
        private const int COL_OBS = 9;

        #endregion

        public frmCadEditProduto()
        {
            InitializeComponent();            
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {
                ProdutoBLL = new ProdutoBLL();

                Produto Produto = ProdutoBLL.Localizar(Id);

                if (Produto != null)
                {
                    txtId.Text = Produto.id.ToString();
                    txtCodigo.Text = Produto.codigo;
                    txtCodigoOmie.Text = Produto.codigo_produto.ToString();
                    txtCodInt.Text = Produto.codigo_produto_integracao;
                    txtDescricao.Text = Produto.descricao;
                    txtPrecoUnitario.Text = Produto.valor_unitario.Value.ToString("N2");
                    txtNCM.Text = Produto.ncm;
                    txtEAN.Text = Produto.ean;
                    cbUnidade.Text = Produto.unidade;
                    cbFamiliaProduto.Text = Produto.descricao_familia;
                    txtPesoLiquido.Text = Produto.peso_liq.ToString();
                    txtPesoBruto.Text = Produto.peso_bruto.ToString();
                    LoadMovimentosToGrid(Produto.movimentacoes);
                }                
            }
        }
        
        protected override bool salvar(object sender, EventArgs e)
        {
            bool Retorno = epValidaDados.Validar(true);

            if (Retorno)
            {
                try
                {
                    ProdutoBLL = new ProdutoBLL();
                    ProdutoBLL.UsuarioLogado = Program.usuario_logado;
                    ProdutoProxy proxy = new ProdutoProxy();

                    Produto Produto = LoadFromControls();
                    Produto.sincronizar = "S";

                    bool IntOmie = Convert.ToBoolean(Parametro.GetParametro("intOmie"));
                    bool updateProdutoOmie = Convert.ToBoolean(Parametro.GetParametro("updateProdutoOmie"));

                    if (Id != null)
                    {                        
                        ProdutoBLL.AlterarProduto(Produto);                        
                    }
                    else
                    {
                        Produto.codigo_produto_integracao = Sequence.GetNextVal("sq_produto_sequence").ToString();
                        ProdutoBLL.AdicionarProduto(Produto);
                        Id = Produto.id;
                        txtId.Text = Id.ToString();                                        
                    }

                    if (IntOmie & updateProdutoOmie)
                    {
                        if (Produto.codigo_produto == 0)
                        {
                            proxy.IncluirProduto(Produto);
                        }
                        else
                        {
                            proxy.AlterarProduto(Produto);
                        }
                    }



                    if (Produto.id != 0)
                    {
                        txtCodInt.Text = Produto.codigo_produto_integracao;
                    }

                    Retorno = true;
                }
                catch (Exception ex)
                {
                    Retorno = false;
                    throw ex;
                }
            }
            return Retorno;
        }

        protected virtual Produto LoadFromControls()
        {
            Produto Produto = new Produto();
            ProdutoBLL = new ProdutoBLL();

            if (Id != null)
            {
                Produto = ProdutoBLL.getProduto(Convert.ToInt64(Id),true).FirstOrDefault();
            }

            Produto.codigo = txtCodigo.Text;
            Produto.descricao = txtDescricao.Text;
            Produto.ncm = txtNCM.Text;
            if (!string.IsNullOrEmpty(txtPesoLiquido.Text))
            {
                Produto.peso_liq = Convert.ToDecimal(txtPesoLiquido.Text);
            }
            if (!string.IsNullOrEmpty(txtPesoBruto.Text))
            {
                Produto.peso_bruto = Convert.ToDecimal(txtPesoBruto.Text);
            }
            if (!string.IsNullOrEmpty(txtPrecoUnitario.Text))
            {
                Produto.valor_unitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            }
            if (cbUnidade.SelectedValue != null)
            {
                Produto.unidade = cbUnidade.SelectedValue.ToString();
            }

            if (cbFamiliaProduto.SelectedValue != null)
            {
                Familia_ProdutoBLL familiaBLL = new Familia_ProdutoBLL();
                long Id_Familia = Convert.ToInt64(cbFamiliaProduto.SelectedValue);
                List<Familia_Produto> fpList = familiaBLL.getFamilia_Produto(p => p.Id == Id_Familia, true);
                if (fpList.Count() > 0)
                {
                    Familia_Produto fp = fpList.First();
                    Produto.id_familia = fp.Id;
                    Produto.codigo_familia = fp.codigo;
                    Produto.descricao_familia = fp.nomeFamilia;
                }
                
            }

            Produto.descr_detalhada = txtDescDetProd.Text;

            List<Movimento> MovList = LoadMovimentoFromGrid();

            if (Id != null)
            {
                foreach (Movimento item in MovList)
                {
                    item.id_produto = Convert.ToInt64(Id);
                }
            }
            Produto.movimentacoes.Clear();

            Produto.movimentacoes = MovList;
            
            return Produto;
        }

        protected override void SetupControls()
        {
            SetupUnidade();
            SetupFamiliaProduto();
            formataGridMovEstoque();
        }

        private void SetupFamiliaProduto()
        {
            Familia_ProdutoBLL familia_ProdutoBLL = new Familia_ProdutoBLL();
            List<Familia_Produto> fpList = familia_ProdutoBLL.getFamilia_Produto();
            cbFamiliaProduto.DataSource = fpList;

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            foreach (Familia_Produto item in fpList)
            {
                acc.Add(item.nomeFamilia);
            }

            cbFamiliaProduto.DisplayMember = "nomeFamilia";
            cbFamiliaProduto.ValueMember = "Id";
            cbFamiliaProduto.SelectedIndex = -1;
        }

        private void SetupUnidade()
        {
            UnidadeBLL unidadeBLL = new UnidadeBLL();
            List<Unidade> unList = unidadeBLL.getUnidade();
            cbUnidade.DataSource = unList;

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            foreach (Unidade item in unList)
            {
                acc.Add(item.codigo);
            }

            cbUnidade.DisplayMember = "codigo";
            cbUnidade.ValueMember = "codigo";
            cbUnidade.SelectedIndex = -1;
        }

        private void formataGridMovEstoque()
        {            
            dgvMovEstoque.AutoGenerateColumns = false;
            dgvMovEstoque.ColumnHeadersVisible = true;
            dgvMovEstoque.RowHeadersVisible = false;
            dgvMovEstoque.ReadOnly = true;
            dgvMovEstoque.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvMovEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //altera a cor das linhas alternadas no grid
            dgvMovEstoque.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvMovEstoque.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            formataColunadgvMovEstoque();
            //seleciona a linha inteira
            dgvMovEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //não permite seleção de multiplas linhas
            dgvMovEstoque.MultiSelect = false;
            // exibe nulos formatados
            dgvMovEstoque.DefaultCellStyle.NullValue = " - ";
            //permite que o texto maior que célula não seja truncado
            dgvMovEstoque.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvMovEstoque.DefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Regular);

            dgvMovEstoque.CellDoubleClick += new DataGridViewCellEventHandler(dgvDados_CellDoubleClick);
            
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarMovimento();
        }

        private void formataColunadgvMovEstoque()
        {
            //altera o nome das colunas                        
            dgvMovEstoque.Columns.Add("ID", "Código");
            dgvMovEstoque.Columns.Add("ID_PRODUTO", "Produto");
            dgvMovEstoque.Columns.Add("DATA", "Data");
            dgvMovEstoque.Columns.Add("ORIGEM", "Origem");
            dgvMovEstoque.Columns.Add("QUANTIDADE", "Quantidade");
            dgvMovEstoque.Columns.Add("VALOR", "Valor");
            dgvMovEstoque.Columns.Add("SALDO", "Saldo Acumulado");
            dgvMovEstoque.Columns.Add("CMCUNITARIO", "CMC Unitário");
            dgvMovEstoque.Columns.Add("CMCTOTAL", "CMC Total");
            dgvMovEstoque.Columns.Add("OBS", "OBS");


            dgvMovEstoque.Columns[COL_ID].Width = 70;
            dgvMovEstoque.Columns[COL_ID].ValueType = typeof(int);
            dgvMovEstoque.Columns[COL_ID].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvMovEstoque.Columns[COL_ID].Visible = false;


            dgvMovEstoque.Columns[COL_IDPRODUTO].Width = 200;
            dgvMovEstoque.Columns[COL_IDPRODUTO].ValueType = typeof(int);
            dgvMovEstoque.Columns[COL_IDPRODUTO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvMovEstoque.Columns[COL_IDPRODUTO].Visible = false;

            dgvMovEstoque.Columns[COL_DATA].Width = 100;
            dgvMovEstoque.Columns[COL_DATA].ValueType = typeof(DateTime);
            dgvMovEstoque.Columns[COL_DATA].SortMode = DataGridViewColumnSortMode.Programmatic;

            dgvMovEstoque.Columns[COL_ORIGEM].Width = 100;
            dgvMovEstoque.Columns[COL_ORIGEM].ValueType = typeof(string);
            dgvMovEstoque.Columns[COL_ORIGEM].SortMode = DataGridViewColumnSortMode.Programmatic;

            dgvMovEstoque.Columns[COL_QUANTIDADE].Width = 100;
            dgvMovEstoque.Columns[COL_QUANTIDADE].ValueType = typeof(string);
            dgvMovEstoque.Columns[COL_QUANTIDADE].SortMode = DataGridViewColumnSortMode.Programmatic;
            
            dgvMovEstoque.Columns[COL_VALOR].Width = 100;
            dgvMovEstoque.Columns[COL_VALOR].ValueType = typeof(decimal);
            dgvMovEstoque.Columns[COL_VALOR].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvMovEstoque.Columns[COL_VALOR].DefaultCellStyle.Format = "N2";
            dgvMovEstoque.Columns[COL_VALOR].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMovEstoque.Columns[COL_SALDO].Width = 150;
            dgvMovEstoque.Columns[COL_SALDO].ValueType = typeof(decimal);
            dgvMovEstoque.Columns[COL_SALDO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvMovEstoque.Columns[COL_SALDO].DefaultCellStyle.Format = "N2";
            dgvMovEstoque.Columns[COL_SALDO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMovEstoque.Columns[COL_CMCUNITARIO].Width = 120;
            dgvMovEstoque.Columns[COL_CMCUNITARIO].ValueType = typeof(decimal);
            dgvMovEstoque.Columns[COL_CMCUNITARIO].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvMovEstoque.Columns[COL_CMCUNITARIO].DefaultCellStyle.Format = "N2";
            dgvMovEstoque.Columns[COL_CMCUNITARIO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMovEstoque.Columns[COL_CMCTOTAL].Width = 120;
            dgvMovEstoque.Columns[COL_CMCTOTAL].ValueType = typeof(decimal);
            dgvMovEstoque.Columns[COL_CMCTOTAL].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvMovEstoque.Columns[COL_CMCTOTAL].DefaultCellStyle.Format = "N2";
            dgvMovEstoque.Columns[COL_CMCTOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMovEstoque.Columns[COL_OBS].Width = 300;
            dgvMovEstoque.Columns[COL_OBS].ValueType = typeof(string);
            dgvMovEstoque.Columns[COL_OBS].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvMovEstoque.Columns[COL_OBS].Visible = true;




            //Adiciona uma linha ao grid.
            //dgvMovEstoque.Rows.Add();
        }

        protected override void Limpar(Control control)
        {
            base.Limpar(control);

            txtCodigo.Focus();
        }

        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsNumber(e.KeyChar)) & (e.KeyChar != 8) & (!e.KeyChar.Equals(',')))
            {
                e.Handled = true;
            }
        }

        private void OnlyNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = Convert.ToDecimal(((TextBox)sender).Text).ToString("N2");
            }
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnNovoMovimento_Click(object sender, EventArgs e)
        {
            NovoMovimento();
        }

        private void NovoMovimento()
        {
            frmCadEditMovimento frm = new frmCadEditMovimento();
            frm.Tag = Tag;
            if (frm.ExibeDialogo(null,txtDescricao.Text) == DialogResult.OK)
            {
                //carrega grid para lista.
                List<Movimento> MovimentoList = new List<Movimento>();
                Movimento mov = Clone(frm.Movimento);                
                LoadToMovGrid(mov);
                dgvMovEstoque.Refresh();
            }
            frm.Dispose();
        }

        private void LoadMovimentosToGrid(ICollection<Movimento> movList)
        {
            foreach (Movimento item in movList)
            {
                LoadToMovGrid(item);
            }
        }

        private void LoadToMovGrid(Movimento item, int Row = -1 )
        {
            int rowIndex = 0;
            if (Row > -1)
            {
                rowIndex = Row;
            }
            else
            {
                rowIndex = dgvMovEstoque.Rows.Add();
            }
                             
            dgvMovEstoque[COL_ID,rowIndex].Value = item.Id;
            dgvMovEstoque[COL_IDPRODUTO, rowIndex].Value = item.id_produto;
            dgvMovEstoque[COL_DATA,rowIndex].Value = item.data;

            if (item.tipo.Substring(0,1)=="E")
            {
                item.quantidade = item.quantidade  * 1;
            }
            else if (item.tipo.Substring(0, 1) == "S")
            {
                if (item.quantidade > 0)
                {
                    item.quantidade = item.quantidade * -1;
                }
                
                dgvMovEstoque[COL_QUANTIDADE, rowIndex].Style.ForeColor = Color.Red;
            }

            dgvMovEstoque[COL_QUANTIDADE, rowIndex].Value = item.quantidade;
            dgvMovEstoque[COL_VALOR, rowIndex].Value = item.valor_unitario;
            
            dgvMovEstoque[COL_CMCUNITARIO, rowIndex].Value = item.valor_unitario;
            if (item.tipo.Substring(0,1) == "E")
            {
                dgvMovEstoque[COL_ORIGEM, rowIndex].Value = "Entrada";
            }
            else if (item.tipo.Substring(0, 1) == "S")
            {
                dgvMovEstoque[COL_ORIGEM, rowIndex].Value = "Saida";
            }
                
            dgvMovEstoque[COL_OBS, rowIndex].Value = item.observacao;

            if (rowIndex > 0)
            {
                int RowAnt = rowIndex;
                RowAnt--;
                decimal saldoant = 0;
                saldoant = Convert.ToDecimal(dgvMovEstoque[COL_SALDO, RowAnt].Value);
                decimal saldo = 0;

                saldo = saldoant + item.quantidade;
                dgvMovEstoque[COL_SALDO, rowIndex].Value = saldo;
            }
            else
            {
                dgvMovEstoque[COL_SALDO, rowIndex].Value = item.quantidade;
            }
            
            if (dgvMovEstoque[COL_SALDO, rowIndex].Value != null)
            {
                decimal saldo = Convert.ToDecimal(dgvMovEstoque[COL_SALDO, rowIndex].Value);
                dgvMovEstoque[COL_CMCTOTAL, rowIndex].Value = saldo * item.valor_unitario;
            }
            
        }

        private Movimento Clone(Movimento movimento)
        {
            Movimento mov = new Movimento()
            {
                data = movimento.data,
                Id = movimento.Id,
                id_produto = movimento.id_produto,
                observacao = movimento.observacao,
                quantidade = movimento.quantidade,
                tipo = movimento.tipo,
                valor_total = movimento.valor_total,
                valor_unitario = movimento.valor_unitario
            };
            return mov;
        }

        protected virtual List<Movimento> LoadMovimentoFromGrid()
        {
            List<Movimento> MovimentoList = new List<Movimento>();
            foreach (DataGridViewRow item in dgvMovEstoque.Rows)
            {
                Movimento mov = new Movimento();
                mov.Id = Convert.ToInt64(item.Cells[COL_ID].Value);
                mov.id_produto = Convert.ToInt64(item.Cells[COL_IDPRODUTO].Value);
                mov.quantidade = Convert.ToDecimal(item.Cells[COL_QUANTIDADE].Value);
                mov.data = Convert.ToDateTime(item.Cells[COL_DATA].Value);
                mov.tipo = item.Cells[COL_ORIGEM].Value.ToString().Substring(0,1);                
                mov.valor_unitario = Convert.ToDecimal(item.Cells[COL_VALOR].Value);
                mov.valor_total = mov.quantidade * mov.valor_unitario;
                mov.observacao = item.Cells[COL_OBS].Value.ToString();
                MovimentoList.Add(mov);
            }
            return MovimentoList;
        }

        protected virtual Movimento LoadLinhaMovimentoFromGrid(int RowIndex)
        {
            Movimento mov = new Movimento();

            DataGridViewRow item = dgvMovEstoque.Rows[RowIndex];

            mov.Id = Convert.ToInt64(item.Cells[COL_ID].Value);
            mov.id_produto = Convert.ToInt64(item.Cells[COL_IDPRODUTO].Value);
            mov.quantidade = Convert.ToDecimal(item.Cells[COL_QUANTIDADE].Value);
            mov.data = Convert.ToDateTime(item.Cells[COL_DATA].Value);
            mov.tipo = item.Cells[COL_ORIGEM].Value.ToString();
            mov.valor_unitario = Convert.ToDecimal(item.Cells[COL_VALOR].Value);
            mov.valor_total = mov.quantidade * mov.valor_unitario;
            mov.observacao = item.Cells[COL_OBS].Value.ToString();

            return mov;
        }

        private void dgvMovEstoque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgvMovEstoque[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    btnEditarMovimento.Visible = true;
                }
            }
            
        }

        private void btnEditarMovimento_Click(object sender, EventArgs e)
        {
            EditarMovimento();            
        }

        private void EditarMovimento()
        {
            if (dgvMovEstoque.CurrentRow != null)
            {
                if (dgvMovEstoque[0, dgvMovEstoque.CurrentRow.Index].Value != null)
                {
                    frmCadEditMovimento frm = new frmCadEditMovimento();
                    frm.Tag = Tag;
                    Movimento movEnt = LoadLinhaMovimentoFromGrid(dgvMovEstoque.CurrentRow.Index);

                    if (movEnt.tipo.Substring(0,1) == "S")
                    {
                        movEnt.quantidade = movEnt.quantidade * -1;
                    }


                    if (frm.ExibeDialogo(movEnt, txtDescricao.Text) == DialogResult.OK)
                    {
                        //carrega grid para lista.
                        List<Movimento> MovimentoList = new List<Movimento>();
                        Movimento mov = Clone(frm.Movimento);
                        LoadToMovGrid(mov, dgvMovEstoque.CurrentRow.Index);
                        dgvMovEstoque.Refresh();
                    }
                    frm.Dispose();

                }
            }
        }
    }
}

