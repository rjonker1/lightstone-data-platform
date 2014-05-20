namespace DataPlatform.Shared.Public.Entities
{
    public interface IUserPackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IUser User { get; set; }
    }
}