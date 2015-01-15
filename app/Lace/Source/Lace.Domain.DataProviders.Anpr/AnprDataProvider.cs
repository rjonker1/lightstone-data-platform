using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Anpr
{
    public class AnprDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;
        private readonly ISendCommandsToBus _monitoring;
        public AnprDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Anpr, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                //TODO: System.Data issue on the build server causes an error
                //var consumer = new ConsumeSource(new HandleAnprSourceCall(),
                //    new CallAnprExternalSource(_request,
                //        new RepositoryFactory(ConnectionFactory.ForLsCorporateAutoDatabase(),
                //            CacheConnectionFactory.LocalClient(), ConfigurationManager.ConnectionStrings["lace/source/database/anpr/certificates/configuration"].ConnectionString)));

                //consumer.ConsumeExternalSource(response, laceEvent);

                if (response.AnprResponse == null)
                    CallFallbackSource(response, _monitoring);
            }
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.AnprResponse = null;
            response.AnprResponseHandled = new AnprResponseHandled();
            response.AnprResponseHandled.HasNotBeenHandled();
        }
    }
}
