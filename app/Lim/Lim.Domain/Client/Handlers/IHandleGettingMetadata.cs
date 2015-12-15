using Lim.Domain.Client.Commands;

namespace Lim.Domain.Client.Handlers
{
    public interface IHandleGettingMetadata
    {
        void Handle(GetApiResponseMetadataCommand command);
    }
}