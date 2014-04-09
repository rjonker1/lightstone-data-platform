using Lace.Request;
namespace Lace.Response.ExternalServices
{
    public class LaceExternalServiceResponse
    {
        public ILaceResponse Response { get; set; }
        public ILaceRequest Request { get; set; }
    }
}
