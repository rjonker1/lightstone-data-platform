namespace Lace.Models.Audatex.Dto
{
    [System.Xml.Serialization.XmlRoot(ElementName = "MsgData")]
    public class AudatexMessageData
    {
        public RequestHeader Header { get; set; }
        public RequestBody Body { get; set; }
    }
}
