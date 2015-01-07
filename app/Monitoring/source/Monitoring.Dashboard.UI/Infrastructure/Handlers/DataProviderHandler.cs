using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Repositories;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class DataProviderHandler : IHandleDataProviderCommands
    {
        private readonly IDataProviderRepository _repository;
        public IEnumerable<DataProviderResponseDto> DataProviders { get; private set; }

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