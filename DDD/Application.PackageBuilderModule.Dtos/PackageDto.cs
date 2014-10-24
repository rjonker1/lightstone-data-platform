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
    [KnownType(typeof(Industry))]
    [KnownType(typeof(State))]
    [KnownType(typeof(PackageDataField))]
    public partial class Package : Entity
    {
        public Package()
        {
    		PackageDataFields = new List<PackageDataField>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private System.Guid _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageDescription")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(512, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Description { get { return _description; } set { if (!Equals(value, _description)) { _description = value; } } }
    	private string _description;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageName")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(128, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Name { get { return _name; } set { if (!Equals(value, _name)) { _name = value; } } }
    	private string _name;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageOwner")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(512, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Owner { get { return _owner; } set { if (!Equals(value, _owner)) { _owner = value; } } }
    	private string _owner;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageStateId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid StateId { get { return _stateId; } set { if (!Equals(value, _stateId)) { _stateId = value; } } }
    	private System.Guid _stateId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageVersion")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(16, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Version { get { return _version; } set { if (!Equals(value, _version)) { _version = value; } } }
    	private string _version;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageCostOfSale")]
    	[DataMember]
        public Nullable<decimal> CostOfSale { get { return _costOfSale; } set { if (!Equals(value, _costOfSale)) { _costOfSale = value; } } }
    	private Nullable<decimal> _costOfSale;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageCreated")]
    	[DataMember]
        public Nullable<System.DateTime> Created { get { return _created; } set { if (!Equals(value, _created)) { _created = value; } } }
    	private Nullable<System.DateTime> _created;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageEdited")]
    	[DataMember]
        public Nullable<System.DateTime> Edited { get { return _edited; } set { if (!Equals(value, _edited)) { _edited = value; } } }
    	private Nullable<System.DateTime> _edited;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageIndustryId")]
    	[DataMember]
        public Nullable<System.Guid> IndustryId { get { return _industryId; } set { if (!Equals(value, _industryId)) { _industryId = value; } } }
    	private Nullable<System.Guid> _industryId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackagePublished")]
    	[DataMember]
        public Nullable<bool> Published { get { return _published; } set { if (!Equals(value, _published)) { _published = value; } } }
    	private Nullable<bool> _published;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageRecomendedRetailPrice")]
    	[DataMember]
        public Nullable<decimal> RecomendedRetailPrice { get { return _recomendedRetailPrice; } set { if (!Equals(value, _recomendedRetailPrice)) { _recomendedRetailPrice = value; } } }
    	private Nullable<decimal> _recomendedRetailPrice;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageRevisionDate")]
    	[DataMember]
        public Nullable<System.DateTime> RevisionDate { get { return _revisionDate; } set { if (!Equals(value, _revisionDate)) { _revisionDate = value; } } }
    	private Nullable<System.DateTime> _revisionDate;
    
    
    	[DataMember]
        public virtual Industry Industry { get { return _industry; } set { if (!Equals(value, _industry)) { _industry = value; } } }
    	private Industry _industry;
    
    	[DataMember]
        public virtual State State { get { return _state; } set { if (!Equals(value, _state)) { _state = value; } } }
    	private State _state;
    
    	[DataMember]
        public virtual List<PackageDataField> PackageDataFields { get { return _packageDataFields; } set { if (!Equals(value, _packageDataFields)) { _packageDataFields = value; } } }
    	private List<PackageDataField> _packageDataFields;
    
    }
}
