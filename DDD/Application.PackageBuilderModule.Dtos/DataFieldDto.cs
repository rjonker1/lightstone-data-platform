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
    [KnownType(typeof(DataProvider))]
    [KnownType(typeof(Industry))]
    [KnownType(typeof(PackageDataField))]
    public partial class DataField : Entity
    {
        public DataField()
        {
    		PackageDataFields = new List<PackageDataField>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private System.Guid _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldCostOfSale")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public decimal CostOfSale { get { return _costOfSale; } set { if (!Equals(value, _costOfSale)) { _costOfSale = value; } } }
    	private decimal _costOfSale;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldDataProviderId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid DataProviderId { get { return _dataProviderId; } set { if (!Equals(value, _dataProviderId)) { _dataProviderId = value; } } }
    	private System.Guid _dataProviderId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldIndustryId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid IndustryId { get { return _industryId; } set { if (!Equals(value, _industryId)) { _industryId = value; } } }
    	private System.Guid _industryId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldName")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(128, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Name { get { return _name; } set { if (!Equals(value, _name)) { _name = value; } } }
    	private string _name;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldSelected")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public bool Selected { get { return _selected; } set { if (!Equals(value, _selected)) { _selected = value; } } }
    	private bool _selected;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldLabel")]
    	[StringLength(32, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Label { get { return _label; } set { if (!Equals(value, _label)) { _label = value; } } }
    	private string _label;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DataFieldTypeDefinition")]
    	[StringLength(255, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string TypeDefinition { get { return _typeDefinition; } set { if (!Equals(value, _typeDefinition)) { _typeDefinition = value; } } }
    	private string _typeDefinition;
    
    
    	[DataMember]
        public virtual DataProvider DataProvider { get { return _dataProvider; } set { if (!Equals(value, _dataProvider)) { _dataProvider = value; } } }
    	private DataProvider _dataProvider;
    
    	[DataMember]
        public virtual Industry Industry { get { return _industry; } set { if (!Equals(value, _industry)) { _industry = value; } } }
    	private Industry _industry;
    
    	[DataMember]
        public virtual List<PackageDataField> PackageDataFields { get { return _packageDataFields; } set { if (!Equals(value, _packageDataFields)) { _packageDataFields = value; } } }
    	private List<PackageDataField> _packageDataFields;
    
    }
}
