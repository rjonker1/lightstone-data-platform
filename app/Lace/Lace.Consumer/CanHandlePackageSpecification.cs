using Lace.Request;
using Lace.Source.Common;
using Lace.Source.Enums;

namespace Lace.Consumer
{
    public class CanHandlePackageSpecification
    {
        private readonly Services _service;
        private readonly ILaceRequest _request;

        public bool IsSatisfied
        {
            get
            {
                return CheckThePackageDataSource.PackageDataSourceChecks.CheckIfPackageDataSourceRequiresService(
                    _request.Package,
                    (int) _service);
            }
        }

        public CanHandlePackageSpecification(Services service, ILaceRequest request)
        {
            _service = service;
            _request = request;
        }
    }
}
