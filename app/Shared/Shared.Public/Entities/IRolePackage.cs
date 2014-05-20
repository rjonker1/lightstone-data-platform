namespace DataPlatform.Shared.Public.Entities
{
    public interface IRolePackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IRole Role { get; set; }
    }
}