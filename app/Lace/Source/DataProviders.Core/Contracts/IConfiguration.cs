namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IConfiguration
    {
        string GetSetting(string key);
    }
}
