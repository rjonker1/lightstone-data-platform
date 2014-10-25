using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Application.PackageBuilderModule.Dtos
{
    [DataContract(IsReference = true)]
    [KnownType(typeof (DataProvider))]
    [KnownType(typeof (Package))]
    public class State : Entity
    {
        private List<DataProvider> _dataProviders;
        private Guid _id;
        private List<Package> _packages;
        private string _value;

        public State()
        {
            DataProviders = new List<DataProvider>();
            Packages = new List<Package>();
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "StateId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "StateValue")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [StringLength(24, ErrorMessageResourceType = typeof (ApplicationResources),
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
        public virtual List<DataProvider> DataProviders
        {
            get { return _dataProviders; }
            set
            {
                if (!Equals(value, _dataProviders))
                {
                    _dataProviders = value;
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