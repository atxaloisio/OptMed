using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RotaView
    {
        public RotaView()
        { }
        public long? Id { get; set; }
        public string Transportadora { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}
