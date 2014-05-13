using Lace.Functions.Xml;
using Lace.Models.Audatex.Dto;

namespace Lace.Source.Audatex.ServiceConfig
{
    public class SerializeAuduatexRequestData
    {
        public string SerializedMessage
        {
            get
            {
                return CleanXml(XmlFunctions.XmlFunction.ObjectToXml(_message) ?? string.Empty);
            }
        }

        private readonly AudatexMessageData _message;

        public SerializeAuduatexRequestData(AudatexMessageData message)
        {
            _message = message;
        }

        private static string CleanXml(string xmlMessage)
        {
            xmlMessage = xmlMessage.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "");
            xmlMessage = xmlMessage.Replace(
                " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"",
                "");
            return xmlMessage ;
        }
    }
}
