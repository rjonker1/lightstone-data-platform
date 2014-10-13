using System.Collections.Generic;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    
    public interface IPackageBuilderContext
    {
        Abstract.PackageBuilder.Owner GetOwnerByOwnerValue(string OwnerValue);
        bool TryGetOwnerByOwnerValue(string OwnerValue, out Abstract.PackageBuilder.Owner Owner);
        Abstract.State GetStateByStateValue(string StateValue);
        bool TryGetStateByStateValue(string StateValue, out Abstract.State State);
        Abstract.Industry GetIndustryByIndustryValue(string IndustryValue);
        bool TryGetIndustryByIndustryValue(string IndustryValue, out Abstract.Industry Industry);
        Abstract.PackageBuilder.Owner CreateOwner(string OwnerValue);
        IEnumerable<Abstract.PackageBuilder.Owner> OwnerCollection
        {
            get;
        }
        Abstract.State CreateState(string StateValue);
        IEnumerable<Abstract.State> StateCollection
        {
            get;
        }
        Abstract.Industry CreateIndustry(string IndustryValue);
        IEnumerable<Abstract.Industry> IndustryCollection
        {
            get;
        }
        Abstract.Package CreatePackage();
        IEnumerable<Abstract.Package> PackageCollection
        {
            get;
        }
        Abstract.DataSource CreateDataSource();
        IEnumerable<Abstract.DataSource> DataSourceCollection
        {
            get;
        }
        Abstract.DateField CreateDateField();
        IEnumerable<Abstract.DateField> DateFieldCollection
        {
            get;
        }
        Abstract.FileAttachment CreateFileAttachment();
        IEnumerable<Abstract.FileAttachment> FileAttachmentCollection
        {
            get;
        }
    }
}