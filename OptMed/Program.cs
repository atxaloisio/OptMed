using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Model;
using Sync;
using SoftwareLocker;
using System.IO;

namespace optmed
{    
    static class Program
    {        
        public static Usuario usuario_logado  {get;set;}
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmSplash splash = new frmSplash();
            splash.Show();
            splash.Cursor = Cursors.AppStarting;


            Application.DoEvents();
           
            splash.setMensagem("Carregando configurações.");
            splash.setprogresso(100);
            Thread.Sleep(500);
            Application.DoEvents();

            //splash.setMensagem("Sincronizando informações com a nuvem.");
            //Application.DoEvents();

            /*Ao incluir um novo webservice no projeto SYNC copiar o conteundo de <system.serviceModel> </system.serviceModel> 
             * para o app.config da aplicação principal.
             */

#if RELEASE

            ////Clientes
            //ClienteProxy cp = new ClienteProxy();
            //try
            //{                
            //    cp.SyncCadastroCliente();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.InnerException.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            ////Produtos
            //ProdutoProxy pp = new ProdutoProxy();
            //try
            //{
            //    pp.SyncCadastroProduto();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            //FormaPagVendasProxy fpv = new FormaPagVendasProxy();
            //try
            //{
            //    fpv.SyncFormaPagVendas();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            //}

            //CidadesProxy cid = new CidadesProxy();
            //try
            //{
            //    cid.SyncCidades();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            //ProdutosImpostosProxy prod = new ProdutosImpostosProxy();
            //try
            //{
            //    prod.SyncProdutosImpostos();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            //ParcelaProxy parcelas = new ParcelaProxy();
            //try
            //{
            //    splash.setMensagem("Sincronizando cadastro de parcelas");
            //    Application.DoEvents();
            //    parcelas.SyncParcela();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            //ProdutosImpostosProxy prod = new ProdutosImpostosProxy();
            //try
            //{
            //    splash.setMensagem("Sincronizando cadastro de Impostos aprendidos.");
            //    Application.DoEvents();
            //    prod.SyncProdutosImpostos();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            //CategoriaProxy categ = new CategoriaProxy();
            //try
            //{
            //    splash.setMensagem("Sincronizando cadastro de Categorias.");
            //    Application.DoEvents();
            //    categ.SyncCategoria();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            // ContaCorrenteProxy cc = new ContaCorrenteProxy();
            //try
            //{
            //    splash.setMensagem("Sincronizando cadastro de Conta Corrente.");
            //    Application.DoEvents();
            //    cc.SyncContaCorrente();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            //ContaCorrenteProxy cc = new ContaCorrenteProxy();
            //try
            //{
            //    splash.setMensagem("Sincronizando cadastro de Conta Corrente.");
            //    Application.DoEvents();
            //    cc.SyncContaCorrente();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}

            //ContaCorrenteProxy cc = new ContaCorrenteProxy();
            //try
            //{
            //    splash.setMensagem("Sincronizando cadastro de Conta Corrente.");
            //    Application.DoEvents();
            //    cc.SyncContaCorrente();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}
#endif







            //splash.setprogresso(60);
            //Thread.Sleep(100);
            //Application.DoEvents();

            //splash.setMensagem("Sincronizado.");            
            //splash.setprogresso(100);
            //Thread.Sleep(100);
            //Application.DoEvents();

            //Thread.Sleep(50);
            //Application.DoEvents();

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            

            string path = appDataPath + @"\Optima\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);



            TrialMaker t = new TrialMaker("Optima", Application.StartupPath + "\\RegFile.reg",
                path + "\\Optima.dbf",
                "Fixo: +55 (21)3226-2645\nCelular: +55 (21)99205-6591",
                15, 10, "289", false);

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 20, 36, 37, 21, 101, 57};
            t.TripleDESKey = MyOwnKey;
            splash.Cursor = Cursors.Default;
            splash.Dispose();

            TrialMaker.RunTypes RT = t.ShowDialog();
            bool is_trial;
            int NrDiasTrial = t.NrDiasFimAvalicao();
                        

            if (RT != TrialMaker.RunTypes.Expired)
            {
                string MsgLogin = string.Empty; 
                if (RT == TrialMaker.RunTypes.Full)
                    is_trial = false;
                else
                    is_trial = true;

                if (is_trial)
                {
                    MsgLogin = string.Format("Versão de avaliação. Tempo restante: {0} dia(s).", NrDiasTrial);
                }

                frmLogin login = new frmLogin(MsgLogin);


                if (login.ShowDialog() == DialogResult.OK)
                {                    
                    Application.Run(new frmPrincipal());
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }                                   
        }
    }
}
