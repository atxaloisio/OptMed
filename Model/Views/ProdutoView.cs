using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProdutoView
    {
        public ProdutoView()
        { }

        public long Id { get; set; }                       
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string unidade { get; set; }
        public string ncm { get; set; }
        public decimal? valor_unitario { get; set; }
        public string familia { get; set; }
    }
}
