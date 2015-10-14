using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Rgt.Infrastructure;
using Lace.Toolbox.Database.Repositories;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Rgt
{
    public sealed class RgtDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private IAmDataProvider _dataProvider;
        private ILogCommandTypes _logCommand;

        public RgtDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.LSAutoSpecs_I_DB, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.LSAutoSpecs_I_DB);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.LSAutoSpecs_I_DB, _dataProvider, _dataProvider.BillablleState.NoRecordState);

                _logCommand.LogBegin(new {_dataProvider });

                var consumer = new ConsumeSource(new HandleRgtDataProviderCall(), new CallRgtDataProvider(_dataProvider, new DataProviderRepository(), _logCommand));

                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromRgt>().Any() || response.OfType<IProvideDataFromRgt>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var rgtResponse = RgtResponse.Empty();
            rgtResponse.HasNotBeenHandled();
            response.Add(rgtResponse);

        }
    }
}
