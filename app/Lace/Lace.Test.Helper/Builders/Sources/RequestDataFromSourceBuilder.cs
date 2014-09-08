using Lace.Source;
using Lace.Source.Lightstone.SourceCalls;
using Lace.Test.Helper.Mothers.Sources;

namespace Lace.Test.Helper.Builders.Sources
{
    public class RequestDataFromSourceBuilder
    {
        private IRequestDataFromSource _requestDataFromSource;

        public IRequestDataFromSource ForRgtVin()
        {
            _requestDataFromSource = new RequestDataFromRgtVinHolderSource();
            return _requestDataFromSource;
        }


        public IRequestDataFromSource ForIvid()
        {
            _requestDataFromSource = new RequestDataFromIvidService();
            return _requestDataFromSource;
        }

        public IRequestDataFromSource ForIvidTitleHolder()
        {
            _requestDataFromSource = new RequestDataFromIvidTitleHolderService();
            return _requestDataFromSource;
        }

        public IRequestDataFromSource ForAudatex()
        {
            _requestDataFromSource = new RequestDataFromAudatexService();
            return _requestDataFromSource;
        }

        public IRequestDataFromSource ForLightstone()
        {
            _requestDataFromSource = new RequestDataFromLightstoneSource();
            return _requestDataFromSource;
        }


    }
}
