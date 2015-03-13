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
using Lace.Domain.DataProviders.Jis.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Jis
{
    public class JisDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public JisDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
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
                var consumer = new ConsumeSource(new HandleJisSourceCall(),
                    new CallJisDataProvider(_request,
                        new RepositoryFactory(ConnectionFactory.ForLsCorporateAutoDatabase(),
                            CacheConnectionFactory.LocalClient(),
                            ConfigurationManager.ConnectionStrings["lace/source/database/jis/certificates/configuration"
                                ].ConnectionString)));
                consumer.ConsumeExternalSource(response, _monitoring);

                if (!response.OfType<IProvideDataFromJis>().Any() || response.OfType<IProvideDataFromJis>().First() == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var jisResponse = new JisResponse();
            jisResponse.HasNotBeenHandled();
            //response.Add(response);
        }
    }
}
