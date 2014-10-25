using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Models
{
    public class StateFindModel : Entity
    {
        private IEnumerable<DataProvider> _dataProviders;
        private Guid? _id;
        private IEnumerable<Package> _packages;

        private string _value;

        [Display(ResourceType = typeof (ApplicationResources), Name = "StateId")]
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

        [Display(ResourceType = typeof (ApplicationResources), Name = "StateValue")]
        [StringLength(24, ErrorMessageResourceType = typeof (ApplicationResources),
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


        public virtual IEnumerable<DataProvider> DataProviders
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