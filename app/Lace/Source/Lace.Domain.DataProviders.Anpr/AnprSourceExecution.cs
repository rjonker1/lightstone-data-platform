using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Anpr
{
    public class AnprSourceExecution : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public AnprSourceExecution(ILaceRequest request, IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Anpr, _request);

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
                    CallFallbackSource(response, laceEvent);
            }
        }

        private static void NotHandledResponse(IProvideLaceResponse response)
        {
            response.AnprResponse = null;
            response.AnprResponseHandled = new AnprResponseHandled();
            response.AnprResponseHandled.HasNotBeenHandled();
        }
    }
}
