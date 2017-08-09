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
using Utils;

namespace optmed
{
    public partial class frmCadEditMovimento : optmed.frmBaseCadEdit
    {       
        public Movimento Movimento {get;set;}
        public frmCadEditMovimento()
        {
            InitializeComponent();
        }

        protected override void LoadToControls()
        {
            base.LoadToControls();

            if (Movimento != null)
            {
                txtData.Text = Movimento.data.ToShortDateString();
                txtQuantidade.Text = Movimento.quantidade.ToString("N2");
                txtValorUnitario.Text = Movimento.valor_unitario.ToString("N2");
                cbTipoMov.Text = Movimento.tipo;
                txtObservacao.Text = Movimento.observacao;
            }

        }

        protected override void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                atualizagrid = true;
                if (ValidaAcessoFuncao(Operacao.Salvar))
                {
                    if (salvar(sender, e))
                    {
                        DialogResult = DialogResult.OK;
                    }
                }


            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override bool salvar(object sender, EventArgs e)
        {
            if (epValidaDados.Validar())
            {                                                
                Movimento = LoadFromControls();
                                                
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual Movimento LoadFromControls()
        {
            if (Movimento == null)
            {
                Movimento = new Movimento();
            }
            

            Movimento.data = Convert.ToDateTime(txtData.Text);
            Movimento.observacao = txtObservacao.Text;
            Movimento.quantidade = Convert.ToDecimal(txtQuantidade.Text);
            Movimento.valor_unitario = Convert.ToDecimal(txtValorUnitario.Text);
            Movimento.tipo = cbTipoMov.Text;
            
            return Movimento;
        }

        protected override void Limpar(Control control)

        {
            base.Limpar(control);
            txtData.Focus();
        }

        public virtual DialogResult ExibeDialogo(Movimento item = null, string DescProduto = "")
        {
            Movimento = item;
            txtDescricao.Text = DescProduto;
            return ShowDialog();
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
    }
}
