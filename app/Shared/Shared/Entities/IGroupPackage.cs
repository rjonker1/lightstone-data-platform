namespace DataPlatform.Shared.Entities
{
    public interface IGroupPackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IGroup Group { get; set; }
    }
}