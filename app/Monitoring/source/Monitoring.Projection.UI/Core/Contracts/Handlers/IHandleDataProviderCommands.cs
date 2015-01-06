using System.Collections.Generic;
using Monitoring.Projection.UI.Infrastructure.Commands;
using Monitoring.Projection.UI.Infrastructure.Dto;

namespace Monitoring.Projection.UI.Core.Contracts.Handlers
{
    public interface IHandleDataProviderCommands
    {
        IEnumerable<DataProviderResponseDto> DataProviders { get; }
        void Handle(GetDataProviderViewRequestCommand command);
    }
}
