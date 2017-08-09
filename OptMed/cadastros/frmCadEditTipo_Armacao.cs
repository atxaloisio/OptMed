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
    public partial class frmCadEditTipo_Armacao : optmed.frmBaseCadEdit
    {
        Tipo_ArmacaoBLL Tipo_ArmacaoBLL;
        public frmCadEditTipo_Armacao()
        {
            InitializeComponent();
        }

        protected override void LoadToControls()
        {
            base.LoadToControls();

            if (Id != null)
            {
                Tipo_ArmacaoBLL = new Tipo_ArmacaoBLL();
                Tipo_Armacao Tipo_Armacao = Tipo_ArmacaoBLL.Localizar(Id);

                if (Tipo_Armacao != null)
                {
                    txtId.Text = Tipo_Armacao.Id.ToString();
                    txtNumero.Text = Tipo_Armacao.descricao;
                    chkInativo.Checked = Tipo_Armacao.inativo == "S";
                }
            }

        }

        protected override bool salvar(object sender, EventArgs e)
        {
            if (epValidaDados.Validar())
            {
                Tipo_Armacao Tipo_Armacao = new Tipo_Armacao();
                Tipo_ArmacaoBLL = new Tipo_ArmacaoBLL();

                Tipo_ArmacaoBLL.UsuarioLogado = Program.usuario_logado;

                Tipo_Armacao = LoadFromControls();

                if (Id != null)
                {                    
                    Tipo_ArmacaoBLL.AlterarTipo_Armacao(Tipo_Armacao);
                }
                else
                {                    
                    Tipo_ArmacaoBLL.AdicionarTipo_Armacao(Tipo_Armacao);
                }

                if (Tipo_Armacao.Id != 0)
                {
                    Id = Tipo_Armacao.Id;
                    txtId.Text = Tipo_Armacao.Id.ToString();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual Tipo_Armacao LoadFromControls()
        {
            Tipo_Armacao Tipo_Armacao = new Tipo_Armacao();

            if (Id != null)
            {
                Tipo_Armacao.Id = Convert.ToInt32(txtId.Text);
            }

            Tipo_Armacao.descricao = txtNumero.Text;
            
            Tipo_ArmacaoBLL = new Tipo_ArmacaoBLL();

            List<Tipo_Armacao> lstTipo_Armacao = Tipo_ArmacaoBLL.getTipo_Armacao(p => p.descricao == Tipo_Armacao.descricao);

            if (lstTipo_Armacao.Count() > 0)
            {
                Tipo_Armacao = lstTipo_Armacao.First();
                Id = Tipo_Armacao.Id;
                txtId.Text = Tipo_Armacao.Id.ToString();
            }

            Tipo_Armacao.inativo = chkInativo.Checked ? "S" : "N";

            return Tipo_Armacao;
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
