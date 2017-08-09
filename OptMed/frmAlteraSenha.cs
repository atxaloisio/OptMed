using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using BLL;
using Model;

namespace optmed
{
    public partial class frmAlteraSenha : optmed.frmBase
    {
        UsuarioBLL usuarioBLL;
        public frmAlteraSenha()
        {
            InitializeComponent();
        }

        private void frmAlteraSenha_Load(object sender, EventArgs e)
        {
            SetupControls();
            LoadToControls();
        }

        private void SetupControls()
        {
            
        }

        private void LoadToControls()
        {
            if (Id != null)
            {
                usuarioBLL = new UsuarioBLL();

                Usuario usuario = usuarioBLL.Localizar(Id);

                if (usuario != null)
                {
                    txtId.Text = usuario.Id.ToString();
                    lblUsuario.Text = usuario.nome;                    
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {                
                if (salvar(sender, e))
                {                    
                    MessageBox.Show(Text + " salvo com sucesso.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool salvar(object sender, EventArgs e)
        {
            bool retorno = true;
            if (Id != null)
            {
                retorno = epValidaDados.Validar();
                if (retorno)
                {
                    usuarioBLL = new UsuarioBLL();
                    Usuario usuario = usuarioBLL.Localizar(Id);

                    retorno = usuario != null;

                    if (retorno)
                    {
                        retorno = usuarioBLL.loginSistema(usuario.email, txtSenhaAtual.Text) != null;
                        if (!retorno)
                        {
                            MessageBox.Show("Senha atual diferente da senha gravada no sistema.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (retorno)
                    {
                        usuario.password = Crypto.Codificar(txtPassword.Text);
                        usuarioBLL.AlterarUsuario(usuario);
                        Program.usuario_logado = usuario;
                    }
                }
                
            }
            return retorno;
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

        private void ckVisualizarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVisualizarSenha.Checked)
            {
                txtSenhaAtual.PasswordChar = '\0';
                txtPassword.PasswordChar = '\0';
                txtConfPassword.PasswordChar = '\0';
            }
            else
            {
                txtSenhaAtual.PasswordChar = '*';
                txtPassword.PasswordChar = '*';
                txtConfPassword.PasswordChar = '*';
            }

            txtConfPassword.PasswordChar = txtConfPassword.PasswordChar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAlteraSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
