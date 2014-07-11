namespace Lace.Models.Audatex.Dto
{
    public class RequestHeader
    {

        public RequestHeader()
        {
            MsgTypeIdentifier = "MSGTYPE_HISTORYCHECK";
            AssessmentNumber = string.Empty;
            Originator = string.Empty;
            Reference = string.Empty;
        }

        public string MsgTypeIdentifier { get; set; }

        public string AssessmentNumber { get; set; }

        public string Originator { get; set; }

        public string Reference { get; set; }
    }
}
