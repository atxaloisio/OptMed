﻿using System;
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
    public partial class frmBaseCadEdit : optmed.frmBase
    {

        public frmBaseCadEdit()
        {
            InitializeComponent();
        }

        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            cancelar(sender, e);
            Close();
        }

        protected virtual void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar_Click(sender, e);                        
        }

        protected virtual void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                atualizagrid = true;
                if (ValidaAcessoFuncao(Operacao.Salvar))
                {
                    if (salvar(sender, e))
                    {
                        btnIncluir.Top = 40;
                        btnIncluir.Visible = true;
                        btnFechar.Top = 75;
                        MessageBox.Show(Text + " salvo com sucesso.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ImprimirRegistro(Id);
                    }
                }


            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void ImprimirRegistro(Int64? id)
        {
            
        }

        protected virtual void cancelar(object sender, EventArgs e)
        {

        }

        protected virtual bool salvar(object sender, EventArgs e)
        {
            return true;
        }

        protected virtual void Limpar(Control control)
        {
            foreach (Control pnl in control.Controls)
            {
                if ((pnl is Panel) || (pnl is GroupBox))
                {
                    foreach (var ctrl in pnl.Controls)
                    {
                        if ((pnl is Panel) || (pnl is GroupBox))
                        {
                            Limpar(pnl);
                        }
                        else if (ctrl is TextBox)
                        {
                            ((TextBox)ctrl).Text = string.Empty;
                        }
                        else if (ctrl is ComboBox)
                        {
                            ((ComboBox)ctrl).SelectedIndex = -1;
                        }
                        else if (ctrl is MaskedTextBox)
                        {
                            ((MaskedTextBox)ctrl).Clear();
                        }
                        else if (ctrl is CheckBox)
                        {
                            ((CheckBox)ctrl).Checked = false;
                        } 

                    }
                }
                else if (pnl is TextBox)
                {
                    ((TextBox)pnl).Text = string.Empty;
                }
                else if (pnl is ComboBox)
                {
                    ((ComboBox)pnl).SelectedIndex = -1;
                }
                else if (pnl is MaskedTextBox)
                {
                    ((MaskedTextBox)pnl).Clear();
                }
                else if (pnl is CheckBox)
                {
                    ((CheckBox)pnl).Checked = false;
                }
            }
        }

        private void frmBaseCadEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }

            
        }

        protected virtual void btnIncluir_Click(object sender, EventArgs e)
        {
            Incluir();
            
        }

        protected virtual void Incluir()
        {
            Limpar(this);
            Id = null;
        }

        protected virtual Boolean ValidarDados()
        {
            return true;
        }

        protected virtual void LoadToControls()
        {

        }
       
        protected virtual void SetupControls()
        {

        }

        private void frmBaseCadEdit_Load(object sender, EventArgs e)
        {
            SetupControls();
            LoadToControls();            
        }
              
    }
}