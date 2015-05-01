using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Jis.Infrastructure;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Jis
{
    public class JisDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public JisDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Jis, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.Jis);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.Jis, _dataProvider);

                var consumer = new ConsumeSource(new HandleJisSourceCall(),
                    new CallJisDataProvider(_dataProvider,
                        new RepositoryFactory(ConnectionFactory.ForLsCorporateAutoDatabase(),
                            CacheConnectionFactory.LocalClient(),
                            ConfigurationManager.ConnectionStrings["lace/source/database/jis/certificates/configuration"
                                ].ConnectionString),_logCommand));
                consumer.ConsumeDataProvider(response);

                if (!response.OfType<IProvideDataFromJis>().Any() || response.OfType<IProvideDataFromJis>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var jisResponse = new JisResponse();
            jisResponse.HasNotBeenHandled();
        }
    }
}
