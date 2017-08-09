using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace optmed
{
    public partial class frmBase : Form, IDisposable
    {
        public virtual bool atualizagrid { get; set; }
        public virtual long? Id { get; set; }
        public frmBase()
        {
            InitializeComponent();
            atualizagrid = false;
            Id = null;
        }

        public virtual DialogResult ExibeDialogo(IWin32Window obj, long? pId)
        {
            Id = pId;
            return ShowDialog(obj);
        }
        public virtual DialogResult ExibeDialogo(IWin32Window obj)
        {
           return ShowDialog(obj);
        }

        public virtual DialogResult ExibeDialogo(long? pId)
        {
            Id = pId;
           return ShowDialog();
        }

        public virtual DialogResult ExibeDialogo()
        {            
           return ShowDialog();
        }

        protected virtual bool ValidaAcessoFuncao(Operacao operacao, object tag = null )
        {
            bool Retorno = true;
            string mensagem = string.Empty;

            if (this.Tag != null)
            {
                if (this.Tag.ToString() == "")
                {
                    this.Tag = null;
                }
            }
            

            if ((this.Tag != null)||(tag != null))
            {                
                int func = Convert.ToInt32(this.Tag);
                if (tag != null)
                {
                    func = Convert.ToInt32(tag);
                }
                Usuario usuario = Program.usuario_logado;

                List<Funcao_Perfil> fpList = usuario.perfil.funcao_perfil.ToList();
                Funcao_Perfil fp = fpList.Find(p => p.codigo_funcao == func);
                if (fp!= null)
                {
                    switch (operacao)
                    {
                        case Operacao.Cancelar:
                            {
                                if (fp.cancelar == "N")
                                {
                                    mensagem = "Usuário não possui direito de canclamento do recurso selecionado \n por favor entre em contato com o administrador do sistema.";
                                }
                            }
                            break;
                        case Operacao.Consultar:
                            {
                                if (fp.consultar == "N")
                                {
                                    mensagem = "Usuário não possui direito de consulta ao recurso selecionado \n por favor entre em contato com o administrador do sistema.";
                                }
                            }
                            break;
                        case Operacao.Editar:
                            {
                                if (fp.consultar == "N")
                                {
                                    mensagem = "Usuário não possui direito de Edição para o recurso selecionado \n por favor entre em contato com o administrador do sistema.";
                                }
                            }
                            break;
                        case Operacao.Excluir:
                            {
                                if (fp.consultar == "N")
                                {
                                    mensagem = "Usuário não possui direito de Exclusão para o recurso selecionado \n por favor entre em contato com o administrador do sistema.";
                                }

                            }
                            break;
                        case Operacao.Salvar:
                            {
                                if (fp.salvar == "N")
                                {
                                    mensagem = "Usuário não possui direito de gravação para o recurso selecionado \n por favor entre em contato com o administrador do sistema.";
                                }
                            }
                            break;
                        case Operacao.Imprimir:
                            {
                                if (fp.imprimir == "N")
                                {
                                    mensagem = "Usuário não possui direito de impressão para o recurso selecionado \n por favor entre em contato com o administrador do sistema.";
                                }
                            }
                            break;
                    }
                }

                

                if (!string.IsNullOrEmpty(mensagem))
                {
                    MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Retorno = false;
                }


            }
            return Retorno;            
        }
    }
}
