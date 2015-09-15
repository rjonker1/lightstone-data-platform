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
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director
{
    public sealed class LightstoneDirectorDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public LightstoneDirectorDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.LSBusinessDirector_E_WS, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.LSBusinessDirector_E_WS);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.LSBusinessDirector_E_WS, _dataProvider);

                _logCommand.LogBegin(new {_dataProvider});

                var consumer = new ConsumeSource(new HandleLightstoneDirectorCall(),
                    new CallLightstoneBusinessDirectorDataProvider(_dataProvider, _logCommand));

                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromLightstoneBusinessDirector>().Any() || response.OfType<IProvideDataFromLightstoneBusinessDirector>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var businessResponse = LightstoneBusinessDirectorResponse.Empty();
            businessResponse.HasNotBeenHandled();
            response.Add(businessResponse);
        }
    }
}