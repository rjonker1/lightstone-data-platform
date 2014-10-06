using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Shared;

namespace Lace.Domain.DataProviders.Core.Consumer
{
    public class CanHandlePackageSpecification
    {
        private readonly Guid _service;
        private readonly ILaceRequest _request;

        public bool IsSatisfied
        {
            get
            {
                return CheckThePackageDataSource.PackageDataSourceChecks.CheckIfPackageDataSourceRequiresService(_request.Package, _service);
            }
        }

        public CanHandlePackageSpecification(Guid service, ILaceRequest request)
        {
            _service = service;
            _request = request;
        }
    }
}
