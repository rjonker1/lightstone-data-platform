using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.PCubed.Infrastructure;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.PCubed
{
    public class PCubedDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogComandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public PCubedDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.PCubedFica, _request);
            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.PCubedFica);
                _logCommand = new LogCommandTypes(_command, DataProviderCommandSource.PCubedFica, _dataProvider);

                _logCommand.LogBegin(new {_request});

                var consumer = new ConsumeSource(new HandlePCubedSourceCall(), new CallPCubedDataProvider(_dataProvider, _logCommand));
                consumer.ConsumeDataProvider(response);

                _logCommand.LogBegin(new {response});

                if (!response.OfType<IProvideDataFromPCubedFicaVerfication>().Any() ||
                    response.OfType<IProvideDataFromPCubedFicaVerfication>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ficaVerficationResponse = new PCubedFicaVerficationResponse();
            ficaVerficationResponse.HasNotBeenHandled();
            response.Add(ficaVerficationResponse);
        }
    }
}
