using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Utils;

namespace optmed
{
    public partial class frmRelReciboVenda : optmed.frmReportBase
    {
        public frmRelReciboVenda()
        {
            InitializeComponent();
        }

        protected override void CarregaRelatorio()
        {

            rvRelatorios.LocalReport.DataSources.Clear();
            rvRelatorios.Reset();
            rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relReciboVenda.rdlc";
            
            dbintegracaoDataSetTableAdapters.qryReciboVendaTableAdapter Venda = new dbintegracaoDataSetTableAdapters.qryReciboVendaTableAdapter();
            dbintegracaoDataSetTableAdapters.empresa_logoTableAdapter Empresa_Logo = new dbintegracaoDataSetTableAdapters.empresa_logoTableAdapter();
            dbintegracaoDataSetTableAdapters.qryParcelaTableAdapter parcela = new dbintegracaoDataSetTableAdapters.qryParcelaTableAdapter();

            DataTable dt = new DataTable();
            DataTable dtl = new DataTable();
            DataTable dtp = new DataTable();

            //dt = prod.GetData(Convert.ToInt64(Id));
            dt = Venda.GetData(Convert.ToInt64(Id));
            dtl = Empresa_Logo.GetData();
            dtp = parcela.GetData(Convert.ToInt64(Id));

            ReportDataSource ds = new ReportDataSource(dt.TableName, dt);
            ReportDataSource ds2 = new ReportDataSource(dtl.TableName, dtl);
            ReportDataSource ds3 = new ReportDataSource(dtp.TableName, dtp);


            ds.Name = "DataSet1";
            ds2.Name = "DataSet2";
            ds3.Name = "DataSet3";
            rvRelatorios.LocalReport.DataSources.Add(ds);
            rvRelatorios.LocalReport.DataSources.Add(ds2);
            rvRelatorios.LocalReport.DataSources.Add(ds3);

            //rvRelatorios.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(onSubreportProcessing);

            ReportParameterCollection parametros = new ReportParameterCollection();
            ReportParameter parametro = new ReportParameter();
            parametro.Name = "EndLaboratorio";
            parametro.Values.Add("Documento sem valor fiscal");
            parametro.Values.Add("");
            parametros.Add(parametro);
            
            ReportParameter nrRecibo = new ReportParameter();
            nrRecibo.Name = "nrRecibo";
            
            nrRecibo.Values.Add(Sequence.GetNextVal("sq_recibo_venda_sequence").ToString());            
            parametros.Add(nrRecibo);
            rvRelatorios.LocalReport.SetParameters(parametros);
        }

        //protected void onSubreportProcessing(object sender, SubreportProcessingEventArgs e)
        //{
        //    dbintegracaoDataSetTableAdapters.qryItemPedido_OticaTableAdapter itempedido = new dbintegracaoDataSetTableAdapters.qryItemPedido_OticaTableAdapter();
        //    DataTable dt = itempedido.GetData(Convert.ToInt64(Id));
        //    e.DataSources.Add(new ReportDataSource("DataSetItemPedido_Otica", (object)dt));
        //}
    }
}
