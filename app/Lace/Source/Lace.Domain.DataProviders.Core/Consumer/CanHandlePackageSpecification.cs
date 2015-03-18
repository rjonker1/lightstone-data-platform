using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.DataProviders.Core.Consumer
{
    public class CanHandlePackageSpecification
    {
        private readonly DataProviderName _dataProvider;
        private readonly ILaceRequest _request;

        public bool IsSatisfied
        {
            get
            {
                return CheckThePackageDataSource.PackageDataSourceChecks.CheckIfPackageDataSourceRequiresService(_request.Package, _dataProvider);
            }
        }

        public CanHandlePackageSpecification(DataProviderName dataProvider, ILaceRequest request)
        {
            _dataProvider = dataProvider;
            _request = request;
        }
    }
}
