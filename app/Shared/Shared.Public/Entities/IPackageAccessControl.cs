namespace DataPlatform.Shared.Public.Entities
{
    public interface IPackageAccessControl : IEntity, IExpirable
    {
        IPackage Package { get; set; }
        IAction Action { get; set; }
    }
}