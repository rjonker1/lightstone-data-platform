using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Requests.CarInformation
{
    public class CarIdRequestType : AbstractRequestDeterminator, IDetermineRequestType
    {
        private readonly IAmCarIdRequestField _carIdField;
        private readonly IAmYearRequestField _yearField;
        private readonly IQueryCarInformation _carInformation;

        public CarIdRequestType(IDetermineRequestType next, IAmCarIdRequestField carIdField, IAmYearRequestField yearField, ICollection<IPointToLaceProvider> response,
            IMineDataProviderResponseFactory factory, IQueryCarInformation carInformation)
            : base(response, next, factory)
        {
            _carIdField = carIdField;
            _yearField = yearField;
            _carInformation = carInformation;
        }

        public IRetrieveCarInformation Retrieve()
        {
            var carId = GetCarId(_carIdField);
            var year = GetYear(_yearField);

            return carId == 0
                ? SearchNext()
                : new GetCarInformation(carId, year, _carInformation).GenerateData().BuildCarInformation().BuildCarInformationRequest() ?? GetCarInformation.Empty();
        }
    }
}