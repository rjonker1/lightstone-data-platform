using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto
{
    public class RgtVinRequestMessage
    {
        public string Vin { get; private set; }
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly IAmRgtVinRequest _request;

        public RgtVinRequestMessage(IAmRgtVinRequest request, ICollection<IPointToLaceProvider> response)
        {
            _response = response;
            _request = request;
            Build();
        }

        private void Build()
        {
            Vin = GetVinNumber();
        }

        private bool ContinueWithIvid()
        {
            return _response.OfType<IProvideDataFromIvid>().Any() && _response.OfType<IProvideDataFromIvid>().First() != null &&
                   _response.OfType<IProvideDataFromIvid>().First().Handled;
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }

        private string GetVinNumber()
        {
            return string.IsNullOrEmpty(GetValue(_request.VinNumber))
                ? ContinueWithIvid() ? _response.OfType<IProvideDataFromIvid>().First().Vin : string.Empty
                : GetValue(_request.VinNumber);
        }
    }
}
