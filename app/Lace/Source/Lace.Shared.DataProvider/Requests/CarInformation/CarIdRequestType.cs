using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Requests.CarInformation
{
    public class CarIdRequestType : AbstractRequestDeterminator, IDetermineRequestType
    {
        private readonly IAmCarIdRequestField _carIdField;
        private readonly IAmYearRequestField _yearField;
        private readonly IReadOnlyRepository _repository;

        public CarIdRequestType(IDetermineRequestType next, IAmCarIdRequestField carIdField, IAmYearRequestField yearField, ICollection<IPointToLaceProvider> response,
            IReadOnlyRepository repository, IMineDataProviderResponseFactory factory)
            : base(response, next, factory)
        {
            _carIdField = carIdField;
            _yearField = yearField;
            _repository = repository;
        }

        public IRetrieveCarInformation Retrieve()
        {
            var carId = GetCarId(_carIdField);
            var year = GetYear(_yearField);

            return carId == 0
                ? SearchNext()
                : new GetCarInformation(carId, year, _repository).SetupDataSources()
                    .GenerateData()
                    .BuildCarInformation()
                    .BuildCarInformationRequest() ?? GetCarInformation.Empty();
        }
    }
}