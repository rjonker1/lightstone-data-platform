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
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Anpr
{
    public class AnprDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;
        public AnprDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Anpr, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.Anpr);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.Anpr, _dataProvider);

                _logCommand.LogBegin(new {_dataProvider});

                //TODO: System.Data issue on the build server causes an error
                //var consumer = new ConsumeSource(new HandleAnprSourceCall(),
                //    new CallAnprExternalSource(_request,
                //        new RepositoryFactory(ConnectionFactory.ForLsCorporateAutoDatabase(),
                //            CacheConnectionFactory.LocalClient(), ConfigurationManager.ConnectionStrings["lace/source/database/anpr/certificates/configuration"].ConnectionString)));

                //consumer.ConsumeExternalSource(response, laceEvent);

                _logCommand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromAnpr>().Any() || response.OfType<IProvideDataFromAnpr>().First() == null)
                    CallFallbackSource(response, _command);
            }
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var anprResponse = new AnprResponse();
            anprResponse.HasNotBeenHandled();
            response.Add(anprResponse);
        }
    }
}
