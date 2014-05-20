namespace DataPlatform.Shared.Public.Entities
{
    public interface IPackageAccessControl : IExpirable
    {
        IPackage Package { get; set; }
        IAction Action { get; set; }
    }
}