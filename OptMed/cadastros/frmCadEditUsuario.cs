using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Model;
using BLL;
using Utils;

namespace optmed
{
    public partial class frmCadEditUsuario : optmed.frmBaseCadEdit
    {
        UsuarioBLL usuarioBLL;
        PerfilBLL perfilBLL;
        FilialBLL filialBLL;
        public frmCadEditUsuario()
        {
            InitializeComponent();
        }
        
        protected override void LoadToControls()
        {
            this.Cursor = Cursors.WaitCursor;
            
            if (Id != null)
            {
                usuarioBLL = new UsuarioBLL();

                Usuario usuario = usuarioBLL.Localizar(Id);

                if (usuario != null)
                {
                    txtId.Text = usuario.Id.ToString();
                    txtNome.Text = usuario.nome;
                    txtEmail.Text = usuario.email;
                    txtPassword.Text = Crypto.Decodificar(usuario.password);
                    txtConfPassword.Text = Crypto.Decodificar(usuario.password);
                    txtDtAlteracao.Text = usuario.alteracao.ToString();
                    txtDtCriacao.Text = usuario.inclusao.ToString();
                    cbPerfil.SelectedValue = usuario.perfil.Id;
                    chkInativo.Checked = usuario.inativo == "S";

                    if (usuario.Id_filial != null)
                    {
                        cbFilial.SelectedValue = usuario.Id_filial;
                    }
                    
                }
            }
            this.Cursor = Cursors.Default;
        }

        protected override void SetupControls()
        {
            base.SetupControls();
            setupcbPerfil();
            setupcbFilial();
        }

        private void setupcbFilial()
        {
            filialBLL = new FilialBLL();
            List<Filial> lstFilial = filialBLL.getFilial();
            cbFilial.DataSource = lstFilial;
            cbFilial.ValueMember = "Id";
            cbFilial.DisplayMember = "nome_fantasia";
            cbFilial.SelectedIndex = -1;
            if (lstFilial.Count <= 0)
            {
                cbFilial.Enabled = false;
            }
        }

        private void setupcbPerfil()
        {
            perfilBLL = new PerfilBLL();
            List<Perfil> lstPerfil = perfilBLL.getPerfil();
            cbPerfil.DataSource = lstPerfil;
            cbPerfil.ValueMember = "Id";
            cbPerfil.DisplayMember = "descricao";
            cbPerfil.SelectedIndex = -1;
        }

        protected override bool salvar(object sender, EventArgs e)
        {           
            if (epValidaDados.Validar())
            {

                Usuario usuario = new Usuario();
                usuarioBLL = new UsuarioBLL();

                usuario.nome = txtNome.Text;
                usuario.email = txtEmail.Text;
                usuario.password = Crypto.Codificar(txtPassword.Text);
                usuario.Id_perfil = Convert.ToInt64(cbPerfil.SelectedValue);
                usuario.inativo = chkInativo.Checked ? "S" : "N";
                if (cbFilial.SelectedValue != null)
                {
                    filialBLL = new FilialBLL();
                    Filial filial = filialBLL.Localizar(Convert.ToInt64(cbFilial.SelectedValue));
                    usuario.Id_filial = filial.Id;
                    usuario.Id_empresa = filial.Id_empresa;
                }
                else
                {
                    EmpresaBLL empresaBLL = new EmpresaBLL();
                    Empresa empresa = empresaBLL.getEmpresa().FirstOrDefault();
                    if (empresa != null)
                    {
                        usuario.Id_empresa = empresa.Id;
                    }
                }

                if (Id != null)
                {
                    usuario.Id = Convert.ToInt32(txtId.Text);
                    usuario.alteracao = DateTime.Now;
                    usuario.usuario_alteracao = Program.usuario_logado.nome;
                    usuarioBLL.AlterarUsuario(usuario);
                }
                else
                {
                    usuario.inclusao = DateTime.Now;
                    usuario.usuario_inclusao = Program.usuario_logado.nome;
                    usuarioBLL.AdicionarUsuario(usuario);
                }

                if (usuario.Id != 0)
                {
                    Id = usuario.Id;
                    txtId.Text = usuario.Id.ToString();
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

        private void ckVisualizarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVisualizarSenha.Checked)
            {
                txtPassword.PasswordChar = '\0';                
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }

            txtConfPassword.PasswordChar = txtConfPassword.PasswordChar;
        }                

        private void txtConfPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                epValidaDados.SetError(txtConfPassword, "Confirmação de senha difere da informada no campo senha.");
            }
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

        private void frmCadEditUsuario_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
