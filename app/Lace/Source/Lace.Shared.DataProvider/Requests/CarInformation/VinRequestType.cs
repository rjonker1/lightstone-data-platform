using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Requests.CarInformation
{
    public class VinRequestType : AbstractRequestDeterminator, IDetermineRequestType
    {
        private readonly IAmVinNumberRequestField _vinNumberField;
        private readonly IQueryCarInformation _carInformationQuery;

        public VinRequestType(IDetermineRequestType next, IAmVinNumberRequestField vinNumberField, ICollection<IPointToLaceProvider> response,
             IMineDataProviderResponseFactory factory, IQueryCarInformation carInformationQuery)
            : base(response, next, factory)
        {
            _vinNumberField = vinNumberField;
            _carInformationQuery = carInformationQuery;
        }

        public IRetrieveCarInformation Retrieve()
        {
            var vinNumber = GetVinNumber(_vinNumberField);
            return string.IsNullOrEmpty(vinNumber)
                ? SearchNext()
                : new GetCarInformation(vinNumber, _carInformationQuery).GenerateData().BuildCarInformation().BuildCarInformationRequest() ??
                  GetCarInformation.Empty();
        }
    }
}