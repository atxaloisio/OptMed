using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pedido_OticaView
    {
        public Pedido_OticaView()
        { }

        public long? id { get; set; }
        public long? codigo { get; set; }

        public string os { get; set; }

        public string cliente { get; set; }

        public string codicao_pagamento { get; set; }

        public string vendedor { get; set; }

        public string laboratorio { get; set; }

        public DateTime? DtEmissao { get; set; }

        public decimal? Total { get; set; }

        public string Status { get; set; }

        public bool Cancelado { get; set; }

        public string usuario { get; set; }

        
    }
}
