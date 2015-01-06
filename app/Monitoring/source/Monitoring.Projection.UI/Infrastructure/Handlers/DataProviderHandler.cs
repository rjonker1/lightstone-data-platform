using System.Collections.Generic;
using System.Linq;
using Monitoring.Projection.UI.Core.Contracts.Handlers;
using Monitoring.Projection.UI.Core.Contracts.Repositories;
using Monitoring.Projection.UI.Infrastructure.Commands;
using Monitoring.Projection.UI.Infrastructure.Dto;

namespace Monitoring.Projection.UI.Infrastructure.Handlers
{
    public class DataProviderHandler : IHandleDataProviderCommands
    {
        private readonly IDataProviderRepository _repository;
        public IEnumerable<DataProviderResponseDto> DataProviders { get; private set; }

        public DataProviderHandler(IDataProviderRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetDataProviderViewRequestCommand command)
        {
            DataProviders = _repository.GetAllDataProviderInformation().ToList();
        }

    }

    
}