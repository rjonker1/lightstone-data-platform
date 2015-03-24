namespace PackageBuilder.Domain.Entities.Contracts.DataProviders.Write
{
    public interface ISourceConfiguration
    {
        bool IsApiConfiguration { get; }
        string Url { get; }
        string Username { get; }
        string Password { get; }
        string ConnectionString { get; }
    }
}