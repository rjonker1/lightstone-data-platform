using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;

using PackageBuilder.Domain.Entities.Enums.DataProviders;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Anpr
{
    public class AnprDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
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
                //TODO: System.Data issue on the build server causes an error
                //var consumer = new ConsumeSource(new HandleAnprSourceCall(),
                //    new CallAnprExternalSource(_request,
                //        new RepositoryFactory(ConnectionFactory.ForLsCorporateAutoDatabase(),
                //            CacheConnectionFactory.LocalClient(), ConfigurationManager.ConnectionStrings["lace/source/database/anpr/certificates/configuration"].ConnectionString)));

                //consumer.ConsumeExternalSource(response, laceEvent);

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
