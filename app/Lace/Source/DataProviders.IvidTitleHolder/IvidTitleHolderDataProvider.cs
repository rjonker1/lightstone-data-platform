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
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.IvidTitleHolder
{
    public sealed class IvidTitleHolderDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public IvidTitleHolderDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.IVIDTitle_E_WS, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.IVIDTitle_E_WS);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.IVIDTitle_E_WS, _dataProvider,
                    _dataProvider.BillablleState.NoRecordState);

                _logCommand.LogBegin(new {_dataProvider});

                var consumer = new ConsumeSource(new HandleIvidTitleHolderSourceCall(),
                    new CallIvidTitleHolderDataProvider(_dataProvider, _logCommand));
                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new {response});

                if (!response.HasRecords<IProvideDataFromIvidTitleHolder>()) CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ividTitleHolderResponse = IvidTitleHolderResponse.Empty();
            ividTitleHolderResponse.HasNotBeenHandled();
            response.Add(ividTitleHolderResponse);
        }
    }
}
