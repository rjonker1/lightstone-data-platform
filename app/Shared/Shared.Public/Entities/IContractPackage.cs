namespace DataPlatform.Shared.Public.Entities
{
    public interface IContractPackage : IPackageAccessControl
    {
        IContract Contract { get; set; }
    }
}