using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace LightstoneApp.Application.PackageBuilderModule.Dtos
{
    using System;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    [KnownType(typeof(DataField))]
    [KnownType(typeof(State))]
    public partial class DataProvider : Entity
    {
        public DataProvider()
        {
    		DataFields = new List<DataField>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private System.Guid _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderName")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(128, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Name { get { return _name; } set { if (!Equals(value, _name)) { _name = value; } } }
    	private string _name;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderOverrideFieldLevelCostOfSale")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public bool OverrideFieldLevelCostOfSale { get { return _overrideFieldLevelCostOfSale; } set { if (!Equals(value, _overrideFieldLevelCostOfSale)) { _overrideFieldLevelCostOfSale = value; } } }
    	private bool _overrideFieldLevelCostOfSale;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderOwner")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(512, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Owner { get { return _owner; } set { if (!Equals(value, _owner)) { _owner = value; } } }
    	private string _owner;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderSourceURL")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(512, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string SourceURL { get { return _sourceURL; } set { if (!Equals(value, _sourceURL)) { _sourceURL = value; } } }
    	private string _sourceURL;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderStateId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid StateId { get { return _stateId; } set { if (!Equals(value, _stateId)) { _stateId = value; } } }
    	private System.Guid _stateId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderVersion")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(16, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Version { get { return _version; } set { if (!Equals(value, _version)) { _version = value; } } }
    	private string _version;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderCostOfSale")]
    	[DataMember]
        public Nullable<decimal> CostOfSale { get { return _costOfSale; } set { if (!Equals(value, _costOfSale)) { _costOfSale = value; } } }
    	private Nullable<decimal> _costOfSale;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderCreated")]
    	[DataMember]
        public Nullable<System.DateTime> Created { get { return _created; } set { if (!Equals(value, _created)) { _created = value; } } }
    	private Nullable<System.DateTime> _created;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderDescription")]
    	[StringLength(512, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Description { get { return _description; } set { if (!Equals(value, _description)) { _description = value; } } }
    	private string _description;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderEdited")]
    	[DataMember]
        public Nullable<System.DateTime> Edited { get { return _edited; } set { if (!Equals(value, _edited)) { _edited = value; } } }
    	private Nullable<System.DateTime> _edited;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataProviderRevisionDate")]
    	[DataMember]
        public Nullable<System.DateTime> RevisionDate { get { return _revisionDate; } set { if (!Equals(value, _revisionDate)) { _revisionDate = value; } } }
    	private Nullable<System.DateTime> _revisionDate;
    
    
    	[DataMember]
        public virtual List<DataField> DataFields { get { return _dataFields; } set { if (!Equals(value, _dataFields)) { _dataFields = value; } } }
    	private List<DataField> _dataFields;
    
    	[DataMember]
        public virtual State State { get { return _state; } set { if (!Equals(value, _state)) { _state = value; } } }
    	private State _state;
    
    }
}
