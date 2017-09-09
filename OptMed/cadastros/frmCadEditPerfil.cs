using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace optmed
{
    public partial class frmCadEditPerfil : optmed.frmBaseCadEdit
    {
        PerfilBLL perfilBLL;
        public frmCadEditPerfil()
        {
            InitializeComponent();
        }

        private void frmCadEditPerfil_Shown(object sender, EventArgs e)
        {

        }

        protected override bool salvar(object sender, EventArgs e)
        {
            if (epValidaDados.Validar())
            {
                Perfil perfil = new Perfil();
                perfilBLL = new PerfilBLL();

                perfil.nome = txtNome.Text;
                perfil.descricao = txtDescricao.Text;

                if (Id != null)
                {
                    perfil.Id = Convert.ToInt32(txtId.Text);
                    perfil.alteracao = DateTime.Now;
                    if (Program.usuario_logado != null)
                    {
                        perfil.usuario_alteracao = Program.usuario_logado.nome;
                    }

                    perfilBLL.AlterarPerfil(perfil);
                }
                else
                {
                    perfil.inclusao = DateTime.Now;
                    if (Program.usuario_logado != null)
                    {
                        perfil.usuario_inclusao = Program.usuario_logado.nome;
                    }
                    perfilBLL.AdicionarPerfil(perfil);
                }

                if (perfil.Id != 0)
                {
                    Id = perfil.Id;
                    txtId.Text = perfil.Id.ToString();
                }
                return true;
            }
            else
            {
                return false;
            }



        }

        protected override void Limpar(Control control)

        {
            base.Limpar(control);
            txtNome.Focus();
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

        protected override void LoadToControls()
        {
            base.LoadToControls();

            if (Id != null)
            {
                perfilBLL = new PerfilBLL();
                Perfil perfil = perfilBLL.Localizar(Id);

                if (perfil != null)
                {
                    txtId.Text = perfil.Id.ToString();
                    txtNome.Text = perfil.nome;
                    txtDescricao.Text = perfil.descricao;
                }
            }
            
        }

        private void frmCadEditPerfil_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
