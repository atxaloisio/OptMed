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
    public partial class frmCadEditTipo_Lente : optmed.frmBaseCadEdit
    {
        Tipo_LenteBLL Tipo_LenteBLL;
        public frmCadEditTipo_Lente()
        {
            InitializeComponent();
        }

        protected override void LoadToControls()
        {
            base.LoadToControls();

            if (Id != null)
            {
                Tipo_LenteBLL = new Tipo_LenteBLL();
                Tipo_Lente Tipo_Lente = Tipo_LenteBLL.Localizar(Id);

                if (Tipo_Lente != null)
                {
                    txtId.Text = Tipo_Lente.Id.ToString();
                    txtNumero.Text = Tipo_Lente.descricao;
                    chkInativo.Checked = Tipo_Lente.inativo == "S";
                }
            }

        }

        protected override bool salvar(object sender, EventArgs e)
        {
            if (epValidaDados.Validar())
            {
                Tipo_Lente Tipo_Lente = new Tipo_Lente();
                Tipo_LenteBLL = new Tipo_LenteBLL();

                Tipo_LenteBLL.UsuarioLogado = Program.usuario_logado;

                Tipo_Lente = LoadFromControls();

                if (Id != null)
                {                    
                    Tipo_LenteBLL.AlterarTipo_Lente(Tipo_Lente);
                }
                else
                {                    
                    Tipo_LenteBLL.AdicionarTipo_Lente(Tipo_Lente);
                }

                if (Tipo_Lente.Id != 0)
                {
                    Id = Tipo_Lente.Id;
                    txtId.Text = Tipo_Lente.Id.ToString();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual Tipo_Lente LoadFromControls()
        {
            Tipo_Lente Tipo_Lente = new Tipo_Lente();

            if (Id != null)
            {
                Tipo_Lente.Id = Convert.ToInt32(txtId.Text);
            }

            Tipo_Lente.descricao = txtNumero.Text;
            
            Tipo_LenteBLL = new Tipo_LenteBLL();

            List<Tipo_Lente> lstTipo_Lente = Tipo_LenteBLL.getTipo_Lente(p => p.descricao == Tipo_Lente.descricao);

            if (lstTipo_Lente.Count() > 0)
            {
                Tipo_Lente = lstTipo_Lente.First();
                Id = Tipo_Lente.Id;
                txtId.Text = Tipo_Lente.Id.ToString();
            }

            Tipo_Lente.inativo = chkInativo.Checked ? "S" : "N";

            return Tipo_Lente;
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

        
    }
}
