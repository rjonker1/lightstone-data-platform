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
    [KnownType(typeof (State))]
    public class DataProvider : Entity
    {
        private decimal? _costOfSale;
        private DateTime? _created;
        private List<DataField> _dataFields;
        private string _description;
        private DateTime? _edited;
        private Guid _id;
        private string _name;
        private bool _overrideFieldLevelCostOfSale;
        private string _owner;
        private DateTime? _revisionDate;
        private string _sourceURL;
        private State _state;
        private Guid _stateId;
        private string _version;

        public DataProvider()
        {
            DataFields = new List<DataField>();
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderName")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderOverrideFieldLevelCostOfSale")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public bool OverrideFieldLevelCostOfSale
        {
            get { return _overrideFieldLevelCostOfSale; }
            set
            {
                if (!Equals(value, _overrideFieldLevelCostOfSale))
                {
                    _overrideFieldLevelCostOfSale = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderOwner")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [StringLength(512, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string Owner
        {
            get { return _owner; }
            set
            {
                if (!Equals(value, _owner))
                {
                    _owner = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderSourceURL")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [StringLength(512, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string SourceURL
        {
            get { return _sourceURL; }
            set
            {
                if (!Equals(value, _sourceURL))
                {
                    _sourceURL = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderStateId")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public Guid StateId
        {
            get { return _stateId; }
            set
            {
                if (!Equals(value, _stateId))
                {
                    _stateId = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderVersion")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
        [StringLength(16, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string Version
        {
            get { return _version; }
            set
            {
                if (!Equals(value, _version))
                {
                    _version = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderCostOfSale")]
        [DataMember]
        public decimal? CostOfSale
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderCreated")]
        [DataMember]
        public DateTime? Created
        {
            get { return _created; }
            set
            {
                if (!Equals(value, _created))
                {
                    _created = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderDescription")]
        [StringLength(512, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (!Equals(value, _description))
                {
                    _description = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderEdited")]
        [DataMember]
        public DateTime? Edited
        {
            get { return _edited; }
            set
            {
                if (!Equals(value, _edited))
                {
                    _edited = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "DataProviderRevisionDate")]
        [DataMember]
        public DateTime? RevisionDate
        {
            get { return _revisionDate; }
            set
            {
                if (!Equals(value, _revisionDate))
                {
                    _revisionDate = value;
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
        public virtual State State
        {
            get { return _state; }
            set
            {
                if (!Equals(value, _state))
                {
                    _state = value;
                }
            }
        }
    }
}