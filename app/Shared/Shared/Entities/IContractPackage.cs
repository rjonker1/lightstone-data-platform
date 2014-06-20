namespace DataPlatform.Shared.Entities
{
    public interface IContractPackage : IPackageAccessControl
    {
        IContract Contract { get; set; }
    }
}