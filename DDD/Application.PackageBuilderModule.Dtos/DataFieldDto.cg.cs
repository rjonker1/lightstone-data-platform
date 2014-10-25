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
    [KnownType(typeof (Industry))]
    [KnownType(typeof (PackageDataField))]
    public class DataField : Entity
    {
        private decimal _costOfSale;
        private DataProvider _dataProvider;
        private Guid _dataProviderId;
        private Guid _id;
        private Industry _industry;
        private Guid _industryId;
        private string _label;
        private string _name;
        private List<PackageDataField> _packageDataFields;
        private bool _selected;
        private string _typeDefinition;

        public DataField()
        {
            PackageDataFields = new List<PackageDataField>();
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldCostOfSale")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public decimal CostOfSale
        {
            get { return _costOfSale; }
            set
            {
                if (!Equals(value, _costOfSale))
                {
                    _costOfSale = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldDataProviderId")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public Guid DataProviderId
        {
            get { return _dataProviderId; }
            set
            {
                if (!Equals(value, _dataProviderId))
                {
                    _dataProviderId = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldIndustryId")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public Guid IndustryId
        {
            get { return _industryId; }
            set
            {
                if (!Equals(value, _industryId))
                {
                    _industryId = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldName")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [StringLength(128, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (!Equals(value, _name))
                {
                    _name = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldSelected")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (!Equals(value, _selected))
                {
                    _selected = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldLabel")]
        [StringLength(32, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string Label
        {
            get { return _label; }
            set
            {
                if (!Equals(value, _label))
                {
                    _label = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataFieldTypeDefinition")]
        [StringLength(255, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string TypeDefinition
        {
            get { return _typeDefinition; }
            set
            {
                if (!Equals(value, _typeDefinition))
                {
                    _typeDefinition = value;
                }
            }
        }


        [DataMember]
        public virtual DataProvider DataProvider
        {
            get { return _dataProvider; }
            set
            {
                if (!Equals(value, _dataProvider))
                {
                    _dataProvider = value;
                }
            }
        }

        [DataMember]
        public virtual Industry Industry
        {
            get { return _industry; }
            set
            {
                if (!Equals(value, _industry))
                {
                    _industry = value;
                }
            }
        }

        [DataMember]
        public virtual List<PackageDataField> PackageDataFields
        {
            get { return _packageDataFields; }
            set
            {
                if (!Equals(value, _packageDataFields))
                {
                    _packageDataFields = value;
                }
            }
        }
    }
}