using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PackageBuilder.Web.Helpers.MetadataProviders
{
    public class ConventionMetadataProvider : AssociatedMetadataProvider
    {
        public ConventionMetadataProvider() : base() { }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
            Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = new ModelMetadata(this, containerType, modelAccessor, modelType, propertyName);
            if (propertyName == null)
                return metadata;
            if (propertyName.EndsWith("Id"))
            {
                metadata.ShowForDisplay = false;
            }

            return metadata;
        }
    }
}