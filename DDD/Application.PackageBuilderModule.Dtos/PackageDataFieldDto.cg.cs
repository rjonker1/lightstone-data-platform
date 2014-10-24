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
    [KnownType(typeof(Package))]
    public partial class PackageDataField : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageDataFieldId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private System.Guid _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageDataFieldDataFieldId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid DataFieldId { get { return _dataFieldId; } set { if (!Equals(value, _dataFieldId)) { _dataFieldId = value; } } }
    	private System.Guid _dataFieldId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageDataFieldPackageId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid PackageId { get { return _packageId; } set { if (!Equals(value, _packageId)) { _packageId = value; } } }
    	private System.Guid _packageId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageDataFieldPriority")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public short Priority { get { return _priority; } set { if (!Equals(value, _priority)) { _priority = value; } } }
    	private short _priority;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageDataFieldSelected")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public bool Selected { get { return _selected; } set { if (!Equals(value, _selected)) { _selected = value; } } }
    	private bool _selected;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PackageDataFieldUnifiedName")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(128, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string UnifiedName { get { return _unifiedName; } set { if (!Equals(value, _unifiedName)) { _unifiedName = value; } } }
    	private string _unifiedName;
    
    
    	[DataMember]
        public virtual DataField DataField { get { return _dataField; } set { if (!Equals(value, _dataField)) { _dataField = value; } } }
    	private DataField _dataField;
    
    	[DataMember]
        public virtual Package Package { get { return _package; } set { if (!Equals(value, _package)) { _package = value; } } }
    	private Package _package;
    
    }
}
