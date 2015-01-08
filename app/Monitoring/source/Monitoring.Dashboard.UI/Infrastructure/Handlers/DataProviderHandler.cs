using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Repositories;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class DataProviderHandler : IHandleDataProviderCommands
    {
        private readonly IDataProviderRepository _repository;
        public IEnumerable<MonitoringResponse> DataProviders { get; private set; }

        public DataProviderHandler(IDataProviderRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetDataProviderViewCommand command)
        {
            DataProviders = _repository.GetAllDataProviderInformation().ToList();
        }

    }

    
}