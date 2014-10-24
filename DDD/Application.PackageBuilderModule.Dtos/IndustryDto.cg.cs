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
    public partial class Industry : Entity
    {
        public Industry()
        {
    		DataFields = new List<DataField>();
    		Packages = new List<Package>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "IndustryId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public System.Guid Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private System.Guid _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "IndustryValue")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(16, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Value { get { return _value; } set { if (!Equals(value, _value)) { _value = value; } } }
    	private string _value;
    
    
    	[DataMember]
        public virtual List<DataField> DataFields { get { return _dataFields; } set { if (!Equals(value, _dataFields)) { _dataFields = value; } } }
    	private List<DataField> _dataFields;
    
    	[DataMember]
        public virtual List<Package> Packages { get { return _packages; } set { if (!Equals(value, _packages)) { _packages = value; } } }
    	private List<Package> _packages;
    
    }
}
