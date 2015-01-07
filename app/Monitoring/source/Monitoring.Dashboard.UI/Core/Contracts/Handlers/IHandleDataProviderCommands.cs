using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleDataProviderCommands
    {
        IEnumerable<DataProviderResponseDto> DataProviders { get; }
        void Handle(GetDataProviderViewCommand command);
    }
}
