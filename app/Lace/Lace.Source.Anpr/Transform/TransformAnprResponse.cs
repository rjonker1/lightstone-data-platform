using System;
using Lace.Models.Anpr.DataObject;
using Lace.Models.Responses.Sources;
using Lace.Source.Anpr.AnprServiceReference;

namespace Lace.Source.Anpr.Transform
{
    public class TransformAnprResponse : ITransform
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
