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

namespace optmed
{
    public partial class frmCadEditRota : optmed.frmBaseCadEdit
    {
        private RotaBLL rotaBLL;
        private CidadeBLL cidadeBLL;
        private ClienteBLL clienteBLL;

        public frmCadEditRota()
        {
            InitializeComponent();            
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {
                rotaBLL = new RotaBLL();

                Rota rota = rotaBLL.Localizar(Id);

                if (rota != null)
                {
                    txtId.Text = rota.id.ToString();
                    cbTransportadora.SelectedValue = rota.cliente.Id;
                    cbUF.Text = rota.cidade.cUF;
                    SetupCidade(rota.cidade.cUF);
                    cbCidade.SelectedValue = rota.cidade.Id;
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
                    rotaBLL = new RotaBLL();
                    rotaBLL.UsuarioLogado = Program.usuario_logado;

                    Rota rota = LoadFromControls();

                    if (Id != null)
                    {
                        rotaBLL.AlterarRota(rota);
                    }
                    else
                    {
                        rotaBLL.AdicionarRota(rota);
                    }
                    
                    if (rota.id != 0)
                    {
                        Id = rota.id;
                        txtId.Text = rota.id.ToString();
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

        protected virtual Rota LoadFromControls()
        {
            Rota rota = new Rota();

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                rota.id = Convert.ToInt64(txtId.Text);
            }

            rota.id_transportadora = Convert.ToInt64(cbTransportadora.SelectedValue);
            rota.id_cidade = Convert.ToInt32(cbCidade.SelectedValue);

            rotaBLL = new RotaBLL();

            List<Rota> RotaList = rotaBLL.getRota(p => p.id_transportadora == rota.id_transportadora & p.id_cidade == rota.id_cidade);

            if (RotaList.Count > 0)
            {
                rota = RotaList.First();
                rota.id_cidade = Convert.ToInt64(cbCidade.SelectedValue);
                rota.id_transportadora = Convert.ToInt64(cbTransportadora.SelectedValue);
                Id = rota.id;
            }
            
            return rota;
        }

        protected override void SetupControls()
        {            
            SetupTransportadora();
            SetupUF();
        }

        private void SetupUF()
        {
            cidadeBLL = new CidadeBLL();
            List<string> CidadeList = cidadeBLL.getCidade().OrderBy(p => p.cUF).Select(c => c.cUF).Distinct().ToList();

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            
            foreach (string item in CidadeList)
            {
                acc.Add(item);
            }

            cbUF.DataSource = CidadeList;
            cbUF.AutoCompleteCustomSource = acc;
            cbUF.SelectedIndex = -1;
        }

        private void SetupTransportadora()
        {
            clienteBLL = new ClienteBLL();
            List<Cliente> ClienteList = clienteBLL.getCliente(x => x.cliente_tag.Any(e => e.tag == "Transportadora"));

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();

            foreach (Cliente item in ClienteList)
            {
                acc.Add(item.nome_fantasia);
            }

            cbTransportadora.DataSource = ClienteList;
            cbTransportadora.AutoCompleteCustomSource = acc;
            cbTransportadora.ValueMember = "Id";
            cbTransportadora.DisplayMember = "nome_fantasia";
            cbTransportadora.SelectedIndex = -1;
        }



        protected override void Limpar(Control control)
        {
            base.Limpar(control);

            cbTransportadora.Focus();
        }

        private void cbUF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetupCidade(cbUF.SelectedValue.ToString());
        }

        private void SetupCidade(string UF)
        {
            cidadeBLL = new CidadeBLL();
            List<Cidade> CidadeList = cidadeBLL.getCidade(p => p.cUF == UF ).OrderBy(p => p.cNome).ToList();
            cbCidade.DataSource = CidadeList;

            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            foreach (Cidade item in CidadeList)
            {
                acc.Add(item.cNome);
            } 
            

            cbCidade.AutoCompleteCustomSource = acc;
            cbCidade.ValueMember = "Id";
            cbCidade.DisplayMember = "cNome";
            cbCidade.SelectedIndex = -1;
        }

        private void cbTransportadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbUF.Text))
            {
                SetupCidade(cbUF.Text);
            }
        }

        private void cbUF_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ((ComboBox)sender).FindStringExact(((ComboBox)sender).Text) < 0;
            if (e.Cancel)
            {
                MessageBox.Show("Valor digitado não encontrado na lista", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
    }
}
