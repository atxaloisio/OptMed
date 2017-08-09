using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VendedorView
    {
        public VendedorView()
        { }

        public long? Id { get; set; }
        public string nome { get; set; }
        public bool inativo { get; set; }
    }
}
