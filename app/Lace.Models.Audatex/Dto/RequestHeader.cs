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

        //public string MsgTypeIdentifier
        //{
        //    get
        //    {
        //        return "MSGTYPE_HISTORYCHECK";
        //    }
        //}

        //public string AssessmentNumber
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}

        //public string Originator
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}

        //public string Reference
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}
    }
}
