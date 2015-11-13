using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commands
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