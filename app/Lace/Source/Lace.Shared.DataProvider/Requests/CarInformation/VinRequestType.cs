using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Requests.CarInformation
{
    public class VinRequestType : AbstractRequestDeterminator, IDetermineRequestType
    {
        private readonly IAmVinNumberRequestField _vinNumberField;
        private readonly IReadOnlyRepository _repository;

        public VinRequestType(IDetermineRequestType next, IAmVinNumberRequestField vinNumberField, ICollection<IPointToLaceProvider> response,
            IReadOnlyRepository repository, IMineDataProviderResponseFactory factory)
            : base(response, next, factory)
        {
            _vinNumberField = vinNumberField;
            _repository = repository;
        }

        public IRetrieveCarInformation Retrieve()
        {
            var vinNumber = GetVinNumber(_vinNumberField);
            return string.IsNullOrEmpty(vinNumber)
                ? SearchNext()
                : new GetCarInformation(vinNumber, _repository).SetupDataSources().GenerateData().BuildCarInformation().BuildCarInformationRequest() ??
                  GetCarInformation.Empty();
        }
    }
}