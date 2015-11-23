using Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleDataProviderIndicators
    {
        DataProviderIndicatorsDto Indicators { get; }
        void Handle();
    }
}
