using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Application.PackageBuilderModule.Dtos
{
    [DataContract(IsReference = true)]
    [KnownType(typeof (Industry))]
    [KnownType(typeof (State))]
    [KnownType(typeof (PackageDataField))]
    public class Package : Entity
    {
        private decimal? _costOfSale;
        private DateTime? _created;
        private string _description;
        private DateTime? _edited;
        private Guid _id;
        private Industry _industry;
        private Guid? _industryId;
        private string _name;
        private string _owner;
        private List<PackageDataField> _packageDataFields;
        private bool? _published;
        private decimal? _recomendedRetailPrice;
        private DateTime? _revisionDate;
        private State _state;
        private Guid _stateId;
        private string _version;

        public Package()
        {
            PackageDataFields = new List<PackageDataField>();
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageDescription")]
        [Required(ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldRequired")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageName")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageOwner")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageStateId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageVersion")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageCostOfSale")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageCreated")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageEdited")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageIndustryId")]
        [DataMember]
        public Guid? IndustryId
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackagePublished")]
        [DataMember]
        public bool? Published
        {
            get { return _published; }
            set
            {
                if (!Equals(value, _published))
                {
                    _published = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageRecomendedRetailPrice")]
        [DataMember]
        public decimal? RecomendedRetailPrice
        {
            get { return _recomendedRetailPrice; }
            set
            {
                if (!Equals(value, _recomendedRetailPrice))
                {
                    _recomendedRetailPrice = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageRevisionDate")]
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