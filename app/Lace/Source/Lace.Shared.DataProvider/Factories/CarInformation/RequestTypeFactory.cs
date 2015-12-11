using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Requests.CarInformation;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Factories.CarInformation
{
    public interface IRequestTypeFactory
    {
        IDetermineRequestType Build();
    }

    public class RequestTypeFactory : IRequestTypeFactory
    {
        private readonly IAmVinNumberRequestField _vinNumberRequestField;
        private readonly IAmCarIdRequestField _carIdRequestField;
        private readonly IAmYearRequestField _yearRequestField;
        private readonly IAmEngineNumberRequestField _engineNumberRequestField;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly IMineDataProviderResponseFactory _factory;
        private readonly IQueryCarInformation _carInformationQuery;

        private RequestTypeFactory(ICollection<IPointToLaceProvider> response, IMineDataProviderResponseFactory factory, IQueryCarInformation carInformationQuery)
        {
            _response = response;
            _factory = factory;
            _carInformationQuery = carInformationQuery;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IMineDataProviderResponseFactory factory,
            IAmVinNumberRequestField vinNumberField, IAmCarIdRequestField carIdRequestField, IAmYearRequestField yearRequestField, IQueryCarInformation carInformationQuery) :
            this(response, factory, carInformationQuery )
        {
            _vinNumberRequestField = vinNumberField;
            _carIdRequestField = carIdRequestField;
            _yearRequestField = yearRequestField;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IMineDataProviderResponseFactory factory,
            IAmVinNumberRequestField vinNumberField, IAmCarIdRequestField carIdRequestField, IAmYearRequestField yearRequestField, IAmEngineNumberRequestField engineNumber, IQueryCarInformation carInformationQuery) :
            this(response, factory, carInformationQuery)
        {
            _vinNumberRequestField = vinNumberField;
            _carIdRequestField = carIdRequestField;
            _yearRequestField = yearRequestField;
            _engineNumberRequestField = engineNumber;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IMineDataProviderResponseFactory factory,
            IAmVinNumberRequestField vinNumberField, IQueryCarInformation carInformationQuery) :
                this(response, factory, carInformationQuery)
        {
            _vinNumberRequestField = vinNumberField;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IMineDataProviderResponseFactory factory,
            IAmCarIdRequestField carIdRequestField, IAmYearRequestField yearRequestField, IQueryCarInformation carInformationQuery) :
                this(response, factory, carInformationQuery)
        {
            _carIdRequestField = carIdRequestField;
            _yearRequestField = yearRequestField;
        }


        public IDetermineRequestType Build()
        {
            return
                new VinRequestType(
                    new CarIdRequestType(
                        new NullRequestTypeDeterminator(), _carIdRequestField, _yearRequestField, _response, _factory,_carInformationQuery),
                    _vinNumberRequestField, _response, _factory, _carInformationQuery);
        }
    }
}
