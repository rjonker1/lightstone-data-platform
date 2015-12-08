using Lim.Core;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Infrastructure.Read.Handlers
{
    public class DataSetDetailDtoHandler : IHandles<DataSetExportCreated>, IHandles<DataSetDeActivated>, IHandles<DataSetModified>
    {
        private readonly IWriteOnlyRepository _repository;
        public DataSetDetailDtoHandler(IWriteOnlyRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataSetExportCreated message)
        {
            var ds = new DataSet
            {
                Id = message.DataSet.Id,
                Name = message.DataSet.Name,
                Activated = message.DataSet.Activated,
                DateCreated = message.DataSet.DateCreated,
                Description = message.DataSet.Description,
                Version = message.Version
            };

            _repository.Save(ds);
        }

        public void Handle(DataSetDeActivated message)
        {
            _repository.Delete(message);
        }

        public void Handle(DataSetModified message)
        {
            var ds = new DataSet
            {
                Id = message.DataSet.Id,
                Name = message.DataSet.Name,
                Activated = message.DataSet.Activated,
                DateCreated = message.DataSet.DateCreated,
                Description = message.DataSet.Description,
                Version = message.Version
            };
            _repository.SaveOrUpdate(ds);
        }
    }

    public class DataSetDtoHandler : IHandles<DataSetExportCreated>, IHandles<DataSetDeActivated>, IHandles<DataSetModified>
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

        public void Handle(DataSetModified message)
        {
            _repository.SaveOrUpdate(message);
        }
    }
}