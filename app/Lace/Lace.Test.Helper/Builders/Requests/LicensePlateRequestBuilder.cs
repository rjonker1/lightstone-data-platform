using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests;
using Lace.Test.Helper.Mothers.Requests.PropertyRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateRequestBuilder
    {
        private ICollection<IPointToLaceRequest> _request;

        public ICollection<IPointToLaceRequest> ForIvid()
        {
            _request = new[] {new LicensePlateNumberIvidOnlyRequest()};
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForAudatex()
        {
            _request = new[] { new LicensePlateNumberAudatexOnlyRequest()};
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForIvidTitleHolder()
        {
            _request = new[] { new LicensePlateNumberIvidTitleHolderOnlyRequest()};
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForIvidTitleHolderWithAbsaFinancedInterest()
        {
            _request = new[] {new LicensePlateNumberIvidTitleHolderWithAbsaFinancedInterestRequest()};
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForRgtVin()
        {
            _request = new[] { new LicensePlateNumberRgtVinOnlyRequest() };
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForRgt()
        {
            _request = new[] {new LicensePlateNumberRgtOnlyRequest()};
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForLightstone()
        {
            _request = new[] {new LicensePlateNumberLightstoneOnlyRequest()};
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForAllSources()
        {
            _request = new[] {new LicensePlateNumberAllDataProvidersRequest()};
            return _request;
        }

        public ICollection<IPointToLaceRequest> ForPropertySources()
        {
            return new Collection<IPointToLaceRequest>() {new PropertiesRequest()};
        }

    }
}
