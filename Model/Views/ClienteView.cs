using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClienteView
    {
        public ClienteView()
        { }

        public long Id { get; set; }        
        public string codigo_cliente_integracao { get; set; }
        public string cnpj_cpf { get; set; }
        public string razao_social { get; set; }
        public string nome_fantasia { get; set; }        
        public string telefone1_ddd { get; set; }
        public string telefone1_numero { get; set; }
        public string contato { get; set; }
        public string email { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string endereco { get; set; }
        public string endereco_numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string inscricao_estadual { get; set; }
        public string inscricao_municipal { get; set; }
    }
}