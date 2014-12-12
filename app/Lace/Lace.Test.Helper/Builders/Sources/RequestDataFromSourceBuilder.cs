using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Domain.DataProviders.Rgt.Infrastructure;
using Lace.Test.Helper.Mothers.Sources;

namespace Lace.Test.Helper.Builders.Sources
{
    public class RequestDataFromSourceBuilder
    {
        private IRequestDataFromDataProviderSource _requestDataFromSource;

        public IRequestDataFromDataProviderSource ForRgtVin()
        {
            _requestDataFromSource = new RequestDataFromRgtVinHolderSource();
            return _requestDataFromSource;
        }

        public IRequestDataFromDataProviderSource ForRgt()
        {
            _requestDataFromSource = new RequestDataFromRgtSource();
            return _requestDataFromSource;
        }


        public IRequestDataFromDataProviderSource ForIvid()
        {
            _requestDataFromSource = new RequestDataFromIvidService();
            return _requestDataFromSource;
        }

        public IRequestDataFromDataProviderSource ForIvidTitleHolder()
        {
            _requestDataFromSource = new RequestDataFromIvidTitleHolderService();
            return _requestDataFromSource;
        }

        public IRequestDataFromDataProviderSource ForAudatex()
        {
            _requestDataFromSource = new RequestDataFromAudatexService();
            return _requestDataFromSource;
        }

        public IRequestDataFromDataProviderSource ForLightstone()
        {
            _requestDataFromSource = new RequestDataFromLightstoneSource();
            return _requestDataFromSource;
        }


    }
}
