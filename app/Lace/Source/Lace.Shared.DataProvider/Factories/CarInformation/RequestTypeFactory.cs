using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Repositories;
using Lace.Toolbox.Database.Requests;
using Lace.Toolbox.Database.Requests.CarInformation;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Factories
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
        private readonly IReadOnlyRepository _repository;
        private readonly IMineDataProviderResponseFactory _factory;

        private RequestTypeFactory(ICollection<IPointToLaceProvider> response, IReadOnlyRepository repository, IMineDataProviderResponseFactory factory)
        {
            _response = response;
            _repository = repository;
            _factory = factory;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IReadOnlyRepository repository, IMineDataProviderResponseFactory factory,
            IAmVinNumberRequestField vinNumberField, IAmCarIdRequestField carIdRequestField, IAmYearRequestField yearRequestField) :
            this(response, repository, factory)
        {
            _vinNumberRequestField = vinNumberField;
            _carIdRequestField = carIdRequestField;
            _yearRequestField = yearRequestField;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IReadOnlyRepository repository, IMineDataProviderResponseFactory factory,
            IAmVinNumberRequestField vinNumberField, IAmCarIdRequestField carIdRequestField, IAmYearRequestField yearRequestField, IAmEngineNumberRequestField engineNumber) :
            this(response, repository, factory)
        {
            _vinNumberRequestField = vinNumberField;
            _carIdRequestField = carIdRequestField;
            _yearRequestField = yearRequestField;
            _engineNumberRequestField = engineNumber;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IReadOnlyRepository repository, IMineDataProviderResponseFactory factory,
            IAmVinNumberRequestField vinNumberField) :
                this(response, repository, factory)
        {
            _vinNumberRequestField = vinNumberField;
        }

        public RequestTypeFactory(ICollection<IPointToLaceProvider> response, IReadOnlyRepository repository, IMineDataProviderResponseFactory factory,
            IAmCarIdRequestField carIdRequestField, IAmYearRequestField yearRequestField) :
                this(response, repository, factory)
        {
            _carIdRequestField = carIdRequestField;
            _yearRequestField = yearRequestField;
        }


        public IDetermineRequestType Build()
        {
            return
                new VinRequestType(
                    new CarIdRequestType(
                        new NullRequestTypeDeterminator(), _carIdRequestField, _yearRequestField, _response, _repository, _factory),
                    _vinNumberRequestField, _response, _repository, _factory);
        }
    }
}
