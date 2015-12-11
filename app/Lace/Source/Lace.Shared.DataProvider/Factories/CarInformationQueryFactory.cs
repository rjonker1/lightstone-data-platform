using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Queries;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Toolbox.Database.Factories
{
    public interface ICarInformationQueryFactory
    {
        IQueryCarInformation Build();
    }

    public class CarInformationQueryFactory : ICarInformationQueryFactory
    {
        private readonly IReadOnlyRepository _repository;
        public CarInformationQueryFactory(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public IQueryCarInformation Build()
        {
            return new VinCarInformationQuery(new CarIdCarInformationQuery(new NullCarInformationQuery(), _repository), _repository);
        }
    }
}
