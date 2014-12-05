using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Dto;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses
{
    public class IvidResponseBuilder
    {
        private IvidResponse _ividResponse = new IvidResponse();
        public IProvideDataFromIvid Build()
        {
            return _ividResponse;
        }

        public IvidResponseBuilder With()
        {
            _ividResponse.BuildSpecificInformation();
            return this;
        } 
    }
}