using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;
using Utils;
using MySql.Data.MySqlClient;

namespace optmed
{
    public partial class frmLogin : Form
    {
        UsuarioBLL usuarioBLL;
        string _MensagemTrial;
        public frmLogin(string MensagemTrial = "")
        {
            InitializeComponent();
            _MensagemTrial = MensagemTrial;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblLogin.Parent = this;
            lblLogin.BackColor = Color.Transparent;

            lblSenha.Parent = this;
            lblSenha.BackColor = Color.Transparent;

            pictureBox1.Parent = this;
            pictureBox1.BackColor = Color.Transparent;

            lblAvaliacao.Parent = this;
            lblAvaliacao.BackColor = Color.Transparent;

            lblAvaliacao.Text = string.Empty;
            if (!string.IsNullOrEmpty(_MensagemTrial))
            {
                lblAvaliacao.Text = _MensagemTrial;
                lblAvaliacao.Visible = true;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            usuarioBLL = new UsuarioBLL();
            try
            {


#if DEBUG
                Program.usuario_logado = usuarioBLL.Localizar(1);
                this.DialogResult = DialogResult.OK;

                //Program.usuario_logado = usuarioBLL.loginSistema(txtUsuaio.Text, txtSenha.Text);

                //if (Program.usuario_logado != null)
                //{
                //    this.DialogResult = DialogResult.OK;
                //}
                //else
                //{
                //    MessageBox.Show("Usuário ou senha incorreto.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    this.DialogResult = DialogResult.None;
                //}
#else
            Program.usuario_logado = usuarioBLL.loginSistema(txtUsuaio.Text, txtSenha.Text);

                if (Program.usuario_logado != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorreto.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
#endif
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
