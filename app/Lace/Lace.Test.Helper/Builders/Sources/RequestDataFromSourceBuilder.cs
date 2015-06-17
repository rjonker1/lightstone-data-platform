using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure;
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
            _requestDataFromSource = new RequestDataFromLightstoneAuto();
            return _requestDataFromSource;
        }


        public IRequestDataFromDataProviderSource ForLightstoneBusinessCompany()
        {
            _requestDataFromSource = new RequestDataFromLightstoneCompany();
            return _requestDataFromSource;
        }

        public IRequestDataFromDataProviderSource ForLightstoneProperty()
        {
            _requestDataFromSource = new RequestDataFromLightstonePropertySource();
            return _requestDataFromSource;
        }

        public IRequestDataFromDataProviderSource ForLightstoneBusinessDirector()
        {
            _requestDataFromSource = new RequestDataFromLightstoneDirector();
            return _requestDataFromSource;
        }

    }
}
