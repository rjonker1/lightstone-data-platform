using System.Linq;
using Lim.Core;
using Lim.Domain.Entities;
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
        private readonly IRepository _repository;

        public GetMetadataHandler(IRepository repository)
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