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
using Model;

namespace optmed
{
    public partial class frmRelListPedido_Otica : optmed.frmReportBase
    {
        public long? pedidoDe { get; set; }
        public long? pedidoAte { get; set; }

        public long? clienteDe { get; set; }
        public long? clienteAte { get; set; }

        public DateTime? data_emissaoDe { get; set; }
        public DateTime? data_emissaoAte { get; set; }

        public DateTime? data_fechamentoDe { get; set; }
        public DateTime? data_fechamentoAte { get; set; }

        public long? vendedorDe { get; set; }
        public long? vendedorAte { get; set; }

        public long? transportadoraDe { get; set; }
        public long? transportadoraAte { get; set; }

        public int? caixaDe { get; set; }
        public int? caixaAte { get; set; }

        public string nrpedclienteDe { get; set; }
        public string nrpedclienteAte { get; set; }

        public int? statusDe { get; set; }
        public int? statusAte { get; set; }

        public frmRelListPedido_Otica()
        {
            InitializeComponent();
        }

        protected override void CarregaRelatorio()
        {

            rvRelatorios.LocalReport.DataSources.Clear();
            rvRelatorios.Reset();
            rvRelatorios.LocalReport.ReportEmbeddedResource = "optmed.relatorios.relListPedido_Otica.rdlc";
            dbintegracaoDataSetTableAdapters.qryListPedido_OticaTableAdapter lstPed = new dbintegracaoDataSetTableAdapters.qryListPedido_OticaTableAdapter();
            dbintegracaoDataSetTableAdapters.empresa_logoTableAdapter Empresa_Logo = new dbintegracaoDataSetTableAdapters.empresa_logoTableAdapter();

            DataTable dt = new DataTable();
            DataTable dtl = new DataTable();

            dt = lstPed.GetData(statusDe,
                                statusAte,
                                pedidoDe,
                                pedidoAte,
                                nrpedclienteDe,
                                nrpedclienteAte,
                                clienteDe,
                                clienteAte,
                                data_emissaoDe,
                                data_emissaoAte,
                                data_fechamentoDe,
                                data_fechamentoAte,
                                vendedorDe,
                                vendedorAte,
                                transportadoraDe,
                                transportadoraAte,
                                caixaDe,
                                caixaAte);

            dtl = Empresa_Logo.GetData();

            ReportDataSource ds = new ReportDataSource(dt.TableName, dt);
            ReportDataSource ds2 = new ReportDataSource(dtl.TableName, dtl);

            ds.Name = "DataSet1";
            ds2.Name = "DataSet2";
            rvRelatorios.LocalReport.DataSources.Add(ds);
            rvRelatorios.LocalReport.DataSources.Add(ds2);

            //rvRelatorios.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(onSubreportProcessing);

            ReportParameterCollection parametros = new ReportParameterCollection();

            ReportParameter parametro = new ReportParameter();
            parametro.Name = "EndLaboratorio";
            //parametro.Values.Add("LABORATORIO PRECISION - Rua Antonio Rabelo Guimarães, 256 - Centro - Nova Iguaçu/RJ - Fone: (21) 2667-6932");
            parametro.Values.Add("");

            ReportParameter pardQtdRegs = new ReportParameter();
            pardQtdRegs.Name = "QtdRegistros";
            pardQtdRegs.Values.Add(dt.Rows.Count.ToString());

            parametros.Add(parametro);
            parametros.Add(pardQtdRegs);
            rvRelatorios.LocalReport.SetParameters(parametros);


        }
    }
}
