//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido_Otica_InfoAdic
    {
        public long Id { get; set; }
        public long id_pedido_otica { get; set; }
        public string nome_medico { get; set; }
        public string crm_medico { get; set; }
        public string laboratorio { get; set; }
        public string telefone_laboratorio { get; set; }
        public string ordem_servico { get; set; }
        public Nullable<int> od_gp_eixo { get; set; }
        public Nullable<int> oe_gp_eixo { get; set; }
        public string od_gp_alt { get; set; }
        public string oe_gp_alt { get; set; }
    
        public virtual Pedido_Otica pedido_otica { get; set; }
    }
}
