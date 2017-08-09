using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tipo_ArmacaoView
    {
        public Tipo_ArmacaoView()
        { }

        public long Id { get; set; }
        public string descricao { get; set; }
        public bool inativo { get; set; }
    }
}
