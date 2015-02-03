using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.PCubed.Infrastructure.Management
{
    public class TransformSignioResponse : ITransformResponseFromDataProvider
    {
        public string Message { get; private set; }
        public IProvideDataFromPCubedFicaVerfication Result { get; private set; }

        public bool Continue { get; private set; }

        public TransformSignioResponse(string response)
        {
            Continue = !string.IsNullOrWhiteSpace(response);
            Message = response;
        }

        public void Transform()
        {
            Result = new PCubedFicaVerficationResponse();
        }
    }
}
