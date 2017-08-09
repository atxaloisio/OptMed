using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pedido_OticaAgrupaView
    {
        public Pedido_OticaAgrupaView()
        { }

        public long? id { get; set; }
        public long? id_pedido_omie { get; set; }
        public bool Agrupa { get; set; }              
        public string numero_pedido_omie { get; set; }
        public long? codigo { get; set; }
        public string cliente { get; set; }

        public string codicao_pagamento { get; set; }

        public DateTime? DtEmissao { get; set; }

        public DateTime? DtFechamento { get; set; }

        public string Status { get; set; }
    }
}
