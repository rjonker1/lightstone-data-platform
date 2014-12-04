using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Lace.Test.Helper.Builders.Responses
{
    public class LaceResponseBuilder
    {
        public IProvideResponseFromLaceDataProviders WithIvidResponseHandled()
        {
            var response = new LaceResponse();

            var ividResponse = new SourceResponseBuilder().ForIvid();
            var transformer = new TransformIvidResponse(ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();

            return response;

        }

        public IProvideResponseFromLaceDataProviders WithIvidResponseHandledAndVin12()
        {

            var response = new LaceResponse();

            var ividResponse = new SourceResponseBuilder().ForIvidWithRepairVin();
            var transformer = new TransformIvidResponse(ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();

            return response;
        }

        public IProvideResponseFromLaceDataProviders WithIvidResponseAndFinancedInterestVin()
        {
            var response = new LaceResponse();

            var ividResponse = new SourceResponseBuilder().ForIvidWithFinancedInterestVin();
            var transformer = new TransformIvidResponse(ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();

            return response;
        }

    }
}
