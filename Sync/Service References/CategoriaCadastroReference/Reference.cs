﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sync.CategoriaCadastroReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://app.omie.com.br/api/v1/geral/categorias/?WSDL", ConfigurationName="CategoriaCadastroReference.CategoriasCadastroSoap")]
    public interface CategoriasCadastroSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://app.omie.com.br/api/v1/geral/categorias/?WSDLConsultarCategoria", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="categoria_cadastro")]
        Sync.CategoriaCadastroReference.categoria_cadastro ConsultarCategoria(Sync.CategoriaCadastroReference.categoria_consultar categoria_consultar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://app.omie.com.br/api/v1/geral/categorias/?WSDLConsultarCategoria", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="categoria_cadastro")]
        System.Threading.Tasks.Task<Sync.CategoriaCadastroReference.categoria_cadastro> ConsultarCategoriaAsync(Sync.CategoriaCadastroReference.categoria_consultar categoria_consultar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://app.omie.com.br/api/v1/geral/categorias/?WSDLListarCategorias", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="categoria_listfull_response")]
        Sync.CategoriaCadastroReference.categoria_listfull_response ListarCategorias(Sync.CategoriaCadastroReference.categoria_list_request categoria_list_request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://app.omie.com.br/api/v1/geral/categorias/?WSDLListarCategorias", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="categoria_listfull_response")]
        System.Threading.Tasks.Task<Sync.CategoriaCadastroReference.categoria_listfull_response> ListarCategoriasAsync(Sync.CategoriaCadastroReference.categoria_list_request categoria_list_request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://app.omie.com.br/api/v1/geral/categorias/?WSDL")]
    public partial class categoria_consultar : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codigoField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
                this.RaisePropertyChanged("codigo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://app.omie.com.br/api/v1/geral/categorias/?WSDL")]
    public partial class categoria_listfull_response : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string paginaField;
        
        private string total_de_paginasField;
        
        private string registrosField;
        
        private string total_de_registrosField;
        
        private categoria_cadastro[] categoria_cadastroField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(DataType="integer", IsNullable=true)]
        public string pagina {
            get {
                return this.paginaField;
            }
            set {
                this.paginaField = value;
                this.RaisePropertyChanged("pagina");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(DataType="integer", IsNullable=true)]
        public string total_de_paginas {
            get {
                return this.total_de_paginasField;
            }
            set {
                this.total_de_paginasField = value;
                this.RaisePropertyChanged("total_de_paginas");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(DataType="integer", IsNullable=true)]
        public string registros {
            get {
                return this.registrosField;
            }
            set {
                this.registrosField = value;
                this.RaisePropertyChanged("registros");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(DataType="integer", IsNullable=true)]
        public string total_de_registros {
            get {
                return this.total_de_registrosField;
            }
            set {
                this.total_de_registrosField = value;
                this.RaisePropertyChanged("total_de_registros");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public categoria_cadastro[] categoria_cadastro {
            get {
                return this.categoria_cadastroField;
            }
            set {
                this.categoria_cadastroField = value;
                this.RaisePropertyChanged("categoria_cadastro");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://app.omie.com.br/api/v1/geral/categorias/?WSDL")]
    public partial class categoria_cadastro : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codigoField;
        
        private string descricaoField;
        
        private string descricao_padraoField;
        
        private string conta_inativaField;
        
        private string definida_pelo_usuarioField;
        
        private string id_conta_contabilField;
        
        private string tag_conta_contabilField;
        
        private string conta_despesaField;
        
        private string nao_exibirField;
        
        private string naturezaField;
        
        private string conta_receitaField;
        
        private string totalizadoraField;
        
        private string transferenciaField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
                this.RaisePropertyChanged("codigo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string descricao {
            get {
                return this.descricaoField;
            }
            set {
                this.descricaoField = value;
                this.RaisePropertyChanged("descricao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string descricao_padrao {
            get {
                return this.descricao_padraoField;
            }
            set {
                this.descricao_padraoField = value;
                this.RaisePropertyChanged("descricao_padrao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string conta_inativa {
            get {
                return this.conta_inativaField;
            }
            set {
                this.conta_inativaField = value;
                this.RaisePropertyChanged("conta_inativa");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string definida_pelo_usuario {
            get {
                return this.definida_pelo_usuarioField;
            }
            set {
                this.definida_pelo_usuarioField = value;
                this.RaisePropertyChanged("definida_pelo_usuario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(DataType="integer", IsNullable=true)]
        public string id_conta_contabil {
            get {
                return this.id_conta_contabilField;
            }
            set {
                this.id_conta_contabilField = value;
                this.RaisePropertyChanged("id_conta_contabil");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string tag_conta_contabil {
            get {
                return this.tag_conta_contabilField;
            }
            set {
                this.tag_conta_contabilField = value;
                this.RaisePropertyChanged("tag_conta_contabil");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string conta_despesa {
            get {
                return this.conta_despesaField;
            }
            set {
                this.conta_despesaField = value;
                this.RaisePropertyChanged("conta_despesa");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string nao_exibir {
            get {
                return this.nao_exibirField;
            }
            set {
                this.nao_exibirField = value;
                this.RaisePropertyChanged("nao_exibir");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string natureza {
            get {
                return this.naturezaField;
            }
            set {
                this.naturezaField = value;
                this.RaisePropertyChanged("natureza");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string conta_receita {
            get {
                return this.conta_receitaField;
            }
            set {
                this.conta_receitaField = value;
                this.RaisePropertyChanged("conta_receita");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string totalizadora {
            get {
                return this.totalizadoraField;
            }
            set {
                this.totalizadoraField = value;
                this.RaisePropertyChanged("totalizadora");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string transferencia {
            get {
                return this.transferenciaField;
            }
            set {
                this.transferenciaField = value;
                this.RaisePropertyChanged("transferencia");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://app.omie.com.br/api/v1/geral/categorias/?WSDL")]
    public partial class categoria_list_request : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string paginaField;
        
        private string registros_por_paginaField;
        
        private string apenas_importado_apiField;
        
        private string ordenar_porField;
        
        private string ordem_descrescenteField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(DataType="integer", IsNullable=true)]
        public string pagina {
            get {
                return this.paginaField;
            }
            set {
                this.paginaField = value;
                this.RaisePropertyChanged("pagina");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(DataType="integer", IsNullable=true)]
        public string registros_por_pagina {
            get {
                return this.registros_por_paginaField;
            }
            set {
                this.registros_por_paginaField = value;
                this.RaisePropertyChanged("registros_por_pagina");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string apenas_importado_api {
            get {
                return this.apenas_importado_apiField;
            }
            set {
                this.apenas_importado_apiField = value;
                this.RaisePropertyChanged("apenas_importado_api");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ordenar_por {
            get {
                return this.ordenar_porField;
            }
            set {
                this.ordenar_porField = value;
                this.RaisePropertyChanged("ordenar_por");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ordem_descrescente {
            get {
                return this.ordem_descrescenteField;
            }
            set {
                this.ordem_descrescenteField = value;
                this.RaisePropertyChanged("ordem_descrescente");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CategoriasCadastroSoapChannel : Sync.CategoriaCadastroReference.CategoriasCadastroSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CategoriasCadastroSoapClient : System.ServiceModel.ClientBase<Sync.CategoriaCadastroReference.CategoriasCadastroSoap>, Sync.CategoriaCadastroReference.CategoriasCadastroSoap {
        
        public CategoriasCadastroSoapClient() {
        }
        
        public CategoriasCadastroSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CategoriasCadastroSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoriasCadastroSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoriasCadastroSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sync.CategoriaCadastroReference.categoria_cadastro ConsultarCategoria(Sync.CategoriaCadastroReference.categoria_consultar categoria_consultar) {
            return base.Channel.ConsultarCategoria(categoria_consultar);
        }
        
        public System.Threading.Tasks.Task<Sync.CategoriaCadastroReference.categoria_cadastro> ConsultarCategoriaAsync(Sync.CategoriaCadastroReference.categoria_consultar categoria_consultar) {
            return base.Channel.ConsultarCategoriaAsync(categoria_consultar);
        }
        
        public Sync.CategoriaCadastroReference.categoria_listfull_response ListarCategorias(Sync.CategoriaCadastroReference.categoria_list_request categoria_list_request) {
            return base.Channel.ListarCategorias(categoria_list_request);
        }
        
        public System.Threading.Tasks.Task<Sync.CategoriaCadastroReference.categoria_listfull_response> ListarCategoriasAsync(Sync.CategoriaCadastroReference.categoria_list_request categoria_list_request) {
            return base.Channel.ListarCategoriasAsync(categoria_list_request);
        }
    }
}
