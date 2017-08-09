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
using Sync;
using Utils;

namespace optmed
{
    public partial class frmCadEditVendedor : optmed.frmBaseCadEdit
    {
        private VendedorBLL VendedorBLL;
       
        public frmCadEditVendedor()
        {
            InitializeComponent();            
        }

        protected override void LoadToControls()
        {
            if (Id != null)
            {
                VendedorBLL = new VendedorBLL();

                Vendedor Vendedor = VendedorBLL.Localizar(Id);

                if (Vendedor != null)
                {
                    txtId.Text = Vendedor.Id.ToString();
                    txtCodigo.Text = Vendedor.codigo.ToString();
                    txtCodInt.Text = Vendedor.codInt;
                    txtNome.Text = Vendedor.nome;
                    chkInativo.Checked = Vendedor.inativo == "S";                    
                }                
            }
        }

        protected override bool salvar(object sender, EventArgs e)
        {
            bool Retorno = epValidaDados.Validar(true);

            if (Retorno)
            {
                try
                {
                    VendedorBLL = new VendedorBLL();
                    VendedorBLL.UsuarioLogado = Program.usuario_logado;
                    VendedorProxy proxy = new VendedorProxy();

                    bool intOmie = Convert.ToBoolean(Parametro.GetParametro("intOmie"));
                    bool updateVendedorOmie = Convert.ToBoolean(Parametro.GetParametro("updateVendedorOmie"));

                    Vendedor Vendedor = LoadFromControls();

                    Vendedor.sincronizar = "S";

                    if (Id != null)
                    {                        
                        VendedorBLL.AlterarVendedor(Vendedor);                      
                    }
                    else
                    {
                        VendedorBLL.AdicionarVendedor(Vendedor);                       
                    }
                    
                    if (Vendedor.Id != 0)
                    {
                        Id = Vendedor.Id;
                        txtCodInt.Text = Vendedor.codInt;
                    }

                    if ((intOmie) & (updateVendedorOmie))
                    {
                        if (Vendedor.codigo <= 0)
                        {
                            proxy.IncluirVendedor(Vendedor);
                        }
                        else
                        {
                            proxy.AlterarVendedor(Vendedor);
                        }
                    }

                    Retorno = true;
                }
                catch (Exception ex)
                {
                    Retorno = false;
                    throw ex;
                }
            }
            return Retorno;
        }

        protected virtual Vendedor LoadFromControls()
        {
            Vendedor Vendedor = new Vendedor();

            if (Id != null)
            {
                Vendedor.Id = Convert.ToInt64(txtId.Text);
                Vendedor.codigo = Convert.ToInt64(txtCodigo.Text);
                Vendedor.codInt = txtCodInt.Text;
            }
            
            Vendedor.nome = txtNome.Text;
            if (Id == null)
            {
                VendedorBLL = new VendedorBLL();
                List<Vendedor> vendedorList = VendedorBLL.getVendedor(p => p.nome.ToLower() == Vendedor.nome.ToLower());
                if (vendedorList.Count > 0)
                {
                    Vendedor.Id = vendedorList.FirstOrDefault().Id;
                    Vendedor.codigo = vendedorList.FirstOrDefault().codigo;
                    Vendedor.codInt = vendedorList.FirstOrDefault().codInt;
                }
                else
                {
                    Vendedor.codInt = Sequence.GetNextVal("sq_vendedor_sequence").ToString();
                }
            }
            
            
            Vendedor.inativo = (chkInativo.Checked == true) ? "S" : "N";
            
            return Vendedor;
        }

        protected override void SetupControls()
        {                        
        }
                    
        protected override void Limpar(Control control)
        {
            base.Limpar(control);

            txtNome.Focus();
        }                
    }
}
