using Lim.Dtos;

namespace Lim.Domain.Client.Commands
{
    public class GetApiResponseMetadataCommand
    {
        public void Set(Metadata metadata)
        {
            Metadata = metadata;
        }
        public Metadata Metadata { get; private set; }
    }
}