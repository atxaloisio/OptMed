using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace optmed
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        public void setMensagem(string mensagem)
        {
            lblMensagem.Text = mensagem;
        }

        public void setprogresso(int vlprogresso)
        {
            progressBar1.Value = vlprogresso;
            progressBar1.Refresh();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            lblMensagem.Parent = pbSplash;
            lblMensagem.BackColor = Color.Transparent;
        }
    }
}
