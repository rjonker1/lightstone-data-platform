using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Shared.DataProvider.Repositories;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Lightstone
{
    public class LightstoneAutoDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public LightstoneAutoDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.LightstoneAuto, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {

                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.LightstoneAuto);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.LightstoneAuto, _dataProvider);

                _logCommand.LogBegin(new {_dataProvider});

                var consumer = new ConsumeSource(new HandleLightstoneAutoSourceCall(),
                    new CallLightstoneAutoDataProvider(_dataProvider,
                        new DataProviderRepository(ConnectionFactory.ForAutoCarStatsDatabase()),
                        new DataProviderRepository(ConnectionFactory.ForAutoCarStatsDatabase()), _logCommand));

                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromLightstoneAuto>().Any() ||
                    response.OfType<IProvideDataFromLightstoneAuto>().First() == null)
                    CallFallbackSource(response, _command); //TODO: VIN12?
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneResponse = new LightstoneAutoResponse();
            lightstoneResponse.HasNotBeenHandled();
            response.Add(lightstoneResponse);
        }
    }
}