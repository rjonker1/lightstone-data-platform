using System.Collections.Generic;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    
    public interface IPackageBuilderContext
    {
        PackageBuilder.Owner GetOwnerByOwnerValue(string OwnerValue);
        bool TryGetOwnerByOwnerValue(string OwnerValue, out PackageBuilder.Owner Owner);
        PackageBuilder.State GetStateByStateValue(string StateValue);
        bool TryGetStateByStateValue(string StateValue, out PackageBuilder.State State);
        PackageBuilder.Industry GetIndustryByIndustryValue(string IndustryValue);
        bool TryGetIndustryByIndustryValue(string IndustryValue, out PackageBuilder.Industry Industry);
        PackageBuilder.Owner CreateOwner(string OwnerValue);
        IEnumerable<PackageBuilder.Owner> OwnerCollection
        {
            get;
        }
        PackageBuilder.State CreateState(string StateValue);
        IEnumerable<PackageBuilder.State> StateCollection
        {
            get;
        }
        PackageBuilder.Industry CreateIndustry(string IndustryValue);
        IEnumerable<PackageBuilder.Industry> IndustryCollection
        {
            get;
        }
        PackageBuilder.Package CreatePackage();
        IEnumerable<PackageBuilder.Package> PackageCollection
        {
            get;
        }
        PackageBuilder.DataSource CreateDataSource();
        IEnumerable<PackageBuilder.DataSource> DataSourceCollection
        {
            get;
        }
        PackageBuilder.DateField CreateDateField();
        IEnumerable<PackageBuilder.DateField> DateFieldCollection
        {
            get;
        }
        PackageBuilder.FileAttachment CreateFileAttachment();
        IEnumerable<PackageBuilder.FileAttachment> FileAttachmentCollection
        {
            get;
        }
    }
}