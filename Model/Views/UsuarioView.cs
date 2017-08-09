using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class UsuarioView
    {
        public UsuarioView()
        { }

        public long? Id { get; set; }
        public string email { get; set; }        
        public string nome { get; set; }        
        public string perfil { get; set; }        
        public bool inativo { get; set; } 
    }
}
