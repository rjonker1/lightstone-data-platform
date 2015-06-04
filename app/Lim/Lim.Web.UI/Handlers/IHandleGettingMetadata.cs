using System.Linq;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Handlers
{
    public interface IHandleGettingMetadata
    {
        void Handle(GetApiResponseMetadataCommand command);
    }

    public class GetMetadataHandler : IHandleGettingMetadata
    {
        private readonly IAmRepository _repository;

        public GetMetadataHandler(IAmRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetApiResponseMetadataCommand command)
        {
            var metadata = _repository.GetAll<PackageMetadata>().FirstOrDefault();
            command.Set(new Metadata(metadata != null ? metadata.Description : string.Empty, metadata != null ? metadata.Payload : new byte[0]));
        }
    }
}