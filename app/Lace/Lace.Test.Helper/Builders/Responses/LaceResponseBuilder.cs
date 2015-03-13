using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;

namespace Lace.Test.Helper.Builders.Responses
{
    public class LaceResponseBuilder
    {
        public ICollection<IPointToLaceProvider> WithIvidResponseHandled()
        {
            var response = new Collection<IPointToLaceProvider>();

            var ividResponse = new SourceResponseBuilder().ForIvid();
            var transformer = new TransformIvidResponse(ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);

            return response;

        }

        public ICollection<IPointToLaceProvider> WithIvidResponseHandledAndVin12()
        {

            var response = new Collection<IPointToLaceProvider>();

            var ividResponse = new SourceResponseBuilder().ForIvidWithRepairVin();
            var transformer = new TransformIvidResponse(ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);

            return response;
        }

        public ICollection<IPointToLaceProvider> WithIvidResponseAndFinancedInterestVin()
        {
            var response = new Collection<IPointToLaceProvider>();

            var ividResponse = new SourceResponseBuilder().ForIvidWithFinancedInterestVin();
            var transformer = new TransformIvidResponse(ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);

            return response;
        }

    }
}
