using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ParcelaView
    {
        public ParcelaView()
        { }
        public long? Id { get; set; }
        public long? Id_Pedido_Otica { get; set; }
        public int? NrParcela { get; set; }
        public string DtVencimento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Percentual { get; set; }
        public bool Pago { get; set; }
        public DateTime? DtPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public string Usuario { get; set; }
        public bool Editado { get; set; }
        public int? NrDias { get; set; }        
    }
}
