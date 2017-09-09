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
    public partial class frmListFornecedores : optmed.frmBaseList
    {
        ClienteBLL clienteBLL;
        #region Constante de Colunas da Grid
        private const int col_Id = 0;
        private const int col_codigo_cliente = 1;
        private const int col_cnpj_cpf = 2;
        private const int col_razao_social = 3;
        private const int col_nome_fantasia = 4;
        private const int col_telefone1_ddd = 5;
        private const int col_telefone1_numero = 6;
        private const int col_contato = 7;
        private const int col_email = 8;
        private const int col_cidade = 9;
        private const int col_estado = 10;
        private const int col_endereco = 11;
        private const int col_endereco_numero = 12;
        private const int col_bairro = 13;
        private const int col_complemento = 14;                
        private const int col_cep = 15;               
        private const int col_inscricao_estadual = 16;
        private const int col_inscricao_municipal = 17;
        #endregion
        public frmListFornecedores()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmClientes_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region Metodos Sobreescritos

        protected override void InstanciarFormulario()
        {
            frmInstancia = new frmCadEditFornecedor();
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
            gridFiltros.Columns.Add("ID", "ID");
            gridFiltros.Columns.Add("CODIGO", "Código");
            gridFiltros.Columns.Add("CNPJ_CPF", "CNPJ / CPF");
            gridFiltros.Columns.Add("RAZAO_SOCIAL", "Razão Social");
            gridFiltros.Columns.Add("NOME_FANTASIA", "Nome Fantasia");
            gridFiltros.Columns.Add("DDD", "DDD");
            gridFiltros.Columns.Add("TELEFONE", "Telefone");
            gridFiltros.Columns.Add("CONTATO", "Contato");
            gridFiltros.Columns.Add("EMAIL", "e-Mail");
            gridFiltros.Columns.Add("CIDADE", "Cidade");                     

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

            gridFiltros.Columns.Add("ENDERECO", "Endereço");
            gridFiltros.Columns.Add("NUMERO", "Número");
            gridFiltros.Columns.Add("BAIRRO", "Bairro");
            gridFiltros.Columns.Add("COMPLEMENTO", "Complemento");            
            gridFiltros.Columns.Add("CEP", "CEP");
            gridFiltros.Columns.Add("INSCRESTADUAL", "Inscrição Estadual");
            gridFiltros.Columns.Add("INSCRMUNICIPAL", "Inscrição Municipal");
            

            gridFiltros.Columns[col_Id].Width = 70;
            gridFiltros.Columns[col_Id].ValueType = typeof(int);
            gridFiltros.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridFiltros.Columns[col_Id].Visible = false;

            gridFiltros.Columns[col_codigo_cliente].Width = 100;
            gridFiltros.Columns[col_codigo_cliente].ValueType = typeof(string);
            gridFiltros.Columns[col_codigo_cliente].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_cnpj_cpf].Width = 150;
            gridFiltros.Columns[col_cnpj_cpf].ValueType = typeof(string);
            gridFiltros.Columns[col_cnpj_cpf].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_razao_social].Width = 350;
            gridFiltros.Columns[col_razao_social].ValueType = typeof(string);
            gridFiltros.Columns[col_razao_social].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_nome_fantasia].Width = 350;
            gridFiltros.Columns[col_nome_fantasia].ValueType = typeof(string);
            gridFiltros.Columns[col_nome_fantasia].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_telefone1_ddd].Width = 80;
            gridFiltros.Columns[col_telefone1_ddd].ValueType = typeof(string);
            gridFiltros.Columns[col_telefone1_ddd].SortMode = DataGridViewColumnSortMode.NotSortable;

            gridFiltros.Columns[col_telefone1_numero].Width = 150;
            gridFiltros.Columns[col_telefone1_numero].ValueType = typeof(string);
            gridFiltros.Columns[col_telefone1_numero].SortMode = DataGridViewColumnSortMode.NotSortable;                      

            gridFiltros.Columns[col_contato].Width = 180;
            gridFiltros.Columns[col_contato].ValueType = typeof(string);
            gridFiltros.Columns[col_contato].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_email].Width = 300;
            gridFiltros.Columns[col_email].ValueType = typeof(string);
            gridFiltros.Columns[col_email].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_cidade].Width = 200;
            gridFiltros.Columns[col_cidade].ValueType = typeof(string);
            gridFiltros.Columns[col_cidade].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_estado].Width = 50;
            //gridFiltros.Columns[col_uf].ValueType = typeof(string);
            gridFiltros.Columns[col_estado].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_endereco].Width = 400;
            gridFiltros.Columns[col_endereco].ValueType = typeof(string);
            gridFiltros.Columns[col_endereco].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_endereco_numero].Width = 80;
            gridFiltros.Columns[col_endereco_numero].ValueType = typeof(string);
            gridFiltros.Columns[col_endereco_numero].SortMode = DataGridViewColumnSortMode.NotSortable;

            gridFiltros.Columns[col_bairro].Width = 200;
            gridFiltros.Columns[col_bairro].ValueType = typeof(string);
            gridFiltros.Columns[col_bairro].SortMode = DataGridViewColumnSortMode.NotSortable;

            gridFiltros.Columns[col_complemento].Width = 150;
            gridFiltros.Columns[col_complemento].ValueType = typeof(string);
            gridFiltros.Columns[col_complemento].SortMode = DataGridViewColumnSortMode.NotSortable;
                        
            gridFiltros.Columns[col_cep].Width = 100;
            gridFiltros.Columns[col_cep].ValueType = typeof(string);
            gridFiltros.Columns[col_cep].SortMode = DataGridViewColumnSortMode.Programmatic;

            gridFiltros.Columns[col_inscricao_estadual].Width = 150;
            gridFiltros.Columns[col_inscricao_estadual].ValueType = typeof(string);
            gridFiltros.Columns[col_inscricao_estadual].SortMode = DataGridViewColumnSortMode.NotSortable;

            gridFiltros.Columns[col_inscricao_municipal].Width = 150;
            gridFiltros.Columns[col_inscricao_municipal].ValueType = typeof(string);
            gridFiltros.Columns[col_inscricao_municipal].SortMode = DataGridViewColumnSortMode.NotSortable;
            

            gridFiltros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gridFiltros_EditingControlShowing);

            //Adiciona uma linha ao grid.
            gridFiltros.Rows.Add();

        }

        private void gridFiltros_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (dgvFiltro.CurrentCell.ColumnIndex)
            {
                case col_estado:
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

            Expression<Func<Cliente, bool>> predicate = p => true;

            if (!string.IsNullOrEmpty(value))
            {
                predicate = predicate.And(p => p.estado == value);
            }

            clienteBLL = new ClienteBLL();
            List<Cliente> ClienteList = clienteBLL.getCliente(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);

            dgvDados.DataSource = clienteBLL.ToList_ClienteView(ClienteList);
        }

        protected override void formataColunagridDados(DataGridView gridDados)
        {
            base.formataColunagridDados(gridDados);
            gridDados.Columns[col_Id].Width = 70;
            gridDados.Columns[col_Id].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_Id].Visible = false;
            gridDados.Columns[col_codigo_cliente].Width = 100;
            gridDados.Columns[col_codigo_cliente].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_razao_social].Width = 350;
            gridDados.Columns[col_razao_social].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_nome_fantasia].Width = 350;
            gridDados.Columns[col_nome_fantasia].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_cnpj_cpf].Width = 150;
            gridDados.Columns[col_cnpj_cpf].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_contato].Width = 180;
            gridDados.Columns[col_contato].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_endereco].Width = 400;
            gridDados.Columns[col_endereco].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_endereco_numero].Width = 80;
            gridDados.Columns[col_endereco_numero].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_complemento].Width = 150;
            gridDados.Columns[col_complemento].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_bairro].Width = 200;
            gridDados.Columns[col_bairro].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_cidade].Width = 200;
            gridDados.Columns[col_cidade].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_estado].Width = 50;
            gridDados.Columns[col_estado].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_cep].Width = 100;
            gridDados.Columns[col_cep].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_telefone1_ddd].Width = 80;
            gridDados.Columns[col_telefone1_ddd].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_telefone1_numero].Width = 150;
            gridDados.Columns[col_telefone1_numero].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_email].Width = 300;
            gridDados.Columns[col_email].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_inscricao_estadual].Width = 150;
            gridDados.Columns[col_inscricao_estadual].SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDados.Columns[col_inscricao_municipal].Width = 150;
            gridDados.Columns[col_inscricao_municipal].SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        protected override void carregaConsulta()
        {
            clienteBLL = new ClienteBLL();
            base.carregaConsulta();
            dgvDados.DataSource = null;
            List<Cliente> ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);

            dgvDados.DataSource = clienteBLL.ToList_ClienteView(ClienteList);
            colOrdem = 0;
        }

        protected override void ordenaCelula(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.ordenaCelula(sender, e);

            clienteBLL = new ClienteBLL();

            List<Cliente> ClienteList;

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

                case col_codigo_cliente:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"),p => p.codigo_cliente_integracao, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_razao_social:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"),p => p.razao_social, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_nome_fantasia:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.nome_fantasia, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_cnpj_cpf:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.cnpj_cpf, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_contato:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.logradouro, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_endereco:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.endereco, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_estado:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.estado, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_cidade:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.cidade, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_cep:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.cep, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                case col_email:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.email, direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;

                //O default será executado quando o index for 0
                default:
                    {
                        ClienteList = clienteBLL.getCliente(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"), p => p.Id.ToString(), direction != ListSortDirection.Ascending, deslocamento, tamanhoPagina, out totalReg);
                    }
                    break;
            }

            dgvDados.DataSource = clienteBLL.ToList_ClienteView(ClienteList);

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

            clienteBLL = new ClienteBLL();

            int id = 0;            
            string codigo_cliente = string.Empty;
            string razao_social = string.Empty;
            string nome_fantasia = string.Empty;
            string cnpj_cpf = string.Empty;
            string logradouro = string.Empty;
            string endereco = string.Empty;
            string endereco_numero = string.Empty;
            string complemento = string.Empty;
            string bairro = string.Empty;
            string cidade = string.Empty;
            string estado = string.Empty;
            string cep = string.Empty;
            string telefone1_ddd = string.Empty;
            string telefone1_numero = string.Empty;
            string email = string.Empty;
            

            if (dgvFiltro[col_Id, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_Id, e.RowIndex].Value.ToString()))
                {
                    id = Convert.ToInt32(dgvFiltro[col_Id, e.RowIndex].Value);
                }
            }

            if (dgvFiltro[col_codigo_cliente, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_codigo_cliente, e.RowIndex].Value))
                {
                    codigo_cliente = dgvFiltro[col_codigo_cliente, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_razao_social, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_razao_social, e.RowIndex].Value))
                {
                    razao_social = dgvFiltro[col_razao_social, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_nome_fantasia, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_nome_fantasia, e.RowIndex].Value))
                {
                    nome_fantasia = dgvFiltro[col_nome_fantasia, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_cnpj_cpf, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_cnpj_cpf, e.RowIndex].Value))
                {
                    cnpj_cpf = dgvFiltro[col_cnpj_cpf, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_contato, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_contato, e.RowIndex].Value))
                {
                    logradouro = dgvFiltro[col_contato, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_endereco, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_endereco, e.RowIndex].Value))
                {
                    endereco = dgvFiltro[col_endereco, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_endereco_numero, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_endereco_numero, e.RowIndex].Value))
                {
                    endereco_numero = dgvFiltro[col_endereco_numero, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_complemento, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_complemento, e.RowIndex].Value))
                {
                    complemento = dgvFiltro[col_complemento, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_bairro, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_bairro, e.RowIndex].Value))
                {
                    bairro = dgvFiltro[col_bairro, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_cidade, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_cidade, e.RowIndex].Value))
                {
                    cidade = dgvFiltro[col_cidade, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_estado, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_estado, e.RowIndex].Value))
                {
                    estado = dgvFiltro[col_estado, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_cep, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_cep, e.RowIndex].Value))
                {
                    cep = dgvFiltro[col_cep, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_telefone1_ddd, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_telefone1_ddd, e.RowIndex].Value))
                {
                    telefone1_ddd = dgvFiltro[col_telefone1_ddd, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_telefone1_numero, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_telefone1_numero, e.RowIndex].Value))
                {
                    telefone1_numero = dgvFiltro[col_telefone1_numero, e.RowIndex].Value.ToString();
                }
            }

            if (dgvFiltro[col_email, e.RowIndex].Value != null)
            {
                if (!string.IsNullOrEmpty((string)dgvFiltro[col_email, e.RowIndex].Value))
                {
                    email = dgvFiltro[col_email, e.RowIndex].Value.ToString();
                }
            }

            Expression<Func<Cliente, bool>> predicate = p => true;


            if (id > 0)
            {
                predicate = predicate = p => p.Id == id;
            }

            if (!string.IsNullOrEmpty(codigo_cliente))
            {
                predicate = predicate.And(p => p.codigo_cliente_integracao == codigo_cliente );
            }

            if (!string.IsNullOrEmpty(razao_social))
            {
                predicate = predicate.And(p => p.razao_social.ToLower().Contains(razao_social.ToLower()));
            }

            if (!string.IsNullOrEmpty(nome_fantasia))
            {
                predicate = predicate.And(p => p.nome_fantasia.ToLower().Contains(nome_fantasia.ToLower()));
            }

            if (!string.IsNullOrEmpty(cnpj_cpf))
            {
                predicate = predicate.And(p => p.cnpj_cpf == cnpj_cpf);
            }

            if (!string.IsNullOrEmpty(logradouro))
            {
                predicate = predicate.And(p => p.logradouro.ToLower().Contains(logradouro.ToLower()));
            }

            if (!string.IsNullOrEmpty(endereco))
            {
                predicate = predicate.And(p => p.endereco.ToLower().Contains(endereco.ToLower()));
            }

            if (!string.IsNullOrEmpty(endereco_numero))
            {
                predicate = predicate.And(p => p.endereco_numero == endereco_numero);
            }

            if (!string.IsNullOrEmpty(bairro))
            {
                predicate = predicate.And(p => p.bairro.ToLower().Contains(bairro.ToLower()));
            }

            if (!string.IsNullOrEmpty(cidade))
            {
                predicate = predicate.And(p => p.cidade.ToLower().Contains(cidade.ToLower()));
            }

            if (!string.IsNullOrEmpty(estado))
            {
                predicate = predicate.And(p => p.estado.ToLower() == estado.ToLower());
            }

            if (!string.IsNullOrEmpty(cep))
            {
                predicate = predicate.And(p => p.cep == cep);
            }

            if (!string.IsNullOrEmpty(telefone1_ddd))
            {
                predicate = predicate.And(p => p.telefone1_ddd == telefone1_ddd);
            }

            if (!string.IsNullOrEmpty(telefone1_numero))
            {
                predicate = predicate.And(p => p.telefone1_numero == telefone1_numero);
            }

            if (!string.IsNullOrEmpty(email))
            {
                predicate = predicate.And(p => p.email.ToLower().Contains(email.ToLower()));
            }

            predicate = predicate.And(p => p.cliente_tag.Any(c => c.tag == "Fornecedor"));

            List<Cliente> ClienteList = clienteBLL.getCliente(predicate.Expand(), t => t.Id.ToString(), false, deslocamento, tamanhoPagina, out totalReg);

            dgvDados.DataSource = clienteBLL.ToList_ClienteView(ClienteList);

        }

        protected override void excluirRegistro(int Id)
        {
            base.excluirRegistro(Id);

            clienteBLL = new ClienteBLL();

            if (Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value) > 0)
            {
                Cliente Cliente = clienteBLL.Localizar(Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                if (MessageBox.Show("Deseja realmente excluir o registro : " + Cliente.nome_fantasia , Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clienteBLL.ExcluirCliente(Cliente);
                }
            }
        }

        #endregion
    }
}
