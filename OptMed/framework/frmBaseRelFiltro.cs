using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using Model;

namespace optmed
{
    public partial class frmBaseRelFiltro : optmed.frmBase
    {
        protected frmBase frmInstancia;

        
        public frmBaseRelFiltro()
        {
            InitializeComponent();
        
        }

        protected virtual void InstanciarFormulario()
        {

        }

        public virtual void ConfigurarForm(Form pFormParent)
        {
            //WindowState = FormWindowState.Maximized;
            MinimizeBox = false;
            MaximizeBox = false;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            MdiParent = pFormParent;
        }

        

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void frmBaseRelFiltro_Load(object sender, EventArgs e)
        {            
            
            WindowState = FormWindowState.Maximized;
                        
            btnFechar.Top = (pnlBotoes.Height - btnFechar.Height);
            Parent.Text = Parent.Text + " : " + Text;            
        }      
                
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirRegistro(sender, e);
        }

        protected virtual void imprimirRegistro(object sender, EventArgs e)
        {
            
        }        
    }
}
