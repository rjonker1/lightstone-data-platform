using System;
using System.Linq;
using PackageBuilder.Common.Helpers.Extensions;
using PackageBuilder.Domain.DataFields.Commands;
using PackageBuilder.Domain.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    public class CreateDataProviderHandler : MessageHandler<CreateDataProvider>
    {
        private readonly IRepository<DataProvider> _repository;
        private readonly IHandleMessages _handler;

        public CreateDataProviderHandler(IRepository<DataProvider> repository, IHandleMessages handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public override void Handle(CreateDataProvider domainCommand)
        {
            var entity = new DataProvider(domainCommand.Id, domainCommand.Name);
            var fields = domainCommand.DataProviderType.GetPublicProperties().Select(x => new Tuple<string, Type>(x.Name, x.PropertyType));
            _repository.Save(entity, Guid.NewGuid());

            foreach (var field in fields)
                _handler.Handle(new CreateDataField(Guid.NewGuid(), field.Item1, field.Item2, domainCommand.Id));
        }
    }
}