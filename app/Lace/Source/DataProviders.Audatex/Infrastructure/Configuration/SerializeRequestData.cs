using Lace.Domain.DataProviders.Audatex.Infrastructure.Dto;
using Lace.Shared.Extensions;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration
{
    public class SerializeRequestData
    {
        public string SerializedMessage
        {
            get
            {
                return CleanXml(_message != null ? _message.ObjectToXml<AudatexMessageData>() : string.Empty);
            }
        }

        private readonly AudatexMessageData _message;

        public SerializeRequestData(AudatexMessageData message)
        {
            _message = message;
        }

        private static string CleanXml(string xmlMessage)
        {
            xmlMessage = xmlMessage.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "");
            xmlMessage = xmlMessage.Replace(
                " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"",
                "");
            return xmlMessage;
        }
    }
}
