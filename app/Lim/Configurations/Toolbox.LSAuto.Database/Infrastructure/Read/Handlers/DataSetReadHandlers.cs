using Lim.Core;
using Toolbox.LightstoneAuto.Database.Domain.Base;
using Toolbox.LightstoneAuto.Database.Domain.Events;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Read.Handlers
{
    public class DataSetDetailDtoHandler : IHandles<DataSetCreated>, IHandles<DataSetDeActivated>
    {
        private readonly IWriteOnlyRepository _repository;
        public DataSetDetailDtoHandler(IWriteOnlyRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataSetCreated message)
        {
            _repository.Save(message);
        }

        public void Handle(DataSetDeActivated message)
        {
            _repository.Delete(message);
        }
    }

    public class DataSetDtoHandler : IHandles<DataSetCreated>, IHandles<DataSetDeActivated>
    {
        private readonly IWriteOnlyRepository _repository;

        public DataSetDtoHandler(IWriteOnlyRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataSetCreated message)
        {
            _repository.Save(message);
        }

        public void Handle(DataSetDeActivated message)
        {
            _repository.Delete(message);
        }
    }
}
