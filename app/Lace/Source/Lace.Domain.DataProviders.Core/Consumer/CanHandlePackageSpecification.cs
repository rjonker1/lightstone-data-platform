using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.DataProviders.Core.Consumer
{
    public class CanHandlePackageSpecification
    {
        private readonly DataProviderName _dataProvider;
        private readonly ICollection<IPointToLaceRequest> _request;

        public bool IsSatisfied
        {
            get
            {
                return
                    CheckThePackageDataSource.PackageDataSourceChecks.CheckIfPackageRequiresDataProvider(
                        _request.First().Package,
                        _dataProvider);
            }
        }

        public CanHandlePackageSpecification(DataProviderName dataProvider, ICollection<IPointToLaceRequest> request)
        {
            _dataProvider = dataProvider;
            _request = request;
        }
    }
}
