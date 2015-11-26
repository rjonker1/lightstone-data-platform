using DataProvider.Infrastructure.Dto.DataProvider;

namespace DataProvider.Infrastructure.Base.Handlers
{
    public interface IHandleDataProviderIndicators
    {
        DataProviderIndicatorsDto Indicators { get; }
        void Handle();
    }
}
