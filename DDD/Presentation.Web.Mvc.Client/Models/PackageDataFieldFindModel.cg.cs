using System;
using System.ComponentModel.DataAnnotations;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Models
{
    public class PackageDataFieldFindModel : Entity
    {
        private DataField _dataField;
        private Guid? _dataFieldId;
        private Guid? _id;
        private Package _package;
        private Guid? _packageId;
        private short? _priority;
        private bool? _selected;
        private string _unifiedName;

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageDataFieldId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageDataFieldDataFieldId")]
        public Guid? DataFieldId
        {
            get { return _dataFieldId; }
            set
            {
                if (!Equals(value, _dataFieldId))
                {
                    _dataFieldId = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageDataFieldPackageId")]
        public Guid? PackageId
        {
            get { return _packageId; }
            set
            {
                if (!Equals(value, _packageId))
                {
                    _packageId = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageDataFieldPriority")]
        public short? Priority
        {
            get { return _priority; }
            set
            {
                if (!Equals(value, _priority))
                {
                    _priority = value;
                }
            }
        }

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageDataFieldSelected")]
        public bool? Selected
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "PackageDataFieldUnifiedName")]
        [StringLength(128, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string UnifiedName
        {
            get { return _unifiedName; }
            set
            {
                if (!Equals(value, _unifiedName))
                {
                    _unifiedName = value;
                }
            }
        }


        public virtual DataField DataField
        {
            get { return _dataField; }
            set
            {
                if (!Equals(value, _dataField))
                {
                    _dataField = value;
                }
            }
        }

        public virtual Package Package
        {
            get { return _package; }
            set
            {
                if (!Equals(value, _package))
                {
                    _package = value;
                }
            }
        }
    }
}