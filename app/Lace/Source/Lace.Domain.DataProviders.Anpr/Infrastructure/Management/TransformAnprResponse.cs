using System;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Anpr.AnprServiceReference;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure.Management
{
    public class TransformAnprResponse : ITransformResponseFromDataProvider
    {
        public bool Continue { get; private set; }
        public IProvideDataFromAnpr Result { get; private set; }

        private readonly AnprResComplexType _response;
        private readonly Guid _transactionToken;

        public TransformAnprResponse(AnprResComplexType response, Guid transactionToken)
        {
            Continue = response != null && response.Result.Equals("result",StringComparison.CurrentCultureIgnoreCase);
            Result = Continue ? new AnprResponse() : new AnprResponse().WasAFailure(response != null ? response.Result : "Null Response from Anpr");
            _response = response;
            _transactionToken = transactionToken;
        }

        public void Transform()
        {
            Result = new AnprResponse(_response.PlatePatch, _response.Overview, string.Empty, _response.PlateResult,
                _transactionToken).WasASuccess();
        }
    }
}
