using System;
namespace Lace.Models.Audatex.Dto
{
    public class RequestHeader
    {
        public string MsgTypeIdentifier
        {
            get
            {
                return "MSGTYPE_HISTORYCHECK";
            }
        }

        public string AssessmentNumber
        {
            get
            {
                return string.Empty;
            }
        }

        public string Originator
        {
            get
            {
                return string.Empty;
            }
        }

        public string Reference
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
