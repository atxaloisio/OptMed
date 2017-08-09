using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pedido_LaboratorioView
    {
        public Pedido_LaboratorioView()
        { }

        public long? id { get; set; }
        public long? codigo { get; set; }

        public string numero_pedido_cliente { get; set; }

        public string numero_caixa { get; set; }

        public string cliente { get; set; }

        public string codicao_pagamento { get; set; }

        public string vendedor { get; set; }

        public string transportadora { get; set; }

        public DateTime? DtEmissao { get; set; }

        public DateTime? DtFechamento { get; set; }

        public string Status { get; set; }

        public bool Cancelado { get; set; }

        public string usuario { get; set; }
    }
}
