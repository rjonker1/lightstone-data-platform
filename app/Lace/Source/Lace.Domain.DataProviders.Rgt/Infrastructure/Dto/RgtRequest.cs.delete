using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Shared.DataProvider.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Dto
{
    public class RgtRequest
    {

        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly IAmRgtRequest _request;
        private readonly IReadOnlyRepository _carRepository;

        public RgtRequest(IAmRgtRequest request, ICollection<IPointToLaceProvider> response, IReadOnlyRepository carRepository)
        {
            _request = request;
            _response = response;
            _carRepository = carRepository;
            Build();
        }

        private void Build()
        {
            GetWithCarId();
            GetWithVin();
        }

        private void GetWithVin()
        {
            if (IsValid)
                return;

            var vinNumber = GetVinNumber();
            IsValid = !string.IsNullOrEmpty(vinNumber);

            if (!IsValid)
                return;

            CarInformation = new GetCarInformation(vinNumber, _carRepository);
        }

        private void GetWithCarId()
        {
            if (_request.CarId == null || string.IsNullOrEmpty(_request.CarId.Field))
                return;

            int carId;
            int.TryParse(_request.CarId.Field, out carId);

            IsValid = carId > 0;
            if (!IsValid)
                return;

            CarInformation = new GetCarInformation(carId, _carRepository);
        }

        private string GetVinNumber()
        {
            return ContinueWithIvid(_response) ? _response.OfType<IProvideDataFromIvid>().First().Vin : string.Empty;
        }

        private static bool ContinueWithIvid(ICollection<IPointToLaceProvider> response)
        {
            return response.OfType<IProvideDataFromIvid>().Any() && response.OfType<IProvideDataFromIvid>().First() != null &&
                   response.OfType<IProvideDataFromIvid>().First().Handled;
        }


        public IRetrieveCarInformation CarInformation { get; private set; }
        public bool IsValid { get; private set; }
    }
}
