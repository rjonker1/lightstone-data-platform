using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto
{
    public class RgtVinRequestMessage
    {
        public string Vin { get; private set; }
        private readonly ICollection<IPointToLaceProvider> _response;

        public RgtVinRequestMessage(ICollection<IPointToLaceProvider> response)
        {
            _response = response;
        }

        public RgtVinRequestMessage Build()
        {


            Vin = _response.OfType<IProvideDataFromIvid>().First() != null &&
                  _response.OfType<IProvideDataFromIvid>().First().Handled
                ? _response.OfType<IProvideDataFromIvid>().First().Vin
                : string.Empty;

            return this;
        }
    }
}
