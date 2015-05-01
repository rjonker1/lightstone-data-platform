using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.Infrastructure;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Audatex
{
    public class AudatexDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogComandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public AudatexDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Audatex, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.Audatex);
                _logCommand = new LogCommandTypes(_command, DataProviderCommandSource.Ivid, _dataProvider);

                _logCommand.LogBegin(new { _request, IvidResponse = response.OfType<IProvideDataFromIvid>().First() });

                var consumer = new ConsumeSource(new HandleAudatexSourceCall(), new CallAudatexDataProvider(_dataProvider,_logCommand));
                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new { response });

                if (!response.OfType<IProvideDataFromAudatex>().Any() || response.OfType<IProvideDataFromAudatex>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var audatexResponse = new AudatexResponse();
            audatexResponse.HasNotBeenHandled();
            response.Add(audatexResponse);
        }
    }
}
