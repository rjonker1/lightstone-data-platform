﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lace.Domain.DataProviders.Anpr.AnprServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AnprSubComplexType", Namespace="http://localhost")]
    [System.SerializableAttribute()]
    public partial class AnprSubComplexType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImagetoAnprField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ImagetoAnpr {
            get {
                return this.ImagetoAnprField;
            }
            set {
                if ((object.ReferenceEquals(this.ImagetoAnprField, value) != true)) {
                    this.ImagetoAnprField = value;
                    this.RaisePropertyChanged("ImagetoAnpr");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AnprResComplexType", Namespace="http://localhost")]
    [System.SerializableAttribute()]
    public partial class AnprResComplexType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PlatePatchField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OverviewField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PlateResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResultField;
        
        private int ConfidenceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string PlatePatch {
            get {
                return this.PlatePatchField;
            }
            set {
                if ((object.ReferenceEquals(this.PlatePatchField, value) != true)) {
                    this.PlatePatchField = value;
                    this.RaisePropertyChanged("PlatePatch");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Overview {
            get {
                return this.OverviewField;
            }
            set {
                if ((object.ReferenceEquals(this.OverviewField, value) != true)) {
                    this.OverviewField = value;
                    this.RaisePropertyChanged("Overview");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string PlateResult {
            get {
                return this.PlateResultField;
            }
            set {
                if ((object.ReferenceEquals(this.PlateResultField, value) != true)) {
                    this.PlateResultField = value;
                    this.RaisePropertyChanged("PlateResult");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Result {
            get {
                return this.ResultField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultField, value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int Confidence {
            get {
                return this.ConfidenceField;
            }
            set {
                if ((this.ConfidenceField.Equals(value) != true)) {
                    this.ConfidenceField = value;
                    this.RaisePropertyChanged("Confidence");
                }
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost", ConfigurationName="AnprServiceReference.AnprServiceSoap")]
    public interface AnprServiceSoap {
        
        // CODEGEN: Generating message contract since element name aps from namespace http://localhost is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/AnprProcessRecognition", ReplyAction="*")]
        Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponse AnprProcessRecognition(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/AnprProcessRecognition", ReplyAction="*")]
        System.Threading.Tasks.Task<Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponse> AnprProcessRecognitionAsync(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AnprProcessRecognitionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AnprProcessRecognition", Namespace="http://localhost", Order=0)]
        public Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequestBody Body;
        
        public AnprProcessRecognitionRequest() {
        }
        
        public AnprProcessRecognitionRequest(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost")]
    public partial class AnprProcessRecognitionRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprSubComplexType aps;
        
        public AnprProcessRecognitionRequestBody() {
        }
        
        public AnprProcessRecognitionRequestBody(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprSubComplexType aps) {
            this.aps = aps;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AnprProcessRecognitionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AnprProcessRecognitionResponse", Namespace="http://localhost", Order=0)]
        public Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponseBody Body;
        
        public AnprProcessRecognitionResponse() {
        }
        
        public AnprProcessRecognitionResponse(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost")]
    public partial class AnprProcessRecognitionResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprResComplexType AnprProcessRecognitionResult;
        
        public AnprProcessRecognitionResponseBody() {
        }
        
        public AnprProcessRecognitionResponseBody(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprResComplexType AnprProcessRecognitionResult) {
            this.AnprProcessRecognitionResult = AnprProcessRecognitionResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AnprServiceSoapChannel : Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AnprServiceSoapClient : System.ServiceModel.ClientBase<Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprServiceSoap>, Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprServiceSoap {
        
        public AnprServiceSoapClient() {
        }
        
        public AnprServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AnprServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AnprServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AnprServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponse Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprServiceSoap.AnprProcessRecognition(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest request) {
            return base.Channel.AnprProcessRecognition(request);
        }
        
        public Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprResComplexType AnprProcessRecognition(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprSubComplexType aps) {
            Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest inValue = new Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest();
            inValue.Body = new Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequestBody();
            inValue.Body.aps = aps;
            Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponse retVal = ((Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprServiceSoap)(this)).AnprProcessRecognition(inValue);
            return retVal.Body.AnprProcessRecognitionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponse> Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprServiceSoap.AnprProcessRecognitionAsync(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest request) {
            return base.Channel.AnprProcessRecognitionAsync(request);
        }
        
        public System.Threading.Tasks.Task<Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionResponse> AnprProcessRecognitionAsync(Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprSubComplexType aps) {
            Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest inValue = new Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequest();
            inValue.Body = new Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprProcessRecognitionRequestBody();
            inValue.Body.aps = aps;
            return ((Lace.Domain.DataProviders.Anpr.AnprServiceReference.AnprServiceSoap)(this)).AnprProcessRecognitionAsync(inValue);
        }
    }
}