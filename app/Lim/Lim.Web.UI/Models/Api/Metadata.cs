using System.Text;

namespace Lim.Web.UI.Models.Api
{
    public class Metadata
    {
        public Metadata(string description, byte[] payload)
        {
            Description = description;
            ApiResponse = payload != null && payload.Length > 0 ?  Encoding.UTF8.GetString(payload) : string.Empty;
        }

        public string Description { get; private set; }
        public string ApiResponse { get; private set; }
    }
}