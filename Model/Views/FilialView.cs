using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FilialView
    {
        public FilialView()
        { }
        
        public long Id { get; set; }
        public long Id_empresa { get; set; }
        public Nullable<long> codigo_filial { get; set; }
        public string codigo_filial_integracao { get; set; }
        public string cnpj { get; set; }
        public string razao_social { get; set; }
        public string nome_fantasia { get; set; }
    }
}
