using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Models
{
    public class IndustryFindModel : Entity
    {
        private IEnumerable<DataField> _dataFields;
        private Guid? _id;
        private IEnumerable<Package> _packages;

        private string _value;

        [Display(ResourceType = typeof (ApplicationResources), Name = "IndustryId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "IndustryValue")]
        [StringLength(16, ErrorMessageResourceType = typeof (ApplicationResources),
            ErrorMessageResourceName = "validation_FieldMaxLenght")]
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


        public virtual IEnumerable<DataField> DataFields
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

        public virtual IEnumerable<Package> Packages
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