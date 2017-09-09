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
    public partial class frmCadEditCaixa : optmed.frmBaseCadEdit
    {
        CaixaBLL CaixaBLL;
        public frmCadEditCaixa()
        {
            InitializeComponent();
        }

        protected override void LoadToControls()
        {
            base.LoadToControls();

            if (Id != null)
            {
                CaixaBLL = new CaixaBLL();
                Caixa Caixa = CaixaBLL.Localizar(Id);

                if (Caixa != null)
                {
                    txtId.Text = Caixa.Id.ToString();
                    txtNumero.Text = Caixa.numero;
                    chkInativo.Checked = Caixa.inativo == "S";
                    txtNumero.Focus();
                }
            }

        }

        protected override bool salvar(object sender, EventArgs e)
        {
            if (epValidaDados.Validar())
            {
                Caixa Caixa = new Caixa();
                CaixaBLL = new CaixaBLL();

                CaixaBLL.UsuarioLogado = Program.usuario_logado;

                Caixa = LoadFromControls();

                if (Id != null)
                {                    
                    CaixaBLL.AlterarCaixa(Caixa);
                }
                else
                {                    
                    CaixaBLL.AdicionarCaixa(Caixa);
                }

                if (Caixa.Id != 0)
                {
                    Id = Caixa.Id;
                    txtId.Text = Caixa.Id.ToString();
                }
                txtNumero.Focus();
                return true;                
            }
            else
            {
                return false;
            }
        }

        protected virtual Caixa LoadFromControls()
        {
            Caixa caixa = new Caixa();

            if (Id != null)
            {
                caixa.Id = Convert.ToInt32(txtId.Text);
            }

            caixa.numero = txtNumero.Text;
            
            CaixaBLL = new CaixaBLL();

            List<Caixa> lstCaixa = CaixaBLL.getCaixa(p => p.numero == caixa.numero);

            if (lstCaixa.Count() > 0)
            {
                caixa = lstCaixa.First();
                Id = caixa.Id;
                txtId.Text = caixa.Id.ToString();
            }

            caixa.inativo = chkInativo.Checked ? "S" : "N";

            return caixa;
        }

        protected override void Limpar(Control control)

        {
            base.Limpar(control);
            txtNumero.Focus();
        }

        private void Ctrls_Validated(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                epValidaDados.SetError((TextBox)sender, string.Empty);
            }
            else if (sender is MaskedTextBox)
            {
                epValidaDados.SetError((MaskedTextBox)sender, string.Empty);
            }
            else if (sender is ComboBox)
            {
                epValidaDados.SetError((ComboBox)sender, string.Empty);
            }
        }

        private void frmCadEditCaixa_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmCadEditCaixa_Load(object sender, EventArgs e)
        {
            
        }
    }
}
