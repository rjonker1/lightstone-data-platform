using System.Text;

namespace Lim.Dtos
{
    public class PackageMetadataDto
    {
        public PackageMetadataDto(string description, byte[] payload, long id)
        {
            Description = description;
            ApiResponse = payload != null && payload.Length > 0 ?  Encoding.UTF8.GetString(payload) : string.Empty;
            Id = id;
        }

        public string Description { get; private set; }
        public string ApiResponse { get; private set; }
        public long Id { get; private set; }
    }
}
