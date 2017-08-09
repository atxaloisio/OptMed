using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cliente_ParcelaView
    {
        public Cliente_ParcelaView()
        {

        }

        public long? id { get; set; }
                
        public string cliente { get; set; }

        public string codicao_pagamento { get; set; }
        
    }
}
