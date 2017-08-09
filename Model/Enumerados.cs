using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StringValue : System.Attribute
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }

    public class itemEnumList
    {
        public itemEnumList()
        { }
        public int chave { get; set; }
        public string descricao { get; set; }
    }
    public static class Enumerados
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            //Check first in our cached results...

            //Look for our 'StringValueAttribute' 

            //in the field's custom attributes

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
               fi.GetCustomAttributes(typeof(StringValue),
                                       false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;

            //codigo para retornar a descricao a partir do indice do enumerado
            //TP e uma variavel do tipo do enumerado que esta sendo utilizado.
            //1 seria o valor retornado da base equivalente ao indice do enumerado
            //Enumerados.GetStringValue((Enum)Enum.ToObject(tp.GetType(),1))
        }

        public static IList<itemEnumList> getListEnum(Enum value)
        {
            IList<itemEnumList> lstRetorno = new List<itemEnumList>();

            Array EnumValues = Enum.GetValues(value.GetType());

            foreach (var item in EnumValues)
            {
                lstRetorno.Add(new itemEnumList { chave = (int)item, descricao = GetStringValue((Enum)item) });
            }

            return lstRetorno;
        }
    }

    public enum TipoPagamento
    {
        [StringValue("Dinheiro")]
        dinheiro = 1,
        [StringValue("Cartão")]
        cartao = 2,
        [StringValue("Cheque")]
        cheque = 3,
        [StringValue("Boleto Bancário")]
        boleto = 4
    }

    public enum StatusPedido
    {
        [StringValue("Gravado")]
        GRAVADO = 0,
        [StringValue("Impresso")]
        IMPRESSO = 1,
        [StringValue("Aguardando Produção")]
        AGPRODUCAO = 2,
        [StringValue("Em Produção")]
        PRODUCAO = 3,
        [StringValue("A Entregar")]
        AENTREGAR = 4,
        [StringValue("Saiu p/ Entrega")]
        SAIUPENTREGA = 5,
        [StringValue("Entregue")]
        ENTREGUE = 6,
        [StringValue("Agrupado")]
        AGRUPADO = 7,
        [StringValue("Faturado")]
        FATURADO = 8
    }

    public enum TipoArmacao
    {
        [StringValue("SEM ARMAÇÃO")]
        SEM_ARMACAO = 1,
        [StringValue("METAL")]
        METAL = 2,
        [StringValue("ZILO")]
        ZILO = 3,
        [StringValue("FIO DE NYLON")]
        FIO_DE_NYLON = 4,
        [StringValue("PARAFUSADA")]
        PARAFUSADA = 5,
        [StringValue("SEGURANÇA")]
        SEGURANCA = 6,
        [StringValue("FIO DE AÇO")]
        FIO_DE_ACO = 7,
        [StringValue("PARAFUSO COM BUCHA")]
        PARAFUSO_COM_BUCHA = 8
    }

    public enum ShapeArmacao
    {
        [StringValue("SHAPE_1")]
        SHAPE_1 = 1,
        [StringValue("SHAPE_2")]
        SHAPE_2 = 2,
        [StringValue("SHAPE_3")]
        SHAPE_3 = 3,
        [StringValue("SHAPE_4")]
        SHAPE_4 = 4,
        [StringValue("SHAPE_5")]
        SHAPE_5 = 5,
        [StringValue("SHAPE_6")]
        SHAPE_6 = 6,
        [StringValue("SHAPE_7")]
        SHAPE_7 = 7,
        [StringValue("SHAPE_8")]
        SHAPE_8 = 8,
        [StringValue("SHAPE_9")]
        SHAPE_9 = 9,
        [StringValue("SHAPE_10")]
        SHAPE_10 = 10,
        [StringValue("SHAPE_11")]
        SHAPE_11 = 11,
        [StringValue("SHAPE_12")]
        SHAPE_12 = 12
    }

    public enum TipoLente
    {
        [StringValue("VISÃO SIMPLES")]
        VISAO_SIMPLES,
        [StringValue("VISÃO SIMPLES BASE INT")]
        VISAO_SIMPLES_BASE_INT,
        [StringValue("KATRAL VISÃO SIMPLES")]
        KATRAL_VISAO_SIMPLES,
        [StringValue("HIDROP VISÃO SIMPLES")]
        HIDROP_VISAO_SIMPLES,
        [StringValue("SOLA ASL")]
        SOLA_ASL,
        [StringValue("BIFOCAL TOPO RETO")]
        BIFOCAL_TOPO_RETO,
        [StringValue("BIFOCAL KRIPTOK")]
        BIFOCAL_KRIPTOK,
        [StringValue("BIFOCAL ULTEX")]
        BIFOCAL_ULTEX,
        [StringValue("BIFOCAL ULTEX CURVA EXT")]
        BIFOCAL_ULTEX_CURVA_EXT,
        [StringValue("BIFOCAL EXECUTIVE")]
        BIFOCAL_EXECUTIVE,
        [StringValue("HIDROP TOPO RETO")]
        HIDROP_TOPO_RETO,
        [StringValue("BIFOCAL KATRAL TOPO RETO")]
        BIFOCAL_KATRAL_TOPO_RETO,
        [StringValue("BIFOCAL KATRAL KRIPTOK")]
        BIFOCAL_KATRAL_KRIPTOK,
        [StringValue("SOLA ASL TOPO RETO")]
        SOLA_ASL_TOPO_RETO,
        [StringValue("PROGRESSIVOS")]
        PROGRESSIVOS,
    }

    public enum EstadoEntidade
    {
        //
        // Summary:
        //     The entity is not being tracked by the context. An entity is in this state immediately
        //     after it has been created with the new operator or with one of the System.Data.Entity.DbSet
        //     Create methods.
        Detached = 1,
        //
        // Summary:
        //     The entity is being tracked by the context and exists in the database, and its
        //     property values have not changed from the values in the database.
        Unchanged = 2,
        //
        // Summary:
        //     The entity is being tracked by the context but does not yet exist in the database.
        Added = 4,
        //
        // Summary:
        //     The entity is being tracked by the context and exists in the database, but has
        //     been marked for deletion from the database the next time SaveChanges is called.
        Deleted = 8,
        //
        // Summary:
        //     The entity is being tracked by the context and exists in the database, and some
        //     or all of its property values have been modified.
        Modified = 16
    }

    public enum Operacao
    {
        [StringValue("Cancelar")]
        Cancelar = 0,
        [StringValue("Consultar")]
        Consultar = 1,
        [StringValue("Editar")]
        Editar = 2,
        [StringValue("Excluir")]
        Excluir = 3,
        [StringValue("Salvar")]
        Salvar = 4,
        [StringValue("Imprimir")]
        Imprimir = 5
    }

    public enum Regime_Tributario
    {
        [StringValue("Simples Nacional")]
        Simples_Nacional = 1,
        [StringValue("Simples Nacional - excesso de sublimite de receita")]
        Simples_Nacional_ESR = 2,
        [StringValue("Regime Normal - Lucro Presumido")]
        Lucro_Presumido = 3,
        [StringValue("Regime Normal - Lucro Real")]
        Lucro_Real = 4,
        [StringValue("Produtor Rural")]
        Produtor_Rural = 5        
    }
}
