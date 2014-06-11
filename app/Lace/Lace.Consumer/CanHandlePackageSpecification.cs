using System;
using Lace.Request;
using Lace.Source.Common;

namespace Lace.Consumer
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
