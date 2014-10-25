using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Application.PackageBuilderModule.Dtos
{
    [DataContract(IsReference = true)]
    [KnownType(typeof (DataField))]
    [KnownType(typeof (Package))]
    public class Industry : Entity
    {
        private List<DataField> _dataFields;
        private Guid _id;
        private List<Package> _packages;
        private string _value;

        public Industry()
        {
            DataFields = new List<DataField>();
            Packages = new List<Package>();
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "IndustryId")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (!Equals(value, _id))
                {
                    _id = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "IndustryValue")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [StringLength(16, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string Value
        {
            get { return _value; }
            set
            {
                if (!Equals(value, _value))
                {
                    _value = value;
                }
            }
        }


        [DataMember]
        public virtual List<DataField> DataFields
        {
            get { return _dataFields; }
            set
            {
                if (!Equals(value, _dataFields))
                {
                    _dataFields = value;
                }
            }
        }

        [DataMember]
        public virtual List<Package> Packages
        {
            get { return _packages; }
            set
            {
                if (!Equals(value, _packages))
                {
                    _packages = value;
                }
            }
        }
    }
}