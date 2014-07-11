using Lace.Models.Ivid;
using Lace.Response;
using Lace.Source.Ivid.Transform;

namespace Lace.Test.Helper.Builders.Responses
{
    public class LaceResponseBuilder
    {
        public ILaceResponse WithIvidResponseHandled()
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

        public ILaceResponse WithIvidResponseHandledAndVin12()
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

        public ILaceResponse WithIvidResponseAndFinancedInterestVin()
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
