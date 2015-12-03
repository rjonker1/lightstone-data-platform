using Lim.Core;
using Toolbox.LightstoneAuto.Database.Domain.Events;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Read.Handlers
{
    public class DataSetDetailDtoHandler : IHandles<DataSetExportCreated>, IHandles<DataSetDeActivated>, IHandles<DataSetRenamed>
    {
        private readonly IWriteOnlyRepository _repository;
        public DataSetDetailDtoHandler(IWriteOnlyRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataSetExportCreated message)
        {
            _repository.Save(message);
        }

        public void Handle(DataSetDeActivated message)
        {
            _repository.Delete(message);
        }

        public void Handle(DataSetRenamed message)
        {
           _repository.SaveOrUpdate(message);
        }
    }

    public class DataSetDtoHandler : IHandles<DataSetExportCreated>, IHandles<DataSetDeActivated>, IHandles<DataSetRenamed>
    {
        private readonly IWriteOnlyRepository _repository;

        public DataSetDtoHandler(IWriteOnlyRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataSetExportCreated message)
        {
            _repository.Save(message);
        }

        public void Handle(DataSetDeActivated message)
        {
            _repository.Delete(message);
        }

        public void Handle(DataSetRenamed message)
        {
            _repository.SaveOrUpdate(message);
        }
    }
}