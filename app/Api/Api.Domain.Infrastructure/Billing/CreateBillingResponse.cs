using System;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using Common.Logging;
using DataPlatform.Shared.Identifiers;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Api.Domain.Infrastructure.Billing
{
    public interface ICreateBillingResponse
    {
        bool BillingCreated { get; }
        void CreateBillingResponseForPackage(Package package, Guid userId, Guid requestId);
    }

    public class CreateBillingResponse : ICreateBillingResponse
    {
        private readonly ILog _log;
        private readonly IConnectToBilling _billing;

        public CreateBillingResponse(IConnectToBilling billing)
        {
            _log = LogManager.GetLogger(GetType());
            _billing = billing;
        }

        public bool BillingCreated { get; private set; }

        public void CreateBillingResponseForPackage(Package package, Guid userId, Guid requestId)
        {
            try
            {
                var packageIdentifier = new PackageIdentifier(package.Id, new VersionIdentifier(package.Version));
                var requestIdentifier = new RequestIdentifier(requestId, SystemIdentifier.CreateApi());
                var userIdentifier = new UserIdentifier(userId);
                var requestContext = new RequestContext(requestId, userIdentifier, requestIdentifier);
                var createResponse = new CreateResponse(packageIdentifier, requestContext);

                _billing.CreateResponse(createResponse);

                BillingCreated = true;
            }
            catch (Exception)
            {
                _log.ErrorFormat("An error creating a billing response for package id {0} and user Id {1}",
                    package.Id, userId);
                BillingCreated = false;
            }
        }
    }
}
