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
using BLL;
using Utils;

namespace optmed
{
    public partial class frmPermissaoAcesso : Form
    {
        PerfilBLL perfilBLL;        
        Funcao_PerfilBLL funcao_perfilBLL;        

        public frmPermissaoAcesso()
        {
            InitializeComponent();
        }

        public virtual void ExibeDialogo()
        {
            ShowDialog();
        }

        private void frmPermissaoAcesso_Load(object sender, EventArgs e)
        {
            try
            {
                perfilBLL = new PerfilBLL();
                List<Perfil> lstPerfil = perfilBLL.getPerfil();
                cbPerfil.DataSource = lstPerfil;
                cbPerfil.ValueMember = "Id";
                cbPerfil.DisplayMember = "descricao";
                cbPerfil.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tvFuncoes_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if ((e.Action != TreeViewAction.Unknown))//(e.Node.Name == "ndCadastros")
                {
                    e.Node.TreeView.BeginUpdate();


                    if (e.Node.Nodes.Count > 0)
                    {
                        foreach (TreeNode node in e.Node.Nodes)
                        {
                            SelecionarNodeFilhos(node, e.Node.Checked);
                        }
                    }
                }
            }
            finally
            {
                e.Node.TreeView.EndUpdate();
            }
        }

        private void SelecionarNodeFilhos(TreeNode nd, Boolean marcado)
        {
            if (nd != null)
            {
                nd.Checked = marcado;
                if (nd.Nodes.Count > 0)
                {

                    foreach (TreeNode node in nd.Nodes)
                    {
                        SelecionarNodeFilhos(node, marcado);
                    }
                }
            }

        }

        private void cbPerfil_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            try
            {
                LoadCheckNodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para carga do checks dos nós da treeview
        /// </summary>
        private void LoadCheckNodes()
        {
            perfilBLL = new PerfilBLL();
            Perfil perfil = perfilBLL.Localizar(Convert.ToInt64(cbPerfil.SelectedValue));

            foreach (Funcao_Perfil item in perfil.funcao_perfil)
            {
                TreeNode[] nodes = tvFuncoes.Nodes.Find(item.codigo_funcao.ToString(), true);
                if (nodes.Count() > 0)
                {
                    if (nodes[0].Nodes.Count > 0)
                    {
                        foreach (TreeNode node in nodes[0].Nodes)
                        {
                            switch (Convert.ToInt32(node.Tag))
                            {
                                case Constantes.OP_CANCELAR:
                                    {
                                        node.Checked = (item.consultar == "S") ? true : false;
                                    }
                                    break;
                                case Constantes.OP_CONSULTAR:
                                    {
                                        node.Checked = (item.consultar == "S") ? true : false;
                                    }
                                    break;
                                case Constantes.OP_EDITAR:
                                    {
                                        node.Checked = (item.editar == "S") ? true : false;
                                    }
                                    break;
                                case Constantes.OP_EXCLUIR:
                                    {
                                        node.Checked = (item.excluir == "S") ? true : false;
                                    }
                                    break;
                                case Constantes.OP_SALVAR:
                                    {
                                        node.Checked = (item.salvar == "S") ? true : false;
                                    }
                                    break;
                                case Constantes.OP_IMPRIMIR:
                                    {
                                        node.Checked = (item.imprimir == "S") ? true : false;
                                    }
                                    break;
                            }
                        }
                    }
                    //MessageBox.Show(nodes[0].Name);
                }
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacbPerfil())
                {
                    salvarnodefilho(tvFuncoes.Nodes);
                    MessageBox.Show(Text + " salvo com sucesso.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparTela();
                }
            }
            catch (Exception ex)
            {
                string mensagem = TrataException.getAllMessage(ex);
                MessageBox.Show(mensagem, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Metodo que percorre o treeview e salva as opções marcadas e não marcadas.
        /// </summary>
        /// <param name="nd">Lista de nós da treeview</param>
        private void salvarnodefilho(TreeNodeCollection nd)
        {
            Funcao_Perfil funcao_perfil = null;

            if (nd != null)
            {
                if (nd.Count > 0)
                {
                    foreach (TreeNode node in nd)
                    {
                        switch (Convert.ToInt32(node.Tag))
                        {
                            case Constantes.OP_CANCELAR:
                                {
                                    if (funcao_perfil == null)
                                    {
                                        funcao_perfil = new Funcao_Perfil(true);
                                    }
                                    funcao_perfil.codigo_funcao = Convert.ToInt32(node.Parent.Tag);
                                    funcao_perfil.cancelar = (node.Checked) ? "S" : "N";
                                }
                                break;
                            case Constantes.OP_CONSULTAR:
                                {
                                    if (funcao_perfil == null)
                                    {
                                        funcao_perfil = new Funcao_Perfil(true);
                                    }
                                    funcao_perfil.codigo_funcao = Convert.ToInt32(node.Parent.Tag);
                                    funcao_perfil.consultar = (node.Checked) ? "S" : "N";
                                }
                                break;
                            case Constantes.OP_EDITAR:
                                {
                                    if (funcao_perfil == null)
                                    {
                                        funcao_perfil = new Funcao_Perfil(true);
                                    }
                                    funcao_perfil.codigo_funcao = Convert.ToInt32(node.Parent.Tag);
                                    funcao_perfil.editar = (node.Checked) ? "S" : "N";
                                }
                                break;
                            case Constantes.OP_EXCLUIR:
                                {
                                    if (funcao_perfil == null)
                                    {
                                        funcao_perfil = new Funcao_Perfil(true);
                                    }
                                    funcao_perfil.codigo_funcao = Convert.ToInt32(node.Parent.Tag);
                                    funcao_perfil.excluir = (node.Checked) ? "S" : "N";
                                }

                                break;
                            case Constantes.OP_SALVAR:
                                {
                                    if (funcao_perfil == null)
                                    {
                                        funcao_perfil = new Funcao_Perfil(true);
                                    }
                                    funcao_perfil.codigo_funcao = Convert.ToInt32(node.Parent.Tag);
                                    funcao_perfil.salvar = (node.Checked) ? "S" : "N";
                                }

                                break;
                            case Constantes.OP_IMPRIMIR:
                                {
                                    if (funcao_perfil == null)
                                    {
                                        funcao_perfil = new Funcao_Perfil(true);
                                    }
                                    funcao_perfil.codigo_funcao = Convert.ToInt32(node.Parent.Tag);
                                    funcao_perfil.imprimir = (node.Checked) ? "S" : "N";
                                }

                                break;
                        }


                        if (Convert.ToInt32(node.Tag) == Constantes.OP_IMPRIMIR)
                        {
                            if (funcao_perfil != null)
                            {
                                funcao_perfilBLL = new Funcao_PerfilBLL();
                                funcao_perfil.Id_perfil = Convert.ToInt64(cbPerfil.SelectedValue);

                                //Exclui os itens da base antes
                                funcao_perfilBLL.ExcluirFuncao_Perfil(funcao_perfil);

                                funcao_perfil.usuario_inclusao = Program.usuario_logado.nome;
                                funcao_perfilBLL.AdicionarFuncao_Perfil(funcao_perfil);

                                //MessageBox.Show(funcao_perfil.codigo_funcao.ToString() + "consultar :" + funcao_perfil.consultar + funcao_perfil.editar + funcao_perfil.salvar);
                                funcao_perfil = null;
                            }
                        }

                        if (funcao_perfil == null)
                        {
                            salvarnodefilho(node.Nodes);
                        }
                    }
                }
            }
        }

        private void tvFuncoes_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = !validacbPerfil();            
        }

        private Boolean validacbPerfil()
        {
            if (cbPerfil.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um perfil para definição de acesso", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbPerfil.DroppedDown = true;
                cbPerfil.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void exibirTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvFuncoes.ExpandAll();
        }

        private void fecharTotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvFuncoes.CollapseAll();
        }

        private void limparTela()
        {            
            limparNodesFilhos(tvFuncoes.Nodes);
            tvFuncoes.CollapseAll();
            cbPerfil.SelectedIndex = -1;
        }

        private void limparNodesFilhos(TreeNodeCollection nodes)
        {
            foreach (TreeNode item in nodes)
            {
                item.Checked = false;
                if (item.Nodes.Count > 0)
                {
                    limparNodesFilhos(item.Nodes);
                }
            }
        }
    }
}
