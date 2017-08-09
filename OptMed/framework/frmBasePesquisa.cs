using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace optmed
{
    public partial class frmBasePesquisa : optmed.frmBase
    {
        public frmBasePesquisa()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar(sender, e);
            Close();
        }

        protected virtual void cancelar(object sender, EventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            setRetorno();
        }

        protected virtual void setRetorno()
        {            
            if (dgvPesquisa.CurrentRow != null)
            {
                if (dgvPesquisa[0, dgvPesquisa.CurrentRow.Index].Value != null)
                {
                    if (Convert.ToInt32(dgvPesquisa[0, dgvPesquisa.CurrentRow.Index].Value) > 0)
                    {
                        Id = Convert.ToInt32(dgvPesquisa[0, dgvPesquisa.CurrentRow.Index].Value);
                        //frmInstancia.ExibeDialogo(this, Convert.ToInt32(dgvDados[0, dgvDados.CurrentRow.Index].Value));
                    }

                }
            }

            if (Id != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ExecutaPesquisa();
            FormataGridPesquisa();
        }

        protected virtual void FormataGridPesquisa()
        {
            dgvPesquisa.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvPesquisa.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            dgvPesquisa.ReadOnly = true;
            dgvPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPesquisa.MultiSelect = false;
            dgvPesquisa.DefaultCellStyle.NullValue = " - ";            
            dgvPesquisa.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPesquisa.DefaultCellStyle.Font = new Font("Tahoma", 8.5F, FontStyle.Regular);            
        }
        
        protected virtual void ExecutaPesquisa()
        {
            
        }

        private void frmBasePesquisa_Load(object sender, EventArgs e)
        {
            SetupControls();
        }

        protected virtual void SetupControls()
        {
            SetupColunasGrid();
            FormataGridPesquisa();

        }

        protected virtual void SetupColunasGrid()
        {

        }

        private void dgvPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setRetorno();
        }

        private void frmBasePesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
