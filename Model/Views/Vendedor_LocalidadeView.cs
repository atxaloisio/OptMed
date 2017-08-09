using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vendedor_LocalidadeView
    {
        public Vendedor_LocalidadeView()
        { }
        public long? Id { get; set; }
        public string vendedor { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}
