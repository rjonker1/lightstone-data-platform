using Lace.Request;
using Lace.Response;
using Lace.Source.Common;
using Lace.Source.Enums;

namespace Lace.Consumer
{
    public class CanHandlePackageSpecification
    {
        private readonly Services _service;
        public bool IsSatisfied { get; private set; }

        public CanHandlePackageSpecification(Services service)
        {
            _service = service;
        }

        public void CanHandle(ILaceRequest request, ILaceResponse response)
        {
            IsSatisfied =
                CheckThePackageDataSource.PackageDataSourceChecks.CheckIfPackageDataSourceRequiresService(
                    request.Package,
                    (int) _service);
        }
    }
}
