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
using Lace.Domain.DataProviders.RgtVin.Infrastructure;
using Lace.Shared.DataProvider.Repositories;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.RgtVin
{
    public sealed class RgtVinDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public RgtVinDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.RgtVin);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.RgtVin, _dataProvider);

                _logCommand.LogBegin(new {_dataProvider});

                var consumer = new ConsumeSource(new HandleRgtVinDataProviderCall(), new CallRgtVinDataProvider(_dataProvider,new DataProviderRepository(), _logCommand));
                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromRgtVin>().Any() || response.OfType<IProvideDataFromRgtVin>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);

        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var rgtVinResponse = RgtVinResponse.Empty();
            rgtVinResponse.HasNotBeenHandled();
            response.Add(rgtVinResponse);
        }
    }
}
