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
using Lace.Domain.DataProviders.Vin12.Infrastructure;
using Lace.Toolbox.Database.Repositories;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Vin12
{
    public class Vin12DataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public Vin12DataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {

            var spec = new CanHandlePackageSpecification(DataProviderName.LSAutoVIN12_I_DB, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.LSAutoVIN12_I_DB);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.LSAutoVIN12_I_DB, _dataProvider,
                    _dataProvider.BillablleState.NoRecordState);

                _logCommand.LogBegin(new {_dataProvider});

                var consumer = new ConsumeSource(new HandleVin12SourceCall(),
                    new CallVin12DataProvider(_dataProvider, new DataProviderRepository(), _logCommand));

                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromVin12>().Any() || response.OfType<IProvideDataFromVin12>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var vin12Response = Vin12Response.Empty();
            vin12Response.HasNotBeenHandled();
            response.Add(vin12Response);
        }
    }
}
