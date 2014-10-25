using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Models
{
    public class PackageFindModel : Entity
    {
        private decimal? _costOfSale;
        private DateTime? _created;
        private string _description;
        private DateTime? _edited;
        private Guid? _id;
        private Industry _industry;
        private Guid? _industryId;
        private string _name;
        private string _owner;
        private IEnumerable<PackageDataField> _packageDataFields;
        private bool? _published;
        private decimal? _recomendedRetailPrice;
        private DateTime? _revisionDate;
        private State _state;
        private Guid? _stateId;
        private string _version;

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageId")]
        public Guid? Id
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
        [StringLength(512, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
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
        [StringLength(128, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
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
        [StringLength(512, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
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
        public Guid? StateId
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
        [StringLength(16, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
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

        public virtual IEnumerable<PackageDataField> PackageDataFields
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